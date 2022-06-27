using ServerApi.Models;
using System.Threading.Tasks;

namespace ServerApi
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
