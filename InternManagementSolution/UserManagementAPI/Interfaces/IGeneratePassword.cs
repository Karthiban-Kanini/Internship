using InterUserManagementAPI.Models;

namespace UserManagementAPI.Interfaces
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Intern intern);

    }
}
