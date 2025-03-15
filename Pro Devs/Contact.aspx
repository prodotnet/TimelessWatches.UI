<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Pro_Devs.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-2"></div>
<div class="container mt-5">
    <div class="p-2"></div>
    <div class="row">
        <div class="col-md-6">
            <h2 class="text-success">Get in Touch</h2>
            <p class="text-description">We would love to hear from you! Whether you have questions about our products, need assistance with your order, or just want to give us feedback, feel free to reach out to us through the following channels:</p>
            <ul class="text-description">
                <li><strong>Address:</strong> 123 WatchHub Lane, Time City, WC 12345</li>
                <li><strong>Phone:</strong> (123) 456-7890</li>
                <li><strong>Email:</strong> support@watchhub.com</li>
            </ul>
        </div>
        <div class="col-md-6">
            <h2 class="text-success">Contact Form</h2>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control mb-3" Placeholder="Your Name"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" Placeholder="Your Email" TextMode="Email"></asp:TextBox>
            <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control mb-3" Placeholder="Subject"></asp:TextBox>
            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control mb-3" TextMode="MultiLine" Rows="4" Placeholder="Your Message"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Send Message" />
        </div>
    </div>
</div>
</asp:Content>
