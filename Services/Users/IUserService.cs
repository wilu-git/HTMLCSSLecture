using HTMLCSSLecture.Models;

namespace HTMLCSSLecture.Services.Users
{
    public interface IUserService
    {
        Task RegisterUser(RegistrationModel model);
        Task<bool> LoginUser(LoginModel model);

    }
}
