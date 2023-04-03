using GestiuneSaliNET7.Data;
using GestiuneSaliNET7.Models;
using Microsoft.EntityFrameworkCore;

namespace GestiuneSaliNET7.Repository
{
    public class AuthenticateLogin : ILogin
    {
        private readonly ApplicationDBContext _context;

        public AuthenticateLogin(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<UserModel> AuthenticateUser(string email, string passcode)
        {
            var succeeded = await _context.Users.FirstOrDefaultAsync(authUser => authUser.Email == email && authUser.Password == passcode);
            return succeeded;
        }

        public async Task<IEnumerable<UserModel>> getuser()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
