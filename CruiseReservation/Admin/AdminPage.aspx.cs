using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CruiseReservation.Models;
using CruiseReservation.Logic;

namespace CruiseReservation.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductActon"];
            if(productAction == "add")
            {
                LabelAddStatus.Text = "Tour added!";
            }

            if(productAction == "remove")
            {
                LabelRemoveStatus.Text = "Tour removed!";
            }
        }

        protected void AddTourButton_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Images");
            if(TourImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(TourImage.FileName).ToLower();
                String[] allowedExtension = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i=0; i< allowedExtension.Length; i++)
                {
                    if (fileExtension == allowedExtension[i])
                    {
                        fileOK = true;
                    }
                }
            }
            if(fileOK)
            {
                try
                {
                    TourImage.PostedFile.SaveAs(path + TourImage.FileName);
                    TourImage.PostedFile.SaveAs(path + "Thumb/" + TourImage.FileName);
                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }

                //Add tour data to DB.
                AddTours tours = new AddTours();
                bool addSuccess = tours.AddTour(AddTourName.Text, AddTourDescription.Text, AddTourPrice.Text, DropDownAddCruises.SelectedValue, TourImage.FileName);

                if(addSuccess)
                {
                    //Reload the page.
                    string pageURL = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageURL + "?TourAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Unable to add new tour to database";
                }
            }
            else
            {
                LabelAddStatus.Text = "Unable to accept file type.";
            }
        }

        public IQueryable GetCruises()
        {
            var db = new CruiseReservation.Models.TourContext();
            IQueryable query = db.Cruises;
            return query;
        }

        public IQueryable GetTours()
        {
            var db = new CruiseReservation.Models.TourContext();
            IQueryable query = db.Tours;
            return query;
        }

        public void RemoveTourButton_Click(object sender, EventArgs e)
        {
            using (var db = new CruiseReservation.Models.TourContext())
            {
                int tourId = Convert.ToInt16(DropDownRemoveTour.SelectedValue);
                var myItem = (from t in db.Tours where t.TourID == tourId select t).FirstOrDefault();
                if (myItem != null)
                {
                    db.Tours.Remove(myItem);
                    db.SaveChanges();

                    //Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?TourAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Unable to locate tours.";
                }
            }
        }
    }
}