using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Entities
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string Name { get; set; }
        public List<PersonSkill> PersonSkills { get; set; }
    }
}
