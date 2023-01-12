using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.ViewComponents
{
	public class CommentList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
