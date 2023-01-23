using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProjectUI.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriter());
		[HttpGet]
		public IActionResult Index()
		{
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "İstanbul", Value = "0" });
            items.Add(new SelectListItem { Text = "Ankara", Value = "1" });
            items.Add(new SelectListItem { Text = "İzmir", Value = "2" });
            items.Add(new SelectListItem { Text = "Antalya", Value = "3" });
            items.Add(new SelectListItem { Text = "Bursa", Value = "4" });
            items.Add(new SelectListItem { Text = "Muğla", Value = "5" });

            ViewBag.sehir = items;
            return View();
		}
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			WriterValidator wv = new WriterValidator();
			ValidationResult results = wv.Validate(writer);
			if (results.IsValid)
			{

				writer.WriteStatus = true;
				writer.WriterAbout = "Test";
				wm.WriterInsert(writer);
				if (writer.WriterPassword == writer.WriterConfirmPassword)
				{
					return RedirectToAction("Index", "Blog");
				}
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

	}
}
