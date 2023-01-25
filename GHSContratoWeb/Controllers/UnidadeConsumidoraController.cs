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
            return View(endereco);
        }
    }
}

