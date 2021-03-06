﻿using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios
{
    public class MarcaRepositorio
    {
        private readonly string caminhoArquivo;
       

        public MarcaRepositorio()
        {
            caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                AppSettings["caminhoArquivoMarca"]);
        }

        public List<Marca> Selecionar()
        {
            var marcas = new List<Marca>();

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var propriedades = linha.Split('|');

                var marca = new Marca();

                marca.Id = Convert.ToInt32(propriedades[0]);
                marca.Nome = propriedades[1];

                marcas.Add(marca);
            }

            return marcas;
        }

        public Marca Selecionar(int id)
        {
            //int? x = null;

            Marca marca = null;

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var propriedades = linha.Split('|');

                if (Convert.ToInt32(propriedades[0]) == id)
                {
                    marca = new Marca();

                    marca.Id = Convert.ToInt32(propriedades[0]);
                    marca.Nome = propriedades[1];
                    //null.ToString();

                    break;
                }
            }

            return marca;
        }
    }
}
