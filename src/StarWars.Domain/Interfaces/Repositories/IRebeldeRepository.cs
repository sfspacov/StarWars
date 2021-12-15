using System.Collections.Generic;
using StarWars.Domain.Entities;

namespace StarWars.Domain.Interfaces.Repositories
{
    public interface IRebeldeRepository : IBaseRepository
    {
        IEnumerable<Rebelde> RetornarTodos();

        Rebelde RetornarPorId(int id);

        Rebelde Criar(Rebelde rebelde);

        Rebelde Update(Rebelde rebelde);

    }
}