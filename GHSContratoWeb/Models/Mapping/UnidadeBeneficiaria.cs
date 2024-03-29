﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GHSContratoWeb.Models.Mapping
{
    public class UnidadeBeneficiaria
    {
		public int ID { get; set; }
		public int IDEndereco { get; set; }
		public int? IDCliente { get; set; }
		public int? IDCidade { get; set; }
		public int? IDEstado { get; set; }
		public string Rua { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string Complemento { get; set; }
		public string CEP { get; set; }
		public bool? Padrao { get; set; }
		public string Observacao { get; set; }
	}
}