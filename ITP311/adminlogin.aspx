<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="ITP311.adminlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Admin Login</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>


    <!-- Custom styles for this template -->
    <link href="font-awesome-4.6.3/css/font-awesome.min.css" rel="stylesheet"/>
    <link href="css/adminLogin.css" rel="stylesheet"/>

    <!-- javascript -->
    <script src="js/adminlogin.js"></script>
</head>
<body>
<div class="container-fluid">
  <div class="row">
    <div class="col-sm-6 col-sm-offset-3">
       <div class="panel panel-primary" id = "box">
           <div class="panel-heading">
                <h3 class="panel-title">Login</h3> <i id="lock-icon" class="fa fa-lock"></i>
           </div>

           <div class="panel-body" >
                  <p>Enter your username and password to log in:</p>

                  <form id="form1" runat="server">
                    <label class="sr-only" for="form-username">Username</label>
                    <asp:TextBox name="username" placeholder="Username..."
                           class="form-username form-control" id="formUsername" runat="server" />

                   <br/>
                    <label class="sr-only" for="form-password">Password</label>
                    <asp:Textbox type="password" name="password" placeholder="Password..."
                           class="form-password form-control" id="formPassword" runat="server"/>
                    
                    <br/>
                    
                    
                    <div class = "span6">
                        <asp:Button id="submitbutton" type="submit" class="btn btn-success" Text="Sign in"  runat="server" OnClick="submitbutton_Click"/>
                    </div>
                  
                  </form>
           </div>
       </div>
    </div>
  </div>
</div>
</body>
</html>
