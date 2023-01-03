using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
