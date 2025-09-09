namespace Lending_CapstoneProject.Models
{
    public enum UserType
    {
        Customer,
        LoanOfficer,
        LoanAdmin
    }

    public enum ApplicationStatus
    {
        Pending,
        Approved,
        Rejected,
        UnderReview
    }

    public enum LoanType
    {
        Home,
        Personal,
        Education,
        Business
    }

    public enum RepaymentMethod
    {
        Online,
        Cheque,
        Cash,
        AutoDebit
    }
}
    
