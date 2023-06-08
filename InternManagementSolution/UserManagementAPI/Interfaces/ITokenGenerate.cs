using InterUserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(USerDTO user);

    }
}
