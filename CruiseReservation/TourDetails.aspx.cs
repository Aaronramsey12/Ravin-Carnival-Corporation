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
    public partial class TourDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Tour> GetTours ([QueryString("tourID")] int?tourId)
        {
            var db = new CruiseReservation.Models.TourContext();
            IQueryable<Tour> query = db.Tours;
            if (tourId.HasValue && tourId > 0)
            {
                query = query.Where(p => p.TourID == tourId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}