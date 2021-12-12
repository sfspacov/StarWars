using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Infra.Data.Repositories
{
    public class rebeldeRepository : IRebeldeRepository
    {
        #region Properties

        private static readonly List<Rebelde> MemoryDatabase = new();

        #endregion

        #region Public Methods

        public IList<Rebelde> GetAll()
        {
            return MemoryDatabase;
        }

        public Rebelde GetBySku(int sku)
        {
            if (MemoryDatabase.All(x => x.Id != sku))
                return null;

            var rebelde = MemoryDatabase.FirstOrDefault(x => x.Id == sku);

            return rebelde;
        }

        public Rebelde Create(Rebelde rebelde)
        {
            rebelde.Id = MemoryDatabase.Any() ? MemoryDatabase.Max(x => x.Id) + 1 : 1;
            MemoryDatabase.Add(rebelde);
            rebelde = MemoryDatabase.FirstOrDefault(x => x.Id == rebelde.Id);

            return rebelde;
        }

        public Rebelde Update(Rebelde rebelde)
        {
            if (MemoryDatabase.Any(x => x.Id == rebelde.Id))
            {
                var index = MemoryDatabase.FindIndex(x => x.Id == rebelde.Id);
                MemoryDatabase[index] = rebelde;
                rebelde = MemoryDatabase.FirstOrDefault(x => x.Id == rebelde.Id);

                return rebelde;
            }
            else
            {
                return null;
            }
        }

        public bool DeleteBySku(int sku)
        {
            if (MemoryDatabase.All(x => x.Id != sku)) return false;

            MemoryDatabase.RemoveAll(x => x.Id == sku);
            var delete = MemoryDatabase.All(x => x.Id != sku);
            return delete;
        }

        #endregion
    }
}