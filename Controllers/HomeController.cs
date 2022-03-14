using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyFly.com.Models;

namespace EasyFly.com.Controllers
{
    public class HomeController : Controller
    {
        private EasyFlycomDatabaseEntities3 db = new EasyFlycomDatabaseEntities3();
        public ActionResult Index()
        {
            var res = db.Database.SqlQuery<string>("Select DISTINCT  From1 from FlightInfo ").ToList();
            
            ViewBag.src = res;
            return View();
        }
        [HttpPost]
        public ActionResult SearchResult(SearchFlight sf)
        {
            var res = db.Database.SqlQuery<FlightInfo>("Select * from FlightInfo where From1 = '"+sf.Source+ "' and To1 = '" + sf.Destination + "' and ClassType = '"+sf.ClassType+"';").ToList();
            List<FlightInfo> flightList = new List<FlightInfo>();
            foreach (FlightInfo x in res)
            {
                if (x.DepartureDate.ToString("dd-MM-yyyy").Equals(sf.FromDate.ToString("dd-MM-yyyy")))
                {
                    
                    flightList.Add(x);
                }
            }
            ViewBag.flightList = flightList;
            return View();
            
            
             
            //return sf.FromDate.ToString("yyyy-MM-dd");
            
            
        }
        [HttpGet]
        public ActionResult Booking(string flightId)
        {
            var seatList = new List<string>() {"A1","A2","A3","A4","A5","B1","B2","B3","B4","B5",
                                               "C1","C2","C3","C4","C5","D1","D2","D3","D4","D5",
                                               "E1","E2","E3","E4","E5","F1","F2","F3","F4","F5",
                                               "G1","G2","G3","G4","G5","H1","H2","H3","H4","H5"};
            var res = db.Database.SqlQuery<FlightInfo>("Select * from FlightInfo where FlightID = '" + flightId + "' ;").ToList();
            ViewBag.flightDetails = res;
            ViewBag.selectedFlightId = flightId;
            TempData["flightId"] = flightId;
            ViewBag.seatList = seatList;
            return View();
        }
        [HttpPost]
        public ActionResult ProceedToBooking(FormCollection form)
        {
            ViewBag.flightId = TempData["flightId"];
            string userId = "180104000";
            
            var usr = db.Database.SqlQuery<SingleUserLog>("Select * from SingleUserLog where S_UserID = '" + userId + "' ;").ToList();
            ViewBag.username = usr[0].FirstName + " " + usr[0].LastName;
            ViewBag.useremail = usr[0].S_UserEmail; 
            TempData["userId"] = userId;
            TempData.Keep("flightId");
            ViewBag.totalFlightFare = form["totalFareForDb"];
            ViewBag.userId = userId;
            ViewBag.bookedSeats = form["selectedSeats"];
            ViewBag.noOfSeats = form["noOfSeats"];
            var res = db.Database.SqlQuery<FlightInfo>("Select * from FlightInfo where FlightID = '" + TempData["flightId"] + "' ;").ToList();
            ViewBag.flighDetails = res;
            int curNoOfSeats =(int) res[0].AvailableSeats;
            curNoOfSeats -= Convert.ToInt32(form["noOfSeats"]) ;
            string curBookedSeats = (string)res[0].BookedSeats;
            curBookedSeats += form["selectedSeats"];
            int noOfRowInserted = db.Database.ExecuteSqlCommand("insert into PassengerFlight(FlightID,S_UserID,NoOfSeats,SeatNumbers,TotalFlightFare)" +
                " values('"+ TempData["flightId"] + "','"+ userId + "',"+ form["noOfSeats"] + ",'"+ form["selectedSeats"] + "',"+ form["totalFareForDb"] + " )");
            int noOfRowUpdated = db.Database.ExecuteSqlCommand("Update FlightInfo " +
                "set AvailableSeats = "+curNoOfSeats+ ", BookedSeats = '"+curBookedSeats+"'  where FlightID = '"+ TempData["flightId"] + "'");
            ViewBag.msg = "Something Went Wrong";
            if(noOfRowInserted>0 && noOfRowUpdated > 0)
            {
                ViewBag.msg = "Booking Successful!!";
            }

            return View();

            

            //return sf.FromDate.ToString("yyyy-MM-dd");


        }
        public ActionResult Packages()
        {
            var res = db.Database.SqlQuery<PackageInfo>("select * from PackageInfo").ToList();
            ViewBag.packages = res;
            return View();
        }
        public ActionResult PackageDetail(string pid)
        {
            var res = db.Database.SqlQuery<PackageInfo>("select * from PackageInfo where PackageID = '"+pid+"'").FirstOrDefault();
            ViewBag.package = res;
            return View();
        }

        public ActionResult ConfirmPackageBooking(FormCollection form)
        {
            ViewBag.msg = "Booking Successfull!!!";
            string userId = "180104000";
            var userInfo = db.Database.SqlQuery<SingleUserLog>("select * from SingleUserLog where S_UserID = '" + userId + "'").FirstOrDefault();
            ViewBag.user = userInfo;
            ViewBag.checkInDate = form["checkInDate"];
            ViewBag.cost = form["totalCost"];
            ViewBag.noOfPerson = form["noOfPerson"];
            ViewBag.packageId = form["packageId"];
            int noOfRowInserted = db.Database.ExecuteSqlCommand("insert into BookedPackages " +
                "values ('" + userId + "','" + form["packageId"] + "','"+ form["checkInDate"] + "',"+ form["noOfPerson"] + ","+ form["totalCost"] + ")");
            if(noOfRowInserted != 1)
            {
                ViewBag.msg = "Something went wrong";
            }
            
            return View();
        }
        public ActionResult FlightHistory()
        {
            string userId = "180104000";
            var res = db.Database.SqlQuery<PassengerFlight>("Select * from PassengerFlight where S_UserID = '" + userId + "' ;").ToList();

            List<PassengerFlight> bookedFlights = new List<PassengerFlight>();
            List<FlightInfo> bookedFlightInfo = new List<FlightInfo>();

            foreach (PassengerFlight x in res)
            {
                var dt = db.Database.SqlQuery<FlightInfo>("select * from FlightInfo where FlightID = '" + x.FlightID + "' ").FirstOrDefault();
                string fdate = dt.DepartureDate.ToString("ddMMyyyy");
                string curdate = System.DateTime.Today.ToString("ddMMyyyy");
                
                if (fdate.CompareTo(curdate) == -1 )
                {
                    bookedFlights.Add(x);
                    bookedFlightInfo.Add(dt);
                    
                }


            }
            ViewBag.bookedFlights = bookedFlights;
            ViewBag.bookedFlightInfo = bookedFlightInfo;

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}