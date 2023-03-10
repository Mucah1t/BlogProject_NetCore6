using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Comment
	{
		public int CommentID { get; set; }
		public string CommentUserName { get; set; }
		public string CommenTitle { get; set; }
		public string CommenContent { get; set; }
		public DateTime CommentDate { get; set; }
		public bool? CommentStatus { get; set; }
        public int BlogScore { get; set; }


        //RELATIONS
        public int BlogID { get; set; }
        public Blog Blog { get; set; }//--many

    }
}
