using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Grid;
using GHSContratoWeb.Models.Helper;
using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GHSContratoWeb.Controllers
{
    public class FerramentaController : Controller
    {
        public ActionResult Index()
        {
            Usuario usuario = new Utils().Usuario;

            if (usuario == null)
            {
                RedirectToAction("Index", "Login");
            }

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

            return View();
        }
    }
}