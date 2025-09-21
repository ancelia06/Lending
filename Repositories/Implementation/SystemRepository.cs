using Lending_CapstoneProject.Data;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace Lending_CapstoneProject.Repositories.Implementation
{
    public class SystemRepository : ISystemRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSystemAdministratorAsync(SystemAdministrator systemAdmin)
        {
            await _context.SystemAdministrators.AddAsync(systemAdmin);
            await _context.SaveChangesAsync();
        }

        public async Task<SystemAdministrator> GetSystemAdministratorByIdAsync(int id)
        {
            return await _context.SystemAdministrators.FindAsync(id);
        }

        public async Task<bool> UpdateSystemAdministratorAsync(SystemAdministrator systemAdmin)
        {
            _context.Entry(systemAdmin).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemAdministratorExists(systemAdmin.UserId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteSystemAdministratorAsync(int id)
        {
            var systemAdmin = await _context.SystemAdministrators.FindAsync(id);
            if (systemAdmin == null)
            {
                return false;
            }

            _context.SystemAdministrators.Remove(systemAdmin);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool SystemAdministratorExists(int id)
        {
            return _context.SystemAdministrators.Any(e => e.UserId == id);
        }

    }
}

