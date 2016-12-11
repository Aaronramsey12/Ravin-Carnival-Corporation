using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CruiseReservation.Models;
using System.Web.ModelBinding;

namespace CruiseReservation
{
    public partial class TourList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Tour> GetTours([QueryString("id")] int? cruiseId)
        {
            var db = new CruiseReservation.Models.TourContext();
            IQueryable<Tour> query = db.Tours;
            if (cruiseId.HasValue && cruiseId > 0)
            {
                query = query.Where(p => p.CruiseID == cruiseId);
            }
            return query;
        }
    }
}