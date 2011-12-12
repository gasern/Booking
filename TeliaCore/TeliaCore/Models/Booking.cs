//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeliaCore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public Booking()
        {
            this.Contacts = new HashSet<Contact>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string Host { get; set; }
    
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual MealOrder MealOrder { get; set; }
        public virtual Room Room { get; set; }
    }
}
