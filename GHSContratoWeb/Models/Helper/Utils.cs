using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GHSContratoWeb.Models.Helper
{
    public class Utils
    {
        /// <summary>
        /// Atributo do tipo Objeto Empresa que recebe e manipula
        /// o Objeto Usuarios.
        /// </summary>
        private Usuario usuario;


        /// <summary>
        /// Armazena os dados da Usuarios e os disponíbiliza quando
        /// necessário.
        /// </summary>
        public Usuario Usuario
        {
            get
            {
                this.usuario = (Usuario)HttpContext.Current.Session["Usuario"];
                return this.usuario;
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }

    }
}
