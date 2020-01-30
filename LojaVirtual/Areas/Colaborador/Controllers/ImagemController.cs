using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ImagemController : Controller
    {
        public IActionResult Armazenar(IFormFile file)
        {            
            return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }
    }
}