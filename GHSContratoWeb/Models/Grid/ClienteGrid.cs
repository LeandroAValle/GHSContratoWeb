using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Grid
{
    public class ClienteGrid
    {
        public int? ID { get; set; }
        public string Nome { get; set; }
        public string TipoCliente { get; set; }
        public string Documento { get; set; }
        public DateTime? DataCliente { get; set; }       
        public DateTime? DataExpedicao { get; set; }
    }
}
