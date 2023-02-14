using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Grid;
using GHSContratoWeb.Models.Helper;
using GHSContratoWeb.Models.Mapping;
using GHSContratoWebBusiness.Helper;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GHSContratoWeb.Controllers
{
    public class ReciboController : Controller
    {
        // GET: Recibo
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

        public ActionResult GetReport(int id = 1)
        {
            // Create the report object
            var report = new StiReport();

            var empresa = new EmpresaBusiness().Buscar();

            List<Cliente> list = new ClienteBusiness().SelectCliente();
            report.Load(@"C:\Users\Usuario\source\repos\GHSContratoWeb\GHSContratoWeb\Reports\Recibo.mrt");
            report.RegBusinessObject("lista", list);

            report.Dictionary.Variables["TopoLinha1"].Value = empresa.NomeFantasia;
            report.Dictionary.Variables["TopoLinha2"].Value = empresa.Endereco + ", N º " + empresa.Numero + "    Bairro: " + empresa.Bairro;
            report.Dictionary.Variables["TopoLinha3"].Value = "CNPJ: " + empresa.CNPJ.FormatarCPFCNPJ() + "    Fone: " + empresa.Telefone.FormatarTelefone() + "   /   " + empresa.Cidade + "-" + empresa.UF;

            return StiMvcViewer.GetReportResult(report);
        }
        public ActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult();
        }


        [HttpPost]
        public PartialViewResult _BuscarClienteRecibo(int id)
        {
            Cliente cliente = new ClienteBusiness().Detalhes(id);
            return PartialView(cliente);
        }

    }
}