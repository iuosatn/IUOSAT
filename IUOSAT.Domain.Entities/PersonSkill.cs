using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Entities
{
    public class PersonSkill
    {
        public int PersonSkillID { get; set; }
        public int PersonID { get; set; }
        public int SkillID { get; set; }
        public Person Person { get; set; }
        public Skill Skill { get; set; }
    }
}
