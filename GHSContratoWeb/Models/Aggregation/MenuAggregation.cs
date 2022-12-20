using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Aggregation
{
    public class MenuAggregation
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Icone { get; set; }
        public int Ordem { get; set; }
        public List<SubMenuAggregation> Submenu { get; set; }

    }
}
