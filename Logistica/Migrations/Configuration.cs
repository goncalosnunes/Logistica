namespace Logistica.Migrations
{
    using Logistica.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

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

            // Qualquer coisa
            var utilizadores = new List<Utilizadores> {
                new Utilizadores{ID = 0, Nome = "Andre", Apelido = "Silveira", Pais = "Portugal", Email = "andreSilveira@mail.com", NIF = "221199422", Contacto = "911874453", CodigoPostal = "1000-200", NumPorta  = "305", Cidade = "Lisboa", NomeEmpresa = "Loja Euro Lda", Rua = "Rua De Faro"},
                new Utilizadores{ID = 1, Nome = "Antonio", Apelido = "Rocha", Pais = "Portugal", Email = "antonioRocha@mail.com", NIF = "223484566", Contacto = "961854454", CodigoPostal = "3260-412", NumPorta  = "252", Cidade = "Figueiro Vinhos", NomeEmpresa = "Pecas Auto Lda", Rua = "Avenida Do Municipio"},
                new Utilizadores{ID = 2, Nome = "Augusto", Apelido = "Carvalho", Pais = "Portugal", Email = "augustoCarvalho@mail.com", NIF = "216643801", Contacto = "935464354", CodigoPostal = "3000-147", NumPorta  = "27", Cidade = "Coimbra", NomeEmpresa = "Bikezone Lda", Rua = "Rua De Dona Sofia"},
                new Utilizadores{ID = 3, Nome = "Beatriz", Apelido = "Almeida", Pais = "Portugal", Email = "beatrizAlmeida@mail.com", NIF = "201815647", Contacto = "935424554", CodigoPostal = "2300-174", NumPorta  = "32", Cidade = "Tomar", NomeEmpresa = "Farmacia Central Lda", Rua = "Rua De Coimbra"},
                new Utilizadores{ID = 4, Nome = "Claudia", Apelido =  "Oliveira", Pais = "Portugal", Email = "claudiaOliveira@mail.com", NIF = "233255117", Contacto = "924852457", CodigoPostal = "4000-034", NumPorta  = "131", Cidade = "Porto", NomeEmpresa = "Cafe Avenida Lda", Rua = "Avenida Da Liberdade"}
            };
            utilizadores.ForEach(uu => context.Utilizadores.AddOrUpdate(u => u.ID, uu));

            context.SaveChanges();

            var pedidos = new List<Pedidos>
            {
                new Pedidos{ID = 0, Nome = "Jorge", Apelido = "Costa", NomeEmpresaDestinataria = "Figueiro Car", PaisDestino = "Portugal", CidadeDestino = "Faro", RuaDestino = "Avenida Comendador Joaquim", NumPortaDestino = "10", EmailDestinatario = "jorgeCosta@mail.com", DataEntregaPretendida = new DateTime(2020, 1, 1), CodigoPostalDestino = "8000-120", ContactoDestinatario = "915653445", Peso = 100, Altura = 10, Comprimento = 10, Largura = 10, Utilizador = utilizadores[0], Utilizadorfk = 0, Preco = 56, Estado = 0, Aceite = 0},
                new Pedidos{ID = 1, Nome = "Silvia", Apelido = "Antunes", NomeEmpresaDestinataria = "BrinMedi Lda", PaisDestino = "Portugal", CidadeDestino = "Ferreira Do Zezere", RuaDestino = "Rua Do Tribunal", NumPortaDestino = "41", EmailDestinatario = "silviaAntunes@mail.com", DataEntregaPretendida = new DateTime(2020, 2, 2), CodigoPostalDestino = "2240-584", ContactoDestinatario = "916687445", Peso = 100, Altura = 10, Comprimento = 20, Largura = 10, Utilizador = utilizadores[1], Utilizadorfk = 1, Preco = 72, Estado = 0, Aceite = 0},
                new Pedidos{ID = 2, Nome = "Ana", Apelido = "Lopes", NomeEmpresaDestinataria = "Wurth Lda", PaisDestino = "Portugal", CidadeDestino = "Almeirim", RuaDestino = "Rua Dos Bombeiros", NumPortaDestino = "202", EmailDestinatario = "anaLopes@mail.com", DataEntregaPretendida = new DateTime(2019, 9, 3), CodigoPostalDestino = "2080-081", ContactoDestinatario = "925444812", Peso = 100, Altura = 10, Comprimento = 10, Largura = 20, Utilizador = utilizadores[2], Utilizadorfk = 2, Preco = 12, Estado = 0, Aceite = 0},
                new Pedidos{ID = 3, Nome = "Tiago", Apelido = "Francisco", NomeEmpresaDestinataria = "Intermarche Sa", PaisDestino = "Portugal", CidadeDestino = "Portalegre", RuaDestino = "Sao Sebastiao", NumPortaDestino = "27", EmailDestinatario = "tiagoFrancisco@mail.com", DataEntregaPretendida = new DateTime(2019, 12, 4), CodigoPostalDestino = "7300-200", ContactoDestinatario = "911784364", Peso = 100, Altura = 30, Comprimento = 10, Largura = 10, Utilizador = utilizadores[3], Utilizadorfk = 3, Preco = 23, Estado = 0, Aceite = 0},
                new Pedidos{ID = 4, Nome = "Lara", Apelido = "David", NomeEmpresaDestinataria = "Continente Sa", PaisDestino = "Portugal", CidadeDestino = "Castelo Branco", RuaDestino = "Cruz De Ferro", NumPortaDestino = "58", EmailDestinatario = "laraDavid@mail.com", DataEntregaPretendida = new DateTime(2020, 5, 5), CodigoPostalDestino = "6000-040", ContactoDestinatario = "966795488", Peso = 100, Altura = 10, Comprimento = 30, Largura = 10, Utilizador = utilizadores[4], Utilizadorfk = 4, Preco = 120, Estado = 0, Aceite = 0}
            };
            pedidos.ForEach(pp => context.Pedidos.AddOrUpdate(p => p.ID, pp));

            context.SaveChanges();

            var transportadores = new List<Transportadora>
            {
                new Transportadora{ID = 0, NomeTransportadora = "Transportes Prates", Email = "transportesPrates@mail.com", Contacto = "218794545", NIF = "500743664", Pais = "Portugal", Cidade = "Lisboa", Rua = "Cais Do Sodre", CodigoPostal = "1000-041", NumPorta = "120" },
                new Transportadora{ID = 1, NomeTransportadora = "Transportes Mario", Email = "transportesMario@mail.com", Contacto = "244483178", NIF = "509434435", Pais = "Portugal", Cidade = "Leiria", Rua = "Marques De Pombal", CodigoPostal = "2400-562", NumPorta = "28" },
                new Transportadora{ID = 2, NomeTransportadora = "Transportes Contente", Email = "transportesContente@mail.com", Contacto = "244948547", NIF = "507364586", Pais = "Portugal", Cidade = "Coimbra", Rua = "Largo Da Portagem", CodigoPostal = "3000-389", NumPorta = "23" },
                new Transportadora{ID = 3, NomeTransportadora = "Dhl Sa", Email = "dhl@mail.com", Contacto = "213787388", NIF = "500744354", Pais = "Portugal", Cidade = "Lisboa", Rua = "Terreiro Do Paco", CodigoPostal = "1000-200", NumPorta = "174" },
                new Transportadora{ID = 4, NomeTransportadora = "Chronopost Sa", Email = "chronopost@mail.com", Contacto = "227434935", NIF = "501786784", Pais = "Portugal", Cidade = "Porto", Rua = "Avenida De Espanha", CodigoPostal = "4000-333", NumPorta = "15" }
            };
            transportadores.ForEach(tt => context.Transportadora.AddOrUpdate(t => t.ID, tt));

            context.SaveChanges();

            var cotacoes = new List<Cotacoes>
            {
                new Cotacoes{ID = 0, Pedido = pedidos[0], Pedidofk = 0, Transportadora = transportadores[0], Transportadorafk = 0,  valorCotacao = 10, Aceite = false},
                new Cotacoes{ID = 1, Pedido = pedidos[1], Pedidofk = 1, Transportadora = transportadores[1], Transportadorafk = 1,  valorCotacao = 20, Aceite = false},
                new Cotacoes{ID = 2, Pedido = pedidos[2], Pedidofk = 2, Transportadora = transportadores[2], Transportadorafk = 2,  valorCotacao = 30, Aceite = false},
                new Cotacoes{ID = 3, Pedido = pedidos[3], Pedidofk = 3, Transportadora = transportadores[3], Transportadorafk = 3,  valorCotacao = 40, Aceite = false},
                new Cotacoes{ID = 4, Pedido = pedidos[4], Pedidofk = 4, Transportadora = transportadores[4], Transportadorafk = 4,  valorCotacao = 50, Aceite = false}
            };
            cotacoes.ForEach(cc => context.Cotacoes.AddOrUpdate(c => c.ID, cc));

            context.SaveChanges();
        }


    }
}