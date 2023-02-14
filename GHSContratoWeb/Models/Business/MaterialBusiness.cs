using Dapper;
using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GHSContratoWeb.Models.Business
{
    public class MaterialBusiness
    {

        public List<Disjuntor> Listar()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Descricao FROM [Disjuntores]";
                    List<Disjuntor> lista = db.Query<Disjuntor>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<Disjuntor> lista = new List<Disjuntor>();
                return lista;
            }
        }


        public int? InsertDisjuntor(Disjuntor disjuntor)
        {
            // Insert            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Disjuntores] (ID, Descricao) VALUES (@ID, @Descricao)";
                    int? re = db.Execute(sql, new { ID = disjuntor.ID, Descricao = disjuntor.Descricao});
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteDisjunor(Disjuntor disjuntor)
        {
            // Delete            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [Disjuntores] WHERE ID = @ID";
                    int? res = db.Execute(sql, new { disjuntor.ID });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Disjuntor Detalhes(int? ID)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT * FROM [Disjuntores] WHERE ID = @ID";
                    Disjuntor disjuntor = db.Query<Disjuntor>(sql, new { ID = ID }).SingleOrDefault();
                    return disjuntor;
                }
            }
            catch (Exception ex)
            {
                Disjuntor disjuntor = new Disjuntor();
                return disjuntor;
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
                        Disjuntores").SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}