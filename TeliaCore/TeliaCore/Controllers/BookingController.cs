using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Components.DictionaryAdapter;
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
            var booking = new BookingExt()
                              {
                                  StartDate = DateTime.Now,
                                  EndDate = DateTime.Now

                              };
            return View(booking);
        } 

     
        [HttpPost]
        public ActionResult AddBooking(BookingExt bookingExt, List<int> ProductIds)
        {
            try
            {
                var booking = MapBookingExtToBooking(bookingExt, ProductIds);

                db.Bookings.Add(booking);
                
                db.SaveChanges();

                 return PartialView("AddContacts",booking.Contacts);
            }
            catch(Exception e)
            {
                return View("Create");
            }
        }

        private Booking MapBookingExtToBooking(BookingExt bookingExt, List<int> productIds)
        {
            try
            {
                var contacts = AddContactsToBooking(bookingExt);
                if (contacts == null)
                    return null;
               
                var room = AddRoomToBooking(bookingExt);
                if (room == null)
                    return null;

                var bookingFinal = new Booking()
                {
                    Title = bookingExt.Title,
                    Description = bookingExt.Description,
                    StartDate = bookingExt.StartDate,
                    EndDate = bookingExt.EndDate,
                    StartTime = bookingExt.StartTime,
                    EndTime = bookingExt.EndTime,
                    Host = "Jimmie Rindal",
                    Contacts = contacts,
                    Room = room
                };

                if (bookingExt.MealOrderWanted)
                {
                    var refreshments = AddRefreshmentsToMealOrder(productIds);
                    var mealOrder = new MealOrder()
                    {
                        Booking = bookingFinal,
                        NumberOfDiningGuests = bookingFinal.Contacts.Count(),
                        DepartmentCharged = "Department",
                        DepartmentCreditNumber = "000000",
                        DishWishServedAt = DateTime.Now,
                        Refreshments = refreshments,
                        TotalPrice = refreshments.Sum(r=>r.Product.Price),//TODO check
                        Contact = db.Contacts.FirstOrDefault() //TODO get profile from session
                    };

                    bookingFinal.MealOrder = mealOrder;
                }
            }
            catch (Exception)
            {
                 throw;
            }
            return null;
        }

        private IList<RefreshmentItem> AddRefreshmentsToMealOrder(List<int> productIds)
        {
            IList<RefreshmentItem> refreshments = new EditableList<RefreshmentItem>();
            foreach (var productId in productIds)
            {
                var refreshmentItem = db.RefreshmentItems.Find(productId);
                if (refreshmentItem != null)
                {
                    refreshments.Add(refreshmentItem);
                }
            }
            return refreshments;
        }

        private ICollection<Contact> AddContactsToBooking(BookingExt booking)
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

        private Room AddRoomToBooking(BookingExt booking)
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
