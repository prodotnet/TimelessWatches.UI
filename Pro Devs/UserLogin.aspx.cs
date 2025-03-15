using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashPass;

namespace Pro_Devs
{
    public partial class UserLogin : System.Web.UI.Page
    {

        ServiceClient SC = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Login_Click(object sender, EventArgs e)
        {
            string Email = email.Value;
            string Password = password.Value;


            string hashedPassword = Secrecy.HashPassword(Password);

            var userlogin = SC.Login(Email, hashedPassword);

            if (userlogin != null)
            {

                if (userlogin.UserType == "Manager")
                {
                    Session["UserId"] = userlogin.Id;
                    Session["Name"] = userlogin.FirstName;
                    Session["Surname"] = userlogin.LastName;
                    Session["Email"] = userlogin.Email;
                    Session["UserType"] = userlogin.UserType;
                    Response.Redirect("Dashboard.aspx");

                }
                else if (userlogin.UserType == "Customer")
                {
                    Session["UserId"] = userlogin.Id;
                    Session["Name"] = userlogin.FirstName;
                    Session["Surname"] = userlogin.LastName;
                    Session["Email"] = userlogin.Email;
                    Session["UserType"] = userlogin.UserType;
                    Response.Redirect("Home.aspx");

                }

                return;

            }
            else
            {
                Label1.Text = "Incorrect Email or Password";
            }


        }

    }


}