using System;
using System.Collections.Generic;
using System.Data.Entity;
using Loja.Dominio;

namespace Loja.Repositorio.SqlServer
{
    internal class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());

            context.SaveChanges();
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