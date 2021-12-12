using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        #region Properties

        private static readonly List<Item> MemoryDatabase = new()
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
        };

        #endregion

        #region Public Methods

        public Item ItensExistem(IEnumerable<Item> itens)
        {
            foreach (var item in itens)
            {
                if (!MemoryDatabase.Any(x => x.Nome.ToLower() == item.Nome.ToLower() && x.Ponto == item.Ponto))
                {
                    return item;
                }
            }

            return null;
        }

        #endregion
    }
}