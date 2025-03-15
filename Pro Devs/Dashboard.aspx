<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Pro_Devs.Dashboard" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="p-2"></div>
    <div class="p-2"></div>
   
    <div class="container mt-5">
     
        <div class="row">
            <div class="col-md-3">
                <div class=" watch-card mb-3  text-white">
                    <div class="card-body">
                        <h5 class="card-title text-warning">Total Products Sold</h5>
                        <asp:Label ID="lblTotalProductsSold" runat="server" CssClass="card-text text-success"></asp:Label>
                    </div>
                </div>
            </div>
         
            <div class="col-md-3">
                <div class="watch-card  mb-3  text-white">
                    <div class="card-body">
                        <h5 class="card-title text-warning">Total Orders Placed</h5>
                        <asp:Label ID="lblTotalOrders" runat="server" CssClass="card-text text-success"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="watch-card  mb-3  text-white">
                    <div class="card-body">
                        <h5 class="card-title text-warning">Available Stock</h5>
                        <asp:Label ID="lblAvailableStock" runat="server" CssClass="card-text text-success"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="watch-card  mb-3 text-white">
                    <div class="card-body">
                        <h5 class="card-title text-warning">Registered Users Today</h5>
                        <asp:Label ID="lblRegisteredUsersToday" runat="server" CssClass="card-text text-success"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <hr class="border-success my-4" style="border-width: 3px;"/>

       <div class=" justify-content-center mb-4">
              
               
                <div class="d-flex align-items-center">
                    <label for="txtStartDate" class="me-2 text-success">Start Date:</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control me-3" TextMode="Date" />
                    
                    <label for="txtEndDate" class="mx-3 text-success">End Date:</label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control me-3" TextMode="Date" />
                    
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success ms-3" Text="Filter" OnClick="btnFilterByDate_Click" />
                </div>
                
               
           
            </div>
         <div class="p-2"></div>
         <!-- Graphs -->
        <div class="row mt-4">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-success text-white">
                        Total Products Sold Over Time
                    </div>
                    <div class="card-body">
                        <canvas id="productsSoldChart"></canvas>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-success text-white">
                        Orders Placed Over Time
                    </div>
                    <div class="card-body">
                        <canvas id="ordersPlacedChart"></canvas>
                    </div>
                </div>
            </div>
        </div>
          <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    </div>
     <div class="p-2"></div>
   

   
    <script>
        function renderCharts(productsSoldData, ordersPlacedData) {
            var ctx1 = document.getElementById('productsSoldChart').getContext('2d');
            var productsSoldChart = new Chart(ctx1, {
                type: 'bar',
                data: {
                    labels: productsSoldData.labels,
                    datasets: [{
                        label: 'Total Products Sold',
                        data: productsSoldData.data,
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        borderColor: 'rgba(75, 192, 192, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });

            var ctx2 = document.getElementById('ordersPlacedChart').getContext('2d');
            var ordersPlacedChart = new Chart(ctx2, {
                type: 'bar',
                data: {
                    labels: ordersPlacedData.labels,
                    datasets: [{
                        label: 'Total Orders Placed',
                        data: ordersPlacedData.data,
                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                        borderColor: 'rgba(255, 99, 132, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }
    </script>

    
      
</asp:Content>
