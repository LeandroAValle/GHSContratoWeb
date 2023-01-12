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

namespace GHSContratoWeb.Controllers
{
    public class UnidadeConsumidoraController : Controller
    {
        public ActionResult Index()
        {
            List<UnidadeConsumidora> listaGrid = new UnidadeConsumidoraBusiness().SelectUnidadeConsumidora();

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

        public ActionResult Novo()
        {
            return View();
        }
    }
}

