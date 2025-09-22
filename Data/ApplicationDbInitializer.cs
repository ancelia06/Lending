using Lending_CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;


namespace Lending_CapstoneProject.Data
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if data already exists
            if (context.LoanBanks.Any())
            {
                return; // DB has been seeded
            }

            // Seed LoanBank first
            var mainBank = new LoanBank
            {
                BankName = "Main Lending Bank",
                Address = "123 Financial District, Mumbai"
            };
            context.LoanBanks.Add(mainBank);
            context.SaveChanges(); // Save to get the BankId

            // Seed LoanSchemes
            var schemes = new LoanScheme[]
            {
                new LoanScheme
                {
                    SchemeName = "Home Loan Basic",
                    InterestRate = 8.5m,
                    MinCreditScore = 650,
                    BankId = mainBank.BankId
                },
                new LoanScheme
                {
                    SchemeName = "Personal Loan Express",
                    InterestRate = 12.0m,
                    MinCreditScore = 600,
                    BankId = mainBank.BankId
                }
            };
            context.LoanSchemes.AddRange(schemes);

            // Seed Admin user
            var admin = new LoanAdmin
            {
                UserName = "admin",
                Email = "admin@lending.com",
                PasswordHash = "hashed_password_here", // Use password hasher in real scenario
                UserType = UserType.LoanAdmin,
                LoanBankId = mainBank.BankId,
                AdminRole = "Super Admin"
            };
            context.Users.Add(admin);

            context.SaveChanges();
        }
    }
}
