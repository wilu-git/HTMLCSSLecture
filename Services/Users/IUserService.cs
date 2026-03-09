using HTMLCSSLecture.Models;
using HTMLCSSLecture.Models.Database;

namespace HTMLCSSLecture.Services.Users
{
    public interface IUserService
    {
        Task RegisterUser(RegistrationModel model);
        Task<LoginResponseModel> LoginUser(LoginModel model);

        Task<UserDetail> GetUserDetails(int id);
    }
}
