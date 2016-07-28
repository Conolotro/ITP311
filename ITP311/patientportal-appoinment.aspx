<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="patientportal-appoinment.aspx.cs" Inherits="ITP311.patientportal_appoinment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Patients - Appointments</title>

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
    <div>
    
    </div>
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
            <li class="active">
                <a href="patientportal-dashboard.aspx"><i class="fa fa-home fa-fw" aria-hidden="true"></i>Dashboard</a>
            </li>
            <li>
                <a href="patientportal-appoinment.aspx"><i class="fa fa-calendar fa-fw" aria-hidden="true"></i> Book an appointment</a>
            </li>
            <li>
                <a href="patientportal-updateparticulars.html"><i class="fa fa-edit fa-fw" aria-hidden="true"></i>Update Particulars</a>
            </li>
            <li>
                <a href="index.html"><i class="fa fa-arrow-left fa-fw" aria-hidden="true"></i> Return to website</a>
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
                        <i class="fa fa-calendar fa-fw" aria-hidden="true"></i>
                    </a>
                </li>
                <li class="active">Book an appointment</li>
            </ol>
        </div>
        <!--/.row-->

        <legend>Appointment Details</legend>

            <br />

            <asp:Label ID="lblDate" runat="server" Text="Date: " Font-Size="Large"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlDate" runat="server" EnableTheming="False" Font-Size="Large">
                <asp:ListItem>Select date</asp:ListItem>
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlMonth" runat="server" Font-Size="Large">
                <asp:ListItem>Select month</asp:ListItem>
                <asp:ListItem>Jan (01)</asp:ListItem>
                <asp:ListItem>Feb (02)</asp:ListItem>
                <asp:ListItem>Mar (03)</asp:ListItem>
                <asp:ListItem>Apr (04)</asp:ListItem>
                <asp:ListItem>May (05)</asp:ListItem>
                <asp:ListItem>June (06)</asp:ListItem>
                <asp:ListItem>July (07)</asp:ListItem>
                <asp:ListItem>Aug (08)</asp:ListItem>
                <asp:ListItem>Sep (09)</asp:ListItem>
                <asp:ListItem>Oct (10)</asp:ListItem>
                <asp:ListItem>Nov (11)</asp:ListItem>
                <asp:ListItem>Dec (12)</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblTime" runat="server" Text="Time:" Font-Size="Large"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlTime" runat="server" Font-Size="Large">
                <asp:ListItem>Select time</asp:ListItem>
                <asp:ListItem>9:00am</asp:ListItem>
                <asp:ListItem>9:30am</asp:ListItem>
                <asp:ListItem>10:00am</asp:ListItem>
                <asp:ListItem>10:30am</asp:ListItem>
                <asp:ListItem>11:00am</asp:ListItem>
                <asp:ListItem>11:30am</asp:ListItem>
                <asp:ListItem>1:00pm</asp:ListItem>
                <asp:ListItem>1:30pm</asp:ListItem>
                <asp:ListItem>2:00pm</asp:ListItem>
                <asp:ListItem>2:30pm</asp:ListItem>
                <asp:ListItem>3:00pm</asp:ListItem>
                <asp:ListItem>3:30pm</asp:ListItem>
                <asp:ListItem>4:00pm</asp:ListItem>
                <asp:ListItem>4:30pm</asp:ListItem>
                <asp:ListItem>5:00pm</asp:ListItem>
                <asp:ListItem>5:30pm</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Location" runat="server" Text="Location:" Font-Size="Large"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlLocation" runat="server" Font-Size="Large">
                <asp:ListItem>Select location</asp:ListItem>
                <asp:ListItem>ITP311 Seletar</asp:ListItem>
                <asp:ListItem>ITP311 Woodlands</asp:ListItem>
                <asp:ListItem>ITP311 Ang Mo Kio</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Font-Size="Large" />
           
            <br />
            <br />
            <br />
            <br />
           
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:DropDownList ID="ddlLength" runat="server">
                <asp:ListItem Text="5" Value="5" />
                <asp:ListItem Text="8" Value="8" />
                <asp:ListItem Text="10" Value="10" />
            </asp:DropDownList>
        </td>
        <td>
            <asp:RadioButtonList ID="rbType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Alphanumeric" Value="1" Selected="True" />
                <asp:ListItem Text="Numeric" Value="2" />
            </asp:RadioButtonList>
        &nbsp;&nbsp;
        </td>
        <td>
            <asp:Button ID="btnGenerate" Text="Generate OTP" runat="server" OnClick="GenerateOTP" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="3">
            OTP:
            <asp:Label ID="lblOTP" runat="server" />
        </td>
    </tr>
</table>

            </form>

</body>

</html>
