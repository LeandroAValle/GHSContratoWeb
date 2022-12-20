using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class CidadeBusiness
    {
        public List<Cidade> SelectCidade()
        {
            // Select            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, nome, IDEstado, Ibge FROM [Cidades]";
                    List<Cidade> lista = db.Query<Cidade>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<Cidade> lista = new List<Cidade>();
                return lista;
            }
        }

        public int? InsertCidade(Cidade cidade)
        {       
            try
            {
                // Insert
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Cidades] (nome, IDEstado, Ibge) VALUES (@nome, @IDEstado, @Ibge)";
                    int? res = db.Execute(sql, new { nome = cidade.nome, IDEstado = cidade.IDEstado, Ibge = cidade.Ibge });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? UpdateCidade(Cidade cidade)
        {
            // Update
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [Cidade] SET nome = @nome, IDEstado = @IDEstado, Ibge = @Ibge WHERE ID = @ID";
                    int? res =db.Execute(sql, new { ID = cidade.ID, nome = cidade.nome, IDEstado = cidade.IDEstado, Ibge = cidade.Ibge });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteCidade(Cidade cidade)
        {         
            try
            {
                // Delete
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [Cidade] WHERE ID = @ID";
                    int? res= db.Execute(sql, new { cidade.ID });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Cidade Detalhes(int? ID)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, nome, IDEstado, Ibge FROM [Cidades] Where ID = @ID";
                    Cidade cidade = db.Query<Cidade>(sql, new {ID = ID }).SingleOrDefault();
                    return cidade;
                }
            }
            catch (Exception ex)
            {
                Cidade cidade = new Cidade();
                return cidade;
            }
        }

        public List<Cidade> ListarIDEstado(int? ID)
        {
            try
            {
                using(var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, nome, IDEstado, Ibge FROM [Cidades] Where IDEstado = @ID";
                    List<Cidade> lista = db.Query<Cidade>(sql, new { ID = ID }).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                List<Cidade> lista = new List<Cidade>();
                return lista;
            }
        }
    }
}
