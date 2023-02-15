using GHSContratoWeb.Models.Business;
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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            Usuario usuario = new Utils().Usuario;

            if (usuario == null)
            {
                RedirectToAction("Index", "Login");
            }

            List<Usuario> listaGrid = new UsuarioBusiness().SelectUsuario();

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

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(FormCollection form)
        {
            Usuario usuario = new Usuario()
            {
                ID = form["ID"].IsNullOrEmptyBoolean() ? null : form["ID"].Trim(),
                Nome = form["Nome"].IsNullOrEmptyBoolean() ? null : form["Nome"].Trim(),
                Login = form["Login"].IsNullOrEmptyBoolean() ? null : form["Login"].Trim(),
                Senha = form["Senha"].IsNullOrEmptyBoolean() ? null : form["Senha"].Trim(),
                DataHora = form["DataHora"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataHora"].ToDate(),
                Ativo = form["Ativo"].ToBoolean()
            };

            int? resultado = new UsuarioBusiness().InsertUsuario(usuario);

            dynamic obj = new System.Dynamic.ExpandoObject();
            if (resultado == 1)
            {
                obj.Resultado = true;
                obj.Mensagem = "Registro salvo com sucesso!";
            }
            else
            {
                obj.Resultado = false;
                obj.Mensagem = "Falha ao realizar cadastro!";
            }
            TempData["Resultado"] = obj;



            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Alterar(string id)
        {
            Usuario usuario = new UsuarioBusiness().Detalhes(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Alterar(FormCollection form)
        {
            Usuario usuario = new Usuario()
            {
                ID = form["ID"].IsNullOrEmptyBoolean() ? null : form["ID"].Trim(),
                Nome = form["Nome"].IsNullOrEmptyBoolean() ? null : form["Nome"].Trim(),
                Login = form["Login"].IsNullOrEmptyBoolean() ? null : form["Login"].Trim(),
                Senha = form["Senha"].IsNullOrEmptyBoolean() ? null : form["Senha"].Trim(),
                DataHora = form["DataHora"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataHora"].ToDate(),
                Ativo = form["Ativo"].ToBoolean()
            };

            int? resultado = new UsuarioBusiness().UpdateUsuario(usuario);

            dynamic obj = new System.Dynamic.ExpandoObject();
            if (resultado == 1)
            {
                obj.Resultado = true;
                obj.Mensagem = "Registro alterado com sucesso!";
            }
            else
            {
                obj.Resultado = false;
                obj.Mensagem = "Falha ao realizar alteração!";
            }
            TempData["Resultado"] = obj;

            return RedirectToAction("Index", new { id = usuario.ID });

        }

        public ActionResult Deletar(string id)
        {
            Usuario usuario = new UsuarioBusiness().Detalhes(id);

            int? resultado = new UsuarioBusiness().UpdateUsuario(usuario);

            dynamic obj = new System.Dynamic.ExpandoObject();
            if (resultado == 1)
            {
                obj.Resultado = true;
                obj.Mensagem = "Registro excluído com sucesso!";
            }
            else
            {
                obj.Resultado = false;
                obj.Mensagem = "Falha ao excluir registro!";
            }
            TempData["Resultado"] = obj;

            return RedirectToAction("Index");

        }
    }
}