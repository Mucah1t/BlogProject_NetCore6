using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.ViewComponents.Comment
{
	public class CommentListByBlog:ViewComponent
	{
		CommentManager cm = new CommentManager(new EfComment());
		public IViewComponentResult Invoke(int id)
		{
			var values = cm.GetCommentByIDx(id);
			return View(values);
		}
	}
}
