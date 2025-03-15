<%@ Page Title="Invoice" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="Pro_Devs.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-4"></div>
    <div class="container mt-5">
        <div class="card shadow-lg">
            <div class="card-header bg-success text-white text-center">
                <h4>Invoice</h4>
            </div>
            <div class="card-body">
                <asp:Label ID="lblInvoiceDetails" runat="server" CssClass="text-success"></asp:Label>

            
                <div class="row mb-4">
                
                    <div class="col-md-6 text-left">
                        <h6><strong>Name:</strong> <asp:Label ID="lblName" runat="server"></asp:Label></h6>
                        <h6><strong>Surname:</strong> <asp:Label ID="lblSurname" runat="server"></asp:Label></h6>
                        <h6><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server"></asp:Label></h6>
                    </div>
                    
                 
                    <div class="col-md-6 text-right">
                        <h6><strong>Date:</strong> <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label></h6>
                    </div>
                </div>

           
                <table class="table text-white" style="background-color: #333;">
                    <thead class="thead-light text-white">
                        <tr>
                            <th class="small">Name</th>
                            <th class="small">Quantity</th>
                            <th class="small">SubTotal</th>
                        </tr>
                    </thead>
                    <tbody id="InvoiceRecord" runat="server">
                        <!-- Invoice items will be dynamically populated here -->
                    </tbody>
                </table>

              
               <div class="text-right">
                     <h6 class="small">Subtotal: <asp:Label ID="lblSubtotal" runat="server" CssClass="text-success"></asp:Label></h6>
                     <h6 class="small">VAT (15%): <asp:Label ID="lblVAT" runat="server" CssClass="text-success"></asp:Label></h6>
                     <h6 class="small">Delivery Fee: <asp:Label ID="lblDeliveryFee" runat="server" CssClass="text-success"></asp:Label></h6>
                     <h6 class="small">Discount: <asp:Label ID="lblDiscount" runat="server" CssClass="text-success"></asp:Label></h6>
                     <h5>Total Amount: <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></h5>
             </div>
            </div>
        </div>

      
        <div class="col-2">
            <div class="text-center mt-4">
                <div class="btn-group" role="group" >
                    <asp:Button ID="btnDownloadInvoice" runat="server" CssClass="btn btn-outline-warning" Text="Download Invoice" OnClick="DownloadInvoice_Click" />
                    <asp:Button ID="btnContinueShopping" runat="server" CssClass="btn btn-outline-success" Text="Continue Shopping" OnClick="btnContinueShopping_Click" />
                </div>
            </div>
        </div>

     
        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    </div>
</asp:Content>
