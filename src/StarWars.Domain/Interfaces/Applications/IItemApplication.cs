using System.Collections.Generic;
using StarWars.Domain.Entities;

namespace StarWars.Domain.Interfaces.Applications
{
    public interface IItemApplication
    {
        bool ItensExistem(IEnumerable<Item> itens);
    }
}