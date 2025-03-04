using Microsoft.EntityFrameworkCore;
using UserProject.Data;
using UserProject.Model;

namespace UserProject.Repisotry
{
    public class UserRepository 
    {
        private readonly ApiContext _context;
        public UserRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task AddNewUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }


    }
}
