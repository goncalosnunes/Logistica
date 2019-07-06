namespace Logistica.Migrations
{
    using Logistica.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Logistica.Models.LogisticaDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Logistica.Models.LogisticaDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var utilizadores = new List<Utilizadores> {
                new Utilizadores{ID = 1, Nome = "Andre", Apelido = "Silveira", NomeEmpresa = "Empresa XPTO", Rua = "Rua Teste", NIF = "123456789", Contacto = "123456789", Pais  = "Portugal", Email = "123456789@mail.com", Cidade = "cidade Teste", CodigoPostal = "1234- 123", NumPorta  = "1", Fotografia = "path XPTO"},
                new Utilizadores{ID = 2, Nome = "Antonio", Apelido = " Rocha", NomeEmpresa = "Empresa XPTO", Rua = "Rua Teste", NIF = "123456789", Contacto = "123456789", Pais  = "Portugal", Email = "123456789@mail.com", Cidade = "cidade Teste", CodigoPostal = "1234- 123", NumPorta  = "1", Fotografia = "path XPTO"},
                new Utilizadores{ID = 3, Nome = "Augusto", Apelido = "Carvalho", NomeEmpresa = "Empresa XPTO", Rua = "Rua Teste", NIF = "123456789", Contacto = "123456789", Pais  = "Portugal", Email = "123456789@mail.com", Cidade = "cidade Teste", CodigoPostal = "1234- 123", NumPorta  = "1", Fotografia = "path XPTO"},
                new Utilizadores{ID = 4, Nome = "Beatriz", Apelido = "Pinto", NomeEmpresa = "Empresa XPTO", Rua = "Rua Teste", NIF = "123456789", Contacto = "123456789", Pais  = "Portugal", Email = "123456789@mail.com", Cidade = "cidade Teste", CodigoPostal = "1234- 123", NumPorta  = "1", Fotografia = "path XPTO"},
                new Utilizadores{ID = 5, Nome = "Claudia", Apelido =  "Pinto", NomeEmpresa = "Empresa XPTO", Rua = "Rua Teste", NIF = "123456789", Contacto = "123456789", Pais  = "Portugal", Email = "123456789@mail.com", Cidade = "cidade Teste", CodigoPostal = "1234- 123", NumPorta  = "1", Fotografia = "path XPTO"}
            };



        }
    }
}