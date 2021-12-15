using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Interfaces.Repositories;

namespace StarWars.Infra.Data.Repositories
{
    public class RebeldeRepository : IRebeldeRepository
    {
        public RebeldeRepository()
        {
            Seed();
        }

        #region Properties

        DbContextOptions<MyContext> options = new DbContextOptionsBuilder<MyContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

        #endregion

        #region Public Methods

        public IEnumerable<Rebelde> RetornarTodos()
        {
            using var context = new MyContext(options);
            var result = context.Rebeldes
                .Include(x => x.Localizacao)
                .Include(x => x.Itens)
                .ToList();
            return result;
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

        public void Seed()
        {
            using var context = new MyContext(options);
            if (!context.Rebeldes.Any())
            {

                context.Rebeldes.AddRange(new List<Rebelde>
                {
                    new Rebelde
                    {
                        Nome = "Monstro",
                        Genero = "Hetero",
                        Itens = new List<Item>
                        {
                            new Item
                            {
                                Ponto = 4,
                                Nome = "Arma"
                            }
                        },
                        Localizacao = new Localizacao
                        {
                            Longitude = 10,
                            NomeDaBase = "Estrala alfa ZB",
                            Latitude = 20
                        },
                        Idade = 689,
                    }
                }
                );
                context.SaveChanges();
            }
        }
    }
}