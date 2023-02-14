using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class UnidadeConsumidora
    {
		public int ID { get; set; }
		public int? IDEnderecoCliente { get; set; }
		public int? IDConsensionaria { get; set; }
		public string Observacao { get; set; }
		public DateTime? DataHoraRegistro { get; set; }
		public bool? Ativo { get; set; }
		public string CodigoUnidadeConsumidora { get; set; }
        public string Concessionaria { get; set; }
        public string FaturaEnergia { get; set; }
        public string codigoUc { get; set; }
        public string demandaContratada { get; set; }
        public string categoriaFases { get; set; }
        public string disjuntor { get; set; }
        public string bitolaEntrada { get; set; }
        public string tipoLigacao { get; set; }
        public string qdca { get; set; }
        public string distanciaBitola { get; set; }
        public string padraoEntrada { get; set; }
        public string projetoMelhoria { get; set; }
        public string consumo { get; set; }
        public string aumentoCarga { get; set; }
        public string obsPertinentes { get; set; }
        public string mediaGeracaoEstimada { get; set; }
        public string GeracaoEstimada { get; set; }
        public string CapacidadeKWP { get; set; }
        public string CapacidadeInversores { get; set; }
        public string QtdModulos { get; set; }
        public string PotenciaTecnologica { get; set; }
        public string QtdInversores { get; set; }
        public string Potencia { get; set; }
        public string AreaAcomodacao { get; set; }
        public string AreaTelhado { get; set; }
        public string Protecao { get; set; }
        public string ProtecaoCA { get; set; }
        public string Capacidade { get; set; }
        public string ValorFinalMF { get; set; }
        public string ValorFinalPSS { get; set; }
        public string ValorFinalTotal { get; set; }
        public string Pagamento { get; set; }
        public string Orientacao { get; set; }
        public string Inclinacao { get; set; }
        public string LocalInstalacao { get; set; }
        public string IdadeTelhado { get; set; }
        public string TipoTelhado { get; set; }
        public string PesoSistema { get; set; }
        public string QualidadeTelhado { get; set; }
        public string Selado { get; set; }
        public string CorroidoDanificado { get; set; }
        public string EstruturaAjuste { get; set; }
        public string Serralheiro { get; set; }
        public string ObstaculosInternos { get; set; }
        public string ObstaculosExternos { get; set; }

        public List<UnidadeBeneficiaria> UnidadeBeneficiarias { get; set; }
    }


}
