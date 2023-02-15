using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Grid;
using GHSContratoWeb.Models.Helper;
using GHSContratoWeb.Models.Mapping;
using GHSContratoWebBusiness.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GHSContratoWeb.Controllers
{
    public class MaterialController : Controller
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

        #region Disjuntores

        [HttpGet]
        public PartialViewResult _Disjuntores()
        {
            List<Disjuntor> disjuntor = new MaterialBusiness().ListarDisjuntores();

            return PartialView(disjuntor);
        }

        [HttpPost]
        public JsonResult SalvarDisjuntor(FormCollection form)
        {
            Disjuntor disjuntor = new Disjuntor()
            {
                ID = form["IDdisjuntor"].ToInt32(),
                Descricao = form["Nomedisjuntor"].IsNullOrEmptyBoolean() ? null : form["Nomedisjuntor"].Trim()
            };

            int? result = new MaterialBusiness().InsertDisjuntor(disjuntor);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AtualizaDisjuntor()
        {
            List<Disjuntor> disjuntor = new MaterialBusiness().ListarDisjuntores();

            return Json(disjuntor, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeletarDisjuntor(int id)
        {
            Disjuntor disjuntor = new MaterialBusiness().Detalhes(id);

            int? result = new MaterialBusiness().DeleteDisjunor(disjuntor);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult BuscaUltimoCodigoDisjuntores()
        {
            int? ultimoCodigo = new MaterialBusiness().BuscarUltimoCodigo();
            ultimoCodigo = (ultimoCodigo != null ? ultimoCodigo.Value + 1 : 1);

            return Json(ultimoCodigo, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}