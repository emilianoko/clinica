using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppVet.Models
{
    public partial class Rooms 
    {
        public int Id_room { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        /*  public int Id_turn { get; set; } */

        public IList<Turn> turn { get; set; }
      
    }

    [MetadataType(typeof(RoomsMetadata))]
    public partial class Rooms {

        public class RoomsMetadata {
            [Key, Column(Order = 0)]
            public int Id_room { get; set; }

           /* [Key, ForeignKey("Turns"), Column(Order = 1)]
            public int Id_turn { get; set; }*/

            [StringLength(50)]
            [Required]            
            public string Name { get; set; }


            [StringLength(50)]
            public string Location { get; set; }

        }

    }


}