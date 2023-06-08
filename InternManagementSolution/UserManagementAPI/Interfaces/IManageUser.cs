using InterUserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface IManageUser
    {
        public Task<USerDTO> Login(USerDTO user);
        public Task<USerDTO> Register(InternDTO intern);
        public Task<USerDTO> ChangeStatus(USerDTO user);
    }
}
