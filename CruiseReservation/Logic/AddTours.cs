using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CruiseReservation.Models;

namespace CruiseReservation.Logic
{
    public class AddTours
    {
        public bool AddTour(string TourNaming, string TourDesc,  string tourPrice, string TourCruise, string TourImagePath)
        {
            var myTour = new Tour();
            myTour.TourName = TourNaming;
            myTour.Decription = TourDesc;
            myTour.UnitPrice = Convert.ToDouble(tourPrice);
            myTour.ImagePath = TourImagePath;
            myTour.CruiseID = Convert.ToInt32(TourCruise);

            using (TourContext db = new TourContext())
            {
                //Add tours tDB.
                db.Tours.Add(myTour);
                db.SaveChanges();
            }

            //Success.
            return true;
        }
    }
}