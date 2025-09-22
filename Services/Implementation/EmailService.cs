using Lending_CapstoneProject.Repositories.Implementation;
using Lending_CapstoneProject.Repositories.Interface;
using Lending_CapstoneProject.Services.Interface;
using System.Net;
using System.Net.Mail;


namespace Lending_CapstoneProject.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IRepaymentRepository _repaymentRepository;
        public EmailService(IRepaymentRepository repaymentRepository)
        {
            _repaymentRepository = repaymentRepository;
        }

        /// <summary>
        /// Sends a reminder email for loan installments that are due in one week.
        /// This method fulfills the FR4.2 system requirement.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task SendLoanReminderEmailsAsync()
        {
            // Find all repayments due exactly one week from today's date.
            var upcomingRepayments = (await _repaymentRepository.GetAllRepaymentsAsync())
                .Where(r => r.DueDate.Date == DateTime.Now.AddDays(7).Date);

            if (!upcomingRepayments.Any())
            {
                Console.WriteLine("No loan repayments are due in one week. No emails sent.");
                return;
            }

            Console.WriteLine("Initiating daily email reminder service...");

            // Replace these with your actual SMTP server credentials from appsettings.json or a secure source.
            // This is a simplified example.
            string smtpServer = "smtp.your-server.com";
            int port = 587;
            string username = "your-email@your-domain.com";
            string password = "your-email-password";

            using (SmtpClient client = new SmtpClient(smtpServer, port))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(username, password);

                foreach (var repayment in upcomingRepayments)
                {
                    try
                    {
                        var mailMessage = new MailMessage
                        {
                            From = new MailAddress("no-reply@lendingapp.com", "Lending App"),
                            Subject = "Upcoming Loan Repayment Reminder",
                            Body = $"Dear {repayment.LoanApplication.Customer.UserName},\n\nYour next loan payment of {repayment.PrincipalPaid + repayment.InterestPaid} is due on {repayment.DueDate.ToShortDateString()}.\n\nThank you,\nLending App Team",
                            IsBodyHtml = false
                        };
                        mailMessage.To.Add(repayment.LoanApplication.Customer.Email);

                        await client.SendMailAsync(mailMessage);
                        Console.WriteLine($"Successfully sent reminder email to {repayment.LoanApplication.Customer.Email}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to send email to {repayment.LoanApplication.Customer.Email}. Error: {ex.Message}");
                    }
                }
            }

            Console.WriteLine("Email reminder service completed.");
        }


    }



}
