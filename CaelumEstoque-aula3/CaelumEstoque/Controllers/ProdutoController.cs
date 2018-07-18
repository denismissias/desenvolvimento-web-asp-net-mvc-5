
using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System.Collections.Generic;
using System.Web.Mvc;
namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Produtos = new ProdutosDAO().Listar();

            return View();
        }

        public ActionResult Form()
        {
            ViewBag.Categorias = new CategoriasDAO().Listar();

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Produto produto)
        {
            new ProdutosDAO().Adiciona(produto);

            return RedirectToAction("Index");
        }
    }
}