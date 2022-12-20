using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class PadraoEntradaBusiness
    {
        public List<PadraoEntrada> SelectPadraoEntrada()
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDConsensionaria, IDUnidadeConsumidora, ApresentouFatouraEnergia, DemandaContratada, Categoria, Disjuntor, BitolaCaboEntrada, TipoLigacao, QDCA, ConsumoMedio, AumentoCarga, Observacao, Datahora, IDContrato FROM [PadroesEntradas]";
                    List<PadraoEntrada> lista = db.Query<PadraoEntrada>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<PadraoEntrada> lista = new List<PadraoEntrada>();
                return lista;
            }
        }

        public int? InsertPadraoEntrada(PadraoEntrada padraoentrada)
        {
            // Insert          
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [PadroesEntradas] (IDConsensionaria, IDUnidadeConsumidora, ApresentouFatouraEnergia, DemandaContratada, Categoria, Disjuntor, BitolaCaboEntrada, TipoLigacao, QDCA, ConsumoMedio, AumentoCarga, Observacao, Datahora, IDContrato) VALUES (@IDConsensionaria, @IDUnidadeConsumidora, @ApresentouFatouraEnergia, @DemandaContratada, @Categoria, @Disjuntor, @BitolaCaboEntrada, @TipoLigacao, @QDCA, @ConsumoMedio, @AumentoCarga, @Observacao, @Datahora, @IDContrato)";
                    int? re = db.Execute(sql, new { IDConsensionaria = padraoentrada.IDConsensionaria, IDUnidadeConsumidora = padraoentrada.IDUnidadeConsumidora, ApresentouFatouraEnergia = padraoentrada.ApresentouFatouraEnergia, DemandaContratada = padraoentrada.DemandaContratada, Categoria = padraoentrada.Categoria, Disjuntor = padraoentrada.Disjuntor, BitolaCaboEntrada = padraoentrada.BitolaCaboEntrada, TipoLigacao = padraoentrada.TipoLigacao, QDCA = padraoentrada.QDCA, ConsumoMedio = padraoentrada.ConsumoMedio, AumentoCarga = padraoentrada.AumentoCarga, Observacao = padraoentrada.Observacao, Datahora = padraoentrada.Datahora, IDContrato = padraoentrada.IDContrato });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? UpdatePadraoEntrada(PadraoEntrada padraoentrada)
        {
            // Update            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [PadroesEntradas] SET IDConsensionaria = @IDConsensionaria, IDUnidadeConsumidora = @IDUnidadeConsumidora, ApresentouFatouraEnergia = @ApresentouFatouraEnergia, DemandaContratada = @DemandaContratada, Categoria = @Categoria, Disjuntor = @Disjuntor, BitolaCaboEntrada = @BitolaCaboEntrada, TipoLigacao = @TipoLigacao, QDCA = @QDCA, ConsumoMedio = @ConsumoMedio, AumentoCarga = @AumentoCarga, Observacao = @Observacao, Datahora = @Datahora, IDContrato = @IDContrato WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = padraoentrada.ID, IDConsensionaria = padraoentrada.IDConsensionaria, IDUnidadeConsumidora = padraoentrada.IDUnidadeConsumidora, ApresentouFatouraEnergia = padraoentrada.ApresentouFatouraEnergia, DemandaContratada = padraoentrada.DemandaContratada, Categoria = padraoentrada.Categoria, Disjuntor = padraoentrada.Disjuntor, BitolaCaboEntrada = padraoentrada.BitolaCaboEntrada, TipoLigacao = padraoentrada.TipoLigacao, QDCA = padraoentrada.QDCA, ConsumoMedio = padraoentrada.ConsumoMedio, AumentoCarga = padraoentrada.AumentoCarga, Observacao = padraoentrada.Observacao, Datahora = padraoentrada.Datahora, IDContrato = padraoentrada.IDContrato });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeletePadraoEntrada(PadraoEntrada padraoentrada)
        {
            // Delete           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [PadroesEntradas] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { padraoentrada.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PadraoEntrada Detalhes(int? ID)
        {
            // Select           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, IDConsensionaria, IDUnidadeConsumidora, ApresentouFatouraEnergia, DemandaContratada, Categoria, Disjuntor, BitolaCaboEntrada, TipoLigacao, QDCA, ConsumoMedio, AumentoCarga, Observacao, Datahora, IDContrato FROM [PadroesEntradas] WHERE ID = @ID";
                    PadraoEntrada padraoEntrada = db.Query<PadraoEntrada>(sql, new { ID = ID}).SingleOrDefault();
                    return padraoEntrada;
                }
            }
            catch (Exception ex)
            {
                PadraoEntrada padraoEntrada = new PadraoEntrada();
                return padraoEntrada;
            }
        }
    }
}
