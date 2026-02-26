using HTMLCSSLecture.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace HTMLCSSLecture.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly RegistrationSystemContext _context;

        public UserRepository(RegistrationSystemContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUser(string username)
        {
            return await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        }

        public async Task<UserDetail?> GetUserDetailsById(int userId)
        {
            return await _context.UserDetails.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task RegisterUser(User user, UserDetail userDetail)
        {
            _context.Users.Add(user);

            if (await _context.SaveChangesAsync() > 0)
            {
                userDetail.UserId = user.UserId;
                _context.UserDetails.Add(userDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
