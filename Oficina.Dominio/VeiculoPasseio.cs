using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    //ToDo: OO - Herança (:) com a clase Veiculo.
    public class VeiculoPasseio : Veiculo
    {
        public Carroceria Carroceria { get; set; }

        //Todo: OO - Polimorfismo por sobrescrita.
        public override List<string> Validar()
        {
            var erros = ValidarBase();

            if (!Enum.IsDefined(typeof(Carroceria), Carroceria))
            {
                erros.Add($"A carroceria informada ({Carroceria}), não é válida!");
            }

            return erros;
        }
    }
}
