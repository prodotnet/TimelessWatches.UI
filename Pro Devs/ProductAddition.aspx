<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="ProductAddition.aspx.cs" Inherits="Pro_Devs.ProductAddition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-2"></div>
     <div class="p-2"></div>
    <div class="container mt-5">
        <h2 class="text-center text-warning mb-4">Add New Product</h2>

        <asp:Panel ID="pnlAddProduct" runat="server" CssClass="card p-4">
            <div class="card-body">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>

                 <asp:Form >
                   
                    <div class="form-group">
                        <asp:Label ID="lblImageUrl" runat="server" AssociatedControlID="fileUploadImage" Text="Image:" CssClass="form-label"></asp:Label>
                        <asp:FileUpload ID="fileUploadImage" runat="server" CssClass="form-control" />
                    </div>
                    
                    <div class="form-group">
                        <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName" Text="Product Name:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblDescription" runat="server" AssociatedControlID="txtDescription" Text="Description:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblPrice" runat="server" AssociatedControlID="txtPrice" Text="Price:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblCategory" runat="server" AssociatedControlID="ddlCategory" Text="Category:" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select Category" Value="" />
                            <asp:ListItem Text="Smart Watches" Value="Smart Watches" />
                            <asp:ListItem Text="Rolex" Value="Rolex" />
                            <asp:ListItem Text="Omega" Value="Omega" />
                        </asp:DropDownList>
                    </div>

                   

                    <div class="form-group">
                        <asp:Button ID="btnAddProduct" runat="server" CssClass="btn btn-success" Text="Add Product" OnClick="btnAddProduct_Click" />
                    </div>
                </asp:Form>
            </div>
        </asp:Panel>
    </div>

</asp:Content>

