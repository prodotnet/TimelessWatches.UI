<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Pro_Devs.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

<div id="carouselExample" class="carousel slide p-7" data-bs-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="img/home/watt3.jpg" class="d-block w-100 carousel-image" alt="Watch 1">
      <div class="carousel-caption d-none d-md-block">
        <h1 class="display-4">Welcome to WatchHub!</h1>
        <p class="lead">Redefining time keeping.</p>
        <p>Explore our range of products and find the perfect watch for you. We offer a wide selection of the latest watches, from top brands to budget-friendly options.</p>
        <p>
           
           <a href="#Catagorty" class="btn btn-success">Browse Categories</a>
        </p>
      </div>
    </div>
    <div class="carousel-item">
      <img src="img/1Rolexx.jpg" class="d-block w-100 carousel-image" alt="Watch 2">
      <div class="carousel-caption d-none d-md-block">
          <h1 class="display-4">Welcome to WatchHub!</h1>
          <p class="lead">Redefining time keeping.</p>
          <p>Rolex watches are celebrated for their reliability, luxurious materials, and their role as a status symbol in the world of horology.</p>
          <p>

         
          <a href="#Catagorty" class="btn btn-success">Browse Categories</a>
      </p>
      </div>
    </div>
    <div class="carousel-item">
      <img src="img/1omega1.jpg"  class="d-block w-100 carousel-image" alt="Watch 3">
      <div class="carousel-caption d-none d-md-block">
       <h1 class="display-4">Welcome to WatchHub!</h1>
        <p class="lead">Redefining time keeping.</p>
        <p>Experience the timeless  innovation of Omega watches, renowned for their luxury and historic achievements.</p>
        <p>

        
         <a href="#Catagorty" class="btn btn-success">Browse Categories</a>
       </p>
      
      </div>
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>

</div>
  


<!-- Categories Section -->
<div class="ad-section container mt-5" id="Catagorty">
    <h3 class="text-center text-warning mb-4">Our Product Categories</h3>
    <div class="row"  id="ViewCatagorty" runat="server">
        <!-- Smart watch-->
        <div class="col-md-4 mb-4">
            <div class="watch-card  text-center">
                <img src="img/w3.jpg" class="img-fluid"  alt="Watches">
                <div class="ad-content">
                     <h3 class="text-warning">Smart Watches</h3>
                     <p class="text-description">Discover the latest smartwatches with advanced features and connectivity options.</p>
                </div>
            </div>
        </div>

         <!-- Rolex Watches -->
        <div class="col-md-4 mb-4">
            <div class="watch-card  text-center">
                <img src="img/1Rolexx.jpg"" class="img-fluid" alt="Watches">
                <div class="ad-content">
                    <h3 class="text-warning">Rolex</h3>
                     <p class="text-description">Explore our collection of premium Rolex watches known for their luxury and precision.</p>
                </div>
            </div>
        </div>




        <!-- Omega Watches -->
        <div class="col-md-4 mb-4">
        <div class=" watch-card  text-center">
         <img src="img/1omega1.jpg" class="card-img-top img-fluid" alt="Watches">
          <div class="card-body ad-content">
           <h3 class="text-warning">Omega</h3>
           <p class="text-description">Experience the timeless  innovation of Omega watches, renowned for their luxury and historic achievements.</p>    
    </div>
  </div>
</div>
    </div>
</div>

 <hr />

<!-- New Arrivals Section -->
<div class="new-arrivals-section container mt-5">
    <h2 class="text-center text-warning mb-4">New Arrivals</h2>
    <div class="row">
         <!-- Samsung Smartwatch -->
        <div class="col-md-4 mb-4">
            <div class="new-arrival-card text-center">
                <img src="img/watch1.jpg" class="img-fluid" alt="New Arrival 1">
                <div class="new-arrival-content">
                     <h3 class="text-warning">Samsung Smartwatch</h3>
                    <p class="text-description">Experience the future of wearables with the Samsung Smartwatch. Featuring cutting-edge technology, sleek design, and seamless connectivity, this smartwatch is your perfect companion for a smart lifestyle.</p>
                   
                </div>
            </div>
        </div>

        <!-- rolex -->
        <div class="col-md-4 mb-4">
            <div class="new-arrival-card text-center">
                <img src="img/A.jpg" class="img-fluid" alt="New Arrival 2">
                <div class="new-arrival-content">
                     <h3 class="text-warning">Rolex</h3>
                     <p class="text-description">Introducing the latest addition to our luxury collection, the Rolex. Known for its timeless elegance and exceptional craftsmanship, this watch is a true symbol of prestige and sophistication.</p>
                   
                    
                </div>
            </div>
        </div>

        <!-- New smartwatch 1 -->
        <div class="col-md-4 mb-4">
            <div class="new-arrival-card text-center">
                <img src="img/w4.jpg" class="img-fluid" alt="New Arrival 3">
                <div class="new-arrival-content">
                    <h3 class="text-warning">Apple Smartwatch</h3>
                    <p class="text-description">Discover the ultimate blend of style and functionality with the Apple Smartwatch. Packed with advanced features and designed for everyday use, this smartwatch helps you stay connected and active.</p>
                </div>
            </div>
        </div>
    </div>
</div>





 <hr  class="text-success"/>

</asp:Content>
