using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
	public class AboutController : Controller
	{
		AboutManager am = new AboutManager(new EfAbout());
		public IActionResult Index()
		{
			var values = am.GetAboutListAll();
			return View(values);
		}
		public PartialViewResult SocialMedia()
		{
			
			return PartialView();
		}
	}
}
