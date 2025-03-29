using AppointmentBooking.Models;
using DataAccessLayer.Repositories.RepositoryAppointment;
using DataAccessLayer.Repositories.RepositoryCustomer;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReservationAppointment.Controllers
{
    public class ReservationAppointmentController : Controller
    {
        private readonly IRepositoryAppointment _appointment;
        private readonly IRepositoryCustomer _customer;

        public ReservationAppointmentController(IRepositoryAppointment appointment, IRepositoryCustomer customer)
        {
            _appointment = appointment;
            _customer = customer;
        }

        // GET: AppointmentBookingController
        public IActionResult Index()
        {
            return View();
        }

        // GET: AppointmentBookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult SearchByDate(DateTime dateTime)
        {
            var res = _appointment.GetByStatusAndDate(false , dateTime);
            return View( "Create" , res);
        }
        // GET: AppointmentBookingController/Create
        public ActionResult Create(DateTime dateTime)
        {
            var res = _appointment.GetAll();
            return View(res);
        }

        // POST: ReservationAppointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentViewModel viewModel)
        {
            try
            {
                Customer res2 = null;
                Appointment res1 = null;
                if (_appointment.FindById(viewModel.appointmentId).BookingStatus != true)
                {
                  res2 = _customer.Create(viewModel.customer);
                  res1 = _appointment.AddCustomerToAppointment(viewModel.appointmentId , res2.id);
                }
                if (res1 != null && res2 != null)
                {
                    ViewData["result"] = true;
                    return View();
                }
                else
                {
                    ViewData["result"] = false;
                    return View();
                }
            }
            catch
            {
                ViewData["result"] = false;
                return View();
            }
        }

        // GET: AppointmentBookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppointmentBookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentBookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppointmentBookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
