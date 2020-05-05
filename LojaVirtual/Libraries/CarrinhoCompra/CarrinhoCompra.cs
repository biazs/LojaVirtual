using System.Collections.Generic;
using System.Linq;
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

        public void Cadastrar(Item item)
        {
            List<Item> Lista;
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
                Lista = new List<Item>();
                Lista.Add(item);
            }

            Salvar(Lista);
        }

        public void Atualizar(Item item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

            if (ItemLocalizado != null)
            {
                ItemLocalizado.Quantidade = item.Quantidade;
                Salvar(Lista);
            }
        }

        public void Remover(Item item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

            if (ItemLocalizado != null)
            {
                Lista.Remove(ItemLocalizado);
                Salvar(Lista);
            }
        }

        public List<Item> Consultar()
        {
            if (_cookie.Existe(key))
            {
                string valor = _cookie.Consultar(key);
                return JsonConvert.DeserializeObject<List<Item>>(valor);
            }
            else
            {
                return new List<Item>();
            }
        }

        public void Salvar(List<Item> Lista)
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

    public class Item
    {
        public int? Id { get; set; }
        public int? Quantidade { get; set; }
    }
}

