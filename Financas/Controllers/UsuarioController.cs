using Financas.DAO;
using Financas.Entidades;
using Financas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuariodao;

        public UsuarioController(UsuarioDAO usuariodao)
        {
            this.usuariodao = usuariodao;
        }
        
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    /*Usuario usuario = new Usuario()
                    {
                        Nome = model.Nome,
                        Email = model.Email
                    };

                    usuariodao.Adiciona(usuario);
                    WebSecurity.CreateAccount(model.Nome, model.Senha); */

                    //cria um usuario na tabela usuario e na tabela de conta de usuario ao mesmo tempo
                    WebSecurity.CreateUserAndAccount(model.Nome, model.Senha, new { Email = model.Email });
                    return RedirectToAction("Index", "Movimentacao");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("usuario.invalido", e);
                    return View("Form", model);
                }               
            }
            else
            {
                return View("Form", model);
            }

        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuariodao.Lista();
            return View(usuarios);
        }
    }
}