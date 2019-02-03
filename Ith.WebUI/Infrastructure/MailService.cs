using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ith.WebUI.Infrastructure
{
    /// <summary>
    /// Для того, чтобы отправлять почту через gmail.com нужно после авторизации в аккаунте gmail.com перейти по этой ссылке
    /// и отметить "Небезопасные приложения разрешены" ("Allow less secure apps"):
    /// https://www.google.com/settings/security/lesssecureapps
    /// </summary>
    public class MailService
    {
        public SmtpClient Client = null;
        public string Host = "smtp.gmail.com";
        public int Port = 587;
        public string MailFrom = "MailFrom@gmail.com";
        public string Password = "Password";
        public bool IsBodyHtml = true;
        public List<string> Erors { get; private set; }

        public IdentityMessage Message;

        public Task SendBySmtpAsync()
        {
            try
            {
                // Адрес и порт smtp-сервера, с которого мы и будем отправлять письмо.
                Client = new SmtpClient(Host, Port);
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.UseDefaultCredentials = false;
                Client.Credentials = new System.Net.NetworkCredential(MailFrom, Password);
                Client.EnableSsl = true;

                // Создаем письмо.
                MailMessage mail = new MailMessage(MailFrom, Message.Destination)
                {
                    Subject = Message.Subject,
                    Body = Message.Body,
                    IsBodyHtml = true
                };

                // Отправить письмо.
                return Client.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Erors = new List<string>();
                Erors.Add(ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }
    }
}