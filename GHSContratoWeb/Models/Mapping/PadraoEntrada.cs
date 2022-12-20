using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class PadraoEntrada
    {
		public int ID { get; set; }
		public int? IDConsensionaria { get; set; }
		public int? IDUnidadeConsumidora { get; set; }
		public bool? ApresentouFatouraEnergia { get; set; }
		public string DemandaContratada { get; set; }
		public string Categoria { get; set; }
		public string Disjuntor { get; set; }
		public string BitolaCaboEntrada { get; set; }
		public string TipoLigacao { get; set; }
		public bool? QDCA { get; set; }
		public string ConsumoMedio { get; set; }
		public bool? AumentoCarga { get; set; }
		public string Observacao { get; set; }
		public DateTime? Datahora { get; set; }
		public int? IDContrato { get; set; }
	}
}
