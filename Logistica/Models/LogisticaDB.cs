using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Logistica.Models
{
    public class LogisticaDB : DbContext
    {
        // *******************************************************************
        // LogisiticaDB

        public LogisticaDB() : base("LogisticaDBConnectionString") { }

        // vamos colocar, aqui, as instruções relativas às tabelas do 'negócio'
        // descrever os nomes das tabelas na Base de Dados
        public virtual DbSet<Pedidos> Pedidos { get; set; } // tabela Pedido
        public virtual DbSet<Transportadora> Transportadora { get; set; } // tabela Transportadora
        public virtual DbSet<Utilizadores> Utilizadores { get; set; } // tabela Utilizadores
        public virtual DbSet<Cotacoes> Cotacoes { get; set; } // tabela Cotação

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }


    }
}
