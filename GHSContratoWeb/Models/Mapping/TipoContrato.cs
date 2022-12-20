using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class TipoContrato
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public bool? Ativo { get; set; }
    }
}
