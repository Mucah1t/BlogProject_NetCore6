using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace BlogProjectUI.Controllers
{
 
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlog());
        CategoryManager cm = new CategoryManager(new EfCategory());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var vList = bm.GetListWithCategory();
            return View(vList);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByIDx(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            var values = bm.GetListWithCategoryByWriterBM(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value=x.CategoryID.ToString()

                                                    }).ToList();
            ViewBag.c = categoryvalues;

            return View();

        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {

            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {

                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerId;
                bm.Insert(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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
        public IActionResult DeleteBlog(int id)
        {
            var vDelete = bm.GetBlogById(id);
            bm.Delete(vDelete);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();
            ViewBag.c = categoryvalues;
            var vUpdate = bm.GetBlogById(id);
            return View(vUpdate);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            var value = bm.GetBlogById(blog.BlogID);
            blog.WriterID = writerId;
            blog.BlogCreateDate= DateTime.Parse(value.BlogCreateDate.ToString());
            blog.BlogStatus = true;
            bm.Update(blog);
            return RedirectToAction("BlogListByWriter");

        }



    }
}
