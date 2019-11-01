using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IUOSAT.DAL.EF.Repositories
{
    public class EFPersonSkillRepository : IPersonSkillRepository
    {
        private readonly ApplicationContext _context;

        public EFPersonSkillRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void DeletePersonSkill(int PersonSkillID)
        {
            List<PersonSkill> properties = _context.PersonSkills.Where(p => p.PersonSkillID == PersonSkillID).ToList();
            foreach (PersonSkill personSkill in properties)
            {
                _context.PersonSkills.Remove(personSkill);
                _context.SaveChanges();
            }
        }

      

        public List<PersonSkill> GetAll()
        {
            return _context.PersonSkills.ToList();
        }

        public PersonSkill GetById(int PersonSkillID)
        {
            return _context.PersonSkills.Find(PersonSkillID);
        }

        public void SavePersonSkill(PersonSkill PersonSkill)
        {
            if (PersonSkill.PersonSkillID == 0)
            {
                _context.PersonSkills.Add(PersonSkill);
            }
            
            _context.SaveChanges();
        }
    }
}
