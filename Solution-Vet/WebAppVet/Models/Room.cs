using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppVet.Interface;

namespace WebAppVet.Models
{
    public partial class Room : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    [MetadataType(typeof(RoomMetadata))]
    public partial class Room {

        public class RoomMetadata {
            [Key]
            public int Id { get; set; }

            [StringLength(50)]
            [Required]            
            public string Name { get; set; }


            [StringLength(50)]
            public string Location { get; set; }

        }

    }


}