<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guest-signup.aspx.cs" Inherits="DB_Project.guest_signup" %>

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
    </style>
    <form class="form-signin" runat="server">
 <div class="text-center mb-4">
        <h1 class="h3 mb-3 font-weight-normal">Become a <b>Guest</b></h1>
        <p>You'll be asked for more information later on. Add your email and password to create a profile.</p>
       <p class="mt-2 mb-3 text-center" style="color:red">
           <asp:Label ID="showErrorsg" runat="server"></asp:Label>
        </p>
      </div>

      <div class="form-label-group">
       
          <asp:TextBox ID="inputMailg" class="form-control" placeholder="Password" runat='server'></asp:TextBox>
        <label for="inputMailg">Email address</label>
      </div>
      <div class="form-label-group">
          <asp:TextBox ID="inputNameg" class="form-control" placeholder="Password" runat='server'></asp:TextBox>
        <label for="inputNameg">Username</label>
      </div>
      <div class="form-label-group">
     
          <asp:TextBox ID="inputPassg" class="form-control" placeholder="Password" runat='server' TextMode="Password"></asp:TextBox>
        <label for="inputPassg">Password</label>
      </div>
     
        <asp:Button OnClick="signup_Guest" CssClass="btn btn-lg btn-primary btn-block" runat="server" ID="registerButtong" Text="Sign Up"/>
      <p class="mt-3 mb-3 text-center"><a href="login.aspx">Already have an account?</a><br><a href="host-signup.aspx">Sign up as host</a></p>
      <p class="mt-2 mb-3 text-muted text-center">FAST-NU Room Sharing App &copy; 2017-2018</p>
    </form>
</body>
</html>

