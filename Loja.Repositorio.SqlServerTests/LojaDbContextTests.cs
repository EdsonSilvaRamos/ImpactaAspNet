using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorio.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;
using System.Data.Entity;

namespace Loja.Repositorio.SqlServer.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private readonly LojaDbContext db = new LojaDbContext();

        public LojaDbContextTests()
        {
            db.Database.Log = LogarQuery;
        }

        private void LogarQuery(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirCategoriaTeste()
        {
            var categoria = new Categoria();

            categoria.Nome = "Informática";
            
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();

            produto.Categoria = db.Categorias.Find(1);
            produto.Nome = "Caneta BIC";
            produto.Preco = 1.50m;
            produto.Estoque = 3;

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTeste()
        {
            var produto = new Produto();

            produto.Categoria = new Categoria { Nome = "Perfumaria" };
            produto.Nome = "Barbeador";
            produto.Preco = 22.09m;
            produto.Estoque = 8;

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void EditarProdustoTeste()
        {
            var produto = db.Produtos
                .Where(p => p.Nome.Contains("BIC"))
                .FirstOrDefault();

            produto.Categoria = db.Categorias.Find(2);
            produto.Estoque = 50;
            produto.Nome = "Perfume";
            produto.Preco = 22.23m;

            db.SaveChanges();
        }

        [TestMethod]
        public void ExluirProdutoTeste()
        {
            var produto = db.Produtos
                .Where(p => p.Categoria.Nome == "Informática")
                .ToList();

            db.Produtos.RemoveRange(produto);
            db.SaveChanges();

            Assert.IsFalse(db.Produtos
                .Any(p => p.Categoria.Nome == "Informática"));

        }

        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            var produto = db.Produtos
                .SingleOrDefault(p => p.Id == 2);

            Assert.IsNull(produto.Categoria);
        }

        [TestMethod]
        public void IncludeTeste()
        {
            var produto = db.Produtos.Include(p => p.Categoria)
               .SingleOrDefault(p => p.Id == 2);

            Console.WriteLine(produto.Categoria.Nome);

        }

        [TestMethod]
        [DataRow(3)]
        public void QueryableTeste(int estoque)
        {
            var query = db.Produtos.Where(p => p.Preco > 10);

            if (estoque > 0)
            {
                query = query.Where(p => p.Estoque >= estoque);
            }

            query.OrderBy(p => p.Preco);

            var primeiro = query.FirstOrDefault();
            var ultimo = query.AsEnumerable().LastOrDefault();
            var unico = query.SingleOrDefault();
            var todos = query.ToList();
        }
    }
}