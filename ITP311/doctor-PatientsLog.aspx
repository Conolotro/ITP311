<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doctor-PatientsLog.aspx.cs" Inherits="ITP311.doctor_PatientsLog" %>

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
            <li>
                <a href="adminportal.html"><i class="fa fa-home fa-fw" aria-hidden="true"></i> Home</a>
            </li>
            <li>
                <a href=""><i class="fa fa-calendar fa-fw" aria-hidden="true"></i> Appointment</a>
            </li>
            <li>
                <a href=""><i class="fa fa-medkit fa-fw" aria-hidden="true"></i> Medicine</a>
            </li>
            <li>
                <a href="">
                    <i class="fa fa-users fa-fw" aria-hidden="true"></i> Accounts</a>
            </li>

            <li class="active">
                <a href="">
                    <i class="fa fa-tasks fa-fw" aria-hidden="true"></i> Patients' Log
                </a>
                
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
            </ol>
        </div>
        <!--/.row-->
        <div class="row">

        </div>
            <div class="column" style="margin-top:3%;">
                <div class="panel panel-default">
                    <!-- Default panel contents -->
                    <div class="panel-heading" style="padding-left:3%;padding-bottom:7%; "><h3>Patients' Log</h3>
                    <ul class="user-menu" style="margin-top:-4.8%;">
                    <li class="dropdown pull-right">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="fa fa-plus fa-fw" aria-hidden="true"></i>Create <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li>
                                <a href="CreatePatientsLog.aspx"><i class="fa fa-file-text-o fa-fw" aria-hidden="true" data-toggle="modal" data-target="#formNewPatient">></i>New Log</a>

                            </li>
                            <li>
                                <a href="#"><i class="fa fa-file-text-o fa-fw" aria-hidden="true"></i>Generate Medical Certificate</a>
                            </li>
                        </ul>
                    </li>
                    </ul>    
                    </div>
                    
                    <div class="panel-body" >
                        <div style="margin:1.35%;margin-top:-1.35%;width:25%;float:left; ">
                            <h3 style="margin-left:3%;">Select Case<asp:GridView ID="gvCaseNumber" style="font-size:15px;width:100%;" runat="server" DataKeyNames="dateTime" SelectedIndex="0"  AutoGenerateColumns="False" PageSize="5" OnSelectedIndexChanged="gvCaseNumber_SelectedIndexChanged">
                    <Columns>
                        
                        <asp:BoundField DataField="dateTime" HeaderText="Date Time" SortExpression="dateTime" />

                        <asp:BoundField DataField="caseNo" HeaderText="Case Number" SortExpression="caseNo"/>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last"
                        Mode="NumericFirstLast" PageButtonCount="5" />

                    <RowStyle BackColor="White" />

                </asp:GridView>
                            </h3>

                            
                        </div>
                        <div class="panel panel-default" style="width:65%;overflow:hidden;;padding-left:0%;">
                        
                            <div class="input-group" style="float:right;width:30%;">
                                <input type="hidden" class="form-control" placeholder="SXXXXXXXXH">
                                <br/>
                            </div>
                        <div class="panel-heading" style="margin-top:-3.3%;">
                            <h3 class="panel-title"><h3 style="padding-bottom:5%;">Patients' Medical History</h3>
                        </div>
                        <div class="panel-body">
                            <p>&nbsp;Number :<asp:Label ID="caseNumberLbl" runat="server"></asp:Label>
                            </p>
                            <br/>
                            <p>NRIC : <asp:Label ID="nricLbl" runat="server"></asp:Label>
                            </p>
                            <br/>
                            <p>Date of Log : 
                                <asp:Label ID="dateOfLogLbl" runat="server"></asp:Label>
                            </p>
                            <br/>
                            <p>Symptoms : 
                                <asp:Label ID="symptomsLbl" runat="server"></asp:Label>
                            </p>
                            <br/>
                            
                            <p>Diagnosis : <asp:Label ID="diagnosisLbl" runat="server"></asp:Label>
                            </p><br/>
                            <p>Prescription : 
                                <asp:Label ID="prescriptionLbl" runat="server"></asp:Label>
                            </p>
                            <div class="button-group" style="float:right;">
                            <button type="button" class="btn btn-primary">Medical Certificate</button>
                            <button type="button" class="btn btn-primary">Update</button>
                            <button type="button" class="btn btn-danger">Delete</button>
                            </div>
                        </div>
                    </div>
                    </div>
                    </div>
                    </div>
                </div>


    </form>
    

</body>

</html>