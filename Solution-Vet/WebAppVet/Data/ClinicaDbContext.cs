using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppVet.Models;

namespace WebAppVet.Data
{
    public class ClinicaDbContext : DbContext
    {

        public ClinicaDbContext() : base("ClinicaDbContext") {
        }

        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Turn> Turn { get; set; }


    }
}