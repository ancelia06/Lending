namespace Lending_CapstoneProject.Models
{
    public enum UserType
    {
        Customer,
        LoanAdmin,
        SystemAdministrator,
        LoanOfficer
    }


    public enum ApplicationStatus
    {
        Pending,
        Approved,
        Rejected,
        Disbursed,
        Repaid,
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
