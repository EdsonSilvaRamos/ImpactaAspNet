using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using Oficina.Repositorios;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var veiculo = new Veiculo();
            veiculo.Placa = "ABC1234";
            veiculo.Ano = 2019;
            veiculo.Observacao = "Teste";
            veiculo.Cambio = Cambio.Automatico;
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Cor = new CorRepositorio().Selecionar(1);
            veiculo.Modelo = new ModeloRepositorio().Selecionar(2);

            new VeiculoRepositorio().Inserir(veiculo);
        }
    }
}