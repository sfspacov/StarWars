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

        #endregion

        #region Constructors

        public RebeldeApplication(INotificator notificator, IRebeldeRepository rebeldeRepository)
        {
            _notificator = notificator;
            _rebeldeRepository = rebeldeRepository;
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
            var rebeldeResponse = _rebeldeRepository.GetBySku(rebelde.Id);

            if (rebeldeResponse != null)
            {
                _notificator.AddError($"Produto (Sku: {rebelde.Id}) já cadastrado.");
            }
            else
            {
                rebeldeResponse = _rebeldeRepository.Create(rebelde);

                if (rebeldeResponse == null)
                    _notificator.AddError($"Falha ao cadastrar o produto (Sku: {rebelde.Id}).");
            }

            return rebeldeResponse;
            }

        public Rebelde Update(Rebelde rebelde)
        {
            var rebeldeResponse = _rebeldeRepository.Update(rebelde);

            if (rebeldeResponse == null)
                _notificator.AddError($"Falha ao atualizar o produto (Sku: {rebelde.Id}).");
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