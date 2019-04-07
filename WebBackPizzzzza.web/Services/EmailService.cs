using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using WebBackPizzzzza.web.Models;

namespace WebBackPizzzzza.web.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailModel email);
    }

    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmail(EmailModel email)
        {
            return await Task.Run(() =>
            {
                using (var client = new SmtpClient())
                {
                    client.Connect("asmtp.unoeuro.com", 8080, SecureSocketOptions.None);

                    client.Authenticate("xxx", "xxx");

                    var options = FormatOptions.Default.Clone();

                    if (client.Capabilities.HasFlag(SmtpCapabilities.UTF8))
                        options.International = true;

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Pizzzza", "pizzzza@pizzzza.com"));
                    message.To.Add(new MailboxAddress("", email.MailTo));
                    message.Subject = "Din ordre er modtaget";

                    client.Send(options, message);

                    client.Disconnect(true);

                    return true;
                }
            });
        }
    }
}