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
            ViewBag.DropDownDisjuntor = DropDownList.DropDownDisjuntor();
            return View(endereco);
        }

        [HttpPost]
        public ActionResult Cadastro(FormCollection form)
        {
            UnidadeConsumidora unidadeConsumidora = new UnidadeConsumidora()
            {
                ID = form["ID"].ToInt32(),
                IDEnderecoCliente = form["TipoCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoCliente"].ToInt32(),
                IDConsensionaria = form["TipoCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoCliente"].ToInt32(),
                Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                DataHoraRegistro = form["DataExpedicao"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataExpedicao"].ToDate(),
                Ativo = form["Ativo"].ToBoolean(),
                CodigoUnidadeConsumidora = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Concessionaria = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                FaturaEnergia = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                codigoUc = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                demandaContratada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                categoriaFases = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                disjuntor = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                bitolaEntrada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                tipoLigacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                qdca = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                distanciaBitola = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                padraoEntrada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                projetoMelhoria = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                consumo = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                aumentoCarga = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                obsPertinentes = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                mediaGeracaoEstimada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                GeracaoEstimada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CapacidadeKWP = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CapacidadeInversores = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                QtdModulos = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                PotenciaTecnologica = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                QtdInversores = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Potencia = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                AreaAcomodacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                AreaTelhado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Protecao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ProtecaoCA = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Capacidade = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ValorFinalMF = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ValorFinalPSS = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ValorFinalTotal = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Pagamento = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Orientacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Inclinacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                LocalInstalacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                IdadeTelhado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                TipoTelhado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                PesoSistema = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                QualidadeTelhado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Selado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CorroidoDanificado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                EstruturaAjuste = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Serralheiro = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ObstaculosInternos = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ObstaculosExternos = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim()
            };

            int unidadeBeneficiariaTotal = form["unidadeBeneficiariaTotal"].ToInt32();
            unidadeConsumidora.UnidadeBeneficiarias = new List<UnidadeBeneficiaria>();
            for (int i = 1; i <= unidadeBeneficiariaTotal; i++)
            {
                unidadeConsumidora.UnidadeBeneficiarias.Add(new UnidadeBeneficiaria
                {
                    ID = form["ID"].ToInt32(),
                    IDEndereco = form["ID"].ToInt32(),
                    IDCliente = form["ID"].ToInt32(),
                    IDCidade = form["ID"].ToInt32(),
                    IDEstado = form["ID"].ToInt32(),
                    Rua = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    Numero = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    Bairro = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    Complemento = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    CEP = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim()
                });
            }


            int? resultado = new UnidadeConsumidoraBusiness().InsertUnidadeConsumidora(unidadeConsumidora);

            dynamic obj = new System.Dynamic.ExpandoObject();
            if (resultado == 1)
            {
                obj.Resultado = true;
                obj.Mensagem = "Registro salvo com sucesso!";
            }
            else
            {
                obj.Resultado = false;
                obj.Mensagem = "Falha ao realizar cadastro!";
            }
            TempData["Resultado"] = obj;

            return RedirectToAction("UnidadeConsumidora");
        }

        [HttpPost]
        public JsonResult ListarCidades(int uf)
        {
            List<SelectListItem> lista = DropDownList.DropDownCidade(null, uf);

            return Json(new { lista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public PartialViewResult _BuscarUnidadeConsumidora(int id)
        {
            UnidadeConsumidora unidadeConsumidora = new UnidadeConsumidoraBusiness().Detalhes(id);
            return PartialView(unidadeConsumidora);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            UnidadeConsumidora unidadeConsumidora = new UnidadeConsumidoraBusiness().Detalhes(id);
            return View(unidadeConsumidora);
        }

        [HttpPost]
        public ActionResult Alterar(FormCollection form)
        {
            UnidadeConsumidora unidadeConsumidora = new UnidadeConsumidora()
            {
                ID = form["ID"].ToInt32(),
                IDEnderecoCliente = form["TipoCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoCliente"].ToInt32(),
                IDConsensionaria = form["TipoCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoCliente"].ToInt32(),
                Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                DataHoraRegistro = form["DataExpedicao"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataExpedicao"].ToDate(),
                Ativo = form["Ativo"].ToBoolean(),
                CodigoUnidadeConsumidora = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Concessionaria = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                FaturaEnergia = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                codigoUc = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                demandaContratada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                categoriaFases = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                disjuntor = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                bitolaEntrada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                tipoLigacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                qdca = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                distanciaBitola = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                padraoEntrada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                projetoMelhoria = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                consumo = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                aumentoCarga = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                obsPertinentes = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                mediaGeracaoEstimada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                GeracaoEstimada = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CapacidadeKWP = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CapacidadeInversores = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                QtdModulos = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                PotenciaTecnologica = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                QtdInversores = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Potencia = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                AreaAcomodacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                AreaTelhado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Protecao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ProtecaoCA = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Capacidade = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ValorFinalMF = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ValorFinalPSS = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ValorFinalTotal = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Pagamento = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Orientacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Inclinacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                LocalInstalacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                IdadeTelhado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                TipoTelhado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                PesoSistema = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                QualidadeTelhado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Selado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CorroidoDanificado = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                EstruturaAjuste = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                Serralheiro = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ObstaculosInternos = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                ObstaculosExternos = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim()
            };

            int unidadeBeneficiariaTotal = form["unidadeBeneficiariaTotal"].ToInt32();
            unidadeConsumidora.UnidadeBeneficiarias = new List<UnidadeBeneficiaria>();
            for (int i = 1; i <= unidadeBeneficiariaTotal; i++)
            {
                unidadeConsumidora.UnidadeBeneficiarias.Add(new UnidadeBeneficiaria
                {
                    ID = form["ID"].ToInt32(),
                    IDEndereco = form["ID"].ToInt32(),
                    IDCliente = form["ID"].ToInt32(),
                    IDCidade = form["ID"].ToInt32(),
                    IDEstado = form["ID"].ToInt32(),
                    Rua = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    Numero = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    Bairro = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    Complemento = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    CEP = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim()
                });
            }


            int? resultado = new UnidadeConsumidoraBusiness().InsertUnidadeConsumidora(unidadeConsumidora);

            dynamic obj = new System.Dynamic.ExpandoObject();
            if (resultado == 1)
            {
                obj.Resultado = true;
                obj.Mensagem = "Registro alterado com sucesso!";
            }
            else
            {
                obj.Resultado = false;
                obj.Mensagem = "Falha ao realizar alteração!";
            }
            TempData["Resultado"] = obj;

            return RedirectToAction("Index", new { id = unidadeConsumidora.ID });

        }

        public ActionResult Deletar(int id)
        {
            UnidadeConsumidora unidadeConsumidora = new UnidadeConsumidoraBusiness().Detalhes(id);

            int? resultado = new UnidadeConsumidoraBusiness().DeleteUnidadeConsumidora(unidadeConsumidora);

            if (resultado == 1)
            {
                //resultado = new UnidadeBeneficiariaBusiness().DeleteUnidadeBeneficiaria(unidadeConsumidora);
            }
            else
            {
                resultado = 0;
            }

            dynamic obj = new System.Dynamic.ExpandoObject();
            if (resultado == 1)
            {
                obj.Resultado = true;
                obj.Mensagem = "Registro excluído com sucesso!";
            }
            else
            {
                obj.Resultado = false;
                obj.Mensagem = "Falha ao excluir registro!";
            }
            TempData["Resultado"] = obj;

            return RedirectToAction("Index");

        }
    }
}

