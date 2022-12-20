using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class TipoClienteBusiness
    {
        public List<TipoCliente> SelectTipoCliente()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Descricao, DataHora, Ativo FROM [TiposClientes]";
                    List<TipoCliente> lista = db.Query<TipoCliente>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<TipoCliente> lista = new List<TipoCliente>();
                return lista;
            }
        }

        public int? InsertTipoCliente(TipoCliente tipocliente)
        {
            // Insert            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [TiposClientes] (Descricao, DataHora, Ativo) VALUES (@Descricao, @DataHora, @Ativo)";
                    int? re = db.Execute(sql, new { Descricao = tipocliente.Descricao, DataHora = tipocliente.DataHora, Ativo = tipocliente.Ativo });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? UpdateTipoCliente(TipoCliente tipocliente)
        {
            // Update
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [TiposClientes] SET Descricao = @Descricao, DataHora = @DataHora, Ativo = @Ativo WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = tipocliente.ID, Descricao = tipocliente.Descricao, DataHora = tipocliente.DataHora, Ativo = tipocliente.Ativo });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteTipoCliente(TipoCliente tipocliente)
        {
            // Delete            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [TiposClientes] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { tipocliente.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TipoCliente Detalhes(int? ID)
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Descricao, DataHora, Ativo FROM [TiposClientes] where ID = @ID";
                    TipoCliente tipoCliente = db.Query<TipoCliente>(sql, new { ID = ID}).SingleOrDefault();
                    return tipoCliente;
                }
            }
            catch (Exception ex)
            {
                TipoCliente tipoCliente = new TipoCliente();
                return tipoCliente;
            }
        }
    }
}
