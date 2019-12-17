using LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private string key = "Login.Colaborador";
        private Session.Session _session;
        public LoginColaborador(Session.Session session)
        {
            _session = session;
        }
        public void Login(Colaborador colaborador)
        {
            //Serializar
            string colaboradorJSONString = JsonConvert.SerializeObject(colaborador);
            _session.Cadastrar(key, colaboradorJSONString);
        }

        public Colaborador GetColaborador()
        {
            //Deserializar
            if (_session.Existe(key))
            {
                string colaboradorJSONString = _session.Consultar(key);

                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSONString);
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
