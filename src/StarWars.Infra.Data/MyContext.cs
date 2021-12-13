using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;

namespace StarWars.Infra.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }
        public DbSet<Rebelde> Rebeldes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
    }
}
