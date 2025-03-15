using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ServiceClient Client = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayReportData();
                //default
                LoadChartsData(DateTime.Today.AddDays(-30), DateTime.Today);
            }
        }

        private void DisplayReportData()
        {
            //variables  and using wcf functions
            int totalProductsSold = Client.GetTotalProductsSold();
            int totalOrders = Client.GetTotalOrdersPlaced();
            int ProductInSock = Client.GetProductsInSockCount();
            int registeredUsersToday = Client.GetRegisteredUsersCountByDate(DateTime.Today);




            // Displaying data on the page
            lblTotalProductsSold.Text = totalProductsSold.ToString();
            lblTotalOrders.Text = totalOrders.ToString();
            lblAvailableStock.Text = ProductInSock.ToString();
            lblRegisteredUsersToday.Text = registeredUsersToday.ToString();
        }


        protected void btnFilterByDate_Click(object sender, EventArgs e)
        {
            try
            {
                
                DateTime startDate;
                DateTime endDate;

                if (DateTime.TryParse(TextBox1.Text, out startDate) && DateTime.TryParse(TextBox2.Text, out endDate))
                {
                    var totalOrdersInRange = Client.GetProductsSoldByDateRange(startDate, endDate);
                    LoadChartsData(startDate, endDate); 
                }
                else
                {
                    lblError.Text = "Invalid date range. Please check your input.";
                }
            }
            catch (Exception ex)
            {

                lblError.Text = $"An error occurred: {ex.Message}";
            }
        }



        private void LoadChartsData(DateTime startDate, DateTime endDate)
        {
            var productsSoldData = Client.GetTotalProductsSoldOverTime(startDate, endDate);
            var ordersPlacedData = Client.GetTotalOrdersPlacedOverTime(startDate, endDate);

           
            string productsSoldJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                labels = Enumerable.Range(0, productsSoldData.Count()).Select(i => startDate.AddDays(i).ToShortDateString()).Take(productsSoldData.Count()).ToArray(),
                data = productsSoldData
            });

            string ordersPlacedJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                labels = Enumerable.Range(0, ordersPlacedData.Count()).Select(i => startDate.AddDays(i).ToShortDateString()).Take(ordersPlacedData.Count()).ToArray(),
                data = ordersPlacedData
            });

            
            string script = $"<script>renderCharts({productsSoldJson}, {ordersPlacedJson});</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "LoadCharts", script);
        }
    }
}
