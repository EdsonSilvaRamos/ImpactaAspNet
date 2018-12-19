﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProductRepositorioTests
    {
        private readonly ProductRepositorio repositorio = new ProductRepositorio();

        [TestMethod()]
        public void PostTest()
        {
            var product = new ProductViewModel();
            product.ProductName = "Geléia";
            product.UnitPrice = 21.57m;

            var response = repositorio.Post(product).Result;

            Console.WriteLine(response.ProductID);
        }

        [TestMethod()]
        public void PutTest()
        {
            var product = new ProductViewModel();
            product.ProductName = "Geléia Editado 2";
            product.UnitPrice = 21.66m;
            product.ProductID = 80;

            repositorio.Put(product);

            var response = repositorio.Get(80).Result;

            Assert.IsTrue(response.UnitPrice == 21.08m);
        }

        [TestMethod]
        public void GetTest()
        {
            Assert.IsTrue(repositorio.Get().Result.Count > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            repositorio.Delete(80).Wait();

            var response = repositorio.Get(80).Result;

            Assert.IsNull(response);
        }

    }
}



