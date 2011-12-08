using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeliaCore.Models;

namespace TeliaCore.Controllers
{
    public class HomeController : AbstractController
    {
        public Model1Container _db { get; set; }
        public StubData.BookingStub Stub { get; set; }
        public HomeController()
        {
            _db = new Model1Container();
        }

        public ActionResult Index()
        {
            List<Booking> bookinger = _db.Bookings.ToList();
            return View(bookinger);
        }

        public ActionResult ListBookinger()
        {

            return View();
        }
        //public ActionResult Kalender()
        //{
        //    return View();
        //}


        public ActionResult About()
        {
            return View();
        }
    }
}
