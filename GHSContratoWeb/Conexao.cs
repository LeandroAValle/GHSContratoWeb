using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb
{
    public class Conexao
    {
        private SqlConnection conexao;

        /// <summary>
        /// Super Classe respónsavel por abrir toda conexão com o DB que
        /// o Sistema solicita para alguma ação
        /// </summary>
        public Conexao()
        {
            this.conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ToString());
        }

        public SqlConnection GetCon()
        {
            return this.conexao;
        }
    }
}
