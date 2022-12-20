using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class Estado
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public int? ibge { get; set; }
    }
}
