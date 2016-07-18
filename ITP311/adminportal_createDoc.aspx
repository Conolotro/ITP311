<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminportal_createDoc.aspx.cs" Inherits="ITP311.adminportal_createDoc" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Admin - Dashboard</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>


    <!-- Custom styles for this template -->
    <link href="font-awesome-4.6.3/css/font-awesome.min.css" rel="stylesheet"/>
    <link href="css/dashboard.css" rel="stylesheet"/>

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
                                <a href="#"><i class = "fa fa-user fa-fw" aria-hidden="true"></i>Profile</a>
                            </li>
                            <li>
                                <a href="#"><i class = "fa fa-cog fa-fw" aria-hidden="true"></i>Settings</a>
                            </li>
                            <li role="separator" class="divider"></li>
                            <li>
                                <a href="#"><i class = "fa fa-sign-out fa-fw" aria-hidden="true"></i> Logout</a>
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
            <li class="active">
                <a href="adminportal.html"><i class="fa fa-home fa-fw" aria-hidden="true"></i> Home</a>
            </li>
            <li>
                <a href=".."><i class="fa fa-calendar fa-fw" aria-hidden="true"></i> Appointment</a>
            </li>
            <li>
                <a href=".."><i class="fa fa-medkit fa-fw" aria-hidden="true"></i> Medicine</a>
            </li>
            <li>
                <a href=".."><i class="fa fa-users fa-fw" aria-hidden="true"></i> Accounts</a>
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
                <li>Accounts</li>
                <li class="active">Create Account</li>
            </ol>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Create Doctor Account</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="col-md-12">
                            <form class="form-horizontal" id="form1" runat="server">
                                <fieldset>
                                    
                                    <div class="form-group">
                                        <label for="inputNric" class="col-lg-2 control-label">NRIC</label>
                                        <div class="col-lg-10">
                                            <asp:Textbox ID="tbNric" type="text" class="form-control" runat="server"/>
                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label for="inputFN" class="col-lg-2 control-label">First Name</label>
                                        <div class="col-lg-10">
                                            <asp:Textbox ID="tbFname" type="text" class="form-control" runat="server" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputLN" class="col-lg-2 control-label">Last Name</label>
                                        <div class="col-lg-10">
                                            <asp:Textbox ID="tbLname" type="text" class="form-control" runat="server"/>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputContact" class="col-lg-2 control-label">Contact Number</label>
                                        <div class="col-lg-10">
                                            <asp:Textbox ID="tbContact" type="number" class="form-control" runat="server"/>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputEmail" class="col-lg-2 control-label">Email</label>
                                        <div class="col-lg-10">
                                            <asp:Textbox ID="tbEmail" type="text" class="form-control" runat="server" />
                                        </div> 
                                    </div>

                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Account Type</label>
                                        <div class="col-lg-10">
                                       <asp:DropDownList ID="ddlType" runat="server" class="form-control">
									   <asp:ListItem Text ="Doctor" Value ="d"/>
                                       <asp:ListItem Text ="Surgeon" Value ="s"/>
                                       <asp:ListItem Text ="admin" Value ="a"/>
                                </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <div class="col-lg-10 col-lg-offset-2">
                                            <asp:Button ID="btnCancel" runat="server" type="reset" class="btn btn-default" Text="Cancel" />
                                            <asp:Button ID="btnSubmit" runat="server" type="submit" class="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click"/>
                                        </div>
                                    </div>
                                </fieldset>
                            </form>
                        </div>
                    </div>
                 </div>
                    <!-- /.col-->
                </div>
                <!-- /.row -->

                <!--/.row-->










            </div>
            <!--/.row-->

</body>

</html>
