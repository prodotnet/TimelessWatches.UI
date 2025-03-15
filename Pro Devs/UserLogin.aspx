<%@ Page Title="" Language="C#" MasterPageFile="~/ProDevs.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Pro_Devs.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="p-2"></div>
<section class="p-4 p-md-3  mt-5">
  <div class="container" >
    <div class="card border-light-subtle shadow-sm" style=" background-color: #333;">
      <div class="row g-0">
        <div class="col-12 col-md-6 text-bg-success">
          <div class="d-flex align-items-center justify-content-center h-100">
            <div class="col-10 col-xl-7 py-2">
              <img class="img-fluid rounded mb-3" loading="lazy" src="img/account.jpg" width="245" height="80" alt="BootstrapBrain Logo">
              <hr class="border-primary-subtle mb-3">
                <h2 class="h3 mb-3">Experience Luxury with Our Exclusive Watches</h2>
                <p class="lead mb-4">Login to explore our exclusive collection and find the perfect watch for you.</p>
            </div>
          </div>
        </div>
        <div class="col-12 col-md-6">
          <div class="card-body p-2 p-md-3 p-xl-4">
            <div class="row">
              <div class="col-12">
                <div class="mb-4">
                 
                  <h3  class="form-label text-warning" style="text-align:center;">Login</h3>
                </div>
              </div>
            </div>
            <form>
              <div class="row gy-2 gy-md-3 overflow-hidden">
                <div class="col-12">
                  <label for="email" class="form-label text-light">Email <span class="text-danger">*</span></label>
                  <input type="email" class="form-control" name="email" id="email"  runat="server" required>
                </div>
                <div class="col-12">
                  <label for="password" class="form-label text-light">Password <span class="text-danger">*</span></label>
                  <input type="password" class="form-control" name="password" id="password" runat="server" required>
                </div>
                <div class="col-12">
                  <div class="form-check">
                    <input class="form-check-input " type="checkbox" value="" name="remember_me" id="remember_me">
                    <label class="form-check-label text-light" for="remember_me">
                      Remember Me
                    </label>
                  </div>

                  <div class="col-12">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                </div>
                <div class="col-12">
                  <div class="d-grid">
                   
                      <asp:Button ID="Button1" class="btn bsb-btn-xl btn-success" runat="server"  type="submit" Text="Submit" OnClick="Login_Click" />
                  </div>
                </div>
              </div>
            </form>
            <div class="row">
              <div class="col-12">
                <hr class="mt-4 mb-3 border-secondary-subtle">
                <div class="d-flex gap-2 flex-column flex-md-row justify-content-md-end">
                 <p class="link-light"> Do Not Have An Account? <a href="UserRegistration.aspx" class="link-success text-decoration-none"> Register</a></p> 
                  
                </div>
              </div>
            </div>
            
          </div>
        </div>
      </div>
    </div>
  </div>
</section>

</asp:Content>
