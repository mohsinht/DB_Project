<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loggedIn.aspx.cs" Inherits="DB_Project.loggedIn" %>

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
        <h1 class="h3 mb-3 font-weight-normal"><b>Welcome</b> to your account</h1>
        <p>You are now logged in.</p>
        <p class="mt-2 mb-3 text-center" style="color:blue">
           <asp:Label ID="showErrorsd" runat="server"></asp:Label>
        </p>
      </div>
      <div class="form-label-group">
        <asp:TextBox ID="inputNamed" class="form-control" placeholder="Username" runat='server' Enabled="false"></asp:TextBox>
        <label for="inputNamed">Username</label>
      </div>
      <div class="form-label-group">
        <asp:TextBox ID="inputEmaild" class="form-control" placeholder="Password" runat='server' Enabled="false"></asp:TextBox>
        <label for="inputEmaild">Email Address</label>
      </div>
      <div class="form-label-group">
        <asp:TextBox ID="inputUserTyped" class="form-control" placeholder="Password" runat='server' Enabled="false"></asp:TextBox>
        <label for="inputUserTyped">User Type</label>
      </div>
      <asp:Button OnClick="logout" CssClass="btn btn-lg btn-primary btn-block" runat="server" ID="registerButtond" Text="Logout"/>
      <p class="mt-2 mb-3 text-muted text-center">FAST-NU Room Sharing App &copy; 2017-2018</p>
    </form>

 
</body>
</html>
