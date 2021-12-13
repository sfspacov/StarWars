using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StarWars.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public ItemRepository()
        {
            Seed();
        }

        #region Properties
        
        DbContextOptions<MyContext> options = new DbContextOptionsBuilder<MyContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

        #endregion

        #region Public Methods


        public Item ItensExistem(IEnumerable<Item> itens)
        {
            using var context = new MyContext(options);
            foreach (var item in itens)
            {
                if (!context.Items.Any(x => x.Nome.ToLower() == item.Nome.ToLower() && x.Ponto == item.Ponto))
                {
                    return item;
                }
            }

            return null;
        }

        #endregion

        #region Private Methods

        private void Seed()
        {
            using var context = new MyContext(options);
            if (!context.Items.Any())
            {
                context.Items.AddRange(new List<Item>
                {
                    new Item
                    {
                        Nome = "Arma",
                        Ponto = 4
                    },
                    new Item
                    {
                        Nome = "Munição",
                        Ponto = 3
                    },
                    new Item
                    {
                        Nome = "Água",
                        Ponto = 2
                    },
                    new Item
                    {
                        Nome = "Comida",
                        Ponto = 1
                    },
                });
                context.SaveChanges();
            }
        }

        #endregion
    }
}