using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace LojaVirtual.Libraries.Arquivo
{
    public class GerenciadorArquivo
    {
        public static string CadastrarImagemProduto(IFormFile file)
        {
            var NomeArquivo = Path.GetFileName(file.FileName);
            var Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", NomeArquivo);

            using (var stream = new FileStream(Caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine("/uploads/temp", NomeArquivo).Replace("\\", "/");
        }
        public static bool ExcluirImagemProduto(string caminho)
        {
            string Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminho.TrimStart('/'));
            if (File.Exists(Caminho))
            {
                File.Delete(Caminho);
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static List<string> MoverImagemProduto(List<string> ListaCaminhoTemporario, string ProdutoId)
        {
            /*
             * Criar a pasta do produto
             */
            var caminhoDefinitivoPastaProduto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", ProdutoId);

            if (!Directory.Exists(caminhoDefinitivoPastaProduto))
            {
                Directory.CreateDirectory(caminhoDefinitivoPastaProduto);
            }

            /*
             * Mover a imagem da pasta temporaria para a definitiva
             */
            List<string> ListaCaminhoDefinitivo = new List<string>();
            foreach (var CaminhoTemp in ListaCaminhoTemporario)
            {
                if (string.IsNullOrEmpty(CaminhoTemp))
                {
                    var NomeArquivo = Path.GetFileName(CaminhoTemp);
                    var CaminhoAbsolutoTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", CaminhoTemp);
                    var CaminhoAbsolutoDef = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", ProdutoId, NomeArquivo);

                    if (File.Exists(CaminhoAbsolutoTemp))
                    {
                        File.Copy(CaminhoAbsolutoTemp, CaminhoAbsolutoDef);
                        if (File.Exists(CaminhoAbsolutoDef))
                        {
                            File.Delete(CaminhoAbsolutoTemp);
                        }
                        ListaCaminhoDefinitivo.Add(Path.Combine("/uploads", ProdutoId, NomeArquivo).Replace("\\", "/"));
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            throw new NotImplementedException();
        }
    }
}
