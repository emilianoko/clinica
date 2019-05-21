using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppVet.SharedKerne
{
    public enum Gender
    {
        Female = 1,
        Male = 2
    }

    public enum TrackingState
    {
        Unchanged = 0,
        Added = 1,
        Modified = 2,
        Deleted = 3
    }
}