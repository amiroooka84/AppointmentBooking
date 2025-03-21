using DataAccessLayer.DataBase;
using DataAccessLayer.Services;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer.Repositories.RepositoryAppointment
{
    public class RepositoryAppointment : RepositoryBase<Appointment> , IRepositoryAppointment
    {
        public RepositoryAppointment(db dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Appointment> GetByDate(DateTime date)
        {
            var res = _Query.Where(i=> ConvertDate.ConvertShamsiToMiladi(i.DateTime) == date);
            return res;
        }

        public IEnumerable<Appointment> GetByStatusAndDate(bool status , DateTime date)
        {
            var res = _Query.Where(i => i.BookingStatus == status && ConvertDate.ConvertShamsiToMiladi(i.DateTime) == date);
            return res;
        }

    }
}
