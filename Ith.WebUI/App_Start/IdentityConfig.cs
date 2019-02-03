using Ith.WebUI.Infrastructure;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Ith.WebUI.App_Start
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            MailService EmailSender = new MailService();
            EmailSender.MailFrom = System.Configuration.ConfigurationManager.AppSettings["Email"];
            EmailSender.Password = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"];
            EmailSender.Message = message;
            Task TaskResult = EmailSender.SendBySmtpAsync();
            return TaskResult;
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Подключите здесь службу SMS, чтобы отправить текстовое сообщение.
            return Task.FromResult(0);
        }
    }
}