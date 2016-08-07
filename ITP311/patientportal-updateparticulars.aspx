<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="patientportal-updateparticulars.aspx.cs" Inherits="ITP311.patientportal_updateparticulars" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <form id="form1" runat="server">
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
                                <a href="PatientPortal_updateProfile.aspx"><i class = "fa fa-user fa-fw" aria-hidden="true"></i>Profile</a>
                            </li>
                            <li>
                                <a href="patientportal_changepassword.aspx"><i class="fa fa-user fa-fw" aria-hidden="true"></i>Change Password</a>
                            </li>
                            <li>
                                <a href="#"><i class = "fa fa-cog fa-fw" aria-hidden="true"></i>Settings</a>
                            </li>
                            <li role="separator" class="divider"></li>
                            <li>
                                <a href="patient-logout.aspx"><i class = "fa fa-sign-out fa-fw" aria-hidden="true"></i> Logout</a>
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
                <a href="patientportal-dashboard.aspx"><i class="fa fa-home fa-fw" aria-hidden="true"></i>Dashboard</a>
            </li>
            <li>
                <a href="patientportal-appoinment.aspx"><i class="fa fa-calendar fa-fw" aria-hidden="true"></i> Book an appointment</a>
            </li>
            <li class="active">
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
                <li class="active">Dashboard</li>
            </ol>
        </div>
        <!--/.rowtop-->

    <h2>Welcome, (name)</h2>

    <div>

        <asp:Label ID="lblNRIC" runat="server" Text="NRIC No.:" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbNRIC" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblName" runat="server" Text="Name:" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbDOB" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblAdd" runat="server" Text="Address:" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbAdd" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblAll" runat="server" Text="Allergy(s):" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbAll" runat="server"></asp:TextBox>

        <br />
        <br />

    </div>
        
        </div>
    </form>

    </body>
</html>
