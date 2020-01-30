using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Arquivo
{
    public class GerenciadorArquivo
    {
        public static string CadastrarImagemProduto(IFormFile file)
        {
            var NomeArquivo = Path.GetFileName(file.FileName);
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", NomeArquivo);

            using (var stream = new FileStream(caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Path.Combine("/uploads/temp", NomeArquivo);
        }
        public static void ExcluirImagemProduto()
        {

        }
    }
}
