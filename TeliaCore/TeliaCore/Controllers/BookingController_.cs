using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TeliaCore.Models;
using TeliaCore.Services;

namespace TeliaCore.Controllers
{
    public class BookingController_ : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController_(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //
        // GET: /Booking/

        public ViewResult Index()
        {
            var booking = _bookingService.GetAll();
            return View();
        }

        public ActionResult Create()
        {
            var booking = new Booking_();
            return View(booking);
        }

        [HttpPost]
        public ActionResult Save(Booking_ booking)
        {
            var result = _bookingService.Save(booking);
            return RedirectToAction("Index");
        }
    }
}
