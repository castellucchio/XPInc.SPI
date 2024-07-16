using XPInc.SPI.Application.Email;

namespace XPInc.SPI.Workers.Workers
{
    public class EmailNotificationBackgroundJob
    {
        private readonly IEmailService _emailService;

        public EmailNotificationBackgroundJob(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Execute()
        {
            await _emailService.SendEmailAsync();
        }
    }
}
