﻿using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //Todo: OO - Classe (entidade) ou abtraçlao
    public abstract class Veiculo
    {
        //public Veiculo()
        //{
        //    Id = Guid.NewGuid();
        //}        

        public Guid Id { get; set; } = Guid.NewGuid();

        //private string Placa;

        //public string Placa
        //{
        //    get
        //    {
        //        return Placa.ToUpper();
        //    }
        //    set
        //    {
        //        Placa = value.ToUpper();
        //    }
        //}

        private string placa;

        //Todo: OO - Encapsulamento.
        public string Placa
        {
            get { return placa?.ToUpper(); }
            set { placa = value?.ToUpper(); }
        }

        public int Ano { get; set; }
        public string Observacao { get; set; }
        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }

        public DateTime Agora
        {
            get { return DateTime.Now; }
        }

        public abstract List<string> Validar();

        protected List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (Ano < 1980 || Ano > DateTime.Now.Year + 1)
            {
                erros.Add($"O ano informado ({Ano}) não é válido.");
            }

            return erros;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Modelo.Marca.Nome, Modelo.Nome, Placa);

            //return base.ToString(); 
        }
    }
}
