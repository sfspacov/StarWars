using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;

namespace StarWars.Application
{
    public class LocalizacaoApplication : ILocalizacaoApplication
    {
        #region Properties

        private readonly INotificator _notificator;
        private readonly ILocalizacaoRepository _localizacaoRepository;

        #endregion

        #region Constructors

        public LocalizacaoApplication(INotificator notificator, ILocalizacaoRepository localizacaoRepository)
        {
            _notificator = notificator;
            _localizacaoRepository = localizacaoRepository;
        }

        #endregion

        #region Public Methods

        public Localizacao Atualizar(Localizacao localizacao)
        {
            var entidadeAtualizada = _localizacaoRepository.Update(localizacao);

            if (entidadeAtualizada == null)
                _notificator.AddError($"Erro ao atualizar localização do Rebelde!");

            return entidadeAtualizada;
        }
        #endregion
    }
}