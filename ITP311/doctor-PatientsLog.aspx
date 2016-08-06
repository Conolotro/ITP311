<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doctor-PatientsLog.aspx.cs" Inherits="ITP311.doctor_PatientsLog" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

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
                <li>
                    <a href="adminportal.html"><i class="fa fa-home fa-fw" aria-hidden="true"></i>Home</a>
                </li>
                <li>
                    <a href=""><i class="fa fa-calendar fa-fw" aria-hidden="true"></i>Appointment</a>
                </li>
                <li>
                    <a href=""><i class="fa fa-medkit fa-fw" aria-hidden="true"></i>Medicine</a>
                </li>
                <li>
                    <a href="">
                        <i class="fa fa-users fa-fw" aria-hidden="true"></i>Accounts</a>
                </li>

                <li class="active">
                    <a href="">
                        <i class="fa fa-tasks fa-fw" aria-hidden="true"></i>Patients' Log
                    </a>

                </li>
                <li role="presentation" class="divider"></li>

            </ul>

        </div>
        <!--/.sidebar-->




        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
            <div style="margin-left: 3%;">
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
                <div class="column" style="margin-top: 3%;">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading" style="padding-left: 3%; padding-bottom: 5%;">
                            <h3>Patients' Log</h3>
                            <ul class="user-menu" style="margin-top: -4.8%;">
                                <li class="dropdown pull-right">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="fa fa-plus fa-fw" aria-hidden="true"></i>Create <span class="caret"></span></a>
                                    <ul class="dropdown-menu" role="menu">
                                        <li>
                                            <a href="CreatePatientsLog.aspx"><i class="fa fa-file-text-o fa-fw" aria-hidden="true" data-toggle="modal" data-target="#formNewPatient"></i>New Log</a>

                                        </li>
                                        <li>
                                            <a href="#"><i class="fa fa-file-text-o fa-fw" aria-hidden="true"></i>Generate Medical Certificate</a>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>

                        <div class="panel-body">
                            <div style="margin-top: -1.35%; width: 25%; float: left; height: 405px; width: 350px; margin-left: 1.35%; margin-right: 4%; margin-bottom: 1.35%;">
                                <h3>Select Case</h3>
                                <div style="overflow: scroll; width: 344px; height: 379px;">
                                    <asp:GridView ID="gvCaseNumber" Style="font-size: 15px; margin-right: 0px;" runat="server" ShowHeader="False" DataKeyNames="dateTime" SelectedIndex="1" AutoGenerateColumns="False" PageSize="5" OnSelectedIndexChanged="gvCaseNumber_SelectedIndexChanged" Height="359px" Width="323px">
                                        <Columns>
                                            
                                            <asp:BoundField DataField="BriefDescription" HeaderText="Brief Description" SortExpression="briefDescription" />
                                            <asp:BoundField DataField="dateTime" HeaderText="Date Time" SortExpression="dateTime" />
                                            <asp:BoundField DataField="caseNo" HeaderText="Case Number" SortExpression="caseNo" />
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last"
                                            Mode="NumericFirstLast" PageButtonCount="5" />
                                        <RowStyle BackColor="White" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>


                            </div>
                            <div class="panel panel-default" style="overflow: hidden">

                                <div class="panel-heading" style="margin-top: 0">
                                    <h3 style="padding-bottom: 5%; height: 30px;" class="panel-title">Patients' Medical History</h3>
                                </div>
                                <div class="panel-body">
                                    <div style="float: left; width: 30%;">
                                        <p>
                                            NRIC :
                                    <asp:Label ID="nricLbl" runat="server"></asp:Label>
                                        </p>
                                        <br />
                                        <p>
                                            Date of Log : 
                                <asp:Label ID="dateOfLogLbl" runat="server"></asp:Label>
                                        </p>
                                        <br />
                                        <p style="height: 100px;" aria-multiline="True">
                                            Symptoms : 
                                <asp:Label ID="symptomsLbl" runat="server"></asp:Label>
                                        </p>
                                        <br />
                                        <p>
                                            Diagnosis :
                                    <asp:Label ID="diagnosisLbl" runat="server"></asp:Label>
                                        </p>
                                        <br />
                                        <p>
                                            Prescription : 
                                <asp:Label ID="prescriptionLbl" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                    <div id="chart_div" style="width: 70%; float: left;">
                                        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="400px" Width="500px">
                                            <Series>
                                                <asp:Series Name="Temperature" XValueMember="datetime" YValueMembers="temperature" ChartType="Line" ChartArea="ChartArea1" IsValueShownAsLabel="false" Label="#LEGENDTEXT" Legend="Pressure">
                                                </asp:Series>
                                                <asp:Series Name="Pulse" XValueMember="datetime" YValueMembers="pulse" ChartType="Line" ChartArea="ChartArea1" Label="#LEGENDTEXT" Legend="Pressure">
                                                </asp:Series>
                                                <asp:Series Name="Pressure" XValueMember="datetime" YValueMembers="pressure" ChartType="Line" ChartArea="ChartArea1" Label="#LEGENDTEXT" Legend="Pressure">
                                                </asp:Series>
                                            </Series>

                                            <ChartAreas>

                                                <asp:ChartArea Name="ChartArea1">
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <asp:Legend ItemColumnSeparatorColor="Red" Name="Pressure">
                                                </asp:Legend>
                                                <asp:Legend ItemColumnSeparatorColor="DarkOrange" Name="Pulse">
                                                </asp:Legend>
                                                <asp:Legend ItemColumnSeparatorColor="LightSkyBlue" Name="Temperature">
                                                </asp:Legend>
                                            </Legends>
                                        </asp:Chart>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medicalportal %>" SelectCommand="SELECT [caseNo], [datetime], [temperature], [pressure], [pulse] FROM [PatientsLog] WHERE ([nric] = @nric)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="nricLbl" Name="nric" PropertyName="Text" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </div>
                                <div style="float: right;">
                                    <button type="button" class="btn btn-primary">Medical Certificate</button>
                                    <asp:Button ID="btnUpdatePatientsLog" runat="server" Text="Update" class="btn btn-primary" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnDeletePatientsLog" runat="server" Text="Delete" class="btn btn-primary" OnClientClick="return confirm('Are you sure?')" OnClick="btnDelete_Click" />
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
