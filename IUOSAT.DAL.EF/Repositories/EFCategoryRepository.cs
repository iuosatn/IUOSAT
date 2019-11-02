using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IUOSAT.DAL.EF.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public EFCategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteCategory(int CategoryID)
        {
            List<Category> properties = _context.Categories.Where(p => p.CategoryID == CategoryID).ToList();
            foreach (Category category in properties)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<Category> Find(string query)
        {
            return _context.Categories.Where(c => c.PersianName == query).ToList();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int CategoryID)
        {
            return _context.Categories.Find(CategoryID);
        }

        public void SaveCategory(Category Category)
        {
            if (Category.CategoryID == 0)
            {
                _context.Categories.Add(Category);
            }
            else
            {
                Category dbEntry = _context.Categories
                .FirstOrDefault(p => p.CategoryID == Category.CategoryID);
                if (dbEntry != null)
                {
                    dbEntry.PersianName = Category.PersianName;
                    dbEntry.EnglishName = Category.EnglishName;
                }
            }
            _context.SaveChanges();
        }
    }
}

