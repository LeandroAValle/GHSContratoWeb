using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class DadosClienteBusiness
    {
        public List<DadosCliente> SelectDadosCliente()
        {
            // Select
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDCliente, CPF, CNPJ, RG, InscricaoEstadual, DataNascimento, DataAbertura FROM [DadosClientes]";
                    List<DadosCliente> lista = db.Query<DadosCliente>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                List<DadosCliente> lista = new List<DadosCliente>();
                return lista;                
            }                      
        }

        public int? InsertDadosCliente(DadosCliente dadoscliente)
        {
            // Insert            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [DadosClientes] (IDCliente, CPF, CNPJ, RG, InscricaoEstadual, DataNascimento, DataAbertura) VALUES (@IDCliente, @CPF, @CNPJ, @RG, @InscricaoEstadual, @DataNascimento, @DataAbertura)";
                    int? resp = db.Execute(sql, new { IDCliente = dadoscliente.IDCliente, CPF = dadoscliente.CPF, CNPJ = dadoscliente.CNPJ, RG = dadoscliente.RG, InscricaoEstadual = dadoscliente.InscricaoEstadual, DataNascimento = dadoscliente.DataNascimento, DataAbertura = dadoscliente.DataAbertura });
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }
        public int? UpdateDadosCliente(DadosCliente dadoscliente)
        {
            // Update    
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [DadosClientes] SET IDCliente = @IDCliente, CPF = @CPF, CNPJ = @CNPJ, RG = @RG, InscricaoEstadual = @InscricaoEstadual, DataNascimento = @DataNascimento, DataAbertura = @DataAbertura WHERE ID = @ID";
                    int? resp = db.Execute(sql, new { ID = dadoscliente.ID, IDCliente = dadoscliente.IDCliente, CPF = dadoscliente.CPF, CNPJ = dadoscliente.CNPJ, RG = dadoscliente.RG, InscricaoEstadual = dadoscliente.InscricaoEstadual, DataNascimento = dadoscliente.DataNascimento, DataAbertura = dadoscliente.DataAbertura });
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? DeleteDadosCliente(DadosCliente dadoscliente)
        {           
            try
            {
                // Delete
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [DadosClientes] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { dadoscliente.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DadosCliente Detalhes(int? id)
        {
            // Select
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDCliente, CPF, CNPJ, RG, InscricaoEstadual, DataNascimento, DataAbertura FROM [DadosClientes] where id = @id";
                    DadosCliente dadosCliente = db.Query<DadosCliente>(sql).SingleOrDefault();
                    return dadosCliente;
                }
            }
            catch (Exception)
            {
                DadosCliente dadosCliente = new DadosCliente();
                return dadosCliente;
            }
        }
    }
}
