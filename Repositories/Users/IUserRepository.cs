using HTMLCSSLecture.Models.Database;

namespace HTMLCSSLecture.Repositories.Users
{
    public interface IUserRepository
    {
        Task RegisterUser(User user, UserDetail userDetail);

        Task<User?> GetUser(string username);

        Task<UserDetail?> GetUserDetailsById(int userId);



    }
}
