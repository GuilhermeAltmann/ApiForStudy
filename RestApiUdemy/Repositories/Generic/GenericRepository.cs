using Microsoft.EntityFrameworkCore;
using RestApiUdemy.Models.Base;
using RestApiUdemy.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiUdemy.Repositories.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly MySqlContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MySqlContext context)
        {

            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {

                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return item;
        }

        public void Delete(long id)
        {

            var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {

                    _dataset.Remove(result);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<T> FindAll()
        {

            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {

            if (!Exist(item.Id))
            {

                return null;
            }

            var result = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            try
            {

                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return item;
        }

        private bool Exist(long? id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }
    }
}
