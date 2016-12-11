using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CruiseReservation.Models
{
    public class Cabin
    {
        [ScaffoldColumn(false)]
        public int CabinID { get; set; }

        [Required, StringLength(100), Display(Name ="Name")]
        public string CabinType { get; set; }

        [Required, StringLength(10000), Display(Name ="Cabin Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }
        [Display(Name ="Price")]
        public double? CabinPrice { get; set; }

        public string ImageDesc { get; set; }
    }
}