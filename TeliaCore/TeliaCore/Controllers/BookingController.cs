using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeliaCore.Models;

namespace TeliaCore.Controllers
{
    public class BookingController : Controller
    {

        Model1Container db = new Model1Container();
        
        //
        // GET: /Booking/

        public ActionResult Index()
        {
            return View(db.Bookings.Include("Contacts"));
        }



        //
        // GET: /Booking/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Booking/Create

        public ActionResult Create()
        {
            ViewData["AllContacts"] = db.Contacts.ToList();
            ViewData["AllRooms"] = db.Rooms.ToList();
            ViewData["AllProducts"] = db.Products.ToList();
            var booking = new Booking()
                              {
                                  StartDate = DateTime.Now,
                                  EndDate = DateTime.Now

                              };
            return View(booking);
        } 

     
        [HttpPost]
        public ActionResult AddBooking(Booking booking, List<int> ProductIds)
        {
            try
            {

                var contacts = AddContactsToBooking(booking);
                if (contacts == null)
                    return JsonFejlmeddelelse("Manglende kontakter, forhindre bookingen i at blive gennemført");
                else
                {
                    booking.Contact = contacts;
                }

                var room = AddRoomToBooking(booking);
                if (room == null)
                    return JsonFejlmeddelelse("Der er angivet et ugyldigt mødelokale");
                else
                {
                    booking.Room = room;
                }

                booking.Host = "Jimmie Rindal";

                
                db.Bookings.Add(booking);
                db.SaveChanges();

                 return PartialView("AddContacts",booking.Contact);
            }
            catch(Exception e)
            {
                return View("Create");
            }
        }

        private List<Contact> AddContactsToBooking(Booking booking)
        {
            var contacts = new List<Contact>();
            foreach (var contactId in booking.ContactIds)
            {
                var contact = db.Contacts.Find(contactId);
                if (contact != null)
                {
                    contacts.Add(contact);
                }
            }
            return contacts;
        }

        private Room AddRoomToBooking(Booking booking)
        {
            return db.Rooms.Find(booking.RoomId);
        }

        //private MealOrder AddMealToBooking(Booking booking)
        //{
        //    //TODO finpuds drinkbestilling og antal
        //    return db.MealOrders.Find(booking.MealId);
        //}

        private JsonResult JsonFejlmeddelelse(string message)
        {
            return Json(new
            {
                success = false,
                message = message,
            }, JsonRequestBehavior.AllowGet);

        }



        // POST: /Booking/Confirm
        [HttpPost]
        public ActionResult Confirm(Booking booking)
        {
            return PartialView(booking);
        }
        
        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            try
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Booking/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(db.Bookings.Find(id));
        }

        //
        // POST: /Booking/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Booking booking)
        {
            try
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Booking/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(db.Bookings.Find(id));
        }

        //
        // POST: /Booking/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Booking booking)
        {
            try
            {
                db.Entry(booking).State = EntityState.Deleted;
                db.SaveChanges();
            
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
