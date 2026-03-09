using HTMLCSSLecture.Models;
using HTMLCSSLecture.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Claims;
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
                    var claims = new List<Claim>
                    {
                        new Claim (ClaimTypes.Name, model.Username),
                        new Claim(ClaimTypes.NameIdentifier, model.Username)
                    };
                    //USERNAME AND PASSWORD MATCH --- REDIRECT
                    var identity = new ClaimsIdentity(claims, 
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    //6 overloads 
                    //1 => Within controller
                    //2 => Punta siya
                    return RedirectToAction("Index", "Home");
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
