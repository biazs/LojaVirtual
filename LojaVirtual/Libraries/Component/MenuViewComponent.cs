using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Libraries.Component
{
    public class MenuViewComponent : ViewComponent
    {
        //TODO CategoriaRepository

        ICategoriaRepository _categoriaRepository;
        public MenuViewComponent(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        //TODO logica do componente
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ListaCategoria = _categoriaRepository.ObterTodasCategorias().ToList();
            return View();
        }
    }
}
