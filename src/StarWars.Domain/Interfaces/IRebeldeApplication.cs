using StarWars.Domain.Entities;
using System.Collections.Generic;

namespace StarWars.Domain.Interfaces
{
    public interface IRebeldeApplication
    {
        IList<Rebelde> GetAll();

        Rebelde GetBySku(int sku);

        Rebelde Create(Rebelde rebelde);

        Rebelde Update(Rebelde rebelde);

        bool DeleteBySku(int sku);
    }
}