<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DB_Project.index" %>

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
        <h1 class="h3 mb-3 font-weight-normal">Login to your <b>Account</b></h1>
        <p>Your host/guest profile will be shown after logging in.</p>
        <p class="mt-2 mb-3 text-center" style="color:red">
           <asp:Label ID="showErrorsl" runat="server"></asp:Label>
        </p>
      </div>
      <div class="form-label-group">
        <asp:TextBox ID="inputNamel" class="form-control" placeholder="Username" runat='server'></asp:TextBox>
        <label for="inputNamel">Username</label>
      </div>
      <div class="form-label-group">
        <asp:TextBox ID="inputPassl" class="form-control" placeholder="Password" runat='server' TextMode="Password"></asp:TextBox>
        <label for="inputPassl">Password</label>
      </div>

      <div class="checkbox mb-3">
        <label>
          <input type="checkbox" value="remember-me"> Remember me
        </label>
      </div>
      <asp:Button OnClick="login" CssClass="btn btn-lg btn-primary btn-block" runat="server" ID="registerButton" Text="Login"/>
      <p class="mt-3 mb-3 text-center"><a href="index.aspx">Create a new account?</a></p>
      <p class="mt-2 mb-3 text-muted text-center">FAST-NU Room Sharing App &copy; 2017-2018</p>
    </form>
</body>
</html>
