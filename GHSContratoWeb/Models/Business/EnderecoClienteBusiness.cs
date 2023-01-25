using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class EnderecoClienteBusiness
    {
        public List<EnderecoCliente> SelectEnderecoCliente()
        {
            // Select  
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDCliente, IDCidade, IDEstado, Rua, Numero, Bairro, Complemento, CEP, LatitudeDecimal, LongitudeDecimal, Padrao, Ativo, Observacao, LatitudeHoras, LongitudeHoras, LocalInstalacao FROM [EnderecosClientes]";
                    List<EnderecoCliente> lista = db.Query<EnderecoCliente>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<EnderecoCliente> lista = new List<EnderecoCliente>();
                return lista;               
            }
        }

        public int? InsertEnderecoCliente(EnderecoCliente enderecocliente)
        {
            // Insert           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [EnderecosClientes] (IDCliente, IDCidade, IDEstado, Rua, Numero, Bairro, Complemento, CEP, LatitudeDecimal, LongitudeDecimal, Padrao, Ativo, Observacao, LatitudeHoras, LongitudeHoras, LocalInstalacao) VALUES (@IDCliente, @IDCidade, @IDEstado, @Rua, @Numero, @Bairro, @Complemento, @CEP, @LatitudeDecimal, @LongitudeDecimal, @Padrao, @Ativo, @Observacao, @LatitudeHoras, @LongitudeHoras, @LocalInstalacao)";
                    int? res = db.Execute(sql, new { IDCliente = enderecocliente.IDCliente, IDCidade = enderecocliente.IDCidade, IDEstado = enderecocliente.IDEstado, Rua = enderecocliente.Rua, Numero = enderecocliente.Numero, Bairro = enderecocliente.Bairro, Complemento = enderecocliente.Complemento, CEP = enderecocliente.CEP, LatitudeDecimal = enderecocliente.LatitudeDecimal, LongitudeDecimal = enderecocliente.LongitudeDecimal, Padrao = enderecocliente.Padrao, Ativo = enderecocliente.Ativo, Observacao = enderecocliente.Observacao, LatitudeHoras = enderecocliente.LatitudeHoras, LongitudeHoras = enderecocliente.LongitudeHoras, LocalInstalacao = enderecocliente.LocalInstalacao });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? UpdateEnderecoCliente(EnderecoCliente enderecocliente)
        {
            // Update           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [EnderecosClientes] SET IDCliente = @IDCliente, IDCidade = @IDCidade, Rua = @Rua, Numero = @Numero, Bairro = @Bairro, Complemento = @Complemento, CEP = @CEP, LatitudeDecimal = @LatitudeDecimal, LongitudeDecimal = @LongitudeDecimal, Padrao = @Padrao, Ativo = @Ativo, Observacao = @Observacao, LatitudeHoras = @LatitudeHoras, LongitudeHoras = @LongitudeHoras, LocalInstalacao = @LocalInstalacao WHERE ID = @ID";
                    int? res = db.Execute(sql, new { ID = enderecocliente.ID, IDCliente = enderecocliente.IDCliente, IDCidade = enderecocliente.IDCidade, Rua = enderecocliente.Rua, Numero = enderecocliente.Numero, Bairro = enderecocliente.Bairro, Complemento = enderecocliente.Complemento, CEP = enderecocliente.CEP, LatitudeDecimal = enderecocliente.LatitudeDecimal, LongitudeDecimal = enderecocliente.LongitudeDecimal, Padrao = enderecocliente.Padrao, Ativo = enderecocliente.Ativo, Observacao = enderecocliente.Observacao, LatitudeHoras = enderecocliente.LatitudeHoras, LongitudeHoras = enderecocliente.LongitudeHoras, LocalInstalacao = enderecocliente.LocalInstalacao });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteEnderecoCliente(EnderecoCliente enderecocliente)
        {
            // Delete
            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                   string sql = @"DELETE FROM [EnderecosClientes] WHERE ID = @ID";
                   int? re = db.Execute(sql, new { enderecocliente.ID });
                   return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public EnderecoCliente Detalhes(int? ID)
        {
            // Select  
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDCliente, IDCidade, Rua, Numero, Bairro, Complemento, CEP, LatitudeDecimal, LongitudeDecimal, Padrao, Ativo, Observacao, LatitudeHoras, LongitudeHoras, LocalInstalacao FROM [EnderecosClientes] where ID = @ID";
                    EnderecoCliente enderecoCliente = db.Query<EnderecoCliente>(sql, new { ID = ID }).SingleOrDefault();
                    return enderecoCliente;
                }
            }
            catch (Exception ex)
            {
                EnderecoCliente enderecoCliente = new EnderecoCliente();
                return enderecoCliente;
            }
        }
    }
}
