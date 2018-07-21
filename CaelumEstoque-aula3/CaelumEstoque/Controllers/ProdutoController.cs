using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System.Collections.Generic;
using System.Web.Mvc;
namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        [Route("produtos", Name = "ListarProdutos")]
        public ActionResult Index()
        {
            return View(new ProdutosDAO().Listar());
        }

        public ActionResult Form()
        {
            ViewBag.Categorias = new CategoriasDAO().Listar();
            ViewBag.Produto = new Produto();
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Produto produto)
        {
            int idInformatica = 1;

            if (produto.CategoriaId.Equals(idInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.Invalido", "Informática com preço abaixo de 100 reais.");
            }

            if (ModelState.IsValid)
            {
                new ProdutosDAO().Adiciona(produto);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Produto = produto;
                ViewBag.Categorias = new CategoriasDAO().Listar();
                return View("Form");
            }
        }

        [Route("produtos/{id}", Name = "VisualizarProduto")]
        public ActionResult Visualizar(int id)
        {
            ViewBag.Produto = new ProdutosDAO().BuscarPorId(id);

            return View();
        }

        public ActionResult DecrementarQtd(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();

            Produto produto = dao.BuscarPorId(id);

            produto.Quantidade--;

            dao.Atualizar(produto);

            return Json(produto);
        }
    }
}