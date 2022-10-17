using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoAppUi.Models.Context;
using TodoAppUi.ViewModels;

namespace TodoAppUi.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
   

        public UserController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInViewModel signInViewModel)
        {
            return null;
        }
       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)

        {
            

            if (ModelState.IsValid)
            {
                var isUser = _context.Users.FirstOrDefault(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);

                if (isUser != null)
                {
                    List<Claim> userClaims = new List<Claim>();

                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.Id.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName));
                  
                 

                    //Veritabanımızdaki role tablosunda kullanıcı hakkında roller varsa onlarıda ekliyoruz
                    //Farzedelim,  fcakiroglu16@outlook.com adlı email admin rolüne sahip,

                    if (isUser.Email == "f-cakiroglu@outlook.com")
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }
                    //Veritabanımızdaki claim tablosunda kullanıcı hakkında claim'ler varsa onlarıda ekliyoruz.

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = loginViewModel.IsRememberMe
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(claimsIdentity),
        authProperties);
                    return RedirectToAction("Index","Todo");
                    //Sadece üye olan kullanıcıların göreceği sayfaya yönlendirme
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }
            }

            return View(loginViewModel);
        }
    }
}
