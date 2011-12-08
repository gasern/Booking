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
    
    public partial class Room
    {
        public Room()
        {
            this.Booking = new HashSet<Booking>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Nr { get; set; }
        public string Location { get; set; }
        public short NumberOfSeats { get; set; }
        public bool InternetAvailable { get; set; }
        public bool ProjectorAvailable { get; set; }
        public bool PhoneAvailable { get; set; }
        public bool WhiteboardAvailable { get; set; }
        public bool VideoconferenceAvailable { get; set; }
    
        public virtual ICollection<Booking> Booking { get; set; }
    }
}