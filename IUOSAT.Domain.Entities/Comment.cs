using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int ParentID { get; set; }
        public int ArticleID { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public Article Article { get; set; }
    }
}
