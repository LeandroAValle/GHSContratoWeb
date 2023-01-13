using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Grid;
using GHSContratoWeb.Models.Mapping;
using GHSContratoWebBusiness.Helper;
using GHSContratoWeb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GHSContratoWeb.Models.Helper;

namespace GHSContratoWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            Usuario usuario = new Utils().Usuario;

            if (usuario == null)
            {
                RedirectToAction("Index", "Login");
            }

            List<ClienteGrid> listaGrid = new ClienteBusiness().ListarGrid();

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
        public ActionResult Novo()
        {
            Usuario usuario = new Utils().Usuario;

            if (usuario == null)
            {
                RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Novo(FormCollection form)
        {
            Cliente cliente = new Cliente()
            {
                Nome = form["Nome"].IsNullOrEmptyBoolean() ? null : form["Nome"].Trim(),
                Ativo = form["Ativo"].ToBoolean(),
                DataExpedicao = form["DataExpedicao"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataExpedicao"].ToDate(),
                IDTipoCliente = form["IDTipoCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["IDTipoCliente"].ToInt32(),
                Telefone = form["Telefone"].IsNullOrEmptyBoolean() ? null : form["Telefone"].Trim(),
                Email = form["Email"].IsNullOrEmptyBoolean() ? null : form["Email"].Trim(),
                Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CPF = form["CPF"].IsNullOrEmptyBoolean() ? null : form["CPF"].Trim(),
                CNPJ = form["CNPJ"].IsNullOrEmptyBoolean() ? null : form["CNPJ"].Trim(),
                RG = form["RG"].IsNullOrEmptyBoolean() ? null : form["RG"].Trim(),
                InscricaoEstadual = form["InscricaoEstadual"].IsNullOrEmptyBoolean() ? null : form["InscricaoEstadual"].Trim(),
                DataNascimento = form["DataNascimento"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataNascimento"].ToDate(),
                DataAbertura = form["DataAbertura"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataAbertura"].ToDate(),
                Cidadania = form["Cidadania"].IsNullOrEmptyBoolean() ? null : form["Cidadania"].Trim(),
                EstadoCivil = form["EstadoCivil"].IsNullOrEmptyBoolean() ? null : form["EstadoCivil"].Trim(),
                Profissao = form["Profissao"].IsNullOrEmptyBoolean() ? null : form["Profissao"].Trim()
            };

            EnderecoCliente endereco = new EnderecoCliente()
            {
                IDCliente = form["IDCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["IDCliente"].ToInt32(),
                IDCidade = form["IDCidade"].IsNullOrEmptyBoolean() ? (Int32?)null : form["IDCidade"].ToInt32(),
                Rua = form["Rua"].IsNullOrEmptyBoolean() ? null : form["Rua"].Trim(),
                Numero = form["Numero"].IsNullOrEmptyBoolean() ? null : form["Numero"].Trim(),
                Bairro = form["Bairro"].IsNullOrEmptyBoolean() ? null : form["Bairro"].Trim(),
                Complemento = form["Complemento"].IsNullOrEmptyBoolean() ? null : form["Complemento"].Trim(),
                CEP = form["CEP"].IsNullOrEmptyBoolean() ? null : form["CEP"].Trim(),
                LatitudeDecimal = form["LatitudeDecimal"].IsNullOrEmptyBoolean() ? (Decimal?)null : form["LatitudeDecimal"].ToDecimal(),
                LongitudeDecimal = form["LongitudeDecimal"].IsNullOrEmptyBoolean() ? (Decimal?)null : form["LongitudeDecimal"].ToDecimal(),
                Padrao = form["Padrao"].ToBoolean(),
                Ativo = form["Ativo"].ToBoolean(),
                Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                LatitudeHoras = form["LatitudeHoras"].IsNullOrEmptyBoolean() ? null : form["LatitudeHoras"].Trim(),
                LongitudeHoras = form["LongitudeHoras"].IsNullOrEmptyBoolean() ? null : form["LongitudeHoras"].Trim(),
                LocalInstalacao = form["LocalInstalacao"].ToBoolean()
            };

            if (this.Request.Files[0].ContentLength > 0)
            {
                if (this.Request.Files.Count == 1)
                {
                    using (Stream inputStream = this.Request.Files[0].InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        cliente.Anexo = memoryStream.ToArray();
                    }
                }
            }

            int? resultado = new ClienteBusiness().InsertCliente(cliente);

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

            return RedirectToAction("ClienteEndereco");
        }

        [HttpPost]
        public PartialViewResult _BuscarCliente(int id)
        {
            Cliente cliente = new ClienteBusiness().Detalhes(id);
            return PartialView(cliente);
        }


        public ActionResult Alterar(int id)
        {
            Cliente cliente = new ClienteBusiness().Detalhes(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Alterar(FormCollection form)
        {
            Cliente cliente = new Cliente();

            if (string.IsNullOrEmpty(form["nome"].ToString().Trim()) == true)
            {
                cliente.Nome = null;
            }
            else
            {
                cliente.Nome = form["nome"].ToString().Trim();
            }

            if (string.IsNullOrEmpty(form["DataExpedicao"].ToString().Trim()) == true)
            {
                cliente.DataExpedicao = null;
            }
            else
            {
                cliente.DataExpedicao = Convert.ToDateTime(form["DataExpedicao"].ToString());
            }

            int? resultado = new ClienteBusiness().UpdateCliente(cliente);

            //dynamic obj = new System.Dynamic.ExpandoObject();
            //if (resultado == true)
            //{
            //    obj.Resultado = true;
            //    obj.Mensagem = "Registro alterado com sucesso!";
            //}
            //else
            //{
            //    obj.Resultado = false;
            //    obj.Mensagem = "Falha ao realizar alteração!";
            //}
            //TempData["Resultado"] = obj;

            return RedirectToAction("Index", new { id = cliente.ID });

        }
    }
}