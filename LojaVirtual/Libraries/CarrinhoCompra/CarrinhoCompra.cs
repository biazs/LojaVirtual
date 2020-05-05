using System.Collections.Generic;
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
            if (_cookie.Existe(key))
            {

            }
            else
            {

            }
        }

        //public void Atualizar(string key, string Valor)
        //{
        //    if (Existe(key))
        //        Remover(key);
        //    Cadastrar(key, Valor);
        //}

        //public void Remover(string key)
        //{
        //    _context.HttpContext.Response.Cookies.Delete(key);
        //}

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
        //public bool Existe(string key)
        //{
        //    if (_context.HttpContext.Request.Cookies[key] == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public void RemoverTodos()
        //{
        //    var ListaCookie = _context.HttpContext.Request.Cookies.ToList();
        //    foreach (var cookie in ListaCookie)
        //    {
        //        Remover(cookie.Key);
        //    }
        //}





    }

    public class Item
    {
        public int? Id { get; set; }
        public int? Quantidade { get; set; }
    }
}

