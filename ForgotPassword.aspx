<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Landing Page - Start Bootstrap Theme</title>

    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom fonts for this template -->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css" />
    <link href="css/freelancer.min.css" rel="stylesheet" />


    <!-- Custom styles for this template -->
    <link href="css/landing-page.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation -->
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top" id="mainNav" style="background-color:#343a40!important;">
        <div class="container">
            <a class="navbar-brand js-scroll-trigger" href="#">CODE LIKE A GIRL</a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                Menu
         
                <i class="fa fa-bars"></i>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive" >
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="LandingPage.aspx">Home </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="LandingPage.aspx#about">About</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="LandingPage.aspx#apply">Apply</a>
                        <%--<button id="btnSetting" class="nav-link js-scroll-trigger" onclick="pageRedirect()" runat="server">Settings</button>--%>
            </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="LandingPage.aspx#contactus">Contact Us</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

        <section class="content-section-b" style="height:100vh;  padding-top:30vh;">
      <div class="container">
            <hr class="section-heading-spacer" />
            <div class="clearfix"></div>
            <h2 class="section-heading mb-2" style="color:white">FORGOT PASSWORD</h2>


          <div class="form-inline mt-5">
              <div class="row w-100" style="margin-right: 0px; margin-left: 0px;">
                  <label class="sr-only" for="txtemail">Email id</label>
                  <div class="input-group w-100 mb-4">
                      <div class="input-group-addon">Email address</div>
                      <asp:TextBox type="text" ID="txtemail" class="form-control input-md" placeholder="you@example.com" runat="server" />
                  </div>
              </div>
               <span runat="server" id="span_pwdreset" style="width:100%;color:white; margin-bottom:5vh;"></span>
          </div>
             <asp:Button ID="btnSendLink" class="btn btn-outline-secondary" style="border:2px solid white; color:white;" runat="server" OnClick="btnSendLink_Click" Text="Send password reset link" />
          <br />
          <br />
          <div class="row" runat="server" id="divMsg" style="align-content: center; color: white; font-size: large;"></div>

      </div>
      <!-- /.container -->

    </section>
    </form>


     <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/popper/popper.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!-- other scripts-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="js/freelancer.min.js"></script>

</body>
</html>