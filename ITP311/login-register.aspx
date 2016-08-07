<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="login-register.aspx.cs" Inherits="ITP311.login_register" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Silver Medical - Login &amp; Registration</title>

    <!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="font-awesome-4.6.3/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/login.css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

    <script src="js/jquery-2.2.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/password.js"></script>
    <script src="js/validator.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#signupbox').validator();
        });
    </script>
</head>
<body>
    <!-- Navigation -->
    <nav class="navbar navbar navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                </button>
                <a class="navbar-brand" href="#">
                    <img src="img/banner-high-heartbeat@1x.png" alt="logo" height="63px" />
                </a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li>
                        <a href="/index.aspx">Home</a>
                    </li>
                    <li>
                        <a href="/index.aspx#about">About</a>
                    </li>
                    <li>
                        <a href="/index.aspx#services">Services</a>
                    </li>
                    <li>
                        <a href="/index.aspx#contact-us">Contact Us</a>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="#">Log In</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>


    <!-- Top content -->
    <div class="top-content">



        <div class="inner-bg">
            <div class="container">
                <form runat="server">
                    <div class="row">
                        <asp:Literal ID="success" runat="server" Visible="false">
                            <div class="alert alert-dismissible alert-success">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>Success!</strong> Please check your inbox to reset your password.
                            </div>

                        </asp:Literal>

                        <asp:Literal ID="errorMsg" runat="server" Visible="false">
                            <div class="alert alert-dismissible alert-danger">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>Database Error!</strong> Please try again later.
                            </div>

                        </asp:Literal>

                        <div class="col-sm-5">
                            <div class="form-box">
                                <div class="form-top">
                                    <div class="form-top-left">
                                        <h3>Login to our site</h3>
                                        <p>Enter username and password to log on:</p>
                                    </div>
                                    <div class="form-top-right">
                                        <i class="fa fa-key"></i>
                                    </div>
                                </div>
                                <div class="form-bottom">
                                    <asp:Label ID="loginError" runat="server" ForeColor="Red" Text="Invalid username or password" Visible="false"></asp:Label>
                                    <div class="form-group">
                                        <label class="sr-only" for="formUsername">Username</label>
                                        <asp:TextBox ID="loginUsername" placeholder="Username..." class="form-username form-control" Width="100%" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="formPassword">Password</label>
                                        <asp:TextBox TextMode="Password" ID="loginPassword" placeholder="Password..." class="form-control" Width="100%" runat="server"></asp:TextBox>
                                        <!-- Trigger the modal with a button -->
                                        <button type="button" class="btn btn-link" data-toggle="modal" data-target="#myModal">Forget your password ?</button>

                                    </div>

                                    <!-- Modal -->
                                    <div id="myModal" class="modal fade" role="dialog">
                                        <div class="modal-dialog modal-mg">

                                            <!-- Modal content-->
                                            <div class="modal-content">

                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h4 class="modal-title">Forget Password</h4>
                                                </div>
                                                <div class="modal-body">
                                                    To reset your password, enter the email address you used to register with us. 
                                                    <br />
                                                    <label class="sr-only" for="forgetEmail">Email:</label>
                                                    <asp:TextBox ID="forgetEmail" placeholder="Email..." class="form-username form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button type="button" class="btn btn-default" ID="resetPassword" OnClick="resetPassword_Click" runat="server" Text="Submit" />
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <asp:Button Text="Sign In" ID="signIn" class="btn btn-default" runat="server" OnClick="signIn_Click" Width="100%" />
                                </div>
                            </div>

                        </div>

                        <div class="col-sm-1 middle-border"></div>
                        <div class="col-sm-1"></div>

                        <div class="col-sm-5">

                            <div class="form-box" id = "signupbox">
                                <div class="form-top">
                                    <div class="form-top-left">
                                        <h3>Sign up now</h3>
                                        <p>Fill in the form below to get instant access:</p>
                                    </div>
                                    <div class="form-top-right">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                </div>
                                <div class="form-bottom">
                                    <div class="form-group">
                                        <label class="sr-only" for="formNRIC">NRIC</label>
                                        <asp:TextBox name="formNRIC" placeholder="NRIC..." class="form-NRIC form-control" AutoComplete="false" ID="formNRIC" data-minlength="9" maxlength="9" runat="server" Width="100%" />
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="formNRIC">Password</label>
                                        <asp:TextBox name="formPassword" TextMode="Password" placeholder="Password..." class="form-password form-control" ID="formPassword" runat="server" Width="100%" />
                                        <div class="pwstrength_viewport_progress"></div>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="formFN">First name</label>
                                        <asp:TextBox name="formFN" placeholder="First name..." class="form-first-name form-control" AutoComplete="false" ID="formFN" runat="server" Width="100%" />
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="formLN">Last name</label>
                                        <asp:TextBox name="formLN" placeholder="Last name..." class="form-last-name form-control" AutoComplete="false" ID="formLN" runat="server" Width="100%" />
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="formPhone">Phone Number</label>
                                        <asp:TextBox TextMode="Phone" name="formPhone" placeholder="Phone Number..." AutoComplete="false" class="form-phonenumber form-control" data-minlength="8" MaxLength="8" ID="formPhone" runat="server" Width="100%" />
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="formEmail">Email</label>
                                        <asp:TextBox TextMode="Email" name="formEmail" placeholder="Email..." class="form-email form-control" AutoComplete="false" ID="formEmail" runat="server" Width="100%" />
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="formEmail">Confirm Email</label>
                                        <asp:TextBox TextMode="Email" name="formCEmail" data-match="#formEmail" placeholder="Confirm Email..." class="form-email form-control" AutoComplete="false" ID="formCEmail" runat="server" Width="100%" data-error="Email not matched" />
                                        <div class="help-block with-errors"></div>                                    
                                    </div>
                                    <div>
                                        <asp:Label runat="server" ID="errorMessage" ForeColor="Red" />
                                    </div>

                                    <asp:Button ID="signUp" class="btn btn-default" Text="Sign me up!" runat="server" Width="100%" OnClick="signUp_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </form>
            </div>
        </div>

    </div>

    <!-- Footer -->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright © Silver Medical Group 2014</p>
                </div>
            </div>
        </div>
    </footer>

</body>
</html>
