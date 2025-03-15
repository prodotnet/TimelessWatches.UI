using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class AboutProduct : System.Web.UI.Page
    {
        ServiceClient SC = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                GetProductsClothing();

            }
        }


        private void GetProductsClothing()
        {

            string Display = "";



            if (Request.QueryString["Id"] != null)
            {


                int prodID = Convert.ToInt32(Request.QueryString["Id"]);

                var product = SC.GetProduct(prodID);


                if (product != null)
                {
                    Display += "<div class='col-4 mb-4'>";
                    Display += "<div class='watch-card text-center'>";
                    Display += "<img src=" + product.ImageUrl_ + " class='img-fluid' + alt='Smart Watch 1'>";
                    Display += "<div class='watch-content'>";
                    Display += "<h5 class='text-success'>" + product.Name + "</h5>";
                    Display += "<p class='text-warning'> R" + product.Price + "</p>";
                    Display += "<p class='text-description'>" + product.Description + "</p>";
                    Display += "<p class='text-warning'>★★★☆☆</p>";        
                    Display += "</div>";
                    Display += "</div>";
                    Display += "</div>";

                    About.InnerHtml = Display;
                }
            }

        }



    }
}