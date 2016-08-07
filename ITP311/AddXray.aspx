<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddXray.aspx.cs" Inherits="WebApplication2.AddXray" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>X-ray</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">


    <!-- Custom styles for this template -->
    <link href="font-awesome-4.6.3/css/font-awesome.min.css" rel="stylesheet">
    <link href="css/dashboard.css" rel="stylesheet">
	<link href="bootstrap-datepicker-1.6.1-dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">

    <!-- javascript -->
    <script src="js/jquery-2.2.4.min.js"></script>
    <script src="js/adminlogin.js"></script>
    <script src="js/bootstrap.min.js"></script>

	<script src="bootstrap-datepicker-1.6.1-dist/js/bootstrap-datepicker.min.js"></script>

    <script>
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: 'dd/mm/yyyy'
            });
        });
    </script>
    <!--
<script>try { for (var lastpass_iter = 0; lastpass_iter < document.forms.length; lastpass_iter++) { var lastpass_f = document.forms[lastpass_iter]; if (typeof (lastpass_f.lpsubmitorig) == "undefined") { if (typeof (lastpass_f.submit) == "function") { lastpass_f.lpsubmitorig = lastpass_f.submit; lastpass_f.submit = function () { var form = this; try { if (document.documentElement && 'createEvent' in document) { var forms = document.getElementsByTagName('form'); for (var i = 0 ; i < forms.length ; ++i) if (forms[i] == form) { var element = document.createElement('lpformsubmitdataelement'); element.setAttribute('formnum', i); element.setAttribute('from', 'submithook'); document.documentElement.appendChild(element); var evt = document.createEvent('Events'); evt.initEvent('lpformsubmit', true, false); element.dispatchEvent(evt); break; } } } catch (e) { } try { form.lpsubmitorig(); } catch (e) { } } } } } } catch (e) { }</script></head>
-->
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
                <a class="navbar-brand" href="#"><span>X-</span>Ray</a>
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
                                <a href="#"><i class="fa fa-sign-out fa-fw" aria-hidden="true"></i> Logout</a>
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
                <a href="Xray.aspx"><i class="fa fa-home fa-fw" aria-hidden="true"></i> Home</a>
            </li>
            <li class="active">
                <a href="Xray.aspx"><i class="fa fa-picture-o fa-fw" aria-hidden="true"></i> X-ray</a>
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
                <li class="active">X-ray</li>
            </ol>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">X-ray</h1>
            </div>
        </div><br/><br/><br/><br/>
        <!--/.row-->


        <!--/.row-->
        <div class="row">
            <div class="col-lg-12">
                <form id="form1" runat="server">
                        <div class="form-group">
                            <label for="txtPatientNric" class="col-lg-1 control-label">Patient NRIC</label>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtPatientIC" runat="server" class="form-control" placeholder="S1234567A"></asp:TextBox>
                            </div>
                        </div><br /><br /><br />
                        <div class="form-group">
                            <label for="txtPatientName" class="col-lg-1 control-label">Patient Name</label>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtPatientName" runat="server" class="form-control" placeholder="Tan Ah Beng"></asp:TextBox>
                            </div>
                        </div><br /><br />
                        <div class="form-group">
                            <label for="textArea" class="col-lg-1 control-label">Patient DOB</label>
                            <div class="col-lg-4">
                                <div class="input-group date" data-provide="datepicker">
                                    <asp:TextBox ID="txtPatientDOB" class="form-control" runat="server"></asp:TextBox>
                                    <div style="" class="input-group-addon">
                                        <span class="glyphicon glyphicon-th"></span>
                                    </div>
                                </div>
                            </div>
                        </div><br /><br />

                        <div class="form-group">
                            <label for="txtDescription" class="col-lg-1 control-label">Description</label>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtDescription" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div><br /><br /><br />

                        <div class="form-group">
                            <label class="col-lg-1 control-label" for="fileInput">X-ray photo</label>
                            <div class="col-lg-4">
                                &nbsp;<asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
                            </div>
                        </div><br /><br /><br /><br /><br /><br />


                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">

                                <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" OnClick="btnAdd_Click1" Text="Add" />

                            </div>
                        </div><br /><br />
                </form>


            </div>
        </div>
        <!--/.row-->




</div></body></html>