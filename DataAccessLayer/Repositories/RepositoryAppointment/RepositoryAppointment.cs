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

        public Appointment AddCustomerToAppointment(int appointmentId, int customerId)
        {
            var appointment = _Query.SingleOrDefault(i => i.id == appointmentId);
            if (appointment == null) return null;
            if (appointment.CustomerId != 0 && appointment.BookingStatus)
            {
                return null;
            }
            appointment.CustomerId = customerId;
            appointment.BookingStatus = true;
            var res = _Query.Entry(appointment).Entity;
            _dbContext.SaveChanges();
            return res;
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
