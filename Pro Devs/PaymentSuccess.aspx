<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="PaymentSuccess.aspx.cs" Inherits="Pro_Devs.PaymentSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-4"></div>
    <div class="container mt-5">
        <div class="card shadow-lg">
            <div class="card-header bg-success text-white text-center">
                <h4>Payment Successful!</h4>
            </div>
            <div class="card-body text-center">
          

                <h5>Payment</h5>
                <div class="card mb-3">
                    <div class="card-body">
                        <asp:Label ID="lblSummary" runat="server" CssClass="text-dark"></asp:Label>
                    </div>
                </div>

                <div class="text-center mt-4">

                </div>
            </div>
        </div>
         <div class="col-2">
            <div class="text-center mt-4">
                <div class="btn-group" role="group" >
                    <asp:Button ID="btnDownloadInvoice" runat="server" CssClass="btn btn-outline-warning" Text="View Invoice" OnClick="Invoice_Click" />
                                        <asp:Button ID="btnContinueShopping" runat="server" Text="Continue Shopping" CssClass="btn btn-outline-success" OnClick="btnContinueShopping_Click" />
                </div>
            </div>
        </div>
        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    </div>
</asp:Content>
