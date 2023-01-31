using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class Empresa
    {
		public string ID { get; set; }
		public string RazaoSocial { get; set; }
		public string NomeFantasia { get; set; }
		public string CNPJ { get; set; }
		public DateTime? DataHora { get; set; }
		public byte[] Brazao { get; set; }
		public string Endereco { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string Telefone { get; set; }
		public string Cidade { get; set; }
		public string UF { get; set; }
	}
}
