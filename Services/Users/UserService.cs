using HTMLCSSLecture.Models;
using HTMLCSSLecture.Repositories.Users;
using HTMLCSSLecture.Models.Database;

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

            //TODO: CREATE PASSWORD HASHER 

            return (userData.Password == model.Password);

        }   

        public async Task RegisterUser(RegistrationModel model)
        {
            var userData = await _repo.GetUser(model.Username);
            if (userData != null)
            {
                throw new Exception("Username already exists");
            }

            //TODO: Create Password Hasher and EMAIL Encrypter
            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                DateCreated = DateTime.Now
            };

            var userDetails = new UserDetail
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateCreated = DateTime.Now
            };

            await _repo.RegisterUser(user, userDetails);
            

            
        }
    }
}
