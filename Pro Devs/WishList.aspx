<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="WishList.aspx.cs" Inherits="Pro_Devs.WishList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="p-2"></div>
    <div class="p-2"></div>
    <div class="container mt-5""> 
            <div class="row justify-content-center"> 
                <div class="col-md-8"> 
                    <div class="watch-card">
                        <table class="table table-bordered fw-normal mx-auto text-center"> 
                            <thead>
                                <tr class="text-primary">
                                    <th>Image</th>
                                    <th>Name</th>
                                    <th>Price</th>
                                    <th>Actions</th>
                                    <th>Add to Cart</th>
                                </tr>
                            </thead>
                            <tbody id="WishlistInfo" runat="server">
                                <!-- Wishlist items will be dynamically populated here -->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
     <div class="col-2">
       <div class="text-center mt-4">
           <a href="Products.aspx" class="btn btn-outline-success">Back to Products</a>
                  
       </div>
    </div>
      <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
</asp:Content>
