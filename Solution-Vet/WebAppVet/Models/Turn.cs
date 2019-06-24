using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppVet.Models
{
    public partial class Turn
    {
        public int Id_turn { get; set; }     
        public DateTime date { get; set; }
        public Service servicio { get; set; }

      /*  public IList<Patient> Patients { get; set; }
        public IList<Doctor> Doctors { get; set; }
        public IList<Rooms> Rooms { get; set; }
    */
     public Patient patient { get; set; }
    public int Id_patient { get; set; }

        public Doctor doctor { get; set; }
        public int Id_doctor { get; set; }

        public Rooms room { get; private set; }
        public int Id_room { get; private set; }
    }

    [MetadataType(typeof(TurnMetadata))]
    public partial class Turn
    {

        public class TurnMetadata
        {
            [Key, Column(Order = 0)]
            public int Id_turn { get; set; }

          /*  [Key, ForeignKey("patient"), Column(Order = 1)]
            public int Id_patient { get; set; }

            [Key, ForeignKey("doctor"), Column(Order = 2)]
            public int Id_doctor { get; set; }

            [Key, ForeignKey("room"), Column(Order = 3)]
            public int Id_room { get; set; }*/

            [Required]
            public int servicio { get; set; }

            [Required]
            public DateTime date { get; set; }

        }

    }
}