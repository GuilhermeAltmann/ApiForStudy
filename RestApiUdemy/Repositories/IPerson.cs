using RestApiUdemy.Models;
using System.Collections.Generic;

namespace RestApiUdemy.Repositories
{
    public interface IPerson
    {

        Person Create(Person person);
        Person FindById(long id);
        Person Update(Person person);
        List<Person> FindAll();
        void Delete(long id);
    }
}
