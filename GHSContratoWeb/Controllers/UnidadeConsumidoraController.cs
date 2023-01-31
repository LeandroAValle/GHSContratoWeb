using System;
using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Grid;
using GHSContratoWeb.Models.Mapping;
using GHSContratoWebBusiness.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using GHSContratoWeb.Models.Helper;

namespace GHSContratoWeb.Controllers
{
    public class UnidadeConsumidoraController : Controller
    {
        public ActionResult Index()
        {
            Usuario usuario = new Utils().Usuario;

            if (usuario == null)
            {
                RedirectToAction("Index", "Login");
            }

            List<EnderecoCliente> listaGrid = new EnderecoClienteBusiness().SelectEnderecoCliente();

            if (TempData["Resultado"] != null)
            {
                dynamic obj = TempData["Resultado"];

                if (((bool)obj.Resultado) == true)
                {
                    ViewBag.Notificacao = "<script>Notiflix.Notify.Success('" + (String)obj.Mensagem + "');</script>";
                }
                else
                {
                    ViewBag.Notificacao = "<script>Notiflix.Notify.Failure('" + (String)obj.Mensagem + "');</script>";
                }
            }

            return View(listaGrid);
        }
              

        [HttpGet]
        public ActionResult Cadastro(int id)
        {
            EnderecoCliente endereco = new EnderecoClienteBusiness().Detalhes(id);
            ViewBag.DropDownTipoCliente = DropDownList.DropDownTipoCliente();
            ViewBag.DropDownCidade = DropDownList.DropDownCidade();
            ViewBag.DropDownEstado = DropDownList.DropDownEstado();
            return View(endereco);
        }

        [HttpPost]
        public ActionResult Cadastro(FormCollection form)
        {
            //Concessionaria
            //FaturaEnergia
            //codigoUc
            //demandaContratada
            //categoriaFases
            //disjuntor
            //bitolaEntrada
            //tipoLigacao
            //qdca
            //distanciaBitola
            //padraoEntrada
            //projetoMelhoria
            //consumo
            //aumentoCarga
            //obsPertinentes
            //mediaGeracaoEstimada
            //GeracaoEstimada
            //CapacidadeKWP
            //CapacidadeInversores
            //QtdModulos
            //PotenciaTecnologica
            //QtdInversores
            //Potencia
            //AreaAcomodacao
            //AreaTelhado
            //Protecao
            //ProtecaoCA
            //Capacidade
            //ValorFinalMF
            //ValorFinalPSS
            //ValorFinalTotal
            //Pagamento
            //Orientacao
            //Inclinacao
            //LocalInstalacao
            //IdadeTelhado
            //TipoTelhado
            //PesoSistema
            //QualidadeTelhado
            //Selado
            //CorroidoDanificado
            //EstruturaAjuste
            //Serralheiro
            //ObstaculosInternos
            //ObstaculosExternos

            //EnderecoCliente unidadeConsumidora = new EnderecoCliente()
            //{
            //    ID = form["ID"].ToInt32(),
            //    Nome = form["Nome"].IsNullOrEmptyBoolean() ? null : form["Nome"].Trim(),
            //    Ativo = form["clienteAtivo"].ToBoolean(),
            //    DataExpedicao = form["DataExpedicao"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataExpedicao"].ToDate(),
            //    IDTipoCliente = form["TipoCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoCliente"].ToInt32(),
            //    Telefone = form["Telefone"].IsNullOrEmptyBoolean() ? null : form["Telefone"].Trim(),
            //    OrgaoExpeditor = form["OE"].IsNullOrEmptyBoolean() ? null : form["OE"].Trim(),
            //    TipoDocumento = form["TipoDocumento"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoDocumento"].ToInt32(),
            //    Email = form["Email"].IsNullOrEmptyBoolean() ? null : form["Email"].Trim(),
            //    Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
            //    CPF = form["CPF"].IsNullOrEmptyBoolean() ? null : form["CPF"].Trim(),
            //    CNPJ = form["CNPJ"].IsNullOrEmptyBoolean() ? null : form["CNPJ"].Trim(),
            //    RG = form["RG"].IsNullOrEmptyBoolean() ? null : form["RG"].Trim(),
            //    InscricaoEstadual = form["InscricaoEstadual"].IsNullOrEmptyBoolean() ? null : form["InscricaoEstadual"].Trim(),
            //    DataNascimento = form["DataNascimento"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataNascimento"].ToDate(),
            //    DataAbertura = form["DataAbertura"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataAbertura"].ToDate(),
            //    Cidadania = form["Cidadania"].IsNullOrEmptyBoolean() ? null : form["Cidadania"].Trim(),
            //    EstadoCivil = form["EstadoCivil"].IsNullOrEmptyBoolean() ? null : form["EstadoCivil"].Trim(),
            //    FaixaSalarial = form["faixaSalarial"].IsNullOrEmptyBoolean() ? null : form["faixaSalarial"].Trim(),
            //    Profissao = form["Profissao"].IsNullOrEmptyBoolean() ? null : form["Profissao"].Trim()
            //};

            //int enderecoTotal = form["enderecoTotal"].ToInt32();
            //unidadeConsumidora.Enderecos = new List<EnderecoCliente>();
            //for (int i = 1; i <= enderecoTotal; i++)
            //{
            //    cliente.Enderecos.Add(new EnderecoCliente
            //    {
            //        IDCliente = form["ID"].IsNullOrEmptyBoolean() ? (Int32?)null : form["ID"].ToInt32(),
            //        IDCidade = form["Cidade"].IsNullOrEmptyBoolean() ? (Int32?)null : form["Cidade"].ToInt32(),
            //        IDEstado = form["Estado"].IsNullOrEmptyBoolean() ? (Int32?)null : form["Estado"].ToInt32(),
            //        Rua = form["Rua"].IsNullOrEmptyBoolean() ? null : form["Rua"].Trim(),
            //        Numero = form["Numero"].IsNullOrEmptyBoolean() ? null : form["Numero"].Trim(),
            //        Bairro = form["Bairro"].IsNullOrEmptyBoolean() ? null : form["Bairro"].Trim(),
            //        Complemento = form["Complemento"].IsNullOrEmptyBoolean() ? null : form["Complemento"].Trim(),
            //        CEP = form["CEP"].IsNullOrEmptyBoolean() ? null : form["CEP"].Trim(),
            //        LatitudeDecimal = form["LatitudeDecimal"].IsNullOrEmptyBoolean() ? (Decimal?)null : form["LatitudeDecimal"].ToDecimal(),
            //        LongitudeDecimal = form["LongitudeDecimal"].IsNullOrEmptyBoolean() ? (Decimal?)null : form["LongitudeDecimal"].ToDecimal(),
            //        Padrao = form["Padrao"].ToBoolean(),
            //        Ativo = form["Ativo"].ToBoolean(),
            //        Observacao = form["EnderecoObs"].IsNullOrEmptyBoolean() ? null : form["EnderecoObs"].Trim(),
            //        LatitudeHoras = form["LatitudeHoras"].IsNullOrEmptyBoolean() ? null : form["LatitudeHoras"].Trim(),
            //        LongitudeHoras = form["LongitudeHoras"].IsNullOrEmptyBoolean() ? null : form["LongitudeHoras"].Trim(),
            //        LocalInstalacao = form["enderecoInstalacao"].ToBoolean()
            //    });
            //}

            //int? resultado = new ClienteBusiness().InsertCliente(cliente);

            //dynamic obj = new System.Dynamic.ExpandoObject();
            //if (resultado == 1)
            //{
            //    obj.Resultado = true;
            //    obj.Mensagem = "Registro salvo com sucesso!";
            //}
            //else
            //{
            //    obj.Resultado = false;
            //    obj.Mensagem = "Falha ao realizar cadastro!";
            //}
            //TempData["Resultado"] = obj;

            return RedirectToAction("ClienteEndereco");
        }

        [HttpPost]
        public JsonResult ListarCidades(int uf)
        {
            List<SelectListItem> lista = DropDownList.DropDownCidade(null, uf);

            return Json(new { lista }, JsonRequestBehavior.AllowGet);

        }
    }
}

