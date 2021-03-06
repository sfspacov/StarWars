using System.Collections.Generic;
using StarWars.Domain.Entities;

namespace StarWars.Domain.Interfaces
{
    public interface IItemRepository
    {
        Item ItensExistem(IEnumerable<Item> itens);
    }
}