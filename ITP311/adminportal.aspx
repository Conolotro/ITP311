<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminportal.aspx.cs" Inherits="ITP311.adminportal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#"><span>Silverwood</span> Medical</a>
                <ul class="user-menu">
                    <li class="dropdown pull-right">
                        <a href="#" id="firstOption" class="dropdown-toggle" data-toggle="dropdown" runat="server">
                            <i class="fa fa-user fa-fw" aria-hidden="true"></i>User <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li>
                                <a href="adminportal_updateProfile.aspx"><i class = "fa fa-user fa-fw" aria-hidden="true"></i>Profile</a>
                            </li>
                            <li>
                                <a href="#"><i class = "fa fa-cog fa-fw" aria-hidden="true"></i>Settings</a>
                            </li>
                            <li role="separator" class="divider"></li>
                            <li>
                                <a href="adminlogin.aspx"><i class = "fa fa-sign-out fa-fw" aria-hidden="true"></i> Logout</a>
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
                <a href="adminportal.html"><i class="fa fa-home fa-fw" aria-hidden="true"></i> Home</a>
            </li>
            <li>
                <a href=""><i class="fa fa-calendar fa-fw" aria-hidden="true"></i> Appointment</a>
            </li>
            <li>
                <a href=""><i class="fa fa-medkit fa-fw" aria-hidden="true"></i> Medicine</a>
            </li>
            <li id="createDocPageLink" runat="server">
                <a href="adminportal_createDoc.aspx">
                    <i class="fa fa-users fa-fw" aria-hidden="true"></i> Accounts</a>
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
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Home</h1>
            </div>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-blue panel-widget ">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <i class="fa fa-calendar-o fa-4x" aria-hidden="true"></i>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                            <div class="large">10</div>
                            <div class="text-muted">Appointments</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-orange panel-widget">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <i class="fa fa-envelope-o fa-4x" aria-hidden="true"></i>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                            <div class="large">5</div>
                            <div class="text-muted">Enquries</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-teal panel-widget">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <i class="fa fa-tasks fa-4x" aria-hidden="true"></i>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                            <div class="large">2</div>
                            <div class="text-muted">New Task</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-md-8">
                <div class="panel panel-default">
                    <div class="panel-heading">Appointments</div>
                    <div class="panel-body">
                        <table class="table table-striped table-hover ">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Date</th>
                                    <th>Start Time</th>
                                    <th>End Time</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>4-06-2016</td>
                                    <td>08:00</td>
                                    <td>08:30</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>4-06-2016</td>
                                    <td>08:30</td>
                                    <td>09:00</td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td>4-06-2016</td>
                                    <td>09:30</td>
                                    <td>10:00</td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>4-06-2016</td>
                                    <td>10:00</td>
                                    <td>10:30</td>
                                </tr>
                                <tr>
                                    <td>5</td>
                                    <td>4-06-2016</td>
                                    <td>08:00</td>
                                    <td>08:30</td>
                                </tr>
                                <tr>
                                    <td>6</td>
                                    <td>4-06-2016</td>
                                    <td>11:00</td>
                                    <td>11:30</td>
                                </tr>
                                <tr>
                                    <td>7</td>
                                    <td>4-06-2016</td>
                                    <td>11:30</td>
                                    <td>12:00</td>
                                </tr>
                                <tr>
                                    <td>8</td>
                                    <td>4-06-2016</td>
                                    <td>1:00</td>
                                    <td>1:30</td>
                                </tr>
                                <tr>
                                    <td>9</td>
                                    <td>4-06-2016</td>
                                    <td>2:00</td>
                                    <td>2:30</td>
                                </tr>
                                <tr>
                                    <td>10</td>
                                    <td>4-06-2016</td>
                                    <td>2:30</td>
                                    <td>3:00</td>
                                </tr>
                            </tbody>
                        </table>

                    </div>
                </div>


            </div>




            <div class="col-md-4">

                <div class="panel panel-blue">
                    <div class="panel-heading dark-overlay">
                        <svg class="glyph stroked clipboard-with-paper">
                            <use xlink:href="#stroked-clipboard-with-paper"></use>
                        </svg>To-do List</div>
                    <div class="panel-body">
                        <ul class="todo-list">
                            <li class="todo-list-item">
                                <div class="checkbox">
                                    <input type="checkbox" id="checkbox" />
                                    <label for="checkbox">Update Medicine</label>
                                </div>
                                <div class="pull-right action-buttons">
                                    <a href="#">
                                        <svg class="glyph stroked pencil">
                                            <use xlink:href="#stroked-pencil"></use>
                                        </svg>
                                    </a>
                                    <a href="#" class="flag">
                                        <svg class="glyph stroked flag">
                                            <use xlink:href="#stroked-flag"></use>
                                        </svg>
                                    </a>
                                    <a href="#" class="trash">
                                        <svg class="glyph stroked trash">
                                            <use xlink:href="#stroked-trash"></use>
                                        </svg>
                                    </a>
                                </div>
                            </li>
                            <li class="todo-list-item">
                                <div class="checkbox">
                                    <input type="checkbox" id="checkbox" />
                                    <label for="checkbox">Send email to Dr Jane</label>
                                </div>
                                <div class="pull-right action-buttons">
                                    <a href="#">
                                        <svg class="glyph stroked pencil">
                                            <use xlink:href="#stroked-pencil"></use>
                                        </svg>
                                    </a>
                                    <a href="#" class="flag">
                                        <svg class="glyph stroked flag">
                                            <use xlink:href="#stroked-flag"></use>
                                        </svg>
                                    </a>
                                    <a href="#" class="trash">
                                        <svg class="glyph stroked trash">
                                            <use xlink:href="#stroked-trash"></use>
                                        </svg>
                                    </a>
                                </div>
                            </li>
                            <li class="todo-list-item">
                                <div class="checkbox">
                                    <input type="checkbox" id="checkbox" />
                                    <label for="checkbox">Tidy up workspace</label>
                                </div>
                                <div class="pull-right action-buttons">
                                    <a href="#">
                                        <svg class="glyph stroked pencil">
                                            <use xlink:href="#stroked-pencil"></use>
                                        </svg>
                                    </a>
                                    <a href="#" class="flag">
                                        <svg class="glyph stroked flag">
                                            <use xlink:href="#stroked-flag"></use>
                                        </svg>
                                    </a>
                                    <a href="#" class="trash">
                                        <svg class="glyph stroked trash">
                                            <use xlink:href="#stroked-trash"></use>
                                        </svg>
                                    </a>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="panel-footer">
                        <div class="input-group">
                            <input id="btn-input" type="text" class="form-control input-md" placeholder="Add new task" />
                            <span class="input-group-btn">
								<button class="btn btn-primary btn-md" id="btn-todo">Add</button>
							</span>
                        </div>
                    </div>
                </div>
            </div>




        </div>
        <!--/.row-->

</body>

</html>