using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;


namespace Pro_Devs
{
    public partial class Invoice : System.Web.UI.Page
    {
        ServiceClient Client = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("UserLogin.aspx");
                return;
            }
            if (!IsPostBack)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                LoadInvoice(userId);
            }
        }

        private void LoadInvoice(int userId)
        {
            dynamic invoice = Client.GetInvoiceDetails(userId);

            if (invoice != null)
            {
                lblName.Text = Session["Name"]?.ToString() ?? "N/A";
                lblSurname.Text = Session["Surname"]?.ToString() ?? "N/A";
                lblEmail.Text = Session["Email"]?.ToString() ?? "N/A";
                lblInvoiceDate.Text = invoice.Date.ToString("d");

                dynamic invoiceItems = Client.GetInvoiceItems(invoice.Id);

                if (invoiceItems == null || invoiceItems.Length == 0)
                {
                    lblError.Text = "No items found for this invoice.";
                    lblError.Visible = true;
                }
                else
                {
                    decimal totalAmount = 0;
                    string display = "";

                    foreach (var item in invoiceItems)
                    {
                        display += "<tr class='text-success'>";
                        display += "<td>" + item.Name + "</td>";
                        display += "<td>" + item.Quantity + "</td>";
                        display += $"<td>R{(item.Price * item.Quantity):F2}</td>";
                        display += "</tr>";

                        totalAmount += item.Price * item.Quantity; 
                    }

                    InvoiceRecord.InnerHtml = display;

                   
                    decimal discount = ApplyDiscount(totalAmount);
                    decimal vatAmount = totalAmount * 0.15m; // 15% VAT
                    decimal deliveryFee = 50.00m; 
                    decimal finalTotal = totalAmount - discount + vatAmount + deliveryFee;

                    // Set label values
                    lblSubtotal.Text = $"R{totalAmount:F2}";
                    lblDiscount.Text = $"R{discount:F2}";
                    lblVAT.Text = $"R{vatAmount:F2}";
                    lblDeliveryFee.Text = $"R{deliveryFee:F2}";
                    lblTotalAmount.Text = $"R{finalTotal:F2}";
                }
            }
            else
            {
                lblError.Text = "No invoice found.";
                lblError.Visible = true;
            }
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }

        protected void DownloadInvoice_Click(object sender, EventArgs e)
        {
            var userId = Convert.ToInt32(Session["UserId"]);
            var invoice = Client.GetInvoiceDetails(userId);

            if (invoice == null)
            {
                lblError.Text = "No invoice found for this user.";
                lblError.Visible = true;
                return;
            }

            string userName = Session["Name"]?.ToString() ?? "N/A";
            string userSurname = Session["Surname"]?.ToString() ?? "N/A";
            string userEmail = Session["Email"]?.ToString() ?? "N/A";
            string invoiceDate = invoice.Date.ToString("d");

            var invoiceItems = Client.GetInvoiceItems(invoice.Id);

            if (invoiceItems == null || !invoiceItems.Any())
            {
                lblError.Text = "No items found for this invoice.";
                lblError.Visible = true;
                return;
            }

            decimal totalAmount = 0;
            decimal vatRate = 0.15m; 
            decimal deliveryFee = 50.00m; 

            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, ms);
                document.Open();

                // Title
                document.Add(new Paragraph("Invoice", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));

                // User details
                document.Add(new Paragraph($"Name: {userName}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                document.Add(new Paragraph($"Surname: {userSurname}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                document.Add(new Paragraph($"Email: {userEmail}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                document.Add(new Paragraph($"Date: {invoiceDate}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));

                // Add a line break
                document.Add(new Paragraph(" "));

                // Create a table for invoice items
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100;

           
                table.AddCell("Name");
                table.AddCell("Quantity");
                table.AddCell("Subtotal");

                foreach (var item in invoiceItems)
                {
                    decimal itemTotal = item.Price * item.Quantity;
                    table.AddCell(item.Name);
                    table.AddCell(item.Quantity.ToString());
                    table.AddCell($"R{itemTotal:F2}");
                    totalAmount += itemTotal; 
                }

                document.Add(table);

              
                decimal discount = ApplyDiscount(totalAmount);
                totalAmount -= discount;
                decimal vatAmount = totalAmount * vatRate;
                decimal finalTotal = totalAmount + vatAmount + deliveryFee;

               
               
                document.Add(new Paragraph($"Subtotal: R{totalAmount:F2}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                document.Add(new Paragraph($"VAT (15%): R{vatAmount:F2}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                document.Add(new Paragraph($"Delivery Fee: R{deliveryFee:F2}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                if (discount > 0)
                {
                    document.Add(new Paragraph($"Discount: R{discount:F2}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                }
                document.Add(new Paragraph($"Total Amount: R{finalTotal:F2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

                document.Close();

                byte[] bytes = ms.ToArray();

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Invoice.pdf");
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }

        private decimal ApplyDiscount(decimal totalAmount)
        {
            
            return totalAmount >= 300000 ? totalAmount * 0.10m : 0;
        }
    }
}