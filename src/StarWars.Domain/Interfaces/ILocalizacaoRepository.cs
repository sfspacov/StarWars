using StarWars.Domain.Entities;

namespace StarWars.Domain.Interfaces
{
    public interface ILocalizacaoRepository
    {
        Localizacao Update(Localizacao localizacao);
    }
}