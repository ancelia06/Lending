using AutoMapper;
using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
namespace Lending_CapstoneProject.Mapping

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Customer Mappings
            CreateMap<CustomerRegistrationDto, Customer>();
            CreateMap<CustomerProfileDto, Customer>();
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.BranchLocation, opt => opt.MapFrom(src => src.Branch.Location))
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            // Loan Application Mappings
            CreateMap<LoanApplicationDto, LoanApplication>();
            CreateMap<LoanApplication, LoanApplicationDto>()
                .ForMember(dest => dest.SchemeName, opt => opt.MapFrom(src => src.LoanScheme.SchemeName))
                .ForMember(dest => dest.InterestRate, opt => opt.MapFrom(src => src.LoanScheme.InterestRate))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));

            // Loan Officer Mappings
            CreateMap<LoanOfficer, LoanOfficerDto>()
                .ForMember(dest => dest.BranchLocation, opt => opt.MapFrom(src => src.Branch.Location))
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.LoanBank.BankName))
                .ForMember(dest => dest.AssignedApplicationsCount, opt => opt.MapFrom(src => src.AssignedApplications.Count));
            CreateMap<LoanOfficerDto, LoanOfficer>();

            // Loan Scheme Mappings
            CreateMap<LoanScheme, LoanSchemeDto>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.LoanBank.BankName));
            CreateMap<LoanSchemeDto, LoanScheme>()
                .ForMember(dest => dest.LoanBank, opt => opt.Ignore());

            // Repayment Mappings
            CreateMap<Repayment, RepaymentDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.LoanApplication.Customer.Name))
                .ForMember(dest => dest.LoanAmount, opt => opt.MapFrom(src => src.LoanApplication.LoanAmount))
                .ForMember(dest => dest.InstallmentNumber, opt => opt.Ignore())
                    // Add the new members for Principal and Interest
                    .ForMember(dest => dest.PrincipalPaid, opt => opt.MapFrom(src => src.PrincipalPaid))
                    .ForMember(dest => dest.InterestPaid, opt => opt.MapFrom(src => src.InterestPaid));

            // Loan Bank Mappings
            CreateMap<LoanBank, LoanBankDto>();
            CreateMap<LoanBankDto, LoanBank>();

            // Loan Branch Mappings
            CreateMap<LoanBranch, LoanBranchDto>();
            CreateMap<LoanBranchDto, LoanBranch>();


            // User and Login Mappings
            CreateMap<User, UserDto>();
            CreateMap<LoginDto, Customer>();
            CreateMap<LoginDto, LoanOfficer>();
            CreateMap<LoginDto, LoanAdmin>();
            CreateMap<LoginDto, SystemAdministrator>();
        }

    }
}
