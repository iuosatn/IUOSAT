using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Contract.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        void SaveCategory(Category Category);
        void DeleteCategory(int CategoryID);
        Category GetById(int CategoryID);
        List<Category> Find(string query);
    }
}
