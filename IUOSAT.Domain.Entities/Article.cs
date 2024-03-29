﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        public int PersonID { get; set; }
        public int CourceID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string Body { get; set; }
        public string GithubUrl { get; set; }
        public Cource Cource { get; set; }
        public Person Person { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
