using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class PaymentSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["InvoiceDetails"] != null)
                {
                    lblSummary.Text = Session["InvoiceDetails"].ToString();
                }
                else
                {
                    lblSummary.Text = "Your payment has been successfully processed. You can now view and download your invoice for your records.";
                }
            }
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }

        protected void Invoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("Invoice.aspx");
        }
    }
}