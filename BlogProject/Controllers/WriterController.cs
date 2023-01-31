using BlogProjectUI.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriter());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;

            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;

            return View();
        }

        public IActionResult Inddex()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult WriterEditProfile()
        {
            Context c = new Context();

            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            UserManager userManager = new UserManager(new EfUser());
            //var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            //var writerValues = wm.GetById(writerId);
            //return View(writerValues);

            var id=c.Users.Where(x=>x.Email==userMail).Select(y=>y.Id).FirstOrDefault();
            var values = userManager.GetById(id);
            return View(values);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            WriterValidator w1 = new WriterValidator();
            ValidationResult results = w1.Validate(p);
            if (results.IsValid)
            {
                wm.Update(p);
                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage!=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName=Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;

            }
            w.WriterMail = p.WriterMail;
            w.WriterName= p.WriterName;
            w.WriterPassword= p.WriterPassword;
            w.WriteStatus = true;
            w.WriterAbout = p.WriterAbout;

            wm.Insert(w);
            return View("Index","Dashboard");
        }
    }
}
