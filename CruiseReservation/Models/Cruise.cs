using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CruiseReservation.Models
{
    public class Cruise
    {
        [ScaffoldColumn(false)]
        public int CruiseID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string CruiseName { get; set; }

        [Display(Name = "Tour Description")]
        public string Description { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}