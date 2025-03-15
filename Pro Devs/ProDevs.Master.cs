using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class ProDevs : System.Web.UI.MasterPage
    {
        ServiceClient SC = new ServiceClient();



        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure the session value is valid
            if (Session["UserId"] != null && Session["UserType"] != null)
            {

                string userType = Session["UserType"].ToString();
                string firstName = Session["Name"]?.ToString();
                string lastName = Session["Surname"]?.ToString();
                int userId = Convert.ToInt32(Session["UserId"]);


                if (userType == "Manager")
                {

                    // Show the Manager navigation
                    Manager.Visible = true;
                    LogoutM.Visible = true;
                    LoginM.Visible = false;
                    customer.Visible = false;
                    Nonlogged.Visible = false;
                    imgId.Visible = false;

                    


                    welcomeMessage.InnerHtml = $"<span class='text-success' style='font-size: 20px;'>{userType}</span> <span class='text-warning' style='font-size: 18px;'>{firstName}</span> <span class='text-warning' style='font-size: 18px;'>{lastName}</span>";
               
                }
                else if (userType == "Customer")
                {

                    // Show the Customer navigation
                    customer.Visible = true;
                    LogoutC.Visible = true;
                    LoginC.Visible = false;
                    Manager.Visible = false;
                    Nonlogged.Visible = false;
                    img1.Visible = false;

                    // Update cart count
                    UpdateCartCount(userId);
                    welcomeMessage1.InnerHtml = $"<span class='text-success' style='font-size: 20px;'>{userType}</span> <span class='text-warning' style='font-size: 18px;'>{firstName}</span> <span class='text-warning' style='font-size: 18px;'>{lastName}</span>";
                    
                }
                else
                {
                    // Show the Nonlogged navigation
                    Nonlogged.Visible = true;
                    Manager.Visible = false;
                    customer.Visible = false;
                }


            }

        }


        protected void Logout_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Session.Abandon();


            Response.Redirect("Home.aspx");
        }



        private void UpdateCartCount(int userId)
        {
            try
            {
                int cartItemCount = SC.GetCartItemCount(userId); 
                cartCount.InnerText = cartItemCount.ToString();
            }
            catch (Exception ex)
            {
               
                cartCount.InnerText = "0"; 
            }
        }
    }

}