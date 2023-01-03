using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetBlogListAll();
        void BlogInsert(Blog blog);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);
        Blog GetBlogById(int id);
    }
}
