<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="patientportal_changepassword.aspx.cs" Inherits="ITP311.patientportal_changepassword" %>

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
    <script src="js/changepassword.js"></script>
    <script src="js/password.js"></script>

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
                                <a href="PatientPortal_updateProfile.aspx"><i class="fa fa-user fa-fw" aria-hidden="true"></i>Profile</a>
                            </li>
                            <li>
                                <a href="patientportal_changepassword.aspx"><i class="fa fa-user fa-fw" aria-hidden="true"></i>Change Password</a>
                            </li>
                            <li>
                                <a href="#"><i class="fa fa-cog fa-fw" aria-hidden="true"></i>Settings</a>
                            </li>
                            <li role="separator" class="divider"></li>
                            <li>
                                <a href="patient-logout.aspx"><i class="fa fa-sign-out fa-fw" aria-hidden="true"></i>Logout</a>
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
            <li class>
                <a href="patientportal-dashboard.aspx"><i class="fa fa-home fa-fw" aria-hidden="true"></i>Dashboard</a>
            </li>
            <li>
                <a href="patientportal-appoinment.aspx"><i class="fa fa-calendar fa-fw" aria-hidden="true"></i> Book an appointment</a>
            </li>   
            <li class = "active">
                <a href="PatientPortal_updateProfile.aspx"><i class="fa fa-edit fa-fw" aria-hidden="true"></i>Update Particulars</a>
            </li>
            <li>
                <a href="index.aspx"><i class="fa fa-arrow-left fa-fw" aria-hidden="true"></i> Return to website</a>
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
            <asp:Literal ID="errorMsg" runat="server" Visible="false">
                <div class="alert alert-dismissible alert-danger text-center">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>Incorrect password</strong> Please try again.
                </div>
            </asp:Literal>

            <asp:Literal ID="Passwordmismatch" runat="server" Visible="false">
                <div class="alert alert-dismissible alert-danger text-center">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    Your new password and confirm password does not match. Please try again.
                </div>
            </asp:Literal>

            <asp:Literal ID="successMsg" runat="server" Visible="false">
                <div class="alert alert-dismissible alert-success text-center">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>Password Updated!</strong>
                </div>


            </asp:Literal>
            <div class="panel panel-default">
                <div class="panel-body">
                    <form class="form-horizontal" runat="server">
                        <fieldset>
                            <legend>Change Password</legend>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <label for="inputCurrent" class="control-label">Current Password</label>
                                    <asp:TextBox ID="inputCurrent" TextMode="Password" Width="100%" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <hr />
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <label for="formPassword" class="control-label">New Password</label>
                                    <asp:TextBox ID="formPassword" TextMode="Password" Width="100%" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                    <div class="pwstrength_viewport_progress"></div>
                                </div>

                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <label for="inputCNew" class="control-label">Confirm New Password</label>
                                    <asp:TextBox ID="inputCNew" TextMode="Password" Width="100%" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                    <span id="pwmatch" class="glyphicon glyphicon-remove" style="color: #FF0004;"></span>Passwords Match
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-12 text-center">
                                    <asp:Button CssClass="btn btn-default" runat="server" Text="Change Password" ID="submit" OnClick="submit_Click" />
                                </div>
                            </div>


                        </fieldset>
                    </form>
                </div>
            </div>
        </div>
    </div>

</body>

</html>

