using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Contract.Repositories
{
    public interface IPersonSkillRepository
    {
        List<PersonSkill> GetAll();
        void SavePersonSkill(PersonSkill PersonSkill);
        void DeletePersonSkill(int PersonSkillID);
        PersonSkill GetById(int PersonSkillID);
       
    }
}
