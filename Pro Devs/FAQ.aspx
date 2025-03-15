<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Pro_Devs.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="p-2"></div>
     <div class="p-2"></div>
       <div class="container mt-5">
            <h3 class="text-center text-warning mb-4">Frequently Asked Questions</h3>
            <div class="accordion" id="faqAccordion">
                <!-- Question 1 -->
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingOne">
                        <button class="accordion-button " type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            What is Pro Devs WatchHub?
                        </button>
                    </h2>
                    <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#faqAccordion">
                        <div class="accordion-body">
                            Pro Devs WatchHub is an e-commerce platform that offers a wide range of watches, including smartwatches, luxury watches, and more. Our goal is to provide high-quality products and excellent customer service.
                        </div>
                    </div>
                </div>
                <!-- Question 2 -->
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingTwo">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            How can I place an order?
                        </button>
                    </h2>
                    <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#faqAccordion">
                        <div class="accordion-body">
                            To place an order, browse our catalog, select the products you wish to purchase, and add them to your shopping cart. Once you are ready, proceed to checkout, enter your payment information, and confirm your order.
                        </div>
                    </div>
                </div>
               
            </div>
        </div>
</asp:Content>
