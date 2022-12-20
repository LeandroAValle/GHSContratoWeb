using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class UnidadeConsumidora
    {
		public int ID { get; set; }
		public int? IDEnderecoCliente { get; set; }
		public int? IDConsensionaria { get; set; }
		public string Observacao { get; set; }
		public DateTime? DataHoraRegistro { get; set; }
		public bool? Ativo { get; set; }
		public string CodigoUnidadeConsumidora { get; set; }
	}
}
