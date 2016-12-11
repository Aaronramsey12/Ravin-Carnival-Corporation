using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using CruiseReservation.Logic;


namespace CruiseReservation
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["TourID"];
            int tourID;
            if (!string.IsNullOrEmpty(rawId) && int.TryParse(rawId, out tourID))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }
            }
            else
            {
                Debug.Fail("Error : We should never get to AddToCart.aspx without a TourId.");
                throw new Exception("Error : It is illegal to load AddToCart.aspx without setting a tourId.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}