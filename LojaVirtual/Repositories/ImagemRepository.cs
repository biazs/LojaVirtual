using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.Extensions.Configuration;

namespace LojaVirtual.Repositories
{
    public class ImagemRepository : IImagemRepository
    {
        private IConfiguration _conf;
        LojaVirtualContext _banco;

        public ImagemRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void CadastrarImagens(List<Imagem> ListaImagens, int ProdutoId)
        {
            if (ListaImagens != null && ListaImagens.Count > 0)
            {
                foreach (var Imagem in ListaImagens)
                {
                    Cadastrar(Imagem);
                }
            }

        }
        public void Cadastrar(Imagem imagem)
        {
            _banco.Add(imagem);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Imagem imagem = _banco.Imagens.Find(Id);
            _banco.Remove(imagem);
            _banco.SaveChanges();
        }

        public void ExcluirImagensdoProduto(int ProdutoId)
        {
            List<Imagem> imagens = _banco.Imagens.Where(a => a.ProdutoId == ProdutoId).ToList();

            foreach (Imagem imagem in imagens)
            {
                _banco.Remove(imagem);
            }
            _banco.SaveChanges();
        }


    }
}
