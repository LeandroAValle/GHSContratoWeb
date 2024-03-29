﻿using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using GHSContratoWeb.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GHSContratoWeb.Models.Mapping;
using GHSContratoWebBusiness.Helper;
using GHSContratoWeb.Models.Grid;

namespace GHSContratoWeb.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Index()
        {
            List<ClienteGrid> listaGrid = new ClienteBusiness().ListarGrid();

            return View(listaGrid);
        }

        public ActionResult GetReport(int id = 1)
        {
            // Create the report object
            var report = new StiReport();

            var empresa = new EmpresaBusiness().Buscar();

            List<Cliente> list = new ClienteBusiness().SelectCliente();
            report.Load(@"C:\Users\Usuario\source\repos\GHSContratoWeb\GHSContratoWeb\Reports\Contrato.mrt");
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
    }
}