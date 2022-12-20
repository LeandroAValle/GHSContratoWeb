using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class ArquivoContratoBusiness
    {
        public List<ArquivoContrato> SelectArquivoContrato()
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDContrato, Descricao, Observacao, DataHora FROM [ArquivosContratos]";
                    List<ArquivoContrato> lista = db.Query<ArquivoContrato>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<ArquivoContrato> lista = new List<ArquivoContrato>();
                return lista;                
            }          
        }

        public int? InsertArquivoContrato(ArquivoContrato arquivocontrato)
        {
            // Insert
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [ArquivosContratos] (IDContrato, Descricao, Observacao, DataHora) VALUES (@IDContrato, @Descricao, @Observacao, @DataHora)";
                    int? res= db.Execute(sql, new { IDContrato = arquivocontrato.IDContrato, Descricao = arquivocontrato.Descricao, Observacao = arquivocontrato.Observacao, DataHora = arquivocontrato.DataHora });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }           
        }

        public int? UpdateArquivoContrato(ArquivoContrato arquivocontrato)
        {
            // Update
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [ArquivosContratos] SET IDContrato = @IDContrato, Descricao = @Descricao, Observacao = @Observacao, DataHora = @DataHora WHERE ID = @ID";
                    int? res = db.Execute(sql, new { ID = arquivocontrato.ID, IDContrato = arquivocontrato.IDContrato, Descricao = arquivocontrato.Descricao, Observacao = arquivocontrato.Observacao, DataHora = arquivocontrato.DataHora });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }           
        }

        public int? DeleteArquivoContrato(ArquivoContrato arquivocontrato)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [ArquivosContratos] WHERE ID = @ID";
                    int? res = db.Execute(sql, new { arquivocontrato.ID });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }      
        }


        public ArquivoContrato Detalhes(int? ID)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDContrato, Descricao, Observacao, DataHora FROM [ArquivosContratos] where ID = @ID";
                    ArquivoContrato arquivoContrato = db.Query<ArquivoContrato>(sql, new { ID = ID }).SingleOrDefault();
                    return arquivoContrato;
                }
            }
            catch (Exception ex)
            {
                ArquivoContrato arquivoContrato = new ArquivoContrato();
                return arquivoContrato;
            }

        }

    }
}
