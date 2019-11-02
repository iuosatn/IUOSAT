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
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Article Article { get; set; }
        public bool MarkShipped { get; set; }
    }
}
