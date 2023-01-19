using System;
using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Grid;
using GHSContratoWeb.Models.Mapping;
using GHSContratoWebBusiness.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}