using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class HistoricoLoginBusiness
    {
        public List<HistoricoLogin> SelectHistoricoLogin()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDUsuario, DataHora FROM [HistoricosLogins]";
                    List<HistoricoLogin> lista = db.Query<HistoricoLogin>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<HistoricoLogin> lista = new List<HistoricoLogin>();
                return lista;                
            }
        }
        public int? InsertHistoricoLogin(HistoricoLogin historicologin)
        {
            // Insert           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [HistoricosLogins] (IDUsuario, DataHora) VALUES (@IDUsuario, @DataHora)";
                    int? re = db.Execute(sql, new { IDUsuario = historicologin.IDUsuario, DataHora = historicologin.DataHora });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? UpdateHistoricoLogin(HistoricoLogin historicologin)
        {
            // Update           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [HistoricosLogins] SET IDUsuario = @IDUsuario, DataHora = @DataHora WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = historicologin.ID, IDUsuario = historicologin.IDUsuario, DataHora = historicologin.DataHora });
                    return re;
                }
            }
            catch (Exception)
            {
                return null;                
            }
        }
        public int? DeleteHistoricoLogin(HistoricoLogin historicologin)
        {
            // Delete           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [HistoricosLogins] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { historicologin.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public HistoricoLogin Detalhes(int? ID)
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDUsuario, DataHora FROM [HistoricosLogins] where ID = @ID";
                    HistoricoLogin historicoLogin = db.Query<HistoricoLogin>(sql).SingleOrDefault();
                    return historicoLogin;
                }
            }
            catch (Exception ex)
            {
                HistoricoLogin historicoLogin = new HistoricoLogin();
                return historicoLogin;     
            }
        }
    }
}
