using System;
using System.Collections.Generic;
using System.Text;
using IUOSAT.Domain.Entities;
namespace IUOSAT.Domain.Contract.Repositories
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        void SavePerson(Person person);
        void DeletePerson(int PersonID);
        Person GetById(int PersonID);
        List<Person> Find(string query);
    }
}
