using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GHSContratoWeb.Models.Mapping
{
    public class ContatoCliente
    {
        public int ID { get; set; }
        public int IDTipoContato { get; set; }
        public int IDCliente { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataHora { get; set; }
        public bool Ativo { get; set; }
    }
}