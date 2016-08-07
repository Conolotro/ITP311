<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPortal_enquiry.aspx.cs" Inherits="ITP311.adminPortal_enquiry" Async="true" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Admin - Dashboard</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">


    <!-- Custom styles for this template -->
    <link href="font-awesome-4.6.3/css/font-awesome.min.css" rel="stylesheet">
    <link href="css/dashboard.css" rel="stylesheet">

    <!-- javascript -->
    <script src="js/jquery-2.2.4.min.js"></script>
    <script src="js/adminlogin.js"></script>
    <script src="js/bootstrap.min.js"></script>

</head>

<body>

    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#"><span>Silverwood</span> Medical</a>
                <ul class="user-menu">
                    <li class="dropdown pull-right">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="fa fa-user fa-fw" aria-hidden="true"></i>User <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li>
                                <a href="adminportal_updateProfile.aspx"><i class="fa fa-user fa-fw" aria-hidden="true"></i>Profile</a>
                            </li>
                            <li>
                                <a href="#"><i class="fa fa-cog fa-fw" aria-hidden="true"></i>Settings</a>
                            </li>
                            <li role="separator" class="divider"></li>
                            <li>
                                <a href="admin_logout.aspx"><i class="fa fa-sign-out fa-fw" aria-hidden="true"></i>Logout</a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>

        </div>
        <!-- /.container-fluid -->
    </nav>

    <div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar">
        <ul class="nav menu">
            <li>
                <a href="adminportal.aspx"><i class="fa fa-home fa-fw" aria-hidden="true"></i>Home</a>
            </li>
            <li class="active">
                <a href="adminportal_mail.aspx"><i class="fa fa-home fa-fw" aria-hidden="true"></i>Mail</a>
            </li>
            <li>
                <a href="#"><i class="fa fa-calendar fa-fw" aria-hidden="true"></i>Appointment</a>
            </li>
            <li>
                <a href="#"><i class="fa fa-medkit fa-fw" aria-hidden="true"></i>Medicine</a>
            </li>
            <li>
                <a href="#">
                    <i class="fa fa-users fa-fw" aria-hidden="true"></i>Accounts</a>
            </li>

            <li role="presentation" class="divider"></li>
        </ul>

    </div>
    <!--/.sidebar-->


    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li>
                    <a href="#">
                        <i class="fa fa-home fa-fw" aria-hidden="true"></i>
                    </a>
                </li>
                <li class="active">Dashboard</li>
                <li class="active">Enquries</li>
            </ol>
        </div>

        <!--/.row-->

        <asp:Literal ID="successMsg" runat="server" Visible ="false">

            <div class="alert alert-dismissible alert-success text-center">
  <button type="button" class="close" data-dismiss="alert">&times;</button>
  <strong> Success </strong> Your email has been sent to the user's inbox.
</div>
        </asp:Literal>


        <div class="panel panel-default">
            <div class="panel-heading">Enquiry #000001</div>
            <div class="panel-body">
                <div class="media">
                    <div class="media-left media-middle">
                        <img class="media-object" src="http://placehold.it/35x35" alt="...">
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">
                            <asp:Literal ID="name" runat="server"></asp:Literal></h4>
                        <asp:Literal ID="email" runat="server"></asp:Literal>
                    </div>
                </div>
                <br />
                <asp:Literal ID="messageEnquiry" runat="server"></asp:Literal>
                <br />
                <br />
                <hr>
                <form runat="server">
                    <div class="form-group">
                        <label for="textArea" class="col-lg-12 control-label">Reply</label>
                        <div class="col-lg-12">
                            <asp:TextBox runat="server" ID="replybox" CssClass="form-control" TextMode="MultiLine" Rows="6" Width="100%"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:Button runat="server" class="btn btn-default btn-block" Text="Send" ID="submit" OnClick="submit_Click" />
                        </div>
                    </div>
                </form>
            </div>
        </div>


    </div>
    <!--/.row-->
</body>

</html>

