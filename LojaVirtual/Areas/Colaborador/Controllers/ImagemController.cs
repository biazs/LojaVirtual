using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Arquivo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ImagemController : Controller
    {
        public object Caminho { get; private set; }

        public IActionResult Armazenar(IFormFile file)
        {
            var caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            if(caminho.Length > 0)
            {
                return Ok(new { caminho = Caminho });
            }
            else
            {
                return new StatusCodeResult(500);
            }

        }

        public IActionResult Deletar(string caminho)
        {
            if (GerenciadorArquivo.ExcluirImagemProduto(caminho))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}