//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flight_Database_WPF.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sector
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public System.DateTime ArrivalDate { get; set; }
        public int ArrivalAirportId { get; set; }
    
        public virtual Airport Airport { get; set; }
        public virtual Flight Flight { get; set; }
    }
}