using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebAppVet.Interface;

namespace WebAppVet.Models
{
    public partial class Client 
    {
       /* public Client()
        {
            Patients = new List<Patient>();
        }*/

        public int Id_client { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Id_patient { get; set; }

        public IList<Patient> Patients { get; private set; }
    }

    [MetadataType(typeof(ClientMetadata))]
    public partial class Client
    {

        public class ClientMetadata
        {
            [Key, Column(Order = 0)]
            public int Id_client { get; set; }

            [Key, ForeignKey("Patients"), Column(Order = 1)]
            public int Id_patient { get; set; }

            [StringLength(50)]
            public string FullName { get; set; }

            [StringLength(50)]
            public string Email { get; set; }

        }

    }
}