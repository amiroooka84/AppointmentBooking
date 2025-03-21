using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RepositoryAppointment
{
    public interface IRepositoryAppointment : IRepository<Appointment>
    {
        //public IEnumerable<Appointment> GetByName(string name);
        //public Appointment GetByPhoneNumber(string phoneNumber);
        public IEnumerable<Appointment> GetByStatusAndDate(bool status , DateTime date);
        public IEnumerable<Appointment> GetByDate(DateTime date);
    }
}
