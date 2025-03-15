using Pro_Devs.ServiceReference1;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class ShoppingCart : System.Web.UI.Page
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
                if (Request.QueryString["Id"] != null)
                {
                    // adding the a specific  product to the cart
                    AddProductToCart();

                    //   display all product in the shopping cart the product in the cart.
                    DisplayCart();
                }
            }
        }








        private void DisplayCart()
        {
            var userId = Convert.ToInt32(Session["UserId"]);


            try
            {

                var cartItems = Client.GetCartItems(userId);

                if (cartItems == null || !cartItems.Any())
                {
                    Cart.InnerHtml = "<tr><td colspan='5' class='text-center text-warning'>Your cart is empty.</td></tr>";
                  
                    return;
                }

                string display = "";
                string checkoutSummary = "";
                decimal totalAmount = 0;

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


                   


                }

                totalAmount = Client.ApplyDiscount(totalAmount);

                Cart.InnerHtml = display;
              


            }catch (Exception ex)
            {
                return;
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



        private void AddProductToCart()
        {
            string Display = "";

            int prodID = Convert.ToInt32(Request.QueryString["Id"]);
            var product = Client.GetProduct(prodID);

            if (product != null)
            {
                Display += "<tr class='text-success'>";
                Display += "<td><img src='" + product.ImageUrl_ + "' alt='" + product.Name + "' style='width:100px;height:auto;' /></td>";
                Display += "<td>" + product.Name + "</td>";
                Display += "<td>" + product.Price + "</td>";
                Display += "<td>";


                // Add the product to the cart
                int userId = Convert.ToInt32(Session["UserId"]);
                int productId = Convert.ToInt32(Request.QueryString["Id"]);
                int quantity = 1;


                bool isAdded = Client.AddToCart(userId, productId, quantity);

                if (isAdded)
                {
                    Cart.InnerHtml = Display;
                    lblError.Visible = false;
                }
                else
                {
                    lblError.Text = "Failed to add product to the cart.";
                    lblError.Visible = true;
                }

            }
        }




    }



}