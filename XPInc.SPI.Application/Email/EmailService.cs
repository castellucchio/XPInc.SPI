using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Microsoft.Extensions.Options;
using XPInc.SPI.Adapters.UseCases.Products;
using System.Text;
using XPInc.SPI.Entities.Models;
using System.Net.Http;

namespace XPInc.SPI.Application.Email
{
    public class EmailService : IEmailService
    {
        private readonly IFinantialProductService _finantialProductService;
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings, IFinantialProductService finantialProductService)
        {
            _emailSettings = emailSettings.Value;
            _finantialProductService = finantialProductService;
        }
        public async Task SendEmailAsync()
        {
            var expiringProducts = await _finantialProductService.GetExpiringProducts();

            if (expiringProducts.Any())
            {

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.Mail));
                message.To.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.Mail));
                message.Subject = "XPInc.SPI Notificação | Produtos financeiros com vencimento próximo";
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = GetHtmlContent(expiringProducts);
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect(_emailSettings.Host, 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(_emailSettings.Mail, _emailSettings.Password);

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }

        private string GetHtmlContent(IEnumerable<FinantialProduct> products)
        {
            var sb = new StringBuilder();

            sb.AppendLine(@"
                <!DOCTYPE html>
                <html lang=""pt-BR"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Produtos Próximos da Data de Vencimento</title>
                </head>
                <body>
                    <h1>Produtos Próximos da Data de Vencimento</h1>
                    <p>Confira os detalhes dos produtos que estão se aproximando da data de vencimento:</p>
                    <table border=""1"">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Nome</th>
                                <th>Descrição</th>
                                <th>Tipo</th>
                                <th>Preço</th>
                                <th>Data de Vencimento</th>
                            </tr>
                        </thead>
                        <tbody>");

            foreach (var product in products)
            {
                sb.AppendLine($@"
                    <tr>
                        <td>{product.Id}</td>
                        <td>{product.Name}</td>
                        <td>{product.Description}</td>
                        <td>{product.Type}</td>
                        <td>R$ {product.Price:F2}</td>
                        <td>{product.ExpireDate?.ToString("dd/MM/yyyy")}</td>
                    </tr>");
            }

            sb.AppendLine(@"
                        </tbody>
                    </table>
                </body>
                </html>");

            return sb.ToString();
        }
    }
}
