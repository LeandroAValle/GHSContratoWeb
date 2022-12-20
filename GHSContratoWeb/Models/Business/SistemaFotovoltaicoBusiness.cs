using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class SistemaFotovoltaicoBusiness
    {
        public List<SistemaFotovoltaico> SelectSistemaFotovoltaico()
        {                 
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, MediaGeracaoMes, Capacidade, QuantidadeModulos, MediaGeracaoAnos, CapacidadeInversor, PotenciaTecnologia, QuantidadeInversor, AreaAcomodacao, ProtecaoCorrenteContinua, ProtecaoCorrenteAlternada, AreaTelhado, Observarcao, IDContrato FROM [SistemasFotovoltaicos]";
                    List<SistemaFotovoltaico> lista = db.Query<SistemaFotovoltaico>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<SistemaFotovoltaico> lista = new List<SistemaFotovoltaico>();
                return lista;                
            }
        }

        public int? InsertSistemaFotovoltaico(SistemaFotovoltaico sistemafotovoltaico)
        {
            // Insert           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [SistemasFotovoltaicos] (MediaGeracaoMes, Capacidade, QuantidadeModulos, MediaGeracaoAnos, CapacidadeInversor, PotenciaTecnologia, QuantidadeInversor, AreaAcomodacao, ProtecaoCorrenteContinua, ProtecaoCorrenteAlternada, AreaTelhado, Observarcao, IDContrato) VALUES (@MediaGeracaoMes, @Capacidade, @QuantidadeModulos, @MediaGeracaoAnos, @CapacidadeInversor, @PotenciaTecnologia, @QuantidadeInversor, @AreaAcomodacao, @ProtecaoCorrenteContinua, @ProtecaoCorrenteAlternada, @AreaTelhado, @Observarcao, @IDContrato)";
                    int? re = db.Execute(sql, new { MediaGeracaoMes = sistemafotovoltaico.MediaGeracaoMes, Capacidade = sistemafotovoltaico.Capacidade, QuantidadeModulos = sistemafotovoltaico.QuantidadeModulos, MediaGeracaoAnos = sistemafotovoltaico.MediaGeracaoAnos, CapacidadeInversor = sistemafotovoltaico.CapacidadeInversor, PotenciaTecnologia = sistemafotovoltaico.PotenciaTecnologia, QuantidadeInversor = sistemafotovoltaico.QuantidadeInversor, AreaAcomodacao = sistemafotovoltaico.AreaAcomodacao, ProtecaoCorrenteContinua = sistemafotovoltaico.ProtecaoCorrenteContinua, ProtecaoCorrenteAlternada = sistemafotovoltaico.ProtecaoCorrenteAlternada, AreaTelhado = sistemafotovoltaico.AreaTelhado, Observarcao = sistemafotovoltaico.Observarcao, IDContrato = sistemafotovoltaico.IDContrato });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public int? UpdateSistemaFotovoltaico(SistemaFotovoltaico sistemafotovoltaico)
        {
            // Update            
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [SistemasFotovoltaicos] SET MediaGeracaoMes = @MediaGeracaoMes, Capacidade = @Capacidade, QuantidadeModulos = @QuantidadeModulos, MediaGeracaoAnos = @MediaGeracaoAnos, CapacidadeInversor = @CapacidadeInversor, PotenciaTecnologia = @PotenciaTecnologia, QuantidadeInversor = @QuantidadeInversor, AreaAcomodacao = @AreaAcomodacao, ProtecaoCorrenteContinua = @ProtecaoCorrenteContinua, ProtecaoCorrenteAlternada = @ProtecaoCorrenteAlternada, AreaTelhado = @AreaTelhado, Observarcao = @Observarcao, IDContrato = @IDContrato WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = sistemafotovoltaico.ID, MediaGeracaoMes = sistemafotovoltaico.MediaGeracaoMes, Capacidade = sistemafotovoltaico.Capacidade, QuantidadeModulos = sistemafotovoltaico.QuantidadeModulos, MediaGeracaoAnos = sistemafotovoltaico.MediaGeracaoAnos, CapacidadeInversor = sistemafotovoltaico.CapacidadeInversor, PotenciaTecnologia = sistemafotovoltaico.PotenciaTecnologia, QuantidadeInversor = sistemafotovoltaico.QuantidadeInversor, AreaAcomodacao = sistemafotovoltaico.AreaAcomodacao, ProtecaoCorrenteContinua = sistemafotovoltaico.ProtecaoCorrenteContinua, ProtecaoCorrenteAlternada = sistemafotovoltaico.ProtecaoCorrenteAlternada, AreaTelhado = sistemafotovoltaico.AreaTelhado, Observarcao = sistemafotovoltaico.Observarcao, IDContrato = sistemafotovoltaico.IDContrato });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteSistemaFotovoltaico(SistemaFotovoltaico sistemafotovoltaico)
        {
            // Delete           
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [SistemasFotovoltaicos] WHERE ID = @ID";
                    int? re = db.Execute(sql, new { ID = sistemafotovoltaico.ID });
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public SistemaFotovoltaico Detalhes(int? ID)
        {
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, MediaGeracaoMes, Capacidade, QuantidadeModulos, MediaGeracaoAnos, CapacidadeInversor, PotenciaTecnologia, QuantidadeInversor, AreaAcomodacao, ProtecaoCorrenteContinua, ProtecaoCorrenteAlternada, AreaTelhado, Observarcao, IDContrato FROM [SistemasFotovoltaicos] WHERE ID = @ID";
                    SistemaFotovoltaico sistemaFotovoltaico = db.Query<SistemaFotovoltaico>(sql, new {ID = ID }).SingleOrDefault();
                    return sistemaFotovoltaico;
                }
            }
            catch (Exception ex)
            {
                SistemaFotovoltaico sistemaFotovoltaico = new SistemaFotovoltaico();
                return sistemaFotovoltaico;
            }
        }
    }
}
