using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfComment());
        public IActionResult Index()
        {
            var values = cm.GetListWithBlog();
            return View(values);
        }
    }
}
