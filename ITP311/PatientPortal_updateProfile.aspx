<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientPortal_updateProfile.aspx.cs" Inherits="ITP311.PatientPortal_updateProfile" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Patients - Dashboard</title>

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
                <a class="navbar-brand" href="#"><span>Medicx</span> Inc</a>
                <ul class="user-menu">
                    <li class="dropdown pull-right">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="fa fa-user fa-fw" aria-hidden="true"></i>User <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li>
                                <a href="#"><i class="fa fa-user fa-fw" aria-hidden="true"></i>Profile</a>
                            </li>
                            <li>
                                <a href="#"><i class="fa fa-cog fa-fw" aria-hidden="true"></i>Settings</a>
                            </li>
                            <li role="separator" class="divider"></li>
                            <li>
                                <a href="#"><i class="fa fa-sign-out fa-fw" aria-hidden="true"></i>Logout</a>
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
                <a href="patientportal-dashboard.html"><i class="fa fa-home fa-fw" aria-hidden="true"></i>Dashboard</a>
            </li>
            <li>
                <a href="patientportal-appoinment.html"><i class="fa fa-calendar fa-fw" aria-hidden="true"></i>Book an appointment</a>
            </li>
            <li>
                <a href="index.html"><i class="fa fa-arrow-left fa-fw" aria-hidden="true"></i>Return to website</a>
            </li>

            <li role="presentation" class="divider"></li>
        </ul>
        <!--/.sidebar-->
    </div>



    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li>
                    <a href="#">
                        <i class="fa fa-home fa-fw" aria-hidden="true"></i>
                    </a>
                </li>
                <li class="active">Profile</li>
            </ol>
        </div>
        <!--/.rowtop-->
        <div class="row">
            <asp:Literal ID="successMsg" runat="server" Visible="false">

            <div class="alert alert-dismissible alert-success text-center">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <b>Success!</b> You have updated your personal particulars.
            </div>

            </asp:Literal>


            <form runat="server" class="form-horizontal">
                <fieldset>
                    <legend>Update Profile</legend>
                    <div class="form-group">
                        <label for="inputFirstName" class="col-lg-2 control-label">First Name</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="inputFirstName" Width="100%" class="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputLastName" class="col-lg-2 control-label">Last Name</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="inputLastName" Width="100%" class="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputAddress" class="col-lg-2 control-label">Address</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="inputAddress" Width="100%" class="form-control" placeholder="Address" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputContact" class="col-lg-2 control-label">Contact No.</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="inputContact" TextMode="Phone" Width="100%" class="form-control" placeholder="91231230" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputDOB" class="col-lg-2 control-label">Date of Birth</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="inputDOB" Width="100%" class="form-control" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail" class="col-lg-2 control-label">E-Mail</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="inputEmail" TextMode="Email" Width="100%" class="form-control" placeholder="e-mail" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <button type="button" class="btn btn-default" data-toggle="modal" data-target="#myModal">Update</button>
                        </div>
                    </div>
                </fieldset>

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Please enter your password to continue</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="inputEmail" class="col-lg-2 control-label">Password</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="inputPassword" TextMode="Password" Width="100%" class="form-control" placeholder="password..." runat="server"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-default" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>


            </form>

        </div>
    </div>

</body>

</html>
