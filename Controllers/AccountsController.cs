using HTMLCSSLecture.Models;
using HTMLCSSLecture.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace HTMLCSSLecture.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _userService.LoginUser(model);

                if (res)
                {
                    //USERNAME AND PASSWORD MATCH --- REDIRECT

                }
                else
                {
                    //USERNAME AND PASSWORD DO NOT MATCH --- SHOW ERROR
                    ViewBag.Error = "Username & Password does not match";
                    return View(model);

                }

            }

            return View(model);
        }
    }
}
