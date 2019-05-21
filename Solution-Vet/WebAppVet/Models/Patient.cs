using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppVet.Interface;
using WebAppVet.SharedKerne;

namespace WebAppVet.Models
{
    public class Patient : IEntity
    {
        public Patient()
        {
        }

        public int Id { get; set; }
        public Client Owner { get; private set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
    }
}