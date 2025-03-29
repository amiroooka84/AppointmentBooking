using Entity;

namespace AppointmentBooking.Models
{
    public class AppointmentViewModel
    {
        public int  appointmentId { get; set; }
        public Customer customer { get; set; }
    }
}
