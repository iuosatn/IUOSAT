using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Contract.Repositories
{
    public interface IGradeRepository
    {
        List<Grade> GetAll();
        void SaveGrade(Grade Grade);
        void DeleteGrade(int GradeID);
        Grade GetById(int GradeID);
        List<Grade> Find(string query);
    }
}
