using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppVet.Models
{
    public partial class Billing
    {
        public int Id_billing { get; set; }
        public Service service { get; set; }
        public int Id_turn { get; set; }
        public int precio { get; set; }

    }

    [MetadataType(typeof(BillingMetadata))]
    public partial class Billing
    {

        public class BillingMetadata
        {
            [Key, Column(Order = 0)]
            public int Id_billing { get; set; }

        
        }

    }
}