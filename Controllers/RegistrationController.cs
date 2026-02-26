using HTMLCSSLecture.Models;
using HTMLCSSLecture.Repositories.Users;
using HTMLCSSLecture.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HTMLCSSLecture.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserService _service;
        public RegistrationController(IUserRepository userRepository)
        {
            _service = new UserService(userRepository);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegistrationModel model)
        {
            if(ModelState.IsValid)
            {
                // Process the registration data (e.g., save to database)
                // For demonstration, we will just redirect to a success page
                var res = await _service.RegisterUser(model);
                if (res)
                {
                    ViewBag.SuccessMessage = "'User registered successfully!'";
                }
                else
                {
                    ViewBag.ErrorMessage = "'Something went Wrong!'";
                }

                    return View();
            }
            return View(model);
        }


    }
}
