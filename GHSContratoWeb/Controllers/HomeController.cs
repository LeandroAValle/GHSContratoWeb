using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GHSContratoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// View com a página de Login e função de validação do usuário
        /// </summary>
        /// <param name="form">formulário com o usuário e a senha</param>
        /// <returns>True || False</returns>
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            new Utils().Usuario = new UsuarioBusiness().Login(form["login"], form["senha"]);

            if (new Utils().Usuario == null)
            {
                ViewBag.FlagLogin = "Usuário inválido!";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Sair do Sistema
        /// </summary>
        /// <returns>View Index da Controller Home</returns>
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("Usuario");
            return RedirectToAction("Login", "Login");
        }
    }
}