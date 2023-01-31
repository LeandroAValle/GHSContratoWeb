using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class EmpresaBusiness
    {
        public List<Empresa> SelectEmpresa()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, RazaoSocial, NomeFantasia, CNPJ, DataHora FROM [Empresas]";
                    List<Empresa> lista = db.Query<Empresa>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<Empresa> lista = new List<Empresa>();
                return lista;                
            }
        }

        public int? InsertEmpresa(Empresa empresa)
        {           
            try
            {         
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Empresas] (RazaoSocial, NomeFantasia, CNPJ, DataHora) VALUES (@RazaoSocial, @NomeFantasia, @CNPJ, @DataHora)";
                    int? res = db.Execute(sql, new { RazaoSocial = empresa.RazaoSocial, NomeFantasia = empresa.NomeFantasia, CNPJ = empresa.CNPJ, DataHora = empresa.DataHora });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? UpdateEmpresa(Empresa empresa)
        {            
            try
            {
                // Update
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [Empresas] SET RazaoSocial = @RazaoSocial, NomeFantasia = @NomeFantasia, CNPJ = @CNPJ, DataHora = @DataHora WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = empresa.ID, RazaoSocial = empresa.RazaoSocial, NomeFantasia = empresa.NomeFantasia, CNPJ = empresa.CNPJ, DataHora = empresa.DataHora });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteEmpresa(Empresa empresa)
        {
            // Delete           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [Empresas] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { empresa.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public Empresa Detalhes(string ID)
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, RazaoSocial, NomeFantasia, CNPJ, DataHora FROM [Empresas] where ID = @ID";
                    Empresa empresa = db.Query<Empresa>(sql, new {ID = ID}).SingleOrDefault();
                    return empresa;
                }
            }
            catch (Exception ex)
            {
                Empresa empresa = new Empresa();
                return empresa; 
            }
        }

        public Empresa Buscar()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, RazaoSocial, NomeFantasia, CNPJ, DataHora, Endereco, Numero, Bairro, Telefone, Cidade, UF FROM [Empresas]";
                    Empresa empresa = db.Query<Empresa>(sql).SingleOrDefault();
                    return empresa;
                }
            }
            catch (Exception ex)
            {
                Empresa empresa = new Empresa();
                return empresa;
            }
        }

    }
}
