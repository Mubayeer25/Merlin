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
    
    public partial class CargoFlight
    {
        public string RequestID { get; set; }
        public string FlightID { get; set; }
        public string ProductType { get; set; }
        public string ProductDimension { get; set; }
        public string ProductWeight { get; set; }
        public string ProductUnit { get; set; }
        public Nullable<int> NoOfSeats { get; set; }
        public string RequestStatus { get; set; }
    
        public virtual FlightInfo FlightInfo { get; set; }
    }
}