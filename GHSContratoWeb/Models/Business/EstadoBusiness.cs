using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GHSContratoWeb.Models.Business
{
    public class EstadoBusiness
    {
        public List<Estado> SelectEstado()
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT id, nome, uf, ibge FROM [Estados]";
                    List<Estado> list = db.Query<Estado>(sql).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                List<Estado> estados = new List<Estado>();
                return estados;                    
            }
            
        }

        public int? InsertEstado(Estado estado)
        {
            // Insert
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Estados] (nome, uf, ibge) VALUES (@nome, @uf, @ibge)";
                    int resposta = db.Execute(sql, new { nome = estado.nome, uf = estado.uf, ibge = estado.ibge });
                    return resposta;
                }
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        public int? UpdateEstado(Estado estado)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [Estados] SET nome = @nome, uf = @uf, ibge = @ibge WHERE id = @id";
                    int resposta = db.Execute(sql, new { id = estado.id, nome = estado.nome, uf = estado.uf, ibge = estado.ibge });
                    return resposta;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public int? DeleteEstado(Estado estado)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                   string sql = @"DELETE FROM [Estados] WHERE id = @id";
                   int resposta = db.Execute(sql, new { estado.id });
                   return resposta;
                }
            }
            catch (Exception ex)
            {
                return null;
            }           
        }

        public Estado Detalhes(int? ID)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT id, nome, uf, ibge FROM [Estados] where id = @ID";
                    Estado estado = db.Query<Estado>(sql, new { ID = ID}).SingleOrDefault();
                    return estado;
                }
            }
            catch (Exception ex)
            {
                Estado estados = new Estado();
                return estados;
            }
        }
      
    }
}
