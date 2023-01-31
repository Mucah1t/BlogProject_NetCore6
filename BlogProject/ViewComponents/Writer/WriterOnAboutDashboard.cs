using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.ViewComponents.Writer
{
    [AllowAnonymous]
    public class WriterOnAboutDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriter());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;

            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
           
            var values = wm.GetWriterByID(writerId );
            return View(values);
        }
    }
}
