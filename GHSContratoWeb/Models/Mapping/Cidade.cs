using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class Cidade
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public int? IDEstado { get; set; }
        public int? Ibge { get; set; }
    }
}
