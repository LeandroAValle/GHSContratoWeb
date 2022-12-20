using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class AcomodacaoModuloBusiness
    {
        public List<AcomodacaoModulo> SelectAcomodacaoModulo()
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Orientacao, Limitacao, LocalInstalacao, IdadeTelhado, TipoTelha, PesoSistema, QualidadeTelhado, EstruturaAjuste, Serralheiro, ObstaculoInterno, ObstaculoExterno, Observacao FROM [AcomodacoesModulos]";
                    List<AcomodacaoModulo> lista = db.Query<AcomodacaoModulo>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<AcomodacaoModulo> lista = new List<AcomodacaoModulo>();
                return lista;
            }
         
        }

        public int? InsertAcomodacaoModulo(AcomodacaoModulo acomodacaomodulo)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [AcomodacoesModulos] (Orientacao, Limitacao, LocalInstalacao, IdadeTelhado, TipoTelha, PesoSistema, QualidadeTelhado, EstruturaAjuste, Serralheiro, ObstaculoInterno, ObstaculoExterno, Observacao) VALUES (@Orientacao, @Limitacao, @LocalInstalacao, @IdadeTelhado, @TipoTelha, @PesoSistema, @QualidadeTelhado, @EstruturaAjuste, @Serralheiro, @ObstaculoInterno, @ObstaculoExterno, @Observacao)";
                    int? resposta = db.Execute(sql, new { Orientacao = acomodacaomodulo.Orientacao, Limitacao = acomodacaomodulo.Limitacao, LocalInstalacao = acomodacaomodulo.LocalInstalacao, IdadeTelhado = acomodacaomodulo.IdadeTelhado, TipoTelha = acomodacaomodulo.TipoTelha, PesoSistema = acomodacaomodulo.PesoSistema, QualidadeTelhado = acomodacaomodulo.QualidadeTelhado, EstruturaAjuste = acomodacaomodulo.EstruturaAjuste, Serralheiro = acomodacaomodulo.Serralheiro, ObstaculoInterno = acomodacaomodulo.ObstaculoInterno, ObstaculoExterno = acomodacaomodulo.ObstaculoExterno, Observacao = acomodacaomodulo.Observacao });
                    return resposta;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public int? UpdateAcomodacaoModulo(AcomodacaoModulo acomodacaomodulo)
        {
            try
            {                
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [AcomodacoesModulos] SET Orientacao = @Orientacao, Limitacao = @Limitacao, LocalInstalacao = @LocalInstalacao, IdadeTelhado = @IdadeTelhado, TipoTelha = @TipoTelha, PesoSistema = @PesoSistema, QualidadeTelhado = @QualidadeTelhado, EstruturaAjuste = @EstruturaAjuste, Serralheiro = @Serralheiro, ObstaculoInterno = @ObstaculoInterno, ObstaculoExterno = @ObstaculoExterno, Observacao = @Observacao WHERE ID = @ID";
                    int resp = db.Execute(sql, new { ID = acomodacaomodulo.ID, Orientacao = acomodacaomodulo.Orientacao, Limitacao = acomodacaomodulo.Limitacao, LocalInstalacao = acomodacaomodulo.LocalInstalacao, IdadeTelhado = acomodacaomodulo.IdadeTelhado, TipoTelha = acomodacaomodulo.TipoTelha, PesoSistema = acomodacaomodulo.PesoSistema, QualidadeTelhado = acomodacaomodulo.QualidadeTelhado, EstruturaAjuste = acomodacaomodulo.EstruturaAjuste, Serralheiro = acomodacaomodulo.Serralheiro, ObstaculoInterno = acomodacaomodulo.ObstaculoInterno, ObstaculoExterno = acomodacaomodulo.ObstaculoExterno, Observacao = acomodacaomodulo.Observacao });
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return null;       
            }
       
        }

        public int? DeleteAcomodacaoModulo(AcomodacaoModulo acomodacaomodulo)
        {
            try
            { // Delete
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [AcomodacoesModulos] WHERE ID = @ID";
                    int? res = db.Execute(sql, new { acomodacaomodulo.ID });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }                     
        }

        public AcomodacaoModulo Detalhes(int? ID)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Orientacao, Limitacao, LocalInstalacao, IdadeTelhado, TipoTelha, PesoSistema, QualidadeTelhado, EstruturaAjuste, Serralheiro, ObstaculoInterno, ObstaculoExterno, Observacao FROM [AcomodacoesModulos] where ID = @ID";
                    AcomodacaoModulo acomodacaoModulo = db.Query<AcomodacaoModulo>(sql, new { ID = ID}).SingleOrDefault();
                    return acomodacaoModulo;
                }
            }
            catch (Exception ex)
            {
                AcomodacaoModulo acomodacaoModulo = new AcomodacaoModulo();
                return acomodacaoModulo;
            }

        }


    }
}
