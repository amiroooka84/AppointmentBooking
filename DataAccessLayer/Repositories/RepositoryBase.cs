using DataAccessLayer.DataBase;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        protected readonly db _dbContext;
        protected readonly DbSet<T> _Query;

        public RepositoryBase(db dbContext)
        {
            _dbContext = dbContext;
            _Query = _dbContext.Set<T>();
        }

        public T Create(T val)
        {
            var res = _dbContext.Add(val).Entity;
            _dbContext.SaveChanges();
            return res;
        }

        public T Delete(int id)
        {
            T res = _Query.Where(i=> i.id == id).Single();
            _Query.Remove(res);
            _dbContext.SaveChanges();
            return res;
        }

        public T FindById(int id)
        {
            T res = _Query.Where(i => i.id == id).Single();
            return res;
        }

        public IEnumerable<T> GetAll()
        {
            return _Query;
        }

        public T Update(T val)
        {
           var res =  _Query.Entry(val).Entity;
            _dbContext.SaveChanges();
            return res;
        }
    }
}
