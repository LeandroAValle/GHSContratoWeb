using System;
using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Grid;
using GHSContratoWeb.Models.Mapping;
using GHSContratoWebBusiness.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GHSContratoWeb.Models.Helper;

namespace GHSContratoWeb.Controllers
{
    public class ConcessionariaController : Controller
    {
        // GET: Concessionaria
        public ActionResult Index()
        {
            List<Concessionaria> listaGrid = new ConcessionariaBusiness().SelectConcessionaria();

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

            int? ultimoCodigo = new ConcessionariaBusiness().BuscarUltimoCodigo();
            ViewBag.ultimoCodigo = (ultimoCodigo != null ? ultimoCodigo.Value + 1 : 1);

            return View();
        }
    }
}