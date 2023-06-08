using InterUserManagementAPI.Models;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class InternRepo : IRepo<int, Intern>
    {
        private readonly UserContext _context;

        public InternRepo(UserContext context)
        {
            _context = context;
        }
        public async Task<Intern?> Add(Intern item)
        {
            _context.Interns.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Task<Intern?> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(int key)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == key);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<ICollection<Intern>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Intern?> Update(Intern item)
        {
            throw new NotImplementedException();
        }
    }
}
