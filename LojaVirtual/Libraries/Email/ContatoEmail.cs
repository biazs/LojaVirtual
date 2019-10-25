using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 5222);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("email@gmail.com","");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - Loja Virtual</h2" +
                "<b>Nome</b> {0} <br />" +
                "<b>E-mail</b> {1} <br />" +
                "<b>Texto</b> {2} <br />" +
                "<br />Email enviado automaticamente do site - Loja Virtual.",
                contato.Nome, contato.Email, contato.Texto
                );

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("email@gmail.com");
            mensagem.To.Add("email@gmail.com");
            mensagem.Subject = "Contato - LojaVirtual";
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            smtp.Send(mensagem);
        }
    }
}
