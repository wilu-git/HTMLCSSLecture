using HTMLCSSLecture.Models;
using HTMLCSSLecture.Repositories.Users;
using HTMLCSSLecture.Models.Database;
using HTMLCSSLecture.Helpers;

namespace HTMLCSSLecture.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> LoginUser(LoginModel model)
        {
            var userData = await _repo.GetUser(model.Username);
            if (userData == null)
            {
                return false;
            }

            var isPwMatch = SecurityHelper.VerifyPassword(model.Password, userData.Password);

            return isPwMatch;

            //return SecurityHelper.VerifyPassword(model.Password, userData.Password);
        }   

        public async Task RegisterUser(RegistrationModel model)
        {
            try
            {
                //TODO: Create Password Hasher and EMAIL Encrypter
                var user = new User
                {
                    Username = model.Username,
                    Password = SecurityHelper.HashPassword(model.Password),//Make hash password before inputting it to the database
                    DateCreated = DateTime.Now
                };

                var userDetails = new UserDetail
                {
                    Email = SecurityHelper.EncryptionEmail(model.Email),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateCreated = DateTime.Now
                };

                await _repo.RegisterUser(user, userDetails);
            }
            catch(Exception ex)
            {
                throw new Exception("Unknown Error");
                //TODO: Log the exception
            }

            var userData = await _repo.GetUser(model.Username);
            if (userData != null)
            {
                throw new Exception("Username already exists");
            }

                       
        }
    }
}
