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

            // Qualquer coisa
            var utilizadores = new List<Utilizadores> {
                new Utilizadores{ID = 0, Nome = "Andre", Apelido = "Silveira", Pais = "Portugal", Email = "teste@mail.com", NIF = "123456789", Contacto = "123456789", CodigoPostal = "1234123", NumPorta  = "1", Cidade = "Cidade", NomeEmpresa = "Empresa Teste", Rua = "Rua Teste"},
                new Utilizadores{ID = 1, Nome = "Antonio", Apelido = "Rocha", Pais = "Portugal", Email = "teste@mail.com", NIF = "123456789", Contacto = "123456789", CodigoPostal = "1234123", NumPorta  = "2", Cidade = "Cidade", NomeEmpresa = "Empresa Teste", Rua = "Rua Teste"},
                new Utilizadores{ID = 2, Nome = "Augusto", Apelido = "Carvalho", Pais = "Portugal", Email = "teste@mail.com", NIF = "123456789", Contacto = "123456789", CodigoPostal = "1234123", NumPorta  = "3", Cidade = "Cidade", NomeEmpresa = "Empresa Teste", Rua = "Rua Teste"},
                new Utilizadores{ID = 3, Nome = "Beatriz", Apelido = "Pinto", Pais = "Portugal", Email = "teste@mail.com", NIF = "123456789", Contacto = "123456789", CodigoPostal = "1234123", NumPorta  = "4", Cidade = "Cidade", NomeEmpresa = "Empresa Teste", Rua = "Rua Teste"},
                new Utilizadores{ID = 4, Nome = "Claudia", Apelido =  "Pinto", Pais = "Portugal", Email = "teste@mail.com", NIF = "123456789", Contacto = "123456789", CodigoPostal = "1234123", NumPorta  = "5", Cidade = "Cidade", NomeEmpresa = "Empresa Teste", Rua = "Rua Teste"}
            };
            utilizadores.ForEach(bb => context.Utilizadores.AddOrUpdate(b => b.ID, bb));

            context.SaveChanges();

            var pedidos = new List<Pedido>
            {
                new Pedido{ID = 0, Nome = "Andre", Apelido = "Pinto", NomeEmpresaDestinataria = "Empresa Teste", PaisDestino = "Portugal", CidadeDestino = "Cidade", RuaDestino = "Rua Teste", NumPortaDestino = "1", EmailDestinatario = "teste@mail.com", DataEntregaPretendida = new DateTime(2016, 1, 1), CodigoPostalDestino = "1234-123", ContactoDestinatario = "123456789", Peso = 100, Altura = 10, Comprimento = 10, Largura = 10},
                new Pedido{ID = 1, Nome = "Antonio", Apelido = "Pinto", NomeEmpresaDestinataria = "Empresa Teste", PaisDestino = "Espanha", CidadeDestino = "Cidade", RuaDestino = "Rua Teste", NumPortaDestino = "2", EmailDestinatario = "teste@mail.com", DataEntregaPretendida = new DateTime(2017, 2, 2), CodigoPostalDestino = "1234-123", ContactoDestinatario = "123456789", Peso = 100, Altura = 10, Comprimento = 20, Largura = 10},
                new Pedido{ID = 2, Nome = "Augusto", Apelido = "Carvalho", NomeEmpresaDestinataria = "Empresa Teste", PaisDestino = "Franca", CidadeDestino = "Cidade", RuaDestino = "Rua Teste", NumPortaDestino = "3", EmailDestinatario = "teste@mail.com", DataEntregaPretendida = new DateTime(2018, 3, 3), CodigoPostalDestino = "1234-123", ContactoDestinatario = "123456789", Peso = 100, Altura = 10, Comprimento = 10, Largura = 20},
                new Pedido{ID = 3, Nome = "Beatriz", Apelido = "Rocha", NomeEmpresaDestinataria = "Empresa Teste", PaisDestino = "Alemanha", CidadeDestino = "Cidade", RuaDestino = "Rua Teste", NumPortaDestino = "4", EmailDestinatario = "teste@mail.com", DataEntregaPretendida = new DateTime(2019, 4, 4), CodigoPostalDestino = "1234-123", ContactoDestinatario = "123456789", Peso = 100, Altura = 30, Comprimento = 10, Largura = 10},
                new Pedido{ID = 4, Nome = "Claudia", Apelido = "Silveira", NomeEmpresaDestinataria = "Empresa Teste", PaisDestino = "Polonia", CidadeDestino = "Cidade", RuaDestino = "Rua Teste", NumPortaDestino = "5", EmailDestinatario = "teste@mail.com", DataEntregaPretendida = new DateTime(2020, 5, 5), CodigoPostalDestino = "1234-123", ContactoDestinatario = "123456789", Peso = 100, Altura = 10, Comprimento = 30, Largura = 10}
            };
            pedidos.ForEach(bb => context.Pedido.AddOrUpdate(b => b.ID, bb));

            context.SaveChanges();

            var transportadores = new List<Transportadora>
            {
                new Transportadora{ID = 0, NomeTransportadora = "Transportadora Xpto", Email = "teste@mail.com", Contacto = "123456789", NIF = "123456789", Pais = "Portugal", Cidade = "Cidade", Rua = "Rua Teste", CodigoPostal = "1234-123", NumPorta = "1" },
                new Transportadora{ID = 1, NomeTransportadora = "Transportadora Xpto", Email = "teste@mail.com", Contacto = "123456789", NIF = "123456789", Pais = "Portugal", Cidade = "Cidade", Rua = "Rua Teste", CodigoPostal = "1234-123", NumPorta = "2" },
                new Transportadora{ID = 2, NomeTransportadora = "Transportadora Xpto", Email = "teste@mail.com", Contacto = "123456789", NIF = "123456789", Pais = "Portugal", Cidade = "Cidade", Rua = "Rua Teste", CodigoPostal = "1234-123", NumPorta = "3" },
                new Transportadora{ID = 3, NomeTransportadora = "Transportadora Xpto", Email = "teste@mail.com", Contacto = "123456789", NIF = "123456789", Pais = "Portugal", Cidade = "Cidade", Rua = "Rua Teste", CodigoPostal = "1234-123", NumPorta = "4" },
                new Transportadora{ID = 4, NomeTransportadora = "Transportadora Xpto", Email = "teste@mail.com", Contacto = "123456789", NIF = "123456789", Pais = "Portugal", Cidade = "Cidade", Rua = "Rua Teste", CodigoPostal = "1234-123", NumPorta = "5" }
            };
            transportadores.ForEach(bb => context.Transportadora.AddOrUpdate(b => b.ID, bb));

            context.SaveChanges();

            var cotacoes = new List<Cotacao>
            {
                new Cotacao{ID = 0, Pedido = pedidos[0], Pedidofk = 0, Transportadora = transportadores[0], Transportadorafk = 0, valorCotacao = 100},
                new Cotacao{ID = 1, Pedido = pedidos[1], Pedidofk = 1, Transportadora = transportadores[1], Transportadorafk = 1, valorCotacao = 200},
                new Cotacao{ID = 2, Pedido = pedidos[2], Pedidofk = 2, Transportadora = transportadores[2], Transportadorafk = 2, valorCotacao = 300},
                new Cotacao{ID = 3, Pedido = pedidos[3], Pedidofk = 3, Transportadora = transportadores[3], Transportadorafk = 3, valorCotacao = 400},
                new Cotacao{ID = 4, Pedido = pedidos[4], Pedidofk = 4, Transportadora = transportadores[4], Transportadorafk = 4, valorCotacao = 500}

            };
            cotacoes.ForEach(bb => context.Cotacao.AddOrUpdate(b => b.ID, bb));

            context.SaveChanges();
        }


    }
}