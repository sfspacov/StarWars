using System;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Application
{
    public class RebeldeApplication : IRebeldeApplication
    {
        #region Properties

        private readonly INotificator _notificator;
        private readonly IRebeldeRepository _rebeldeRepository;
        private readonly IItemApplication _itemApplication;

        #endregion

        #region Constructors

        public RebeldeApplication(INotificator notificator, IRebeldeRepository rebeldeRepository, IItemApplication itemApplication)
        {
            _notificator = notificator;
            _rebeldeRepository = rebeldeRepository;
            _itemApplication = itemApplication;
        }

        #endregion

        #region Public Methods

        public IEnumerable<Rebelde> RetornarTodos()
        {
            return _rebeldeRepository.RetornarTodos();
        }

        public Rebelde Criar(Rebelde rebelde)
        {
            if (!_itemApplication.ItensExistem(rebelde.Itens))
                throw new ArgumentException();

            var rebeldeResponse = _rebeldeRepository.Criar(rebelde);

            if (rebeldeResponse == null)
                _notificator.AddError($"Falha ao cadastrar o rebelde (Id: {rebelde.Id}).");

            return rebeldeResponse;
        }

        public Rebelde AtualizarLocalizacao(Rebelde rebelde)
        {
            var entidade = _rebeldeRepository.RetornarPorId(rebelde.Id);

            if (entidade == null)
            {
                _notificator.AddError($"Não existe Rebelde com Id = {rebelde.Id}");
                throw new ArgumentException();
            }

            entidade.Lozalizacao = rebelde.Lozalizacao;
            var entidadeAtualizada = _rebeldeRepository.Update(entidade);

            if (entidadeAtualizada == null)
                _notificator.AddError($"Erro ao atualizar localização do Rebelde! (Id = {rebelde.Id})");

            return entidadeAtualizada;
        }

        public string ReportarTraidor(int id)
        {
            var entidade = _rebeldeRepository.RetornarPorId(id);

            if (entidade == null)
            {
                _notificator.AddError($"Não existe Rebelde com Id = {id}");
                throw new ArgumentException();
            }

            entidade.ReporteTraicao += 1;
            var entidadeAtualizada = _rebeldeRepository.Update(entidade);

            if (entidadeAtualizada == null)
                _notificator.AddError($"Erro ao reportar Rebelde como traidor! (Id = {entidade.Id})");

            return $"Reportes de traição: {entidade.ReporteTraicao}";
        }

        public bool EhTraidor(int id)
        {
            var entidade = _rebeldeRepository.RetornarPorId(id);

            if (entidade != null)
                return entidade.Traidor;

            _notificator.AddError($"Não existe Rebelde com Id = {id}");
            throw new ArgumentException();
        }

        public void NegociarItens(int idRebelde1, ICollection<Item> itensRebelde1, int idRebelde2, ICollection<Item> itensRebelde2)
        {
            if (EhTraidor(idRebelde1))
            {
                _notificator.AddError($"O Rebelde {idRebelde1} é traidor e não pode negociar itens");
                return;
            }

            if (EhTraidor(idRebelde2))
            {
                _notificator.AddError($"O Rebelde {idRebelde2} é traidor e não pode negociar itens");
                return;
            }

            if (!_itemApplication.ItensExistem(itensRebelde1))
            {
                return;
            }

            if (!_itemApplication.ItensExistem(itensRebelde2))
            {
                return;
            }

            if (itensRebelde1.Sum(x => x.Ponto) != itensRebelde2.Sum(x => x.Ponto))
            {
                _notificator.AddError("Ambos os lados deverão oferecer a mesma quantidade de pontos para haver negociação");
                return;
            }


            var rebelde1 = _rebeldeRepository.RetornarPorId(idRebelde1);
            bool hasMatch = rebelde1.Itens.Any(x => itensRebelde1.Any(y => y.Nome == x.Nome && y.Ponto == x.Ponto));
            if (!hasMatch)
            {
                _notificator.AddError($"Rebelde Id: {idRebelde1} não possui os itens que deseja negociar");
                return;
            }

            var rebelde2 = _rebeldeRepository.RetornarPorId(idRebelde2);
            hasMatch = rebelde2.Itens.Any(x => itensRebelde2.Any(y => y.Nome == x.Nome && y.Ponto == x.Ponto));
            if (!hasMatch)
            {
                _notificator.AddError($"Rebelde Id: {idRebelde2} não possui os itens que deseja negociar");
                return;
            }
            rebelde1.Itens.AddRange(itensRebelde2);
            foreach (var item in itensRebelde1)
            {
                if (rebelde1.Itens.Any(x => x.Nome == item.Nome))
                {
                    var itemToRemove =
                        rebelde1.Itens.First(x => x.Ponto == item.Ponto && x.Nome == item.Nome);
                    rebelde1.Itens.Remove(itemToRemove);
                }
            }

            rebelde2.Itens.AddRange(itensRebelde1);
            foreach (var item in itensRebelde2)
            {
                if (rebelde2.Itens.Any(x => x.Nome == item.Nome))
                {
                    var itemToRemove =
                        rebelde2.Itens.First(x => x.Ponto == item.Ponto && x.Nome == item.Nome);
                    rebelde2.Itens.Remove(itemToRemove);
                }
            }
        }

        #endregion
    }
}