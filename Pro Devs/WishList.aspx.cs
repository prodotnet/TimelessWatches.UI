using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class WishList : System.Web.UI.Page
    {
        ServiceClient Client = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                int productId = Convert.ToInt32(Request.QueryString["Id"]);
                AddToWishlist(productId);
            }

            if (!IsPostBack)
            {
                DisplayWishlist();
            }
        }

        private void DisplayWishlist()
        {
            // Retrieve wishlist from session
            List<Product> wishlistItems = Session["Wishlist"] as List<Product>;

            string Display = "";

            if (wishlistItems != null && wishlistItems.Count > 0)
            {
                foreach (var product in wishlistItems)
                {
                    Display += "<tr>";
                    Display += "<td><img src='" + product.ImageUrl_ + "' alt='" + product.Name + "' style='width:100px;height:auto;' /></td>";
                    Display += "<td>" + product.Name + "</td>";
                    Display += "<td>R" + product.Price + "</td>";
                    Display += "<td>";
                    Display += "<a href='Wishlist.aspx?removeId=" + product.Id + "' class='btn btn-danger btn-sm'>Remove</a>";
                    Display += "</td>";
                    Display += "<td>";
                    Display += "<a href='Wishlist.aspx?AddToCart=" + product.Id + "' class='btn btn-success btn-sm'>Add to Cart</a>";
                    Display += "</td>";
                    Display += "</tr>";
                }
            }
            else
            {
                Display = "<tr><td colspan='5'>Your wishlist is empty.</td></tr>";
            }

            WishlistInfo.InnerHtml = Display;
        }

        // Adding  a product to the wishlist
        private void AddToWishlist(int productId)
        {

            Product product = Client.GetProduct(productId);


            List<Product> wishlistItems = Session["Wishlist"] as List<Product> ?? new List<Product>();

            // Check if the product is already in the wishlist
            if (!wishlistItems.Exists(p => p.Id == product.Id))
            {
                wishlistItems.Add(product);
                // Save back to session
                Session["Wishlist"] = wishlistItems;
            }

            Response.Redirect("Wishlist.aspx");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Request.QueryString["removeId"] != null)
            {
                int removeID = Convert.ToInt32(Request.QueryString["removeId"]);
                RemoveFromWishlist(removeID);
                Response.Redirect("Wishlist.aspx");
            }

            if (Request.QueryString["AddToCart"] != null)
            {
                int productId = Convert.ToInt32(Request.QueryString["AddToCart"]);
                AddToCart(productId);
                Response.Redirect("Cart.aspx");
            }
        }

        private void RemoveFromWishlist(int prodID)
        {
            List<Product> wishlistItems = Session["Wishlist"] as List<Product>;

            if (wishlistItems != null)
            {
                var productToRemove = wishlistItems.Find(p => p.Id == prodID);
                if (productToRemove != null)
                {
                    wishlistItems.Remove(productToRemove);
                    Session["Wishlist"] = wishlistItems;
                }
            }
        }

        private void AddToCart(int prodID)
        {
            List<Product> wishlistItems = Session["Wishlist"] as List<Product>;

            if (wishlistItems != null)
            {
                var productToMove = wishlistItems.Find(p => p.Id == prodID);

                if (productToMove != null)
                {
                    int userId = Convert.ToInt32(Session["UserId"]);
                    int quantity = 1;

                    // Add product to cart
                    bool isAdded = Client.AddToCart(userId, prodID, quantity);

                    if (isAdded)
                    {
                        // Remove from wishlist after adding to cart
                        wishlistItems.Remove(productToMove);
                        Session["Wishlist"] = wishlistItems;
                    }
                    else
                    {
                        // Log the failure reason
                        lblError.Text = "Failed to add to cart. Please try again.";
                        lblError.Visible = true;
                    }
                }
            }
        }

    }
}