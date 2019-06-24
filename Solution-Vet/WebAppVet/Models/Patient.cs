using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebAppVet.Interface;
using WebAppVet.SharedKerne;

namespace WebAppVet.Models
{
    public partial class Patient 
    {
       /* public Patient()
        {
        }*/

        public int Id_patient { get; set; }
        public Client Owner { get; private set; }
        public int Id_client { get; set; }
        public string Name { get; set; }

        public IList<Client> Clients { get; private set; }

    }

    [MetadataType(typeof(PatientMetadata))]
    public partial class Patient
    {

        public class PatientMetadata
        {
            [Key, Column(Order = 0)]
            public int Id_patient { get; set; }

            [Key, ForeignKey("Clients"), Column(Order = 1)]
            public int Id_client { get; set; }

            [StringLength(50)]
            public string Name { get; set; }

            [Required]
            public Client Owner { get; set; }

        }

    }
}