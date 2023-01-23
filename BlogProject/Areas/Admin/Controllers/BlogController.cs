using BlogProjectUI.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {

            using (var _workbook = new XLWorkbook())
            {
                var _worksheet = _workbook.Worksheets.Add("Blog List");  

                _worksheet.Cell(1, 1).Value = "Blog ID";  
                _worksheet.Cell(1, 2).Value = "Blog Name"; 

                int BlogRowCount = 2;  
                foreach (var item in GetBlogList()) 
                {
                    _worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    _worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    _workbook.SaveAs(stream); // Save
                    var content = stream.ToArray(); 
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Worksheet.xlsx"); 
                }
            }
        }
        public List<BlogModel> GetBlogList()  
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel {Id=1,BlogName="C# Programing"},
                new BlogModel {Id=2,BlogName="Tesla's Car"},
                new BlogModel {Id=3,BlogName="2020 Olimpic Games"}
            };
            return bm;
        }
        public IActionResult BlogListExcel()
        {
            return View();  
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var _workbook = new XLWorkbook())
            {
                var _worksheet = _workbook.Worksheets.Add("Blog List");

                _worksheet.Cell(1, 1).Value = "Blog ID";
                _worksheet.Cell(1, 2).Value = "Blog Name";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    _worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    _worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    _workbook.SaveAs(stream); // Save
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Worksheet.xlsx");
                }
            }
        }
        public List<BlogModel2> BlogTitleList()  
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using (var db = new Context())
            {
                bm = db.Blogs.Select(x => new BlogModel2
                {
                    Id = x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return bm;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
