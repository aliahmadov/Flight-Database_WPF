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
    
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            this.Sectors = new HashSet<Sector>();
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int Id { get; set; }
        public string FlightNo { get; set; }
        public int AirlineId { get; set; }
        public int AircraftId { get; set; }
        public System.DateTime StartDate { get; set; }
        public int StartAirportId { get; set; }
    
        public virtual Aircraft Aircraft { get; set; }
        public virtual Airline Airline { get; set; }
        public virtual Airport Airport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sector> Sectors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
