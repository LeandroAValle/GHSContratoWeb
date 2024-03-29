﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class Cliente
    {
        public int? ID { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public int? IDTipoCliente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string FaixaSalarial { get; set; }
        public string RG { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataAbertura { get; set; }
        public bool Deletado { get; set; }
        public string Cidadania { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public Byte[] Anexo { get; set; }
        public int? IDCliente { get; set; }
        public int? TipoDocumento { get; set; }
        public string OrgaoExpeditor { get; set; }
        public Byte[] Foto { get; set; }

        public List<EnderecoCliente> Enderecos { get; set; }
        public List<ContatoCliente> Contatos { get; set; }
        public List<InformacoesAcessoCliente> Acessos { get; set; }
        public List<ClienteAnexo> Anexos { get; set; }
    }
}
