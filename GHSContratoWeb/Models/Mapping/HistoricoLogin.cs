using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class HistoricoLogin
    {
        public int ID { get; set; }
        public string IDUsuario { get; set; }
        public DateTime? DataHora { get; set; }
    }
}
