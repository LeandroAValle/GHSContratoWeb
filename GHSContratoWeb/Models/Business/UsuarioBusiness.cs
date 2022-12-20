using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GHSContratoWeb.Models.Business
{
    public class UsuarioBusiness
    {
        public List<Usuario> SelectUsuario()
        {
            // Select            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Login, Senha, Nome, Ativo, DataHora FROM [Usuarios]";
                    List<Usuario> lista = db.Query<Usuario>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<Usuario> lista = new List<Usuario>();
                return lista;
            }
        }

        public int? InsertUsuario(Usuario usuario)
        {
            // Insert            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Usuarios] (ID, Login, Nome, Senha, Ativo, DataHora) VALUES (@ID, @Login, @Nome @Senha, @Ativo, @DataHora)";
                    int? re = db.Execute(sql, new {ID = usuario.ID, Login = usuario.Login, Nome = usuario.Nome, Senha = usuario.Senha, Ativo = usuario.Ativo, DataHora = usuario.DataHora });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int? UpdateUsuario(Usuario usuario)
        {
            // Update       
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [Usuarios] SET Login = @Login, Nome = @Nome, Senha = @Senha, Ativo = @Ativo, DataHora = @DataHora WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = usuario.ID, Login = usuario.Login, Nome = usuario.Nome, Senha = usuario.Senha, Ativo = usuario.Ativo, DataHora = usuario.DataHora });
                    return re;
                }
            }
            catch (Exception)
            {
                return null;                
            }
        }

        public int? DeleteUsuario(Usuario usuario)
        {
            // Delete           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [Usuarios] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = usuario.ID });
                    return re;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Usuario Detalhes(string ID)
        {
            // Select            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Login, Nome, Senha, Ativo, DataHora FROM [Usuarios] WHERE ID = @ID";
                    Usuario usuario = db.Query<Usuario>(sql, new {ID = ID }).SingleOrDefault();
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                Usuario usuario = new Usuario();
                return usuario;
            }
        }

        public Usuario Login(string email, string senha)
        {
            // Select            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Login, Nome, Senha, Ativo, DataHora FROM [Usuarios] WHERE Login = @Login";
                    Usuario usuario = db.Query<Usuario>(sql, new { Login = email }).SingleOrDefault();
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                Usuario usuario = new Usuario();
                return usuario;
            }
        }

        public bool Acesso(string email, string senha)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"select count(*) from Usuarios where login = @email and senha = @senha";
                    int resposta = db.Query<int>(sql,new {email = email, senha = senha}).SingleOrDefault();
                    if (resposta > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;                
            }
        }
    }
}
