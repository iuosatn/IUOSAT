using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Entities
{
    public class Cource
    {
        public int CourceID { get; set; }
        public string PersianName { get; set; }
        public string EnglishName { get; set; }
        public List<Article> Articles { get; set; }
    }
}
