using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager:IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public Blog GetBlogById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetBlogListAll()
        {
            return _blogDal.GetListAll();
        }
		public List<Blog> GetBlogByIDx(int id)
		{
			return _blogDal.GetListAll(x=>x.BlogID==id);
		}

		public List<Blog> GetListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}
        public List<Blog> GetListWithCategoryByWriterBM(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }


        public List<Blog> GetListWithWriter(int id)
		{
            return _blogDal.GetListAll(x => x.WriterID == id);
		}

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public void Insert(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
