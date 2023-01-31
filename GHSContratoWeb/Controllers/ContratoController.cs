using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using GHSContratoWeb.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport(int id = 1)
        {
            // Create the report object
            var report = new StiReport();
            List<EnderecoCliente> list = new EnderecoClienteBusiness().SelectEnderecoCliente();
            report.Load(@"C:\Users\Usuario\source\repos\GHSContratoWeb\GHSContratoWeb\Reports\Pais.mrt");
            report.RegBusinessObject("lista", list);
            return StiMvcViewer.GetReportResult(report);
        }
        public ActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult();
        }
    }
}