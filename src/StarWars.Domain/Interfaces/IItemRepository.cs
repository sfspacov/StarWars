using StarWars.Domain.Entities;
using System.Collections.Generic;

namespace StarWars.Domain.Interfaces
{
    public interface IItemRepository
    {
        IList<Item> RetornaTodos();

        Item RetornaPorName(string nome);
        Item RetornaPorPonto(int ponto);
    }
}