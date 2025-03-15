<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="AboutProduct.aspx.cs" Inherits="Pro_Devs.AboutProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="p-4"></div>

<div class="all-watches-section container mt-5" id="Products">


      <div class="row justify-content-center" id="About" runat="server">
        <!-- About Product items will be dynamically loaded here -->
     </div>

     <div class="text-center mt-4">
            <a href="Products.aspx" class="btn btn-outline-success">Back to Products</a>
      </div>
</div>
</asp:Content>
