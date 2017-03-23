using Financas.DAO;
using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Adiciona(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuariodao.Adiciona(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", usuario);
            }

        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuariodao.Lista();
            return View(usuarios);
        }
    }
}