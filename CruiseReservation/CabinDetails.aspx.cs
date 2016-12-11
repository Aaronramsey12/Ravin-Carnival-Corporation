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
    public partial class CabinDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Cabin> GetCabinDetail([QueryString("cabinID")] int?cabinId)
        {
            var db = new CruiseReservation.Models.TourContext();
            IQueryable<Cabin> query = db.Cabin;
            if (cabinId.HasValue && cabinId>0)
            {
                query = query.Where(b => b.CabinID == cabinId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}