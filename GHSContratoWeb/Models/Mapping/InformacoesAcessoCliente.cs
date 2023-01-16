using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class InformacoesAcessoCliente
    {
		public int ID { get; set; }
		public int? IDCliente { get; set; }
		public string Internet { get; set; }
		public string AplicativoMonitor { get; set; }
		public string LoginUsuario { get; set; }
		public string Senha { get; set; }
		public int? IDConsensionaria { get; set; }
		public string Observacao { get; set; }
	}
}
