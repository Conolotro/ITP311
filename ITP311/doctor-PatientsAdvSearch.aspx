<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doctor-PatientsAdvSearch.aspx.cs" Inherits="ITP311.doctor_PatientsLogAdvSearch" %>

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
            url: 'AdvSearch.asmx/advanceSearch',
            type: 'post',
            dataType: 'json',
            render: $.fn.dataTable.render.text(),
            success: function (data) {

                $('#datatable').dataTable({
                    data: data,
                    columns: [
                    { 'data': 'Nric' },
                    { 'data': 'FirstName' },
                    { 'data': 'LastName' },
                    { 'data': 'ContactNo' },
                    { 'data': 'Email' }]

                });
                var table = $('#datatable').DataTable();

                $('#datatable tbody').on('click', 'tr', function () {
                    console.log(table.row(this).data().Nric);
                    var myvar = table.row(this).data().Nric;
                    window.location = "doctor-PatientsLog.aspx?Nric=" + myvar;
                });
            }

        });

    </script>
    <script>
        
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
    <!--/.sidebar-->
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main" style="margin-left: 18%; ">
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
            <div class="column" style="margin-top: 2%; width: 100%;">
                <div class="panel panel-primary" style="width: 60%; float: left;">
                    <div class="panel-body">
                        <div style="width: 100%; float: left; overflow: hidden;">
                            <div class="panel-heading" style="margin-top: -3%; padding-bottom: 12%;">
                                <h2>Advanced Search</h2>
                            </div>
                            <table class="table" id="datatable">
                                <thead>
                                    <tr>
                                        <th>NRIC</th>
                                        <th>First Name</th>
                                        <th>Last Name</th>
                                        <th>Contact No</th>
                                        <th>Address</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>

</html>
