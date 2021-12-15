using System.Collections.Generic;
using StarWars.Domain.Entities;

namespace StarWars.Domain.Interfaces.Applications
{
    public interface IRebeldeApplication
    {
        IEnumerable<Rebelde> RetornarTodos();

        Rebelde Criar(Rebelde rebelde);

        string ReportarTraidor(int id);

        bool EhTraidor(int id);
        
        void NegociarItens(int idRebelde1, ICollection<Item> itensRebelde1, int idRebelde2, ICollection<Item> itensRebelde2);

    }
}