using System.Diagnostics;
using HTMLCSSLecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTMLCSSLecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index ()
        //{
        //    //var data = new UserDetailsModel
        //    //{
        //    //    Userid = 1,
        //    //    NameOfUser = "John Doe",
        //    //    Email = "sample@email.com",
        //    //    Addresses = new List<string>
        //    //    {
        //    //        "123 Main St, Anytown, USA",
        //    //        "456 Elm St, Othertown, USA",
        //    //        "Address3"
        //    //    }
        //    //};
        //    //return View(data);
        //    return View("Test");
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login(LoginModel model)
        {
            return View("Test");
        }

    }
}
