<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetpassword.aspx.cs" Inherits="ITP311.forgetpassword" Async="true" %>

<!DOCTYPE htm>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Silver Medical - Forget Password</title>

    <!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="font-awesome-4.6.3/css/font-awesome.min.css">
    <link rel="stylesheet" href="css/forgetpassword.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

    <script src="js/jquery-2.2.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>



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
                        <a href="/index.aspx/#contact-us">Contact Us</a>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="login-register.aspx">Log In</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

    <!-- Top content -->
    <div class="top-content">

        <asp:Literal ID="error" runat="server" Text="
        &lt;div class=&quot;alert alert-dismissible alert-danger&quot;&gt;
            &lt;button type=&quot;button&quot; class=&quot;close&quot; data-dismiss=&quot;alert&quot;&gt;&amp;times;&lt;/button&gt;
            Invalid Email Address, Please Try Again.
        &lt;/div&gt;
        "
            Visible="False"></asp:Literal>

        <asp:Literal ID="success" runat="server" Visible="false">

            <div class="alert alert-dismissible alert-success">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>Success!</strong> Please check your inbox to reset your password.

            </div>

        </asp:Literal>



        <div class="inner-bg">
            <div class="container">
                <div class="row">
                    <div class="col-lg-10-offset-2  ">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h2>Forget Password</h2>
                            </div>
                            <div class="panel-body">
                                To reset your password, enter the email address you used to register with us. Instructions of resetting your password will be sent to you.<br />
                                <br />

                                <form class="form-horizontal" runat="server">
                                    <fieldset>
                                        <div class="form-group">
                                            <label for="inputEmail" class="col-lg-4 control-label">Email</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox class="form-control" runat="server" ID="inputEmail" Width="350px" />
                                                <br />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <asp:Button runat="server" class="btn btn-default" ID="emailForget" OnClick="emailForget_Click" Text="submit" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </form>
                            </div>
                        </div>

                    </div>
                </div>
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

    <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->

</body>

</html>

