<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doctor-index.aspx.cs" Inherits="ITP311.doctor_index" %>

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
    <link href="//cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="//cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script>
        $.ajax({
            url: 'UpdateLogDT.asmx/getUpdateLogDT',
            type: 'post',
            dataType: 'json',
            success: function (data) {

                $('#datatable').dataTable({

                    data: data,
                    columns: [
                    { 'data': 'Cnric' },
                    { 'data': 'ModifiedAt' },
                    { 'data': 'UpdatedBy' },
                    { 'data': 'ModifiedMethod' }]

                })
            }

        });
    </script>
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
    <form runat="server">
        <!--/.sidebar-->
        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main" style="margin-left: 18%;">
            <div class="row">
                <ol class="breadcrumb">
                    <li>
                        <a href="#"><i class="fa fa-home fa-fw" aria-hidden="true"></i></a>
                    </li>
                    <li class="active">Dashboard</li>
                </ol>
            </div>
            <!--/.row-->
            <div class="wrapper">
                <div class="column" style="margin-top: 3%;">
                    <div class="panel panel-primary" style="width: 60%; float: left;">
                        <div class="panel-body">
                            <div style="width: 100%; float: left; overflow: hidden;">
                                <div class="panel-heading" style="margin-left: -2%; margin-top: -3%; padding-bottom: 12%;">
                                    <h3>Recent Updates</h3>
                                </div>
                                <table class="table" id="datatable">
                                    <thead>
                                        <tr>
                                            <th>NRIC</th>
                                            <th>Modified Date</th>
                                            <th>Modified By</th>
                                            <th>Modified Type</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div>
                        <button class="btn btn-primary" type="button" style="margin-left: 2%; width: 35%; padding-top: 3%; padding-bottom: 3%; font-size: 20px;" data-toggle="modal" data-target="#formNewPatient"><i class="fa fa-user fa-fw" aria-hidden="true"></i>New Patient<span class="badge"></span> </button>

                        <div id="formNewPatient" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Add new patient account</h4>
                                    </div>


                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="formNRIC">NRIC</label>
                                            <asp:TextBox name="formNRIC" placeholder="NRIC..." class="form-NRIC form-control " ID="formNRIC" runat="server" Width="300px" />

                                        </div>
                                        <div class="form-group">
                                            <label for="formFN">First name</label>
                                            <asp:TextBox name="formFN" placeholder="First name..." class="form-first-name form-control" ID="formFN" runat="server" Width="300px" />

                                        </div>
                                        <div class="form-group">
                                            <label for="formLN">Last name</label>
                                            <asp:TextBox name="formLN" placeholder="Last name..." class="form-last-name form-control" ID="formLN" runat="server" Width="300px" />

                                        </div>
                                        <div class="form-group">
                                            <label for="formPhone">Phone Number</label>
                                            <asp:TextBox TextMode="phone" name="formPhone" placeholder="Phone Number..." class="form-phonenumber form-control" ID="formPhone" runat="server" Width="300px" />

                                        </div>
                                        <div class="form-group">
                                            <label for="formEmail">Email</label>
                                            <asp:TextBox TextMode="Email" name="formEmail" placeholder="Email..." class="form-email form-control" ID="formEmail" runat="server" Width="300px" />

                                        </div>
                                        <div class="form-group">
                                            <label for="formCEmail">Confirm Email</label>
                                            <asp:TextBox TextMode="Email" name="formCEmail" placeholder="Email..." class="form-cemail form-control" ID="formCEmail" runat="server" Width="300px" />

                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="Button1" class="btn btn-default" Text="Sign me up!" runat="server" OnClick="signUp_Click" />
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-primary" style="margin-top: 2%; width: 35%; margin-left: 2%; float: left; overflow: hidden;" id="box">
                    <div class="panel-heading">Search </div>
                    <div class="panel-body">
                        <p>Search for patient (Enter NRIC):</p>
                        <asp:TextBox name="searchtbx" placeholder="eg. sXXXXXXXh" class="form-control" ID="searchNric" runat="server" Width="392px" />
                        <br>
                        <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
                        <br />
                        <a href="doctor-PatientsAdvSearch.aspx"><u>Advanced Search</u></a>
                        <asp:Button ID="search" runat="server" class="btn btn-success" Style="float: right;" Text="Search" OnClick="search_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

</html>
