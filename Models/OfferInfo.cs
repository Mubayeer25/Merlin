//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyFly.com.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OfferInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfferInfo()
        {
            this.PassengerFlights = new HashSet<PassengerFlight>();
        }
    
        public string OfferID { get; set; }
        public string S_UserID { get; set; }
        public string HotelID { get; set; }
        public string OfferDesc { get; set; }
        public string OfferStatus { get; set; }
        public int Discount { get; set; }
    
        public virtual HotelInfo HotelInfo { get; set; }
        public virtual SingleUserLog SingleUserLog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PassengerFlight> PassengerFlights { get; set; }
    }
}
