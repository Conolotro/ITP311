<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminReset.aspx.cs" Inherits="ITP311.adminReset" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Reset Password</title>

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
                <h3 class="panel-title">Reset Password</h3> <i id="lock-icon" class="fa fa-lock"></i>
           </div>

           <div class="panel-body" >

                  <form id="form1" runat="server">
                  <p>Enter your new password and confirm new password </p>

                    <label class="sr-only" for="form-username">Password</label>
                    <asp:TextBox type="password" style="display:inline-block" name="username" placeholder="Password"
                           class="form-username form-control" id="formPassword" runat="server" AutoPostBack="True" OnTextChanged="formPassword_TextChanged" />
                      &nbsp;&nbsp;&nbsp;
                      
                    <label class="sr-only" for="form-password">Confirm Password</label>&nbsp;
                      <asp:Label ID="Label1" style="text-align:center" runat="server" Font-Names="Lucida Sans" Height="35px" Font-Size="Large"></asp:Label>
                      <br />
                      <br />
                    <asp:Textbox type="password" style="" name="password" placeholder="Confirm Password"
                           class="form-password form-control" id="formConfirmPassword" runat="server"/>
                    
                    <br>
                    
                    
                    <div class = "span6">
                        <asp:Button id="submitbutton" type="submit" class="btn btn-success" Text="Confirm"  runat="server" OnClick="submitbutton_Click"/>
                    </div>
                  
                  </form>
           </div>
       </div>
    </div>
  </div>
</div>
</body>
</html>
