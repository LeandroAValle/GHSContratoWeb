using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class DadosCliente
    {
		public int ID { get; set; }
		public int? IDCliente { get; set; }
		public string CPF { get; set; }
		public string CNPJ { get; set; }
		public string RG { get; set; }
		public string InscricaoEstadual { get; set; }
		public DateTime? DataNascimento { get; set; }
		public DateTime? DataAbertura { get; set; }
	}
}
