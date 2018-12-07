using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViagensOnline.Mvc.Models
{
    public class DestinoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Cidade { get; set; }        

        public string CaminhoImagem { get; set; }

        [Display(Name = "Foto")]
        public HttpPostedFileBase ArquivoFoto { get; set; }
    }
}