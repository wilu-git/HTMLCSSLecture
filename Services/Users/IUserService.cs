using HTMLCSSLecture.Models;

namespace HTMLCSSLecture.Services.Users
{
    public interface IUserService
    {
        Task<bool> RegisterUser(RegistrationModel model);
        Task<bool> LoginUser(LoginModel model);

    }
}
