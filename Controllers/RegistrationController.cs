using HTMLCSSLecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTMLCSSLecture.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegistrationModel model)
        {
            if(ModelState.IsValid)
            {
                // Process the registration data (e.g., save to database)
                // For demonstration, we will just redirect to a success page
                return Ok("The User Has Been Registered");
            }
            return View(model);
        }


    }
}
