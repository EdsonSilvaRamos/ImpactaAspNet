using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorio.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;

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
    }
}