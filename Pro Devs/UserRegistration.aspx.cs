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
    public partial class UserRegistration : System.Web.UI.Page
    {
        ServiceClient SC = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            // Retrieve form values
            string FirstName = firstname.Value;
            string LastName = lastname.Value;
            string Email = email.Value;
            string Password = password.Value;
            string ConfirmPassword = confirm_password.Value;
            string Gender = gender.Value;
            string UserType = type.Value;

            

            // Validate passwords
            if (Password != ConfirmPassword)
            {
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Passwords do not match.')", true);
                return;
            }

             //hashing the password
             string hashedPassword = Secrecy.HashPassword(Password);


            //using the Api method
            bool isRegistered = SC.Register(FirstName, LastName, Email, hashedPassword, Gender, UserType, DateTime.Now);

            if (isRegistered)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('You Have Sucessfully Registered')", true);
                Response.Redirect("UserLogin.aspx"); 
            }
            else
            {
                // Display error message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registration failed. Please try again.')", true);
            }
        }
    }
}