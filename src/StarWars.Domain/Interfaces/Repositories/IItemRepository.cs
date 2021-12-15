using System.Collections.Generic;
using StarWars.Domain.Entities;

namespace StarWars.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IBaseRepository
    {
        Item ItensExistem(IEnumerable<Item> itens);
    }
}