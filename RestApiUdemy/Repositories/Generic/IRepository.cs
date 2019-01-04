using RestApiUdemy.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiUdemy.Repositories.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {

        T Create(T item);
        T FindById(long id);
        T Update(T item);
        List<T> FindAll();
        void Delete(long id);
    }
}
