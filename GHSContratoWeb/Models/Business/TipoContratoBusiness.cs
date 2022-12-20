using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class TipoContratoBusiness
    {
        public List<TipoContrato> SelectTipoContrato()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Descricao, DataHora, Ativo FROM [TiposContratos]";
                    List<TipoContrato> lista = db.Query<TipoContrato>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<TipoContrato> lista = new List<TipoContrato>();
                return lista;
            }
        }

        public int? InsertTipoContrato(TipoContrato tipocontrato)
        {
            // Insert           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [TipoContrato] (Descricao, DataHora, Ativo) VALUES (@Descricao, @DataHora, @Ativo)";
                    int? re = db.Execute(sql, new { Descricao = tipocontrato.Descricao, DataHora = tipocontrato.DataHora, Ativo = tipocontrato.Ativo });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null  ;
            }
        }

        public int? UpdateTipoContrato(TipoContrato tipocontrato)
        {
            // Update           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [TipoContrato] SET Descricao = @Descricao, DataHora = @DataHora, Ativo = @Ativo WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = tipocontrato.ID, Descricao = tipocontrato.Descricao, DataHora = tipocontrato.DataHora, Ativo = tipocontrato.Ativo });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteTipoContrato(TipoContrato tipocontrato)
        {
            // Delete           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [TipoContrato] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = tipocontrato.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public TipoContrato Detalhes(int? ID)
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Descricao, DataHora, Ativo FROM [TiposContratos] where ID = @ID";
                    TipoContrato tipoContrato = db.Query<TipoContrato>(sql, new {ID = ID }).SingleOrDefault();
                    return tipoContrato;
                }
            }
            catch (Exception ex)
            {
                TipoContrato tipoContrato = new TipoContrato();
                return tipoContrato;
            }
        }
    }
}
