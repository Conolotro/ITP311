<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePatientsLog.aspx.cs" Inherits="ITP311.CreatePatientsLog" %>

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
    <link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/jquery.bootstrapvalidator/0.5.3/css/bootstrapValidator.min.css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery.bootstrapvalidator/0.5.3/js/bootstrapValidator.min.js"> </script>
    
    <script>
        $(document).ready(function () {
            $('#form').bootstrapValidator({
                container: '#messages',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    briefDescription: {
                        validators: {
                            notEmpty: {
                                message: 'The NRIC is required and cannot be empty'
                            },
                            stringLength: {
                                message: 'NRIC must contain only 9 characters',
                                max: function (value, validator, $field) {
                                    return 250 - (value.match(/\r/g) || []).length;
                                }
                            }
                        }
                    },
                    pressuretbx: {
                        validators: {
                            notEmpty: {
                                message: 'Pressure is required and cannot be empty'
                            },
                            digits: {
                                message: 'Pressure should contain numeric values only'
                            }
                        }
                    },
                    pulsetbx: {
                        validators: {
                            notEmpty: {
                                message: 'Pulse is required and cannot be empty'
                            },
                            digits: {
                                message: 'Pulse should contain numeric values only'
                            }
                        }
                    },
                    temperaturetbx: {
                        validators: {
                            notEmpty: {
                                message: 'Pulse is required and cannot be empty'
                            },
                            numeric: {
                                message: 'The value is not a number',
                                // The default separators
                                thousandsSeparator: '',
                                decimalSeparator: '.'
                            },
                            stringLength: {
                                message: 'NRIC must contain only 9 characters',
                                max: function (value, validator, $field) {
                                    return 4 - (value.match(/\r/g) || []).length;
                                }
                            }
                        }
                    },
                    formDoctorsNotes: {
                        validators: {
                            notEmpty: {
                                message: 'Doctors Notes is required and cannot be empty'
                            },
                            stringLength: {
                                message: 'NRIC must contain only 9 characters',
                                max: function (value, validator, $field) {
                                    return 250 - (value.match(/\r/g) || []).length;
                                }
                            }
                        }
                    }
                }
            });
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
    <!--/.sidebar-->
    <div style="margin-left: 2%;">
        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
            <div class="row">
                <ol class="breadcrumb">
                    <li>
                        <a href="#"><i class="fa fa-file-text-o" aria-hidden="true"></i></a>
                    </li>
                    <li class="active">Create new log</li>

                </ol>
            </div>
            <!--/.row-->
            <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2" style="margin-left: 0%; width:100%;">
                <div class="main panel panel-default" style="width: 100%; height: 100%; margin-top: 1%; margin-left: 2%;">
                    <div class="panel-heading" style="padding-bottom: 5%;">
                        <h2>Create Patients' Log</h2>
                    </div>
                    <form runat="server" id="form">
                        <div class="modal-body panel-body">
                            <div class="form-group">
                                <label for="title">Brief Description : </label>
                                <asp:TextBox name="briefDescription" placeholder="Description" class="form-control " ID="briefDescription" runat="server" Width="385px" />
                            </div>
                            <div class="form-group">
                                <div style="float: left; margin-right: 3%; width: 124px;">
                                    <label for="pressure">Select Prescription</label>
                                    <asp:TextBox name="pressure" class=" form-control " ID="pressuretbx" runat="server" Width="90px" />
                                </div>
                                <div style="float: left; margin-right: 3%;">
                                    <label for="pulse">Pulse (BPM)</label>
                                    <asp:TextBox name="pulse" class=" form-control " ID="pulsetbx" runat="server" Width="90px" />
                                </div>
                                <div>
                                    <label for="temperature">Temperature (Degree Celcius)</label>
                                    <asp:TextBox name="temperature" class=" form-control " ID="temperaturetbx" runat="server" Width="90px" />
                                </div>
                            </div>
                            
                            
                            <div class="form-group">
                                <label for="formDoctorsNotes">Doctor's Notes</label>
                                <asp:TextBox name="formDoctorsNotes" placeholder="Doctor's Notes..." class="formDoctorsNotes form-control " ID="formDoctorsNotes" runat="server" Width="637px" Height="96px" TextMode="MultiLine" />
                            </div>
                            <div style="float: left; width: 100%;">
                                <div class="form-group" style="float: left; height: 361px; width: 290px;">
                                    <h3 style="margin-left: 3%;">Select Symptoms</h3>
                                    <div style="height: 309px; overflow: scroll; width: 293px;">
                                        <asp:GridView ID="gvSymptoms" ShowHeader="False" Height="500px" CssClass="table table-hover table-striped" Style="font-size: 15px; margin: 2%; margin-top: 3%;" runat="server" SelectedIndex="0" PageSize="5" OnSelectedIndexChanged="gvSymptoms_SelectedIndexChanged" Width="270px">
                                            <RowStyle Height="20px" />
                                            <AlternatingRowStyle Height="20px" />
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                                            </Columns>
                                            <RowStyle BackColor="White" />

                                        </asp:GridView>
                                    </div>
                                </div>
                                <div style="float: left;">
                                    <h1><i class="fa fa-arrow-right" aria-hidden="true" style="font-size: 100px; margin-top: 190%; margin-left: 30%; margin-right: 20%;"></i></h1>
                                </div>
                                <div  style="float: left; margin-left: 5%; height: 361px; width: 285px;">
                                    <h3 style="margin-left: 3%; width: 239px;">Selected Symptoms</h3>
                                    <div style="height: 309px; overflow: scroll; width: 296px;">
                                        <asp:GridView ID="gvSelectedSymptoms" ShowHeader="False" Height="500px" CssClass="table table-hover table-striped" Style="font-size: 15px; margin: 2%; margin-top: 3%;" SelectedIndex="0" runat="server" Width="279px" OnSelectedIndexChanged="gvSelectedSymptoms_SelectedIndexChanged">


                                            <RowStyle Height="20px" />
                                            <AlternatingRowStyle Height="20px" />
                                            <Columns>
                                                <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
                                            </Columns>
                                            <RowStyle BackColor="White" />

                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div id="messages"></div>
                            </div>
                            <div class="modal-footer" style="padding-bottom:5%;">
                                <asp:Button ID="createNewLog" class="btn btn-default" Text="Create Log" runat="server" OnClick="createNewLog_Click" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>

</html>
