using InterUserManagementAPI.Models;
using InterUserManagementAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IRepo<int, User> _userRepo;
        private readonly IRepo<int, Intern> _internRepo;
        private readonly IGeneratePassword _passwordService;
        private readonly ITokenGenerate _tokenService;

        public ManageUserService(IRepo<int, User> userRepo,
            IRepo<int, Intern> internRepo,
            IGeneratePassword passwordService,
            ITokenGenerate tokenService)
        {
            _userRepo = userRepo;
            _internRepo = internRepo;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }
        public Task<USerDTO> ChangeStatus(USerDTO user)
        {
            throw new NotImplementedException();
        }

        public USerDTO Login(USerDTO userDTO)
        {
            USerDTO user = null;
            User userData = _internRepo.Get(userDTO.UserId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.HashKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new USerDTO();
                user.UserId = userData.U;
                user.Role = userData.;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        public async Task<USerDTO> Register(InternDTO intern)
        {

            USerDTO user = null;
            var hmac = new HMACSHA512();
            string? generatedPassword = await _passwordService.GeneratePassword(intern);
            intern.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(generatedPassword??"1234"));
            intern.User.PasswordKey = hmac.Key;
            intern.User.Role = "Intern";
            var userResult = await _userRepo.Add(intern.User);
            var internResult = await _internRepo.Add(intern);
            if (userResult != null && internResult != null)
            {
                user = new USerDTO();
                user.UserId = internResult.Id;
                user.Role = userResult.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;

        }
    }
}
