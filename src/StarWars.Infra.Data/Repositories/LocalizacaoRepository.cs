using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StarWars.Infra.Data.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        #region Properties

        DbContextOptions<MyContext> options = new DbContextOptionsBuilder<MyContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

        #endregion

        #region Public Methods

        public Localizacao Update(Localizacao localizacao)
        {
            using var context = new MyContext(options);
            if (context.Rebeldes.Any(x => x.Id != localizacao.Id))
                return null;

            context.Entry(localizacao).State = EntityState.Modified;
            context.SaveChanges();

            return localizacao;
        }

        #endregion
    }
}