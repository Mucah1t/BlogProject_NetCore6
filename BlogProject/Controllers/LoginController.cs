using BlogProjectUI.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProjectUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        //      [HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //	Context c = new Context();
        //	var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        //          if (dataValue != null) 
        //          {
        //              var claims = new List<Claim>
        //              {
        //                  new Claim(ClaimTypes.Name,writer.WriterMail)
        //              };
        //              var userIdentity = new ClaimsIdentity(claims,"a");
        //              ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //              await HttpContext.SignInAsync(principal);

        //              return RedirectToAction("Index", "Dashboard");
        //          }
        //          else
        //          {
        //              return View();
        //          }
        //}
    }
}

