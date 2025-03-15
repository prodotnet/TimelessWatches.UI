using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class ProductAddition : System.Web.UI.Page
    {
        ServiceClient SC = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnAddProduct_Click(object sender, EventArgs e)
        {

               string ImagUrl = "img/";
            
                // Create a new product object
                Product addProduct = new Product
                {
                    ImageUrl_ = ImagUrl + fileUploadImage.FileName,
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Category = ddlCategory.SelectedValue,
                    
                };

                bool result = SC.AddProduct(addProduct);

             try
             {



                if (result)
                {
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Product added successfully')", true);
                    // Clear the input fields
                    txtName.Text = "";
                    txtDescription.Text = "";
                    txtPrice.Text = "";
                    ddlCategory.SelectedValue = "";
                    fileUploadImage.Attributes.Clear(); 

                 

                }
                else
                {
                    lblMessage.Text = "";
                    lblErrorMessage.Text = "Failed to add the product. Please try again.";
                }
             }
             catch (Exception ex)
             {
                lblMessage.Text = "";
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
             }
        }
    }
}