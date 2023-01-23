using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.ViewComponents.Writer
{
    [AllowAnonymous]
    public class WriterOnAboutDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriter());
        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
           
            var values = wm.GetWriterByID(writerId );
            return View(values);
        }
    }
}
