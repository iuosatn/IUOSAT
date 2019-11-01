using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IUOSAT.DAL.EF.Repositories
{
    public class EFGradeRepository: IGradeRepository   
    {
        private readonly ApplicationContext _context;

        public EFGradeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteGrade(int GradeID)
        {
            List<Grade> properties = _context.Grades.Where(p => p.GradeID == GradeID).ToList();
            foreach (Grade grade in properties)
            {
                _context.Grades.Remove(grade);
                _context.SaveChanges();
            }
        }

        public List<Grade> Find(string query)
        {
            return _context.Grades.Where(c => c.Name == query).ToList();
        }

        public List<Grade> GetAll()
        {
            return _context.Grades.ToList();
        }

        public Grade GetById(int GradeID)
        {
            return _context.Grades.Find(GradeID);
        }

        public void SaveGrade(Grade Grade)
        {
            if (Grade.GradeID == 0)
            {
                _context.Grades.Add(Grade);
            }
            else
            {
                Grade dbEntry = _context.Grades
                .FirstOrDefault(p => p.GradeID == Grade.GradeID);
                if (dbEntry != null)
                {
                    dbEntry.Name = Grade.Name;
                   

                }
            }
            _context.SaveChanges();
        }
    }
}
