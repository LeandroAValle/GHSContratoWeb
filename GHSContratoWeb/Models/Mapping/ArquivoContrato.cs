using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class ArquivoContrato
    {
		public int ID { get; set; }
		public int? IDContrato { get; set; }
		public byte[] Arquivo { get; set; }
		public string Descricao { get; set; }
		public string Observacao { get; set; }
		public DateTime? DataHora { get; set; }
	}
}
