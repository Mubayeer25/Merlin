using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyFly.com.Models
{
    public class SearchFlight
    {
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [Required]
        public string ClassType { get; set; }
    }
    public enum FlightFrom
    {
        
        Barisal,Chattogram,CoxsBazar,Dhaka,Ishurdi,Jessore,Rajshahi,Sylhet

    }
    public enum TypeOfClass
    {
        Economic,Business
    }
}