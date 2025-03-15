<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Pro_Devs.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-2"></div>
    
<asp:ScriptManager ID="ScriptManager1" runat="server" />
 <div class="p-4"></div>
<!-- All Watches Section -->
<div class="all-watches-section container mt-5" id="Products">

    <!-- UpdatePanel  To avoid the page refreshing when clicking the category buttons  -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <div class="container mt-5">
               <div class="d-flex justify-content-between mb-4">

                   <div class="d-flex justify-centre mb-4">
                       <!-- Button Group for Categories -->
                           <div class="btn-group" role="group" aria-label="Product Categories">
                              <asp:Button ID="btnAll" runat="server" CssClass="btn btn-success" Text="All" OnClick="btnAll_Click" />
                              <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Smart Watches" OnClick="btnSmartWatches_Click" />
                              <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Rolex" OnClick="btnRolex_Click" />
                              <asp:Button ID="Button3" runat="server" CssClass="btn btn-success" Text="Omega" OnClick="btnOmega_Click" />
                         </div>
                  </div>

                        <!-- Price Range Filters -->       
                   <div class="d-flex align-items-center">
                         <asp:DropDownList ID="ddlPriceRange" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPriceRange_SelectedIndexChanged" CssClass="form-select">
                            <asp:ListItem Text="Select Price Range" Value="0,400000" />
                            <asp:ListItem Text="0 - 2000" Value="0,2000" />
                            <asp:ListItem Text="2000 - 60000" Value="2000,60000" />
                            <asp:ListItem Text="80000 - 100000" Value="80000,100000" />
                            <asp:ListItem Text="100000 - 400000" Value="100000,400000" />
                        </asp:DropDownList>
                  </div>
              </div>
        </div>

        <div class="row" id="AllProducts" runat="server">
           
            <!-- Product items will be dynamically loaded here -->
         
        </div>




        </ContentTemplate>
    </asp:UpdatePanel>
</div>

<hr class="border-success my-4" style="border-width: 3px;"/>



<div class="best-selling-section container mt-5">
    <h2 class="text-center text-warning">Best Selling Products</h2>
    <div class="row" id="BestSellingProducts" runat="server">
        <!-- Best selling products will be dynamically loaded here -->
    </div>
</div>


</asp:Content>
