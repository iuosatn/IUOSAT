using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IUOSAT.DAL.EF.Repositories
{
    public class EFSkillRepository : ISkillRepository
    {
        private readonly ApplicationContext _context;

        public EFSkillRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void DeleteSkill(int SkillID)
        {
            List<Skill> properties = _context.Skills.Where(p => p.SkillID == SkillID).ToList();
            foreach (Skill skill in properties)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }
        }

        public List<Skill> Find(string query)
        {
            return _context.Skills.Where(c=>c.Name==query).ToList();
        }

        public List<Skill> GetAll()
        {
            return _context.Skills.ToList();
        }

        public Skill GetById(int SkillID)
        {
            return _context.Skills.Find(SkillID);
        }

        public void SaveSkill(Skill Skill)
        {
            if (Skill.SkillID == 0)
            {
                _context.Skills.Add(Skill);
            }
            else
            {
                Skill dbEntry = _context.Skills
                .FirstOrDefault(p => p.SkillID == Skill.SkillID);
                if (dbEntry != null)
                {
                    dbEntry.Name = Skill.Name;
                    
                }
            }
            _context.SaveChanges();

        }
    }
}
