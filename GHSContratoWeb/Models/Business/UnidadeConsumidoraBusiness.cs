using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GHSContratoWeb.Models.Business
{
    public class UnidadeConsumidoraBusiness
    {
        public List<UnidadeConsumidora> SelectUnidadeConsumidora()
        {
            // Select            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDEnderecoCliente, IDConsensionaria, Observacao, DataHoraRegistro, Ativo, CodigoUnidadeConsumidora FROM [UnidadesConsumidoras]";
                    List<UnidadeConsumidora> lista = db.Query<UnidadeConsumidora>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<UnidadeConsumidora> lista = new List<UnidadeConsumidora>();
                return lista;                
            }
        }

        public int? InsertUnidadeConsumidora(UnidadeConsumidora unidadeconsumidora)
        {
            // Insert           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [UnidadesConsumidoras] (IDEnderecoCliente, IDConsensionaria, Observacao, DataHoraRegistro, Ativo, CodigoUnidadeConsumidora) VALUES (@IDEnderecoCliente, @IDConsensionaria, @Observacao, @DataHoraRegistro, @Ativo, @CodigoUnidadeConsumidora)";
                    int? re = db.Execute(sql, new { IDEnderecoCliente = unidadeconsumidora.IDEnderecoCliente, IDConsensionaria = unidadeconsumidora.IDConsensionaria, Observacao = unidadeconsumidora.Observacao, DataHoraRegistro = unidadeconsumidora.DataHoraRegistro, Ativo = unidadeconsumidora.Ativo, CodigoUnidadeConsumidora = unidadeconsumidora.CodigoUnidadeConsumidora });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? UpdateUnidadeConsumidora(UnidadeConsumidora unidadeconsumidora)
        {
            // Update         
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [UnidadesConsumidoras] SET IDEnderecoCliente = @IDEnderecoCliente, IDConsensionaria = @IDConsensionaria, Observacao = @Observacao, DataHoraRegistro = @DataHoraRegistro, Ativo = @Ativo, CodigoUnidadeConsumidora = @CodigoUnidadeConsumidora WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = unidadeconsumidora.ID, IDEnderecoCliente = unidadeconsumidora.IDEnderecoCliente, IDConsensionaria = unidadeconsumidora.IDConsensionaria, Observacao = unidadeconsumidora.Observacao, DataHoraRegistro = unidadeconsumidora.DataHoraRegistro, Ativo = unidadeconsumidora.Ativo, CodigoUnidadeConsumidora = unidadeconsumidora.CodigoUnidadeConsumidora });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? DeleteUnidadeConsumidora(UnidadeConsumidora unidadeconsumidora)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [UnidadesConsumidoras] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = unidadeconsumidora.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }         
        }

        public UnidadeConsumidora Detalhes(int? ID)
        {
            // Select            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDEnderecoCliente, IDConsensionaria, Observacao, DataHoraRegistro, Ativo, CodigoUnidadeConsumidora FROM [UnidadesConsumidoras] where ID = @ID";
                    UnidadeConsumidora unidadeConsumidora = db.Query<UnidadeConsumidora>(sql).SingleOrDefault();
                    return unidadeConsumidora;
                }
            }
            catch (Exception ex)
            {
                UnidadeConsumidora unidadeConsumidora = new UnidadeConsumidora();
                return unidadeConsumidora;
            }
        }
    }
}
