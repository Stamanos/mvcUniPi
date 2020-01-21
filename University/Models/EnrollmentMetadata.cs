using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class EnrollmentMetadata
    {
        [Range(0, 4)]
        public Nullable<decimal> Grade;
    }
}