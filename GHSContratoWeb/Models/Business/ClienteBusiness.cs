using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Grid;

namespace GHSContratoWeb.Models.Business
{
    public class ClienteBusiness
    {
        public List<Cliente> SelectCliente()
        {                      
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT * FROM [Clientes]";
                    List<Cliente> lista = db.Query<Cliente>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<Cliente> lista = new List<Cliente>();
                return lista;                
            }
        }

        public int? InsertCliente(Cliente cliente)
        {
            // Insert            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Clientes] (Nome, Ativo, DataExpedicao, IDTipoCliente) VALUES (@Nome, @Ativo, @DataExpedicao, @IDTipoCliente)";
                    int res = db.Execute(sql, new { Nome = cliente.Nome, Ativo = cliente.Ativo, DataExpedicao = cliente.DataExpedicao, IDTipoCliente = cliente.IDTipoCliente });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? UpdateCliente(Cliente cliente)
        {
            // Update            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [Clientes] SET Nome = @Nome, Ativo = @Ativo, DataExpedicao = @DataExpedicao, IDTipoCliente = @IDTipoCliente WHERE ID = @ID";
                    int? res = db.Execute(sql, new { ID = cliente.ID, Nome = cliente.Nome, Ativo = cliente.Ativo, DataExpedicao = cliente.DataExpedicao, IDTipoCliente = cliente.IDTipoCliente });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteCliente(Cliente cliente)
        {
            // Delete            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [Clientes] WHERE ID = @ID";
                    int? res = db.Execute(sql, new { cliente.ID });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Cliente Detalhes(int? ID)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT * FROM [Clientes] WHERE ID = @ID";
                    Cliente cliente = db.Query<Cliente>(sql,new { ID = ID}).SingleOrDefault();
                    return cliente;
                }
            }
            catch (Exception ex)
            {
                Cliente cliente = new Cliente();
                return cliente;                
            }
        }

        public List<ClienteGrid> ListarGrid()        
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT Clientes.ID as ID, Clientes.Nome as nome, TiposClientes.Descricao as TipoCliente, CASE WHEN DadosClientes.CPF is not null THEN DadosClientes.CPF ELSE DadosClientes.Cnpj END as Documento, CASE WHEN DadosClientes.DataNascimento is not null THEN DadosClientes.DataNascimento ELSE DadosClientes.DataAbertura END as DataCliente, Clientes.DataExpedicao FROM Clientes INNER JOIN DadosClientes ON Clientes.ID = DadosClientes.IDCliente INNER JOIN TiposClientes on Clientes.IDTipoCliente = TiposClientes.ID";
                    List<ClienteGrid> lista = db.Query<ClienteGrid>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<ClienteGrid> lista = new List<ClienteGrid>();
                return lista;
            }
        }
    }
}
