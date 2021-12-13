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

        public IList<Rebelde> GetAll()
        {
            var rebeldes = _rebeldeRepository.GetAll();

            return rebeldes;
        }

        public Rebelde GetBySku(int sku)
        {
            var rebelde = _rebeldeRepository.GetBySku(sku);

            if (rebelde == null)
                _notificator.AddError($"Produto (Sku: {sku}) não encontrado.");

            return rebelde;
        }

        public Rebelde Create(Rebelde rebelde)
        {
            if (!_itemApplication.ItensExistem(rebelde.Inventario.Itens))
                return null;

            var rebeldeResponse = _rebeldeRepository.Create(rebelde);

            if (rebeldeResponse == null)
                _notificator.AddError($"Falha ao cadastrar o rebelde (Id: {rebelde.Id}).");

            return rebeldeResponse;
        }

        public Rebelde AtualizarLocalizacao(Rebelde rebelde)
        {
            var rebeldeResponse = _rebeldeRepository.Update(rebelde);

            if (rebeldeResponse == null)
                _notificator.AddError($"Não existe Rebelde com Id = {rebelde.Id}.");
            return rebeldeResponse;
        }

        public bool DeleteBySku(int sku)
        {
            var response = _rebeldeRepository.DeleteBySku(sku);

            if (!response)
                _notificator.AddError($"Erro ao excluir o produto (Sku: {sku}).");

            return response;
        }

        #endregion

        #region Private Methods


        #endregion
    }
}