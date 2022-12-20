using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GHSContratoWeb.Models.Helper;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaContratoWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();

            //return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// View com a página de Login e função de validação do usuário
        /// </summary>
        /// <param name="form">formulário com o usuário e a senha</param>
        /// <returns>True || False</returns>
        [HttpPost]
        public ActionResult Acesso(string email, string senha)
        {
            bool loginAcesso = new UsuarioBusiness().Acesso(email, senha);
            if (loginAcesso == true)
            {
                new Utils().Usuario = new UsuarioBusiness().Login(email, senha);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("Usuario");
            return RedirectToAction("Index", "Login");
        }
    }
}