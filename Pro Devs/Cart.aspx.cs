using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
namespace Pro_Devs
{
    public partial class Cart : System.Web.UI.Page
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
                DisplayCart();
            }
        }

        private void DisplayCart()
        {
            var userId = Convert.ToInt32(Session["UserId"]);
            string display = "";
            string checkoutSummary = "";
            decimal totalAmount = 0;
            decimal vatRate = 0.15m; 
            decimal deliveryFee = 50.00m; 
             

            try
            {
                var cartItems = Client.GetCartItems(userId);
                if (cartItems == null || !cartItems.Any())
                {
                    ShoppingCart.InnerHtml = "<tr><td colspan='5' class='text-center text-warning'>Your cart is empty.</td></tr>";
                    TotalAmount.InnerText = "Total Amount: R0.00";
                    return;
                }
              

                foreach (var item in cartItems)
                {
                    totalAmount += item.Price * item.Quantity;
                    display += "<tr class='text-success'>";
                    display += $"<td><img src='{item.ImageUrl}' alt='{item.Name}' style='width:100px;height:auto;' /></td>";
                    display += $"<td>{item.Name}</td>";
                    display += $"<td>R{item.Price:F2}</td>";
                    display += $"<td>";
                    display += $"<form method='post' action='cart.aspx' style='display:inline;'>";
                    display += $"<input type='hidden' name='action' value='update' />";
                    display += $"<input type='hidden' name='productId' value='{item.ProductId}' />";
                    display += $"<input type='hidden' name='quantity' value='{Math.Max(item.Quantity - 1, 0)}' />";
                    display += $"<button type='submit' class='btn btn-warning btn-sm'>-</button>";
                    display += $"</form>";
                    display += $"<span style='margin:0 10px;'>{item.Quantity}</span>";
                    display += $"<form method='post' action='cart.aspx' style='display:inline;'>";
                    display += $"<input type='hidden' name='action' value='update' />";
                    display += $"<input type='hidden' name='productId' value='{item.ProductId}' />";
                    display += $"<input type='hidden' name='quantity' value='{item.Quantity + 1}' />";
                    display += $"<button type='submit' class='btn btn-success btn-sm'>+</button>";
                    display += $"</form>";
                    display += $"</td>";
                    display += $"<td><a href='Cart.aspx?removeId={item.ProductId}' class='btn btn-danger btn-sm'>Remove</a></td>";
                    display += "</tr>";

                    checkoutSummary += "<li class='list-group-item d-flex justify-content-between lh-condensed'>";
                    checkoutSummary += "<div>";
                    checkoutSummary += $"<h6 class='my-0'>{item.Name}</h6>";
                    checkoutSummary += "</div>";
                    checkoutSummary += $"<span class='text-muted'>R{item.Price * item.Quantity:F2}</span>";
                    checkoutSummary += "</li>";
                }


               
                decimal vatAmount = totalAmount * vatRate;
                decimal discount = ApplyDiscount(totalAmount);
                totalAmount -= discount; 
                decimal amountWithVat = totalAmount + vatAmount + deliveryFee;

                ShoppingCart.InnerHtml = display;
                CheckoutCart.InnerHtml = checkoutSummary;
                Subtotal.InnerText = $"Subtotal: R{totalAmount:F2} - Discount: R{discount:F2} + VAT (15%): R{vatAmount:F2}";
                TotalAmount.InnerText = $"Total Amount due: R{amountWithVat:F2}";
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Request.QueryString["removeId"] != null)
            {
                int removeID = Convert.ToInt32(Request.QueryString["removeId"]);
                RemoveFromCart(removeID);
                Response.Redirect("Cart.aspx");
            }

            if (Request.Form["action"] == "update")
            {
                int productId = Convert.ToInt32(Request.Form["productId"]);
                int quantity = Convert.ToInt32(Request.Form["quantity"]);
                UpdateQuantity(productId, quantity);
                Response.Redirect("Cart.aspx");
            }
        }

        private void RemoveFromCart(int prodID)
        {
            var userId = Convert.ToInt32(Session["UserId"]);
            Client.RemoveFromCart(userId, prodID);
        }

        private void UpdateQuantity(int productId, int quantity)
        {
            var userId = Convert.ToInt32(Session["UserId"]);
            if (quantity > 0)
            {
                Client.UpdateCart(userId, productId, quantity);
            }
            else
            {
                RemoveFromCart(productId);
            }
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var cartItems = Client.GetCartItems(userId);

               

               
                decimal totalAmount = cartItems.Sum(item => item.Price * item.Quantity);
                decimal discount = ApplyDiscount(totalAmount);
                decimal vatAmount = totalAmount * 0.15m;
                decimal deliveryFee = 50.00m; 
                decimal amountWithVat = totalAmount - discount + vatAmount + deliveryFee;

                // Create the invoice
                var invoice = Client.Checkout(userId);

                if (invoice != null) 
                {
                    Response.Redirect("PaymentSuccess.aspx");
                }
                else
                {
                    lblError.Text = "An error occurred during checkout. Please try again.";
                    lblError.Visible = true;
                }

             
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
                lblError.Visible = true;
            }
        }


        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Invoice.aspx");
        }

       

        private decimal ApplyDiscount(decimal totalAmount)
        {
            if (totalAmount >= 300000)
            {
                return totalAmount * 0.10m; 
            }
            return 0; 
        }
    }
}
