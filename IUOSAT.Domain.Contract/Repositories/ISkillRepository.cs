using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Contract.Repositories
{
    public interface ISkillRepository
    {
        List<Skill> GetAll();
        void SaveSkill(Skill Skill);
        void DeleteSkill(int SkillID);
        Skill GetById(int SkillID);
        List<Skill> Find(string query);
    }
}
