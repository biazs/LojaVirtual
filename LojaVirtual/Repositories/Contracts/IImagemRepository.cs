using System.Collections.Generic;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IImagemRepository
    {
        void CadastrarImagens(List<Imagem> ListaImagens, int ProdutoId);
        void Cadastrar(Imagem imagem);
        void Excluir(int Id);
        void ExcluirImagensdoProduto(int ProdutoId);
    }
}
