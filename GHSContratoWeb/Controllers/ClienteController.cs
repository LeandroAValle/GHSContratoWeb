using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Grid;
using GHSContratoWeb.Models.Mapping;
using GHSContratoWebBusiness.Helper;
using GHSContratoWeb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GHSContratoWeb.Models.Helper;

namespace GHSContratoWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
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

        [HttpGet]
        public ActionResult Novo()
        {
            Usuario usuario = new Utils().Usuario;

            if (usuario == null)
            {
                RedirectToAction("Index", "Login");
            }

            ViewBag.DropDownTipoCliente = DropDownList.DropDownTipoCliente();
            ViewBag.DropDownCidade =  DropDownList.DropDownCidade();
            ViewBag.DropDownEstado =  DropDownList.DropDownEstado();

            int? ultimoCodigo = new ClienteBusiness().BuscarUltimoCodigo();
            ViewBag.ultimoCodigo = (ultimoCodigo != null ? ultimoCodigo.Value + 1 : 1);

            return View();
        }

        [HttpPost]
        public ActionResult Novo(FormCollection form)
        {
            Cliente cliente = new Cliente()
            {
                ID = form["ID"].ToInt32(),
                Nome = form["Nome"].IsNullOrEmptyBoolean() ? null : form["Nome"].Trim(),
                Ativo = form["clienteAtivo"].ToBoolean(),
                DataExpedicao = form["DataExpedicao"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataExpedicao"].ToDate(),
                IDTipoCliente = form["TipoCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoCliente"].ToInt32(),
                Telefone = form["Telefone"].IsNullOrEmptyBoolean() ? null : form["Telefone"].Trim(),
                OrgaoExpeditor = form["OE"].IsNullOrEmptyBoolean() ? null : form["OE"].Trim(),
                TipoDocumento = form["TipoDocumento"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoDocumento"].ToInt32(),
                Email = form["Email"].IsNullOrEmptyBoolean() ? null : form["Email"].Trim(),
                Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CPF = form["CPF"].IsNullOrEmptyBoolean() ? null : form["CPF"].Trim(),
                CNPJ = form["CNPJ"].IsNullOrEmptyBoolean() ? null : form["CNPJ"].Trim(),
                RG = form["RG"].IsNullOrEmptyBoolean() ? null : form["RG"].Trim(),
                InscricaoEstadual = form["InscricaoEstadual"].IsNullOrEmptyBoolean() ? null : form["InscricaoEstadual"].Trim(),
                DataNascimento = form["DataNascimento"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataNascimento"].ToDate(),
                DataAbertura = form["DataAbertura"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataAbertura"].ToDate(),
                Cidadania = form["Cidadania"].IsNullOrEmptyBoolean() ? null : form["Cidadania"].Trim(),
                EstadoCivil = form["EstadoCivil"].IsNullOrEmptyBoolean() ? null : form["EstadoCivil"].Trim(),
                FaixaSalarial = form["faixaSalarial"].IsNullOrEmptyBoolean() ? null : form["faixaSalarial"].Trim(),
                Profissao = form["Profissao"].IsNullOrEmptyBoolean() ? null : form["Profissao"].Trim()
            };

            int enderecoTotal = form["enderecoTotal"].ToInt32();
            cliente.Enderecos = new List<EnderecoCliente>();
            for (int i = 1; i <= enderecoTotal; i++)
            {
                cliente.Enderecos.Add(new EnderecoCliente
                {
                    IDCliente = form["ID"].IsNullOrEmptyBoolean() ? (Int32?)null : form["ID"].ToInt32(),
                    IDCidade = form["Cidade"].IsNullOrEmptyBoolean() ? (Int32?)null : form["Cidade"].ToInt32(),
                    IDEstado = form["Estado"].IsNullOrEmptyBoolean() ? (Int32?)null : form["Estado"].ToInt32(),
                    Rua = form["Rua"].IsNullOrEmptyBoolean() ? null : form["Rua"].Trim(),
                    Numero = form["Numero"].IsNullOrEmptyBoolean() ? null : form["Numero"].Trim(),
                    Bairro = form["Bairro"].IsNullOrEmptyBoolean() ? null : form["Bairro"].Trim(),
                    Complemento = form["Complemento"].IsNullOrEmptyBoolean() ? null : form["Complemento"].Trim(),
                    CEP = form["CEP"].IsNullOrEmptyBoolean() ? null : form["CEP"].Trim(),
                    LatitudeDecimal = form["LatitudeDecimal"].IsNullOrEmptyBoolean() ? (Decimal?)null : form["LatitudeDecimal"].ToDecimal(),
                    LongitudeDecimal = form["LongitudeDecimal"].IsNullOrEmptyBoolean() ? (Decimal?)null : form["LongitudeDecimal"].ToDecimal(),
                    Padrao = form["Padrao"].ToBoolean(),
                    Ativo = form["Ativo"].ToBoolean(),
                    Observacao = form["EnderecoObs"].IsNullOrEmptyBoolean() ? null : form["EnderecoObs"].Trim(),
                    LatitudeHoras = form["LatitudeHoras"].IsNullOrEmptyBoolean() ? null : form["LatitudeHoras"].Trim(),
                    LongitudeHoras = form["LongitudeHoras"].IsNullOrEmptyBoolean() ? null : form["LongitudeHoras"].Trim(),
                    LocalInstalacao = form["enderecoInstalacao"].ToBoolean()
                });
            }

            int contatoTotal = form["contatoTotal"].ToInt32();
            cliente.Contatos = new List<ContatoCliente>();
            for (int i = 1; i <= contatoTotal; i++)
            {
                cliente.Contatos.Add(new ContatoCliente
                {
                    IDCliente = form["IDCliente" + i].ToInt32(),
                    Telefone = form["Telefone"].IsNullOrEmptyBoolean() ? null : form["Telefone"].Trim(),
                    Email = form["Email"].IsNullOrEmptyBoolean() ? null : form["Email"].Trim(),
                    Proprietario = form["Proprietario"].IsNullOrEmptyBoolean() ? null : form["Proprietario"].Trim(),
                });;
            }

            int acessoTotal = form["acessoTotal"].ToInt32();
            cliente.Acessos = new List<InformacoesAcessoCliente>();
            for (int i = 1; i <= acessoTotal; i++)
            {
                cliente.Acessos.Add(new InformacoesAcessoCliente
                {
                    Internet = form["Internet"].IsNullOrEmptyBoolean() ? null : form["Internet"].Trim(),
                    AplicativoMonitor = form["AplicativoMonitor"].IsNullOrEmptyBoolean() ? null : form["AplicativoMonitor"].Trim(),
                    LoginUsuario = form["Usuario"].IsNullOrEmptyBoolean() ? null : form["Usuario"].Trim(),
                    Senha = form["Senha"].IsNullOrEmptyBoolean() ? null : form["Senha"].Trim(),
                    IDConsensionaria = form["IDConsensionaria" + i].ToInt32(),
                    Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    IDCliente = form["IDCliente" + i].ToInt32()
                });
            }

            if (this.Request.Files[0].ContentLength > 0)
            {
                if (this.Request.Files.Count == 1)
                {
                    using (Stream inputStream = this.Request.Files[0].InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        cliente.Anexo = memoryStream.ToArray();
                    }
                }
            }

            if (this.Request.Files[0].ContentLength > 0)
            {
                if (this.Request.Files.Count == 1)
                {
                    using (Stream inputStream = this.Request.Files[0].InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        cliente.Foto = memoryStream.ToArray();
                    }
                }
            }

            int? resultado = new ClienteBusiness().InsertCliente(cliente);

            //if (resultado != null)
            //{
            //    resultado = new EnderecoClienteBusiness().InsertEnderecoCliente(cliente);

            //    if (resultado != null)
            //    {
            //        resultado = new ContatoClienteBusiness().InsertContatoCliente(cliente);

            //        if (resultado != null)
            //        {
            //            resultado = new InformacaoAcessoBusiness().InsertInformacaoAcesso(cliente);

            //        }
            //        else
            //        {
            //            resultado = null;
            //        }
            //    }
            //    else
            //    {
            //        resultado = null;
            //    }
            //}
            //else
            //{
            //    resultado = null;
            //}

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

        [HttpPost]
        public PartialViewResult _BuscarCliente(int id)
        {
            Cliente cliente = new ClienteBusiness().Detalhes(id);
            return PartialView(cliente);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            Cliente cliente = new ClienteBusiness().Detalhes(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Alterar(FormCollection form)
        {
            Cliente cliente = new Cliente()
            {
                ID = form["ID"].ToInt32(),
                Nome = form["Nome"].IsNullOrEmptyBoolean() ? null : form["Nome"].Trim(),
                Ativo = form["clienteAtivo"].ToBoolean(),
                DataExpedicao = form["DataExpedicao"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataExpedicao"].ToDate(),
                IDTipoCliente = form["TipoCliente"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoCliente"].ToInt32(),
                Telefone = form["Telefone"].IsNullOrEmptyBoolean() ? null : form["Telefone"].Trim(),
                OrgaoExpeditor = form["OE"].IsNullOrEmptyBoolean() ? null : form["OE"].Trim(),
                TipoDocumento = form["TipoDocumento"].IsNullOrEmptyBoolean() ? (Int32?)null : form["TipoDocumento"].ToInt32(),
                Email = form["Email"].IsNullOrEmptyBoolean() ? null : form["Email"].Trim(),
                Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                CPF = form["CPF"].IsNullOrEmptyBoolean() ? null : form["CPF"].Trim(),
                CNPJ = form["CNPJ"].IsNullOrEmptyBoolean() ? null : form["CNPJ"].Trim(),
                RG = form["RG"].IsNullOrEmptyBoolean() ? null : form["RG"].Trim(),
                InscricaoEstadual = form["InscricaoEstadual"].IsNullOrEmptyBoolean() ? null : form["InscricaoEstadual"].Trim(),
                DataNascimento = form["DataNascimento"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataNascimento"].ToDate(),
                DataAbertura = form["DataAbertura"].IsNullOrEmptyBoolean() ? (DateTime?)null : form["DataAbertura"].ToDate(),
                Cidadania = form["Cidadania"].IsNullOrEmptyBoolean() ? null : form["Cidadania"].Trim(),
                EstadoCivil = form["EstadoCivil"].IsNullOrEmptyBoolean() ? null : form["EstadoCivil"].Trim(),
                FaixaSalarial = form["faixaSalarial"].IsNullOrEmptyBoolean() ? null : form["faixaSalarial"].Trim(),
                Profissao = form["Profissao"].IsNullOrEmptyBoolean() ? null : form["Profissao"].Trim()
            };

            int enderecoTotal = form["enderecoTotal"].ToInt32();
            cliente.Enderecos = new List<EnderecoCliente>();
            for (int i = 1; i <= enderecoTotal; i++)
            {
                cliente.Enderecos.Add(new EnderecoCliente
                {
                    IDCliente = form["ID"].IsNullOrEmptyBoolean() ? (Int32?)null : form["ID"].ToInt32(),
                    IDCidade = form["Cidade"].IsNullOrEmptyBoolean() ? (Int32?)null : form["Cidade"].ToInt32(),
                    IDEstado = form["Estado"].IsNullOrEmptyBoolean() ? (Int32?)null : form["Estado"].ToInt32(),
                    Rua = form["Rua"].IsNullOrEmptyBoolean() ? null : form["Rua"].Trim(),
                    Numero = form["Numero"].IsNullOrEmptyBoolean() ? null : form["Numero"].Trim(),
                    Bairro = form["Bairro"].IsNullOrEmptyBoolean() ? null : form["Bairro"].Trim(),
                    Complemento = form["Complemento"].IsNullOrEmptyBoolean() ? null : form["Complemento"].Trim(),
                    CEP = form["CEP"].IsNullOrEmptyBoolean() ? null : form["CEP"].Trim(),
                    LatitudeDecimal = form["LatitudeDecimal"].IsNullOrEmptyBoolean() ? (Decimal?)null : form["LatitudeDecimal"].ToDecimal(),
                    LongitudeDecimal = form["LongitudeDecimal"].IsNullOrEmptyBoolean() ? (Decimal?)null : form["LongitudeDecimal"].ToDecimal(),
                    Padrao = form["Padrao"].ToBoolean(),
                    Ativo = form["Ativo"].ToBoolean(),
                    Observacao = form["EnderecoObs"].IsNullOrEmptyBoolean() ? null : form["EnderecoObs"].Trim(),
                    LatitudeHoras = form["LatitudeHoras"].IsNullOrEmptyBoolean() ? null : form["LatitudeHoras"].Trim(),
                    LongitudeHoras = form["LongitudeHoras"].IsNullOrEmptyBoolean() ? null : form["LongitudeHoras"].Trim(),
                    LocalInstalacao = form["enderecoInstalacao"].ToBoolean()
                });
            }

            int contatoTotal = form["contatoTotal"].ToInt32();
            cliente.Contatos = new List<ContatoCliente>();
            for (int i = 1; i <= contatoTotal; i++)
            {
                cliente.Contatos.Add(new ContatoCliente
                {
                    IDCliente = form["IDCliente" + i].ToInt32(),
                    Telefone = form["Telefone"].IsNullOrEmptyBoolean() ? null : form["Telefone"].Trim(),
                    Email = form["Email"].IsNullOrEmptyBoolean() ? null : form["Email"].Trim(),
                    Proprietario = form["Proprietario"].IsNullOrEmptyBoolean() ? null : form["Proprietario"].Trim(),
                }); ;
            }

            int acessoTotal = form["acessoTotal"].ToInt32();
            cliente.Acessos = new List<InformacoesAcessoCliente>();
            for (int i = 1; i <= acessoTotal; i++)
            {
                cliente.Acessos.Add(new InformacoesAcessoCliente
                {
                    Internet = form["Internet"].IsNullOrEmptyBoolean() ? null : form["Internet"].Trim(),
                    AplicativoMonitor = form["AplicativoMonitor"].IsNullOrEmptyBoolean() ? null : form["AplicativoMonitor"].Trim(),
                    LoginUsuario = form["Usuario"].IsNullOrEmptyBoolean() ? null : form["Usuario"].Trim(),
                    Senha = form["Senha"].IsNullOrEmptyBoolean() ? null : form["Senha"].Trim(),
                    IDConsensionaria = form["IDConsensionaria" + i].ToInt32(),
                    Observacao = form["Observacao"].IsNullOrEmptyBoolean() ? null : form["Observacao"].Trim(),
                    IDCliente = form["IDCliente" + i].ToInt32()
                });
            }

            if (this.Request.Files[0].ContentLength > 0)
            {
                if (this.Request.Files.Count == 1)
                {
                    using (Stream inputStream = this.Request.Files[0].InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        cliente.Anexo = memoryStream.ToArray();
                    }
                }
            }

            if (this.Request.Files[0].ContentLength > 0)
            {
                if (this.Request.Files.Count == 1)
                {
                    using (Stream inputStream = this.Request.Files[0].InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        cliente.Foto = memoryStream.ToArray();
                    }
                }
            }

            int? resultado = new ClienteBusiness().UpdateCliente(cliente);

            //if (resultado != null)
            //{
            //    resultado = new EnderecoClienteBusiness().InsertEnderecoCliente(cliente);

            //    if (resultado != null)
            //    {
            //        resultado = new ContatoClienteBusiness().InsertContatoCliente(cliente);

            //        if (resultado != null)
            //        {
            //            resultado = new InformacaoAcessoBusiness().InsertInformacaoAcesso(cliente);

            //        }
            //        else
            //        {
            //            resultado = null;
            //        }
            //    }
            //    else
            //    {
            //        resultado = null;
            //    }
            //}
            //else
            //{
            //    resultado = null;
            //}

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

            return RedirectToAction("Index", new { id = cliente.ID });

        }

        [HttpPost]
        public JsonResult ListarCidades(int uf)
        {
            List<SelectListItem> lista = DropDownList.DropDownCidade(null, uf);

            return Json(new { lista }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Deletar(int id)
        {
            Cliente cliente = new ClienteBusiness().Detalhes(id);

            int? resultado = new ClienteBusiness().DeleteCliente(cliente);

            if (resultado == 1)
            {
                //resultado = new EnderecoClienteBusiness().DeleteEnderecoCliente(cliente);

                //if (resultado == 1)
                //{
                //    resultado = new ContatoClienteBusiness().Delete(cliente);

                //    if (resultado == 1)
                //    {
                //        resultado = new InformacaoAcessoBusiness().Delete(cliente);
                //    }
                //    else
                //    {
                //        resultado = 0;
                //    }
                //}
                //else
                //{
                //    resultado = 0;
                //}
            }
            else
            {
                resultado = 0;
            }

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