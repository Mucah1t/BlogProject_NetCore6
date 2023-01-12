using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
	public class EfBlog : GenericRepository<Blog>, IBlogDal
	{
		public List<Blog> GetListWithCategory()
		{
			using(var db= new Context())
			{
				return db.Blogs.Include(x=>x.Category).ToList();
			}
		}

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var db = new Context())
            {
                return db.Blogs.Include(x => x.Category).Where(x=>x.WriterID== id).ToList();
            }
        }
    }
}
