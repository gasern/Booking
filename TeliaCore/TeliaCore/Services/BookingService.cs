using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeliaCore.Models;

namespace TeliaCore.Services
{
    public class BookingService : IBookingService
    {
        private Model1Container db_Stub { get; set; }

        public BookingService()
        {
            db_Stub = new Model1Container();
        }

        public Booking Get(int id)
        {
            var booking = (from b in db_Stub.Bookings
                           where b.Id == id
                           select b).FirstOrDefault();

            return booking;

        }

        public List<Booking> GetAll()
        {
            var bookings = (from b in db_Stub.Bookings
                            select b).ToList();

            return bookings;

        }

        public bool Save(Booking booking)
        {
            //TODO LOG
            try
            {
                var _booking = new Booking()
                {
                    //TODO Implement automapper
                    //DateStart = booking.DateStart,
                    //DateEnd = booking.DateEnd,
                    //TimeStart = booking.TimeStart,
                    //TimeEnd = booking.TimeEnd,
                    //Subject = booking.Subject,
                    //Description = booking.Description,
                    //RoomId = booking.RoomId,
                    //Invited = booking.Invited,
                    //MealOrder = booking.MealOrder,
                    //Host = booking.Host

                };
                db_Stub.Bookings.Add(_booking);
                db_Stub.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                //TODO LOG 
                throw e;
            }

        }

        public bool Update(Booking booking)
        {
            try
            {
                //TODO implement property changed logic
                var _bboking = db_Stub.Bookings.Find(booking);
                //booking.DateStart = booking.DateStart;
                //booking.DateEnd = booking.DateEnd;
                //booking.TimeStart = booking.TimeStart;
                //booking.TimeEnd = booking.TimeEnd;
                //booking.Subject = booking.Subject;
                //booking.Description = booking.Description;
                //booking.RoomId = booking.RoomId;
                //booking.Invited = booking.Invited;
                //booking.MealOrder = booking.MealOrder;
                //booking.Host = booking.Host;

                db_Stub.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}