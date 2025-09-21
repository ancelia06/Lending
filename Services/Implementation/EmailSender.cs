//using Lending_CapstoneProject.Services.Interface;
//using System.Net;
//using System.Net.Mail;

//namespace Lending_CapstoneProject.Services.Implementation
//{
//    public class EmailSender:IEmailService
//    {
//        private readonly IConfiguration _configuration;

//        public EmailSender(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public async Task SendEmailAsync(string toEmail, string subject, string message)
//        {
//            var senderEmail = _configuration["SmtpSettings:SenderEmail"];
//            var senderPassword = _configuration["SmtpSettings:Password"];
//            var smtpServer = _configuration["SmtpSettings:Server"];
//            var smtpPort = int.Parse(_configuration["SmtpSettings:Port"]);

//            using (var client = new SmtpClient(smtpServer, smtpPort))
//            {
//                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
//                client.EnableSsl = true;

//                var mailMessage = new MailMessage
//                {
//                    From = new MailAddress(senderEmail, _configuration["SmtpSettings:SenderName"]),
//                    Subject = subject,
//                    Body = message,
//                    IsBodyHtml = true
//                };

//                mailMessage.To.Add(toEmail);

//                await client.SendMailAsync(mailMessage);
//            }
//        }
//    }
//}
