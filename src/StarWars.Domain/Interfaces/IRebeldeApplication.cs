using StarWars.Domain.Entities;
using System.Collections.Generic;

namespace StarWars.Domain.Interfaces
{
    public interface IRebeldeApplication
    {
        IList<Rebelde> RetornarTodos();

        Rebelde RetornarPorId(int id);

        Rebelde Criar(Rebelde rebelde);

        Rebelde AtualizarLocalizacao(Rebelde rebelde);

        string ReportarTraidor(int id);
        bool EhTraidor(int id);
    }
}