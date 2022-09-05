using Hospital.Core.Interfaces;

namespace Hospital.Infrastructure
{
    public class FakeEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string to, string from, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}