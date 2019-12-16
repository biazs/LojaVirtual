using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Session;
using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string key = "Login.cliente";
        private Session.Session _session;
        public LoginCliente(Session.Session session)
        {
            _session = session;
        }
        public void Login(Cliente cliente)
        {
            //Serializar
            string clienteJSONString = JsonConvert.SerializeObject(cliente);
            _session.Cadastrar(key, clienteJSONString);
        }

        public Cliente GetCliente()
        {
            //Deserializar
            if(_session.Existe(key))
            {
                string clienteJSONString = _session.Consultar(key);

                return JsonConvert.DeserializeObject<Cliente>(clienteJSONString);
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _session.RemoverTodos();
        }

    }
}
