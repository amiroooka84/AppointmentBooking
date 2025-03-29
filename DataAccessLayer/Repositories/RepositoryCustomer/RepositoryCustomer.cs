using DataAccessLayer.DataBase;
using DataAccessLayer.Repositories.RepositoryAppointment;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RepositoryCustomer
{
    public class RepositoryCustomer : RepositoryBase<Customer>, IRepositoryCustomer
    {
        public RepositoryCustomer(db dbContext) : base(dbContext)
        {
        }

    }
}
