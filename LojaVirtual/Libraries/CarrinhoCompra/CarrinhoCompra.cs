using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Models.ProdutoAgregador;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.CarrinhoCompra
{

    public class CarrinhoCompra
    {
        private string key = "Carrinho.Compras";
        private Cookie.Cookie _cookie;
        public CarrinhoCompra(Cookie.Cookie cookie)
        {
            _cookie = cookie;
        }

        /* Adicionar item, remover item, alterar quantidade*/

        public void Cadastrar(ProdutoItem item)
        {
            List<ProdutoItem> Lista;
            if (_cookie.Existe(key))
            {
                Lista = Consultar();
                var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);
                if (ItemLocalizado == null)
                {
                    Lista.Add(item);
                }
                else
                {
                    ItemLocalizado.Quantidade = ItemLocalizado.Quantidade + 1;
                }

            }
            else
            {
                Lista = new List<ProdutoItem>();
                Lista.Add(item);
            }

            Salvar(Lista);
        }

        public void Atualizar(ProdutoItem item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

            if (ItemLocalizado != null)
            {
                ItemLocalizado.Quantidade = item.Quantidade;
                Salvar(Lista);
            }
        }

        public void Remover(ProdutoItem item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

            if (ItemLocalizado != null)
            {
                Lista.Remove(ItemLocalizado);
                Salvar(Lista);
            }
        }

        public List<ProdutoItem> Consultar()
        {
            if (_cookie.Existe(key))
            {
                string valor = _cookie.Consultar(key);
                return JsonConvert.DeserializeObject<List<ProdutoItem>>(valor);
            }
            else
            {
                return new List<ProdutoItem>();
            }
        }

        public void Salvar(List<ProdutoItem> Lista)
        {
            string Valor = JsonConvert.SerializeObject(Lista);
            _cookie.Cadastrar(key, Valor);
        }

        public bool Existe(string key)
        {
            if (_cookie.Existe(key))
            {
                return false;
            }

            return true;
        }

        public void RemoverTodos()
        {
            _cookie.Remover(key);
        }

    }

}

