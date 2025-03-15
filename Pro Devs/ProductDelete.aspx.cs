using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class ProductDelete : System.Web.UI.Page
    {
        ServiceClient SC = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId;
                if (int.TryParse(Request.QueryString["id"], out productId))
                {
                    LoadProduct(productId);
                }
                else
                {
                    lblErrorMessage.Text = "Invalid product ID.";
                }
            }
        }

        private void LoadProduct(int id)
        {
            var product = SC.GetProduct(id);
            if (product != null)
            {
                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString("F2");
                ddlCategory.SelectedValue = product.Category;
                txtImageUrl.Text = product.ImageUrl_;
            }
            else
            {
                lblErrorMessage.Text = "Product not found.";
            }
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int productId;
                if (int.TryParse(Request.QueryString["id"], out productId))
                {
                    Product updatedProduct = new Product
                    {
                        Id = productId,
                        Name = txtName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        Price = decimal.Parse(txtPrice.Text.Trim()),
                        Category = ddlCategory.SelectedValue,
                        ImageUrl_ = txtImageUrl.Text.Trim()
                    };

                    bool result = SC.DeleteProduct(productId);

                    if (result)
                    {
                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Product Deleted successfully')", true);

                        //clearing the imput box
                        txtName.Text = "";
                        txtDescription.Text = "";
                        txtPrice.Text = "";
                        ddlCategory.SelectedValue = "";
                        txtImageUrl.Text = "";
                    }
                    else
                    {
                        lblErrorMessage.Text = "Failed to update the product. Please try again.";
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Invalid product ID.";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
            }
        }


        
    }
}