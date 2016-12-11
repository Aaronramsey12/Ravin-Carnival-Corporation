using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CruiseReservation.Models
{
    public class Tour
    {
        [ScaffoldColumn(false)]
        public int TourID { get; set; }

        [Required, StringLength(100), Display(Name = "Tour Name")]
        public string TourName { get; set; }

        [Required, StringLength(10000), Display(Name = "Tour Description"),
            DataType (DataType.MultilineText)]
        public string Decription { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int? CruiseID { get; set; }

        public virtual Cruise Cruise { get; set; }
    }
}