<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createprofile.aspx.cs" Inherits="DB_Project.createprofile" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Project</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="floating-labels.css" rel="stylesheet">
</head>
<body>

    <style>
        .form-signin{
            min-width: 94%;
        }
    </style>
    <form class="form-signin" runat="server">
<div class="text-center mb-4">
        <h1 class="h3 mb-3 font-weight-normal">Create a <b>Profile</b> to continue</h1>
        <p>You'll be asked for more information later on. Add your email and password to create a profile.</p>
        <p class="mt-2 mb-3 text-center" style="color:red">
           <asp:Label ID="showErrors" runat="server"></asp:Label>
        </p>
      </div>

        <div class="container">
            <div class ="row">
                <div class ="col-sm">
                    <div class="row">
                      <div class="col-sm">
                          <div class="form-label-group">
                              <asp:TextBox ID="fullName" class="form-control" placeholder="Name" runat='server'></asp:TextBox>
                            <label for="fullName">Full Name</label>
                          </div>
                      </div>
                      <div class="col-sm">
                          <div class="form-label-group">
                              <asp:TextBox ID="phone" class="form-control" placeholder="Name" runat='server'></asp:TextBox>
                            <label for="phone">Phone Number</label>
                          </div>
                      </div>
                    </div>

                    <div class="row">
                      <div class="col-sm">
                          <div class="form-label-group">
                              <asp:TextBox ID="TextBox1" class="form-control" placeholder="Name" runat='server'></asp:TextBox>
                            <label for="fullName">Full Name</label>
                          </div>
                      </div>
                      <div class="col-sm">
                          <div class="form-label-group">
                              <asp:TextBox ID="TextBox2" class="form-control" placeholder="Name" runat='server'></asp:TextBox>
                            <label for="phone">Phone Number</label>
                          </div>
                      </div>
                    </div>

                </div>
                <div class ="col-sm">Profile Pic</div>
            </div>
        </div>
      <div class="form-label-group">
        <!--<input type="text" id="inputEmail" class="form-control" placeholder="Email address" runat='server' required autofocus>-->
          <asp:TextBox ID="inputMail" class="form-control" placeholder="Password" runat='server'></asp:TextBox>
        <label for="inputMail">Email address</label>
      </div>
      <div class="form-label-group">
        <!--<input type="text" id="inputUsername" class="form-control" placeholder="Username" runat='server' required autofocus>-->
          <asp:TextBox ID="inputName" class="form-control" placeholder="Password" runat='server'></asp:TextBox>
        <label for="inputName">Username</label>
      </div>
      <div class="form-label-group">
        <!--<input type="password" id="inputPassword" class="form-control" placeholder="Password" runat='server' required>-->
          <asp:TextBox ID="inputPass" class="form-control" placeholder="Password" runat='server' TextMode="Password"></asp:TextBox>
        <label for="inputPass">Password</label>
      </div>
     
        <asp:Button CssClass="btn btn-lg btn-primary btn-block" runat="server" ID="registerButtoncp" Text="Sign Up"/>
      <p class="mt-3 mb-3 text-center"><a href="login.aspx">Already have an account?</a><br><a href="guest-signup.aspx">Sign up as guest</a></p>
      <p class="mt-2 mb-3 text-muted text-center">FAST-NU Room Sharing App &copy; 2017-2018</p>
    </form>
</body>
</html>

