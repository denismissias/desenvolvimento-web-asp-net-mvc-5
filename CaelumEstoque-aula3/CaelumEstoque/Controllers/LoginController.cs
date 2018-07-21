using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(string login, string senha)
        {
            Usuario usuario = new UsuariosDAO().Buscar(login, senha);

            if (usuario != null)
            {
                Session["UsuarioLogado"] = usuario;
                return RedirectToAction("index", "Produto");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}