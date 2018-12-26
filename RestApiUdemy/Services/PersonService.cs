using RestApiUdemy.Models;
using RestApiUdemy.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestApiUdemy.Services
{
    public class PersonService : IPerson
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++) {

                persons.Add(MockPerson(i));
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return MockPerson(id);
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(long i)
        {

            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person Lastname " + i,
                Address = "Some Address " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {

            return Interlocked.Increment(ref count);
        }
    }
}
