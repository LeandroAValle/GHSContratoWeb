using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GHSContratoWeb.Models.Business
{
    public class InformacaoAcessoBusiness
    {
        public List<InformacaoAcesso> SelectInformacaoAcesso()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Internet, AplicativoMonitor, LoginUsuario, Senha, IDConsensionaria, Observacao FROM [InformacoesAcessos]";
                    List<InformacaoAcesso> lista = db.Query<InformacaoAcesso>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<InformacaoAcesso> lista = new List<InformacaoAcesso>();
                return lista;
            }
        }

        public int? InsertInformacaoAcesso(InformacaoAcesso informacaoacesso)
        {
            // Insert           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [InformacoesAcessos] (Internet, AplicativoMonitor, LoginUsuario, Senha, IDConsensionaria, Observacao) VALUES (@Internet, @AplicativoMonitor, @LoginUsuario, @Senha, @IDConsensionaria, @Observacao)";
                    int? re = db.Execute(sql, new { Internet = informacaoacesso.Internet, AplicativoMonitor = informacaoacesso.AplicativoMonitor, LoginUsuario = informacaoacesso.LoginUsuario, Senha = informacaoacesso.Senha, IDConsensionaria = informacaoacesso.IDConsensionaria, Observacao = informacaoacesso.Observacao });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? UpdateInformacaoAcesso(InformacaoAcesso informacaoacesso)
        {
            // Update           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [InformacoesAcessos] SET Internet = @Internet, AplicativoMonitor = @AplicativoMonitor, LoginUsuario = @LoginUsuario, Senha = @Senha, IDConsensionaria = @IDConsensionaria, Observacao = @Observacao WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = informacaoacesso.ID, Internet = informacaoacesso.Internet, AplicativoMonitor = informacaoacesso.AplicativoMonitor, LoginUsuario = informacaoacesso.LoginUsuario, Senha = informacaoacesso.Senha, IDConsensionaria = informacaoacesso.IDConsensionaria, Observacao = informacaoacesso.Observacao });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? DeleteInformacaoAcesso(InformacaoAcesso informacaoacesso)
        {
            // Delete            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [InformacoesAcessos] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { informacaoacesso.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public InformacaoAcesso Detalhes(int? ID)
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Internet, AplicativoMonitor, LoginUsuario, Senha, IDConsensionaria, Observacao FROM [InformacoesAcessos] where ID = @ID";
                    InformacaoAcesso informacaoAcesso = db.Query<InformacaoAcesso>(sql, new { ID = ID }).SingleOrDefault();
                    return informacaoAcesso;
                }
            }
            catch (Exception ex)
            {
                InformacaoAcesso informacaoAcesso = new InformacaoAcesso();
                return informacaoAcesso;
            }
        }
    }
}
