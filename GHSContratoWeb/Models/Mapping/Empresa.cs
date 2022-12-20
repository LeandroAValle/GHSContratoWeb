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
	}
}
