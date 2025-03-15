<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Pro_Devs.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="p-2"></div>
    <div class="p-2"></div>
    <div class="container mt-5">
        <h4 class="text-center text-warning mb-4">your Shopping Cart</h4>
         <div class="row justify-content-center">
            <!-- Cart Table Column -->
            <div class=" watch-card col-md-8">
                <table class="table table-bordered" style="background-color: #333;">
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Quantity</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody id="Cart" runat="server">
                        <!-- Cart items will be dynamically populated here -->
                    </tbody>
                </table>
            </div>
           
        </div>
    </div>
       <div class="col-2">
       <div class="text-center mt-4">
           <a href="Products.aspx" class="btn btn-outline-success">Continue Shopping</a>
                  
       </div>
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
</asp:Content>
