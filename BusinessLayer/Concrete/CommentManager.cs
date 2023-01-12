using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager:ICommentService
    {
        ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		public void CommentDelete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public void CommentInsert(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentDal.Update(comment);    
        }

        public Comment GetCommentById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> GetCommentListAll()
        {
            return _commentDal.GetListAll(x=>x.BlogID== 1);
        }
		public List<Comment> GetCommentByIDx(int id)
		{
			return _commentDal.GetListAll(x => x.BlogID == id);
		}
	}
}
