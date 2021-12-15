using StarWars.Domain.Entities;

namespace StarWars.Domain.Interfaces.Repositories
{
    public interface ILocalizacaoRepository : IBaseRepository
    {
        Localizacao Update(Localizacao localizacao);
        void Criar(Localizacao localizacao);
    }
}