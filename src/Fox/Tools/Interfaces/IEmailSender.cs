using Fox.Models;

namespace Fox.Tools.Interfaces
{
    public interface IEmailSender
    {
        void Send(string to, string body, SmtpConfiguration smtp);
    }
}
