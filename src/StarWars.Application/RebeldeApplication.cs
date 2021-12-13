using System;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;

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

        public IList<Rebelde> RetornarTodos()
        {
            var rebeldes = _rebeldeRepository.GetAll();

            return rebeldes;
        }

        public Rebelde RetornarPorId(int id)
        {
            var rebelde = _rebeldeRepository.RetornarPorId(id);

            if (rebelde == null)
            {
                _notificator.AddError($"Produto (Sku: {id}) não encontrado.");
                throw new ArgumentException();
            }

            return rebelde;
        }

        public Rebelde Criar(Rebelde rebelde)
        {
            if (!_itemApplication.ItensExistem(rebelde.Inventario.Itens))
                throw new ArgumentException();

            var rebeldeResponse = _rebeldeRepository.Create(rebelde);

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

        #endregion

        #region Private Methods


        #endregion
    }
}