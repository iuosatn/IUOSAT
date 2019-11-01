using System;
using System.Collections.Generic;
using System.Text;


namespace IUOSAT.Domain.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public int CategoryID { get; set; }
        public int CourceID { get; set; }
        public int GradeID { get; set; }
        public string PersianFullName { get; set; }
        public string EnglishFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PersianBio { get; set; }
        public string EnglishBio { get; set; }
        public string PersianAddress { get; set; }
        public string EnglishAddress { get; set; }
        public string WebSite { get; set; }    
        public string Facebook { get; set; }      
        public string Twitter { get; set; }      
        public string Instagram { get; set; }

        public string Pinteret { get; set; }      
        public byte[] Image { get; set; }
        public Cource Cource { get; set; }
        public Grade Grade { get; set; }
        public Category Category { get; set; }
        public List<PersonSkill> PersonSkills { get; set; }
    }
}
