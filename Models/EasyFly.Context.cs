﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EasyFlycomDatabaseEntities3 : DbContext
    {
        public EasyFlycomDatabaseEntities3()
            : base("name=EasyFlycomDatabaseEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AircraftInfo> AircraftInfoes { get; set; }
        public virtual DbSet<CargoFlight> CargoFlights { get; set; }
        public virtual DbSet<CompanyLog> CompanyLogs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FlightInfo> FlightInfoes { get; set; }
        public virtual DbSet<HotelInfo> HotelInfoes { get; set; }
        public virtual DbSet<OfferInfo> OfferInfoes { get; set; }
        public virtual DbSet<PackageInfo> PackageInfoes { get; set; }
        public virtual DbSet<SingleUserLog> SingleUserLogs { get; set; }
        public virtual DbSet<CustomerSupport> CustomerSupports { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<PassengerFlight> PassengerFlights { get; set; }
        public virtual DbSet<BookedPackage> BookedPackages { get; set; }
    }
}