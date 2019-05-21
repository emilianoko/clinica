using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppVet.Interface;

namespace WebAppVet.Models
{
    public class Client : IEntity
    {
        public Client()
        {
            Patients = new List<Patient>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }


        public string Email { get; set; }

        public IList<Patient> Patients { get; private set; }
    }
}