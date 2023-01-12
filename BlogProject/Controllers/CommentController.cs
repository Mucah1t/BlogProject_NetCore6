using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfComment());


		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();	
		}
		[HttpPost]
		public PartialViewResult PartialAddComment(Comment comment)
		{
			comment.CommentDate= DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;
			comment.BlogID = 4;
			cm.CommentInsert(comment);
			return PartialView();
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetCommentByIDx(id);
			return PartialView(values);
		}
	}
}
