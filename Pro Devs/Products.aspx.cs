using Pro_Devs.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro_Devs
{
    public partial class Products : System.Web.UI.Page
    {
        ServiceClient SC = new ServiceClient();
        private bool Manager;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Manager = Session["UserType"] != null && Session["UserType"].ToString() == "Manager";
                GetProducts();
                GetBestSellingProducts();
            }



        }


        //The method  that dynamically  get  products from the database
        private void GetProducts()
        {


            string Display = "";

            dynamic Products = SC.GetAllProducts();

            if (Products != null)
            {
                foreach (Product p in Products)
                {


                    if (Manager)
                    {

                        Display += "<div class='col-md-4 mb-4'>";
                        Display += "<div class='watch-card text-center'>";
                        Display += "<img src=" + p.ImageUrl_ + " class='img-fluid' + alt='Smart Watch 1'>";
                        Display += "<div class='watch-content'>";
                        Display += "<h5 class='text-success'>" + p.Name + "</h5>";
                        Display += "<p class='text-warning'> R" + p.Price + "</p>";
                        Display += "<p class='text-description'>" + p.Description + "</p>";
                        Display += "<a href='ProductEdit.aspx?Id=" + p.Id + "' class='btn btn-success me-2' >Edit Product</a>";
                        Display += "<a href='ProductDelete.aspx?Id=" + p.Id + "' class='btn btn-warning'>Delete Product</a>";
                        Display += "</div>";
                        Display += "</div>";
                        Display += "</div>";
                    }
                    else
                    {
                        Display += "<div class='col-md-4 mb-4'>";
                        Display += "<div class='watch-card text-center'>";
                        Display += "<img src=" + p.ImageUrl_ + " class='img-fluid' + alt='Smart Watch 1'>";
                        Display += "<div class='watch-content'>";
                        Display += "<h5 class='text-success'>" + p.Name + "</h5>";
                        Display += "<p class='text-warning'> R" + p.Price + "</p>";
                        Display += "<p><a href='AboutProduct.aspx?Id=" + p.Id + "' class='p-1 text-light text-decoration-none'>More details</a></P>";
                        Display += "<a href='ShoppingCart.aspx?Id=" + p.Id + "'class='btn btn-success ms-1'>Add to Cart</a>";
                        Display += "<a href='Wishlist.aspx?Id=" + p.Id + "' class='btn btn-success ms-3'><i class='fa-solid fa-heart'></i></a>";                      
                        Display += "</div>";                       
                        Display += "</div>";        
                        Display += "</div>";
                    }

                }

                AllProducts.InnerHtml = Display;
            }
        }

        private void GetBestSellingProducts()
        {
            string display = "";

            dynamic bestSellingProducts = SC.GetBestSellingProducts(); 

            if (bestSellingProducts != null)
            {
                foreach (Product p in bestSellingProducts)
                {
                    display += "<div class='col-md-4 mb-4'>";
                    display += "<div class='watch-card text-center'>";
                    display += "<img src='" + p.ImageUrl_ + "' class='img-fluid' alt='" + p.Name + "'>";
                    display += "<div class='watch-content'>";
                    display += "<h5 class='text-success'>" + p.Name + "</h5>";
                    display += "<p class='text-warning'> R" + p.Price + "</p>";
                    display += "<p><a href='AboutProduct.aspx?Id=" + p.Id + "' class='p-1 text-light text-decoration-none'>More details</a></p>";
                    display += "<a href='ShoppingCart.aspx?Id=" + p.Id + "' class='btn btn-success ms-1'>Add to Cart</a>";
                    display += "<a href='Wishlist.aspx?Id=" + p.Id + "' class='btn btn-success ms-3'><i class='fa-solid fa-heart'></i></a>";
                    display += "</div>";
                    display += "</div>";
                    display += "</div>";
                }

                BestSellingProducts.InnerHtml = display; // Set the inner HTML of the new section
            }
        }

        //The method to get the products from the database and sort them according to thier catagory
        private void ShowProducts(string category)
        {
            try
            {
                var products = SC.GetProductsByCategory(category);
                Manager = Session["UserType"] != null && Session["UserType"].ToString() == "Manager";

                if (products != null && products.Any())
                {
                    string Display = "";

                    foreach (Product p in products)
                    {
                        // Create a unique ID for each button to identify the product

                        if (Manager)
                        {
                            Display += "<div class='col-md-4 mb-4'>";
                            Display += "<div class='watch-card text-center'>";
                            Display += "<img src=" + p.ImageUrl_ + " class='img-fluid' + alt='Smart Watch 1'>";
                            Display += "<div class='watch-content'>";
                            Display += "<h5 class='text-success'>" + p.Name + "</h5>";
                            Display += "<p class='text-warning'> R" + p.Price + "</p>";
                            Display += "<p class='text-warning'>★★★☆☆</p>";
                            Display += "<p class='text-description'>" + p.Description + "</p>";
                            Display += "<a href='ProductEdit.aspx?Id=" + p.Id + "' class='btn btn-success me-2' >Edit Product</a>";
                            Display += "<a href='ProductDelete.aspx?Id=" + p.Id + "' class='btn btn-warning'>Delete Product</a>";
                            Display += "</div>";
                            Display += "</div>";
                            Display += "</div>";
                        }
                        else
                        {
                            Display += "<div class='col-md-4 mb-4'>";
                            Display += "<div class='watch-card text-center'>";
                            Display += "<img src='" + p.ImageUrl_ + "' class='img-fluid' alt='Smart Watch'>";
                            Display += "<div class='watch-content'>";
                            Display += "<h5 class='text-success'>" + p.Name + "</h5>";
                            Display += "<p class='text-warning'> R" + p.Price + "</p>";
                            Display += "<p><a href='AboutProduct.aspx?Id=" + p.Id + "' class='p-1 text-light text-decoration-none'>More details</a></P>";
                            Display += "<a href='ShoppingCart.aspx?Id=" + p.Id + "'class='btn btn-success ms-1'>Add to Cart</a>";
                            Display += "<a href='Wishlist.aspx?addId=" + p.Id + "' class='btn btn-success ms-3'><i class='fa-solid fa-heart'></i></a>";
                            Display += "</div>";
                            Display += "</div>";
                            Display += "</div>";
                        }

                    }

                    AllProducts.InnerHtml = Display;
                }
                else
                {
                    // Handle case where no products are returned
                    AllProducts.InnerHtml = "<p class='text-success'>No products available in this category.</p>";
                }
            }
            catch (Exception ex)
            {
                // Log the error and show a friendly message
                Console.WriteLine("Error displaying products: " + ex.Message);
                AllProducts.InnerHtml = "<p class='text-danger'>Sorry, an error occurred while loading products.</p>";
            }
        }




        private void ShowProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var products = SC.GetProductsByPriceRange(minPrice, maxPrice);
                Manager = Session["UserType"] != null && Session["UserType"].ToString() == "Manager";

                if (products != null && products.Any())
                {
                    string Display = "";

                    foreach (Product p in products)
                    {


                        if (Manager)
                        {
                            Display += "<div class='col-md-4 mb-4'>";
                            Display += "<div class='watch-card text-center'>";
                            Display += "<img src=" + p.ImageUrl_ + " class='img-fluid' + alt='Smart Watch 1'>";
                            Display += "<div class='watch-content'>";
                            Display += "<h5 class='text-success'>" + p.Name + "</h5>";
                            Display += "<p class='text-warning'> R" + p.Price + "</p>";
                            Display += "<p class='text-warning'>★★★☆☆</p>";
                            Display += "<p class='text-description'>" + p.Description + "</p>";
                            Display += "<a href='ProductEdit.aspx?Id=" + p.Id + "' class='btn btn-success me-2' >Edit Product</a>";
                            Display += "<a href='ProductDelete.aspx?Id=" + p.Id + "' class='btn btn-warning'>Delete Product</a>";
                            Display += "</div>";
                            Display += "</div>";
                            Display += "</div>";
                        }
                        else
                        {
                            Display += "<div class='col-md-4 mb-4'>";
                            Display += "<div class='watch-card text-center'>";
                            Display += "<img src='" + p.ImageUrl_ + "' class='img-fluid' alt='Smart Watch'>";
                            Display += "<div class='watch-content'>";
                            Display += "<h5 class='text-success'>" + p.Name + "</h5>";
                            Display += "<p class='text-warning'> R" + p.Price + "</p>";
                            Display += "<p><a href='AboutProduct.aspx?Id=" + p.Id + "' class='p-1 text-light text-decoration-none'>More details</a></P>";
                            Display += "<a href='ShoppingCart.aspx?Id=" + p.Id + "'class='btn btn-success ms-1'>Add to Cart</a>";
                            Display += "<a href='Wishlist.aspx?addId=" + p.Id + "' class='btn btn-success ms-3'><i class='fa-solid fa-heart'></i></a>";
                            Display += "</div>";
                            Display += "</div>";
                            Display += "</div>";
                        }
                    }


                    AllProducts.InnerHtml = Display;
                }
                else
                {
                    AllProducts.InnerHtml = "<p class='text-success'>No products available in this price range.</p>";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error displaying products: " + ex.Message);
                AllProducts.InnerHtml = "<p class='text-danger'>Sorry, an error occurred while loading products.</p>";
            }
        }






        protected void btnAll_Click(object sender, EventArgs e)
        {
            GetProducts();
        }
        protected void btnSmartWatches_Click(object sender, EventArgs e)
        {
            ShowProducts("Smart Watches");
        }


        protected void btnRolex_Click(object sender, EventArgs e)
        {

            ShowProducts("Rolex");
        }


        protected void btnOmega_Click(object sender, EventArgs e)
        {
            ShowProducts("Omega");
        }


        protected void ddlPriceRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlPriceRange.SelectedValue;
            string[] range = selectedValue.Split(',');
            decimal minPrice = Convert.ToDecimal(range[0]);
            decimal maxPrice = Convert.ToDecimal(range[1]);

            ShowProductsByPriceRange(minPrice, maxPrice);
        }
    }
}