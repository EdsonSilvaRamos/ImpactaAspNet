namespace Loja.Repositorio.SqlServer.Migrations
{
    using Loja.Dominio;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Loja.Repositorio.SqlServer.LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorio.SqlServer.LojaDbContext";
        }

        protected override void Seed(LojaDbContext context)
        {
            if (!context.Produtos.Any())
            {
                //context.Database.ExecuteSqlCommand("");
                context.Produtos.AddRange(ObterProdutos());

                context.SaveChanges();
            }
        }

        private IEnumerable<Produto> ObterProdutos()
        {
            var grampeador = new Produto();

            grampeador.Categoria = new Categoria { Nome = "Papelaria" };
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 22.08m;
            grampeador.Estoque = 29;

            var penDrive = new Produto();

            penDrive.Categoria = new Categoria { Nome = "Informática" };
            penDrive.Nome = "Pen Drive";
            penDrive.Preco = 22.30m;
            penDrive.Estoque = 29;

            return new List<Produto> { grampeador, penDrive };
        }

    }
}
