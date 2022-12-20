using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class Contrato
    {
		public int ID { get; set; }
		public int? IDCliente { get; set; }
		public string Descricao { get; set; }
		public string Observacao { get; set; }
		public decimal? Valor { get; set; }
		public DateTime? DataHoraContrato { get; set; }
		public bool? Ativo { get; set; }
		public string ConteudoContrato { get; set; }
	}
}
