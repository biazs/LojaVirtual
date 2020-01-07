using LojaVirtual.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class GerenciarEmail
    {
        private SmtpClient _smtp;
        private IConfiguration _configuration;
        public GerenciarEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }
        public void EnviarContatoPorEmail(Contato contato)
        {

            string corpoMsg = string.Format("<h2>Contato - Loja Virtual</h2" +
                "<b>Nome</b> {0} <br />" +
                "<b>E-mail</b> {1} <br />" +
                "<b>Texto</b> {2} <br />" +
                "<br />Email enviado automaticamente do site - Loja Virtual.",
                contato.Nome, contato.Email, contato.Texto
                );

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(_configuration.GetValue<string>("Email: UserName"));
            mensagem.To.Add("email@gmail.com");
            mensagem.Subject = "Contato - LojaVirtual";
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            _smtp.Send(mensagem);
        }
    }
}
