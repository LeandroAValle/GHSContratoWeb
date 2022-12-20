using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class AcomodacaoModulo
    {
		public int ID { get; set; }
		public bool? Orientacao { get; set; }
		public bool? Limitacao { get; set; }
		public string LocalInstalacao { get; set; }
		public string IdadeTelhado { get; set; }
		public string TipoTelha { get; set; }
		public decimal? PesoSistema { get; set; }
		public string QualidadeTelhado { get; set; }
		public bool? EstruturaAjuste { get; set; }
		public bool? Serralheiro { get; set; }
		public string ObstaculoInterno { get; set; }
		public string ObstaculoExterno { get; set; }
		public string Observacao { get; set; }
	}
}
