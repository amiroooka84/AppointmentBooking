using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<T> 
    {
        public T FindById(int id);
        public T Create(T val);
        public T Update(T val);
        public T Delete(int id);
        public IEnumerable<T> GetAll();
        
    }
}
