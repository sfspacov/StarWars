using StarWars.Domain.Entities;
using System.Collections.Generic;

namespace StarWars.Domain.Interfaces
{
    public interface IRebeldeRepository
    {
        IEnumerable<Rebelde> RetornarTodos();

        Rebelde RetornarPorId(int id);

        Rebelde Criar(Rebelde rebelde);

        Rebelde Update(Rebelde rebelde);

    }
}