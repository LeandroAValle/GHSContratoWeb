using Dapper;
using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GHSContratoWeb.Models.Business
{
    public class ContatoClienteBusiness
    {
        public int? InsertContatoCliente(Cliente cliente)
        {
            // Insert           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    int? res = 0;

                    int count = 0;

                    foreach (var item in cliente.Contatos)
                    {
                        string sql = @"INSERT INTO [ContatosClientes] (IDTipoContato, IDCliente, Descricao, Observacao, DataHora, Ativo) VALUES (@IDTipoContato, @IDCliente, @Descricao, @Observacao, @DataHora, @Ativo)";
                        res = db.Execute(sql, new { IDTipoContato = item.IDTipoContato, IDCliente = item.IDCliente, Descricao = item.Descricao, Observacao = item.Observacao, DataHora = item.DataHora, Ativo = item.Ativo });

                        count = +1;
                    }

                    if (count == 0)
                    {
                        return res;
                    }

                    if (res == null)
                    {
                        return null;
                    }

                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}