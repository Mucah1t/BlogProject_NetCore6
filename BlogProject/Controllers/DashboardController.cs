using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();

            var username = User.Identity.Name;
            ViewBag.veri = username;

            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId=c.Writers.Where(x=>x.WriterMail==userMail).Select(y=>y.WriterID).FirstOrDefault();

            ViewBag.v1=c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerId).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
