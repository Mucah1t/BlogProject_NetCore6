using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.ViewComponents.Blog
{
	public class WriterRecentBlog:ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlog());

		public IViewComponentResult Invoke()
		{
			var values = bm.GetListWithWriter(2);
			return View(values);
		}
	}
}
