<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePatientsLog.aspx.cs" Inherits="ITP311.UpdatePatientsLog" %>

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
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                <a class="navbar-brand" href="#"><span>Medicx</span> Inc</a>
                <ul class="user-menu">
                    <li class="dropdown pull-right">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user fa-fw" aria-hidden="true"></i>User <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="#"><i class="fa fa-user fa-fw" aria-hidden="true"></i>Profile</a> </li>
                            <li><a href="#"><i class="fa fa-cog fa-fw" aria-hidden="true"></i>Settings</a> </li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#"><i class="fa fa-sign-out fa-fw" aria-hidden="true"></i>Logout</a> </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
        <!-- /.container-fluid -->
    </nav>
    <div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar">
        <ul class="nav menu">
            <li><a href="adminportal.html"><i class="fa fa-home fa-fw" aria-hidden="true"></i>Home</a> </li>
            <li><a href=""><i class="fa fa-calendar fa-fw" aria-hidden="true"></i>Appointment</a> </li>
            <li><a href=""><i class="fa fa-medkit fa-fw" aria-hidden="true"></i>Medicine</a> </li>
            <li>
                <a href=""><i class="fa fa-users fa-fw" aria-hidden="true"></i>Accounts</a>
            </li>
            <li class="active">
                <a href=""><i class="fa fa-tasks fa-fw" aria-hidden="true"></i>Patients' Log </a>
            </li>
            <li role="presentation" class="divider"></li>
        </ul>
    </div>
    <!--/.sidebar-->
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div style="margin-left: 0.5%;">
            <div class="row" style="margin-left:0.05%;">
                <ol class="breadcrumb">
                    <li>
                        <a href="#"><i class="fa fa-file-text-o" aria-hidden="true"></i></a>
                    </li>
                    <li class="active">Create new log</li>

                </ol>
            </div>
            <!--/.row-->

                <div class="main panel panel-default" style="width: 100%; height: 100%">
                    <div class="panel-heading" style=" padding-bottom: 5%;">
                        <h2>Create Patients' Log</h2>
                    </div>
                    <form runat="server">
                        <div class="modal-body panel-body">
                            <div class="form-group">
                                <label for="title">Brief Description : </label>
                                <asp:TextBox name="title" class="form-control " ID="briefDescriptiontbx" runat="server" Width="385px" />
                            </div>
                            <div class="form-group">
                                <div style="float: left; margin-right: 3%;">
                                    <label for="pressure">Pressure (mmHG)</label>
                                    <asp:TextBox name="pressure" class="formDoctorsNotes form-control " ID="pressuretbx" runat="server" Width="90px" />
                                </div>
                                <div style="float: left; margin-right: 3%;">
                                    <label for="pulse">Pulse (BPM)</label>
                                    <asp:TextBox name="pulse" class="formDoctorsNotes form-control " ID="pulsetbx" runat="server" Width="90px" />
                                </div>
                                <div>
                                    <label for="temperature">Temperature (Degree Celcius)</label>
                                    <asp:TextBox name="temperature" class="formDoctorsNotes form-control " ID="temperaturetbx" runat="server" Width="90px" />
                                </div>

                            </div>
                            <div class="form-group">
                                <label for="symptoms">Symptoms</label>
                                <asp:TextBox name="symptoms" class="formDoctorsNotes form-control " ID="symptomstbx" runat="server" Width="637px" Height="96px" TextMode="MultiLine" />
                            </div>

                            <div class="form-group">
                                <label for="formDoctorsNotes">Doctor's Notes</label>
                                <asp:TextBox name="formDoctorsNotes" class="formDoctorsNotes form-control " ID="formDoctorsNotes" runat="server" Width="637px" Height="96px" TextMode="MultiLine" />
                            </div>

                            <div class="modal-footer">
                                <asp:Button ID="updateLog" class="btn btn-default" Text="Update Log" runat="server" OnClientClick="return confirm('Are you sure?')" OnClick="updateLog_Click" />
                                <asp:Button ID="cancelUpdate" class="btn btn-default" Text="Cancel" runat="server" OnClick="cancelUpdate_Click" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
    </div>
</body>

</html>

