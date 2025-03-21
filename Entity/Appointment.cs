using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Appointment : EntityBase
    {
        public string DateTime { get; set; }
        public bool BookingStatus { get; set; }
        public int CustomerId { get; set; }
    }
}
