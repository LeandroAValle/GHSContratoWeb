using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class SistemaFotovoltaico
    {
		public int ID { get; set; }
		public string MediaGeracaoMes { get; set; }
		public string Capacidade { get; set; }
		public string QuantidadeModulos { get; set; }
		public string MediaGeracaoAnos { get; set; }
		public string CapacidadeInversor { get; set; }
		public string PotenciaTecnologia { get; set; }
		public decimal? QuantidadeInversor { get; set; }
		public decimal? AreaAcomodacao { get; set; }
		public string ProtecaoCorrenteContinua { get; set; }
		public string ProtecaoCorrenteAlternada { get; set; }
		public decimal? AreaTelhado { get; set; }
		public string Observarcao { get; set; }
		public int? IDContrato { get; set; }
	}
}
