using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class ConcessionariaBusiness
    {
        public List<Concessionaria> SelectConcessionaria()
        {
            // Select     
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Nome, DataHora, Ativo FROM [Concessionarias]";
                    List<Concessionaria> lista = db.Query<Concessionaria>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<Concessionaria> lista = new List<Concessionaria>();
                return lista;                
            }
        }
        public int? InsertConcessionaria(Concessionaria concessionaria)
        {         
            try
            {
                // Insert
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Concessionarias] (Nome, DataHora, Ativo) VALUES (@Nome, @DataHora, @Ativo)";
                    int? resp =  db.Execute(sql, new { Nome = concessionaria.Nome, DataHora = concessionaria.DataHora, Ativo = concessionaria.Ativo });
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? UpdateConcessionaria(Concessionaria concessionaria)
        {
            // Update           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [Concessionarias] SET Nome = @Nome, DataHora = @DataHora, Ativo = @Ativo WHERE ID = @ID";
                    int? res = db.Execute(sql, new { ID = concessionaria.ID, Nome = concessionaria.Nome, DataHora = concessionaria.DataHora, Ativo = concessionaria.Ativo });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int? DeleteConcessionaria(Concessionaria concessionaria)
        {
            // Delete           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [Concessionarias] WHERE ID = @ID";
                    int? res = db.Execute(sql, new { concessionaria.ID });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Concessionaria Detalhes(int? ID)
        {
            // Select     
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Nome, DataHora, Ativo FROM [Concessionarias] Where ID = @ID";
                    Concessionaria concessionaria = db.Query<Concessionaria>(sql).SingleOrDefault();
                    return concessionaria;
                }
            }
            catch (Exception ex)
            {
                Concessionaria concessionaria = new Concessionaria();
                return concessionaria;
            }
        }

        internal int? BuscarUltimoCodigo()
        {
            try
            {
                using (var con = new Conexao().GetCon())
                {
                    return con.Query<int?>(@"
                    SELECT
                        MAX(ID)
                    FROM
                        Concessionarias").SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
