using Microsoft.EntityFrameworkCore;
using NUINFDAO.DOMINIOMAP;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.CONTEXTOS
{
    public class BD_Nuinf_Context : DbContext
    {
        public BD_Nuinf_Context ()
        { }

        public BD_Nuinf_Context(DbContextOptions<BD_Nuinf_Context> opcoes)
            :base(opcoes)
        { }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=BD_NUINF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  base.OnModelCreating(modelBuilder);
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new TelefoneMap());
        }
    }
}
