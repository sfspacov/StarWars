using StarWars.Domain.Entities;
using System.Collections.Generic;

namespace StarWars.Domain.Interfaces
{
    public interface IRebeldeRepository
    {
        IList<Rebelde> GetAll();

        Rebelde GetBySku(int id);

        Rebelde Create(Rebelde rebelde);

        Rebelde Update(Rebelde rebelde);

        bool DeleteBySku(int id);
    }
}