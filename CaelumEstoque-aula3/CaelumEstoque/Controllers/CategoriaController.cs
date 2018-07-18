using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;
namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Categorias = new CategoriasDAO().Listar();

            return View();
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(CategoriaDoProduto categoria)
        {
            new CategoriasDAO().Adicionar(categoria);

            return RedirectToAction("Index");
        }
    }
}