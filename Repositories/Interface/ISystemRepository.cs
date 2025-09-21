using Lending_CapstoneProject.Models;

namespace Lending_CapstoneProject.Repositories.Interface
{
    public interface ISystemRepository
    {

        Task AddSystemAdministratorAsync(SystemAdministrator systemAdmin);
        Task<SystemAdministrator> GetSystemAdministratorByIdAsync(int id);
        Task<bool> UpdateSystemAdministratorAsync(SystemAdministrator systemAdmin);
        Task<bool> DeleteSystemAdministratorAsync(int id);

    }
}
