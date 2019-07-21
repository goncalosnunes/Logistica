namespace Logistica.Migrations
{
    using Logistica.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LogisticaDB>
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

            // Adiciona utilizadores
            var utilizadores = new List<Utilizadores> {
            new Utilizadores {ID=1, Nome="Tania", Apelido="Vieira", Fotografia="TaniaVieira.jpg"},
            new Utilizadores {ID=2, Nome="António", Apelido="Rocha", Fotografia="AntonioRocha.jpg"},
            new Utilizadores {ID=3, Nome="André", Apelido="Silveira", Fotografia="AndreSilveira.jpg"},
            new Utilizadores {ID=4, Nome="Lurdes", Apelido="Vieira", Fotografia="LurdesVieira.jpg"},
            new Utilizadores {ID=5, Nome="Cláudia", Apelido="Pinto", Fotografia="ClaudiaPinto.jpg"},
            new Utilizadores {ID=6, Nome="Rui", Apelido="Vieira", Fotografia="RuiVieira.jpg"},
            new Utilizadores {ID=7, Nome="Augusto", Apelido="Carvalho", Fotografia="AugustoCarvalho.jpg"}
         };
            utilizadores.ForEach(uu => context.Utilizador.AddOrUpdate(u => u.ID, uu));

            context.SaveChanges();

            // Adiciona utilizadores
            var clientes = new List<Cliente> {
            new Cliente {NomeEmpresa="Loja De Tecidos Lda", Pais="Portugal", Cidade="Coimbra", Rua="Rua De Lisboa", CodigoPostal="3000-008", NumPorta="14", NIF="501000000", Contacto="00351911000001", Email="taniavieira@lojadetecidos.pt", UtilizadorFK=1},
            new Cliente {NomeEmpresa="Loja Dos Pasteis Lda", Pais="Portugal", Cidade="Lisboa", Rua="Avenida da Républica", CodigoPostal="1000-004", NumPorta="209", NIF="501111111", Contacto="00351911222222", Email="antoniorocha@lojadospasteis.pt", UtilizadorFK=2},
            new Cliente {NomeEmpresa="Café Central Lda", Pais="Portugal", Cidade="Porto", Rua="Avenida Dos Combatentes", CodigoPostal="4000-015", NumPorta="125", NIF="501222222", Contacto="00351911333333", Email="andresilveira@cafecentral.pt", UtilizadorFK=3}
         };
            clientes.ForEach(cc => context.Cliente.AddOrUpdate(c => c.ID, cc));

            context.SaveChanges();


            // Adiciona Transportadoras
            var transportadora = new List<Transportadora> {
            new Transportadora {ID=1, NomeTransportadora="Luis Simoes Lda", Pais="Portugal", Cidade="Loures", Rua="Avenida Da Liberdade", CodigoPostal="2620-412", NumPorta="12",NIF="502333444",Contacto="00351910234432",Email="geral@luis-simoes.com"},
            new Transportadora {ID=2, NomeTransportadora="Transportes Pombalense Lda", Pais="Portugal", Cidade="Pombal", Rua="Avenida De Coimbra",CodigoPostal="3100-200", NumPorta="30",NIF="502661199",Contacto="00351912987456",Email="geral@transportespombalense.pt"},
            new Transportadora {ID=3, NomeTransportadora="Dhl Sa", Pais="Suecia", Cidade="Estocolmo", Rua="Main Street" ,CodigoPostal="1000-002", NumPorta="1",NIF="500111999",Contacto="00351911111111",Email="geral@dhl.com"}
         };
            transportadora.ForEach(tt => context.Transportadora.AddOrUpdate(t => t.ID, tt));

            context.SaveChanges();

            // Adiciona utilizadores
            var transportador = new List<Transportador> {
            new Transportador {UtilizadorFK=4, TransportadoresFK=1},
            new Transportador {UtilizadorFK=5, TransportadoresFK=2},
            new Transportador {UtilizadorFK=6, TransportadoresFK=3}
         };
            transportador.ForEach(ttt => context.Transportador.AddOrUpdate(t => t.ID, ttt));

            context.SaveChanges();

            // Adiciona gestor
            var gestor = new List<Gestor> {
            new Gestor {UtilizadorFK=7}
         };
            gestor.ForEach(gg => context.Gestor.AddOrUpdate(g => g.ID, gg));

            context.SaveChanges();
        }
    }
}