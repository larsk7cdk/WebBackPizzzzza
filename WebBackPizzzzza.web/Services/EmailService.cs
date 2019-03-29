using System.Threading.Tasks;
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
            return await Task.FromResult(true);
        }
    }
}