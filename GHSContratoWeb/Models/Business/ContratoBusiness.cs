using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class ContratoBusiness
    {
        public List<Contrato> SelectContrato()
        {            
            try
            {
                // Select
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDCliente, Descricao, Observacao, Valor, DataHoraContrato, Ativo, ConteudoContrato FROM [Contratos]";
                    List<Contrato> lista = db.Query<Contrato>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<Contrato> lista = new List<Contrato>();
                return lista;                
            }
        }

        public int? InsertContrato(Contrato contrato)
        {
            // Insert            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Contratos] (IDCliente, Descricao, Observacao, Valor, DataHoraContrato, Ativo, ConteudoContrato) VALUES (@IDCliente, @Descricao, @Observacao, @Valor, @DataHoraContrato, @Ativo, @ConteudoContrato)";
                    int? res = db.Execute(sql, new { IDCliente = contrato.IDCliente, Descricao = contrato.Descricao, Observacao = contrato.Observacao, Valor = contrato.Valor, DataHoraContrato = contrato.DataHoraContrato, Ativo = contrato.Ativo, ConteudoContrato = contrato.ConteudoContrato });
                    return res;
                }
            }
            catch (Exception)
            {
                return null;                
            }
        }
        public int? UpdateContrato(Contrato contrato)
        {
            // Update     
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [Contratos] SET IDCliente = @IDCliente, Descricao = @Descricao, Observacao = @Observacao, Valor = @Valor, DataHoraContrato = @DataHoraContrato, Ativo = @Ativo, ConteudoContrato = @ConteudoContrato WHERE ID = @ID";
                    int? res = db.Execute(sql, new { ID = contrato.ID, IDCliente = contrato.IDCliente, Descricao = contrato.Descricao, Observacao = contrato.Observacao, Valor = contrato.Valor, DataHoraContrato = contrato.DataHoraContrato, Ativo = contrato.Ativo, ConteudoContrato = contrato.ConteudoContrato });
                    return res;
                }
            }
            catch (Exception)
            {
                return null;                
            }
        }

        public int? DeleteContrato(Contrato contrato)
        {           
            try
            {
                // Delete
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [Contratos] WHERE ID = @ID";
                    int? res = db.Execute(sql, new { contrato.ID });
                    return res;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Contrato Detalhes(int? ID)
        {
            try
            {
                // Select
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDCliente, Descricao, Observacao, Valor, DataHoraContrato, Ativo, ConteudoContrato FROM [Contratos] where ID = @ID";
                    Contrato contrato = db.Query<Contrato>(sql, new { ID = ID}).SingleOrDefault();
                    return contrato;
                }
            }
            catch (Exception ex)
            {
                Contrato contrato = new Contrato();
                return contrato;
            }
        }
    }
}
