using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppVet.Models
{
    public partial class Doctor
    {
        public int Id_doctor { get; set; }
        public string name { get; set; }
        public string specialization { get; set; }
        /*public int Id_turn { get; set; }

        public IList<Turn> Turns { get; set; }*/

        public IList<Turn> turn { get; set; }
        
    }

    [MetadataType(typeof(DoctorMetadata))]
    public partial class Doctor
    {

        public class DoctorMetadata
        {
            [Key, Column(Order = 0)]
            public int Id_doctor { get; set; }

           /* [Key, ForeignKey("Turns"), Column(Order = 1)]
            public int Id_turn { get; set; } */

            [Required]
            public string name { get; set; }


            [Required]
            public string specialization { get; set; }

        }

    }
}