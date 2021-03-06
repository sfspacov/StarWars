using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Infra.Data.Repositories
{
    public class RebeldeRepository : IRebeldeRepository
    {
        #region Properties

        private static readonly List<Rebelde> MemoryDatabase = new();

        #endregion

        #region Public Methods

        public IEnumerable<Rebelde> RetornarTodos()
        {
            return MemoryDatabase;
        }

        public Rebelde RetornarPorId(int id)
        {
            return MemoryDatabase.All(x => x.Id != id) ? null : MemoryDatabase.FirstOrDefault(x => x.Id == id);
        }

        public Rebelde Criar(Rebelde rebelde)
        {
            rebelde.Id = MemoryDatabase.Any() ? MemoryDatabase.Max(x => x.Id) + 1 : 1;
            MemoryDatabase.Add(rebelde);
            rebelde = MemoryDatabase.FirstOrDefault(x => x.Id == rebelde.Id);

            return rebelde;
        }

        public Rebelde Update(Rebelde rebelde)
        {
            if (MemoryDatabase.All(x => x.Id != rebelde.Id))
                return null;

            var index = MemoryDatabase.FindIndex(x => x.Id == rebelde.Id);
            MemoryDatabase[index] = rebelde;
            rebelde = MemoryDatabase.FirstOrDefault(x => x.Id == rebelde.Id);

            return rebelde;
        }

        #endregion
    }
}