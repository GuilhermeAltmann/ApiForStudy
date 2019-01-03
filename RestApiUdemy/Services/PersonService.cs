using RestApiUdemy.Models;
using RestApiUdemy.Models.Context;
using RestApiUdemy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestApiUdemy.Services
{
    public class PersonService : IPerson
    {
        private MySqlContext _context;

        public PersonService(MySqlContext context)
        {

            _context = context;
        }

        public Person Create(Person person)
        {
            try {

                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex) {

                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if(result != null)
                {

                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {

            if (!Exist(person.Id)) {

                return new Person();
            }

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {

                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
