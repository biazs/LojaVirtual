using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        private ICategoriaRepository _categoriaRepository;
        private IProdutoRepository _produtoRepository;
        public ProdutoController(ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        [Route("Produto/Categoria/{slug}")]
        public ActionResult ListagemCategoria(string slug)
        {
            return View(_categoriaRepository.ObterCategoria(slug));
        }

        /*
         * ActionResult
         * IActionResult
         */
        [HttpGet]
        public ActionResult Visualizar(int id)
        {
            return View(_produtoRepository.ObterProduto(id));
        }
    }
}
