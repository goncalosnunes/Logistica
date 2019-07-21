using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class LogisticaDB : DbContext
    {
        // *******************************************************************
        // LogisiticaDB

        public LogisticaDB() : base("LogisticaDBConnectionString") { }


        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        

        // vamos colocar, aqui, as instruções relativas às tabelas do 'negócio'
        // descrever os nomes das tabelas na Base de Dados
        public virtual DbSet<Pedido> Pedido { get; set; } // tabela Pedido
        public virtual DbSet<Transportador> Transportador { get; set; } // tabela Transportador
        public virtual DbSet<Transportadora> Transportadora { get; set; } // tabela Utilizadores
        public virtual DbSet<Utilizadores> Utilizador { get; set; } // tabela Utilizadores
        public virtual DbSet<Cliente> Cliente { get; set; } // tabela Utilizadores
        public virtual DbSet<Gestor> Gestor { get; set; } // tabela Utilizadores
        public virtual DbSet<Cotacao> Cotacao { get; set; } // tabela Cotação

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }


    }
}
