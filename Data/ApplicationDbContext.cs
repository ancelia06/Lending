using Microsoft.EntityFrameworkCore;
using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets for all your entities
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanOfficer> LoanOfficers { get; set; }
        public DbSet<LoanAdmin> LoanAdmins { get; set; }
        public DbSet<SystemAdministrator> SystemAdministrators { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<LoanBank> LoanBanks { get; set; }
        public DbSet<LoanBranch> LoanBranches { get; set; }
        public DbSet<LoanScheme> LoanSchemes { get; set; }
        public DbSet<Repayment> Repayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the User inheritance hierarchy (TPH - Table Per Hierarchy)
            modelBuilder.Entity<User>()
                .HasDiscriminator<UserType>(u => u.UserType)
                .HasValue<Customer>(UserType.Customer)
                .HasValue<LoanOfficer>(UserType.LoanOfficer)
                .HasValue<LoanAdmin>(UserType.LoanAdmin)
                .HasValue<SystemAdministrator>(UserType.SystemAdministrator);

            // Configure User relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.LoanBank)
                .WithMany(b => b.Users)
                .HasForeignKey(u => u.LoanBankId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Customer
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Branch)
                .WithMany(b => b.Customers)
                .HasForeignKey(c => c.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure LoanOfficer
            modelBuilder.Entity<LoanOfficer>()
                .HasOne(o => o.Branch)
                .WithMany(b => b.Officers)
                .HasForeignKey(o => o.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure LoanApplication
            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.Customer)
                .WithMany(c => c.LoanApplications)
                .HasForeignKey(la => la.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.LoanOfficer)
                .WithMany(o => o.AssignedApplications)
                .HasForeignKey(la => la.LoanOfficerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.LoanScheme)
                .WithMany()
                .HasForeignKey(la => la.LoanSchemeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure LoanBank
            modelBuilder.Entity<LoanBank>()
                .HasMany(b => b.LoanSchemes)
                .WithOne(s => s.LoanBank)
                .HasForeignKey(s => s.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanBank>()
                .HasMany(b => b.LoanBranches)
                .WithOne(br => br.LoanBank)
                .HasForeignKey(br => br.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure LoanBranch
            modelBuilder.Entity<LoanBranch>()
                .HasOne(br => br.LoanBank)
                .WithMany(b => b.LoanBranches)
                .HasForeignKey(br => br.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure LoanScheme
            modelBuilder.Entity<LoanScheme>()
                .HasOne(s => s.LoanBank)
                .WithMany(b => b.LoanSchemes)
                .HasForeignKey(s => s.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Repayment
            modelBuilder.Entity<Repayment>()
                .HasOne(r => r.LoanApplication)
                .WithMany(la => la.Repayments)
                .HasForeignKey(r => r.LoanApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            // REMOVE THE SEEDING FROM HERE - it causes design-time issues
            // SeedData(modelBuilder); // Comment out or delete this line
        }

        // REMOVE THE SeedData METHOD ENTIRELY or comment it out
        /*
        private void SeedData(ModelBuilder modelBuilder)
        {
            // This causes the error - remove it
        }
        */

    }
}




