using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Contract.Repositories
{
    public interface ICourceRepository
    {
        List<Cource> GetAll();
        void SaveCource(Cource Cource);
        void DeleteCource(int CourceID);
        Cource GetById(int CourceID);
        List<Cource> Find(string query);
    }
}
