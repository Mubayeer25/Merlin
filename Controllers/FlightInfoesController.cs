using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyFly.com.Models;

namespace EasyFly.com.Controllers
{
    public class FlightInfoesController : Controller
    {
        private EasyFlycomDatabaseEntities3 db = new EasyFlycomDatabaseEntities3();

        // GET: FlightInfoes
        public ActionResult Index()
        {
            var flightInfoes = db.FlightInfoes.Include(f => f.Employee).Include(f => f.Employee1).Include(f => f.Employee2).Include(f => f.Employee3).Include(f => f.Employee4);
            return View(flightInfoes.ToList());
        }

        // GET: FlightInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightInfo flightInfo = db.FlightInfoes.Find(id);
            if (flightInfo == null)
            {
                return HttpNotFound();
            }
            return View(flightInfo);
        }

        // GET: FlightInfoes/Create
        public ActionResult Create()
        {
            ViewBag.CabinCrew1 = new SelectList(db.Employees, "EmployeeID", "E_Email");
            ViewBag.CabinCrew2 = new SelectList(db.Employees, "EmployeeID", "E_Email");
            ViewBag.CabinCrew3 = new SelectList(db.Employees, "EmployeeID", "E_Email");
            ViewBag.Pilot1 = new SelectList(db.Employees, "EmployeeID", "E_Email");
            ViewBag.Pilot2 = new SelectList(db.Employees, "EmployeeID", "E_Email");
            return View();
        }

        // POST: FlightInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightID,From1,To1,DepartureDate,ArrivalDate,ClassType,Pilot1,Pilot2,CabinCrew1,CabinCrew2,CabinCrew3,Fare,AvailableSeats,BookedSeats")] FlightInfo flightInfo)
        {
            if (ModelState.IsValid)
            {
                db.FlightInfoes.Add(flightInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CabinCrew1 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew1);
            ViewBag.CabinCrew2 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew2);
            ViewBag.CabinCrew3 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew3);
            ViewBag.Pilot1 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.Pilot1);
            ViewBag.Pilot2 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.Pilot2);
            return View(flightInfo);
        }

        // GET: FlightInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightInfo flightInfo = db.FlightInfoes.Find(id);
            if (flightInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CabinCrew1 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew1);
            ViewBag.CabinCrew2 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew2);
            ViewBag.CabinCrew3 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew3);
            ViewBag.Pilot1 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.Pilot1);
            ViewBag.Pilot2 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.Pilot2);
            return View(flightInfo);
        }

        // POST: FlightInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightID,From1,To1,DepartureDate,ArrivalDate,ClassType,Pilot1,Pilot2,CabinCrew1,CabinCrew2,CabinCrew3,Fare,AvailableSeats,BookedSeats")] FlightInfo flightInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CabinCrew1 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew1);
            ViewBag.CabinCrew2 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew2);
            ViewBag.CabinCrew3 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.CabinCrew3);
            ViewBag.Pilot1 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.Pilot1);
            ViewBag.Pilot2 = new SelectList(db.Employees, "EmployeeID", "E_Email", flightInfo.Pilot2);
            return View(flightInfo);
        }

        // GET: FlightInfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightInfo flightInfo = db.FlightInfoes.Find(id);
            if (flightInfo == null)
            {
                return HttpNotFound();
            }
            return View(flightInfo);
        }

        // POST: FlightInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FlightInfo flightInfo = db.FlightInfoes.Find(id);
            db.FlightInfoes.Remove(flightInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
