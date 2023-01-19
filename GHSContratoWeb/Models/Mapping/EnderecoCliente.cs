using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class EnderecoCliente
    {
		public int ID { get; set; }
		public int? IDCliente { get; set; }
		public int? IDCidade { get; set; }
		public int? IDEstado { get; set; }
		public string Rua { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string Complemento { get; set; }
		public string CEP { get; set; }
		public decimal? LatitudeDecimal { get; set; }
		public decimal? LongitudeDecimal { get; set; }
		public bool? Padrao { get; set; }
		public bool? Ativo { get; set; }
		public string Observacao { get; set; }
		public string LatitudeHoras { get; set; }
		public string LongitudeHoras { get; set; }
		public bool? LocalInstalacao { get; set; }
	}
}
