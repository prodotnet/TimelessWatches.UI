<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Pro_Devs.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-2"></div>
    <div class="p-2"></div>
    <div class="container mt-5">
        <h4 class="text-center text-warning mb-4">Your Cart</h4>
        <div class="row">
            <!-- Cart Table Column -->
            <div class="watch-card col-md-8">
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
                    <tbody id="ShoppingCart" runat="server">
                        <!-- Cart items will be dynamically populated here -->
                    </tbody>
                </table>
            </div>
            
            <!-- Checkout Section Column -->
            <div class="col-md-4">
                <div class="watch-card mb-4">
                    <form class="card p-2">
                        <h4 class="d-flex justify-content-between align-items-center mb-3">
                            <span class="text-success">Checkout</span>
                        </h4>
                        <ul class="list-group mb-3" id="CheckoutCart" runat="server">
                            <!-- Product summary items will be dynamically populated here -->
                        </ul>
                        <div class="text-right mt-4">
                            <span class="h7 text-dark" id="Subtotal" runat="server"></span><br />
                            <span class="h6 text-dark" id="TotalAmount" runat="server"></span>

                            <br />
                            
                        </div>
                    </form>
                 
                </div>
            </div>
        </div>
    </div>
    <hr class="border-success my-4" style="border-width: 3px;"/>
        <div class="p-4"></div>
         <div class="row justify-content-center">
           <div class="watch-card col-md-8">
                <div class="watch-card mb-4">
                    <div class="card p-2">
                        <h4 class="text-success">Payment</h4>
                        <div class="d-block my-3">
                            <asp:RadioButton ID="rbCredit" runat="server" GroupName="paymentMethod" CssClass="custom-control-input" checked="true" />
                            <label class="custom-control-label" for="rbCredit">Credit card</label>
                            <asp:RadioButton ID="rbDebit" runat="server" GroupName="paymentMethod" CssClass="custom-control-input" />
                            <label class="custom-control-label" for="rbDebit">Debit card</label>
                            <asp:RadioButton ID="rbPaypal" runat="server" GroupName="paymentMethod" CssClass="custom-control-input" />
                            <label class="custom-control-label" for="rbPaypal">Paypal</label>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="cc-name">Name on card</label>
                                <asp:TextBox ID="txtCardName" runat="server" CssClass="form-control" required="true" />
                                <div class="invalid-feedback">Name on card is required</div>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label for="cc-number">Credit card number</label>
                                <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" required="true" />
                                <div class="invalid-feedback">Credit card number is required</div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 mb-3">
                                <label for="cc-expiration">Expiration</label>
                                <asp:TextBox ID="txtCardExpiration" runat="server" CssClass="form-control" required="true" />
                                <div class="invalid-feedback">Expiration date required</div>
                            </div>
                            <div class="col-md-3 mb-3">
                                <label for="cc-cvv">CVV</label>
                                <asp:TextBox ID="txtCardCVV" runat="server" CssClass="form-control" required="true" />
                                <div class="invalid-feedback">Security code required</div>
                            </div>
                        </div>
                        <hr class="mb-4">
                                          
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success btn-lg btn-block" Text="Checkout" OnClick="btnPayment_Click" />
                      </div>
                </div>
            </div>
   </div>
       <div class="col-2">
       <div class="text-center mt-4">
           <a href="Products.aspx" class="btn btn-outline-success">Continue Shopping</a>
                  
       </div>
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    <asp:Label ID="lblInvoiceDetails" runat="server" CssClass="text-success"></asp:Label>

</asp:Content>
