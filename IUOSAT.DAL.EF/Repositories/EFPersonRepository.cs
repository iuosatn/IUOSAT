using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IUOSAT.DAL.EF.Repositories
{
    public class EFPersonRepository : IPersonRepository
    {
        private readonly ApplicationContext _context;

        public EFPersonRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void DeletePerson(int PersonID)
        {
            List<Person> properties = _context.People.Where(p => p.PersonID == PersonID).ToList();
            foreach (Person person in properties)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
        }

        public List<Person> Find(string query)
        {
            return _context.People.Where(c=>c.EnglishFullName==query||c.PersianFullName==query).ToList();
        }

        public List<Person> GetAll()
        {
            return _context.People.ToList();
        }

        public Person GetById(int PersonID)
        {
            return _context.People.Find(PersonID);
        }

        public void SavePerson(Person person)
        {
            if (person.PersonID == 0)
            {
                _context.People.Add(person);
            }
            else
            {
                Person dbEntry = _context.People
                .FirstOrDefault(p => p.PersonID == person.PersonID);
                if (dbEntry != null)
                {
                    dbEntry.PersianFullName = person.PersianFullName;
                    dbEntry.EnglishFullName = person.EnglishFullName;
                    dbEntry.PersianAddress = person.PersianAddress;
                    dbEntry.EnglishAddress = person.EnglishAddress;
                    dbEntry.Email = person.Email;
                    dbEntry.EnglishBio = person.EnglishBio;
                    dbEntry.PersianBio = person.PersianBio;
                    dbEntry.WebSite = person.WebSite;
                    dbEntry.Instagram = person.Instagram;
                    dbEntry.Pinteret = person.Pinteret;
                    dbEntry.Twitter = person.Twitter;
                    dbEntry.Facebook = person.Facebook;
                    dbEntry.PhoneNumber = person.PhoneNumber;
                  
                }
            }
            _context.SaveChanges();
        }
    }
}
