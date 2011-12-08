using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeliaCore.Models
{
    public class BookingExt
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string Host { get; set; }
        public int RoomId { get; set; }
        public bool MealOrderWanted { get; set; }
        public List<int> ContactIds { get; set; }
    }
}