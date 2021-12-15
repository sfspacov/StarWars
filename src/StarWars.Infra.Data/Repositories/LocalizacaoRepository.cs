using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Interfaces.Repositories;

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

        public void Criar(Localizacao localizacao)
        {
            using var context = new MyContext(options);
            context.Localizacoes.Add(localizacao);
            context.SaveChanges();
        }
        public Localizacao Update(Localizacao localizacao)
        {
            using var context = new MyContext(options);
            var firstOrDefault = context.Rebeldes.Include(x => x.Localizacao).FirstOrDefault(x => x.Id == localizacao.IdRebelde);
            if (firstOrDefault == null)
                return null;
            localizacao.Id = firstOrDefault.Localizacao.Id;
            context.Entry(localizacao).State = EntityState.Modified;
            context.SaveChanges();

            return localizacao;
        }

        #endregion

        public void Seed()
        {
            throw new System.NotImplementedException();
        }
    }
}