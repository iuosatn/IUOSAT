using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IUOSAT.DAL.EF.Repositories
{
    public class EFCourceRepository : ICourceRepository
    {
        private readonly ApplicationContext _context;

        public EFCourceRepository(ApplicationContext context)
        {
            _context = context;
        }
    
      public void DeleteCource(int CourceID)
        {
            List<Cource> properties = _context.Cources.Where(p => p.CourceID == CourceID).ToList();
            foreach (Cource cource in properties)
            {
                _context.Cources.Remove(cource);
                _context.SaveChanges();
            }
        }

        public List<Cource> Find(string query)
        {
            return _context.Cources.Where(c => c.Name == query).ToList();
        }

        public List<Cource> GetAll()
        {
            return _context.Cources.ToList();
        }

        public Cource GetById(int CourceID)
        {
            return _context.Cources.Find(CourceID);
        }

        public void SaveCource(Cource Cource)
        {
            if (Cource.CourceID == 0)
            {
                _context.Cources.Add(Cource);
            }
            else
            {
                Cource dbEntry = _context.Cources
                .FirstOrDefault(p => p.CourceID == Cource.CourceID);
                if (dbEntry != null)
                {
                    dbEntry.Name = Cource.Name;
                    
                }
            }
            _context.SaveChanges();
        }
    }
}
