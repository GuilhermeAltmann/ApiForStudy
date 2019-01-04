using RestApiUdemy.Models;
using System.Collections.Generic;

namespace RestApiUdemy.Repositories
{
    public interface IBook
    {

        Book Create(Book person);
        Book FindById(long id);
        Book Update(Book person);
        List<Book> FindAll();
        void Delete(long id);
    }
}
