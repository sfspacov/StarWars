using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StarWars.Infra.Data.Repositories
{
    public class RebeldeRepository : IRebeldeRepository
    {
        #region Properties

        DbContextOptions<MyContext> options = new DbContextOptionsBuilder<MyContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

        #endregion

        #region Public Methods

        public IEnumerable<Rebelde> RetornarTodos()
        {
            using var context = new MyContext(options);
            return context.Rebeldes
                .Include(x => x.Localizacao)
                .Include(x => x.Itens)
                .ToList();
        }

        public Rebelde RetornarPorId(int id)
        { 
            using var context = new MyContext(options);
            return context.Rebeldes
                .Include(x => x.Localizacao)
                .FirstOrDefault(x => x.Id == id);
        }

        public Rebelde Criar(Rebelde rebelde)
        {
            using var context = new MyContext(options);
            context.Rebeldes.Add(rebelde);
            context.SaveChanges();

            return rebelde;
        }

        public Rebelde Update(Rebelde rebelde)
        {
            using var context = new MyContext(options);
            if (context.Rebeldes.Any(x => x.Id != rebelde.Id))
                return null;

            context.Entry(rebelde).State = EntityState.Modified;
            context.SaveChanges();

            return rebelde;
        }

        #endregion
    }
}