<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nricForgotPassword.aspx.cs" Inherits="ITP311.nricForgotPassword"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Forgot Password</title>

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
                <h3 class="panel-title">Forgot Password</h3> <i id="lock-icon" class="fa fa-lock"></i>
           </div>

           <div class="panel-body" >

                  <form id="form1" runat="server">
                      <center>
                  <p>Enter your NRIC below and we will send you the email along with a temporary password to reset your password </p>

                    <label class="sr-only" for="form-username">NRIC</label>
                    <asp:TextBox type="text" style="display:inline-block" name="nric" placeholder="NRIC"
                           class="form-username form-control" id="formNRIC" runat="server" Width="251px" />
                      &nbsp;<br />
                    
                    <br>
                    
                    
                    <div class = "span6">
                        <asp:Button id="submitbutton" type="submit" class="btn btn-success" Text="Confirm"  runat="server" OnClick="submitbutton_Click"/>
                        <asp:Button id="buttonCancel" type="submit" class="btn btn-success2" Text="Cancel"  runat="server" OnClick="cancel_buttonClick"/>
                    </div>
                          </center>
                  
                  </form>
           </div>
       </div>
    </div>
  </div>
</div>
</body>
</html>
