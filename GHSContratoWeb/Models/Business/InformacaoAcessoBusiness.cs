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
        public List<InformacoesAcessoCliente> SelectInformacaoAcesso()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Internet, AplicativoMonitor, LoginUsuario, Senha, IDConsensionaria, Observacao FROM [InformacoesAcessos]";
                    List<InformacoesAcessoCliente> lista = db.Query<InformacoesAcessoCliente>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<InformacoesAcessoCliente> lista = new List<InformacoesAcessoCliente>();
                return lista;
            }
        }

        public int? InsertInformacaoAcesso(InformacoesAcessoCliente informacaoacesso)
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

        public int? UpdateInformacaoAcesso(InformacoesAcessoCliente informacaoacesso)
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

        public int? DeleteInformacaoAcesso(InformacoesAcessoCliente informacaoacesso)
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

        public InformacoesAcessoCliente Detalhes(int? ID)
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Internet, AplicativoMonitor, LoginUsuario, Senha, IDConsensionaria, Observacao FROM [InformacoesAcessos] where ID = @ID";
                    InformacoesAcessoCliente informacaoAcesso = db.Query<InformacoesAcessoCliente>(sql, new { ID = ID }).SingleOrDefault();
                    return informacaoAcesso;
                }
            }
            catch (Exception ex)
            {
                InformacoesAcessoCliente informacaoAcesso = new InformacoesAcessoCliente();
                return informacaoAcesso;
            }
        }
    }
}
