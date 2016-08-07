<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ITP311.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>ITP311 Online Medical Portal - Homepage</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/small-business.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    <!-- javascript -->
    <script src="js/jquery-2.2.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <!-- Navigation -->
    <nav class="navbar navbar navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                </button>
                <a class="navbar-brand" href="#">
                    <img src="img/banner-high-heartbeat@1x.png" alt="logo" height="63px" />
                </a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li>
                        <a href="#">Home</a>
                    </li>
                    <li>
                        <a href="#services">Services</a>
                    </li>
					<li>
                        <a href="#locations">Locations</a>
                    </li>
                    <li>
                        <a href="#contact-us">Contact Us</a>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="login-register.aspx">Log In</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
    <asp:Literal ID="successmsg" runat="server" Visible="false">
        <div class="alert alert-dismissible alert-success">
  <button type="button" class="close" data-dismiss="alert">&times;</button>
  <strong>Well done!</strong> The message has been sent successfully.
</div>

    </asp:Literal>
    <!-- Page Content -->
    <div class="container">
        <!-- Heading Row -->
        <div class="row">
		    <div class="col-lg-4">
                <h1><b>ITP311 Online Medical Portal</b></h1>
                <p>Hello and welcome to the ITP311 Online Medical Portal! Thank you for choosing us as your clinic. At ITP311, we aim to provide our clients with top-notch health services. 
				<br/> 
				<br/>
				If you are a patient and wish to book an appointment, kindly log in or you may create an account through the same action.
				</p>
            </div>
            <!-- /.col-md-4 -->
			
            <div class="col-lg-8">
                <div id="carousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#carousel" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel" data-slide-to="1"></li>
                        <li data-target="#carousel" data-slide-to="2"></li>
                        <li data-target="#carousel" data-slide-to="3"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <img src="img/1.jpg" alt="1">
                            <div class="carousel-caption">
                                Best Medical Care
                            </div>
                        </div>
                        <div class="item">
                            <img src="img/2.jpg" alt="2">
                            <div class="carousel-caption">
                                Caring Doctors
                            </div>
                        </div>
                        <div class="item">
                            <img src="img/3.jpg" alt="3">
                            <div class="carousel-caption">
                                Good Services
                            </div>
                        </div>
                        <div class="item">
                            <img src="img/4.jpg" alt="4">
                            <div class="carousel-caption">
                                Professional
                            </div>
                        </div>

                    </div>

                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#carousel" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
            <!-- /.col-md-8 -->
        </div>
        <!-- /.row -->
        <!-- Call to Action Well -->
        <!--        <div class="row">
            <div class="col-lg-12">
                <div class="well text-center">This is a well that is a great spot for a business tagline or phone number for easy access!
                </div>
            </div>
        </div>-->
		
        <!-- Content Row -->

        <div class="row" id="services">
            <div class="col-lg-12">
                <div class="page-header jTitle">
                    <h1>Services</h1>
                </div>

            <div class="col-md-6 services">
                <h2>Common Ailments</h2>
                <p>Treatment for common illnesses:</p>
				<ul style="list-style-type:circle">
				  <li>Asthma</li>
				  <li>Common Cold</li>
				  <li>Influenza</li>
				  <li>Sinus</li>
				  <li>Sore Throat</li>
				  <li>Pink Eye</li>
				</ul>
            </div>
            <!-- /.col-md-4 -->

            <div class="col-md-6 services">
                <h2>Vacinations</h2>
                <p>Protect yourself and your loved ones with our immunisation programmes available at all ITP311 clinics:</p>
				<ul style="list-style-type:circle">
				  <li>Immunisation for Infants and Children</li>
				  <li>Polio - Against Poliomelytis Elective</li>
				  <li>Hepatitis A & B - Against Liver Infections Hepatitis A and B</li>
				  <li>Influenza - Against Flu Virus</li>
				  <li>Chicken Pox - Against Chicken Pox</li>
				</ul>  	
					
            </div>
            <!-- /.col-md-4 -->
			
            </div>
        </div>

		
		<div class="row" id="locations">
            <div class="col-lg-12">
                <div class="page-header jTitle">
                    <h1>Locations</h1>
                </div>

            <div class="col-md-4 locations">
                <h2>ITP311 Seletar</h2>
                <p>117 Seletar Ave<br> #02-45<br>Singapore 524313<br> Phone: +65 6550 1111<br> E-mail: <a href="mailto:#">seletar@itp311medical.com</a></p>
            </div>
            <!-- /.col-md-4 -->

            <div class="col-md-4 locations">
                <h2>ITP311 Woodlands</h2>
                <p>150 Woodlands Road<br> #01-22<br>Singapore 547653<br> Phone: +65 6550 1112<br> E-mail: <a href="mailto:#">woodlands@itp311medical.com</a></p>
            </div>
            <!-- /.col-md-4 -->

            <div class="col-md-4 locations">
                <h2>ITP311 Ang Mo Kio</h2>
                <p>87 Ang Mo Kio Ave 7<br> #01-26<br>Singapore 585424<br> Phone: +65 6550 1113<br> E-mail: <a href="mailto:#">amk@itp311medical.com</a></p>
            </div>
            <!-- /.col-md-4 -->
			
            </div>
        </div>
		
		
        <div class="row" id="contact-us">
            <div class="col-lg-12">
                    <div class="page-header jTitle">
                        <h1>Contact Us</h1>
                    </div>
            </div>
		
			<div class="row">
                <div class="col-lg-12">
                    <form class="form-horizontal" id="form1" runat="server">
                        <fieldset>
                            <div class="form-group">
                                <label for="inputName" class="col-lg-2 control-label">Name</label>
                                <div class="col-lg-9">
                                    <asp:TextBox  type="text" class="form-control" id="inputName" Width="100%" placeholder="Name" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail" class="col-lg-2 control-label">Email</label>
                                <div class="col-lg-9">
                                    <asp:TextBox  type="text" class="form-control" id="inputEmail" Width="100%" placeholder="Email" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="textArea" class="col-lg-2 control-label">Enquires</label>
                                <div class="col-lg-9">
                                    <asp:TextBox  type="text"  class="form-control" TextMode="MultiLine" Width="100%" id="tbEnquiry" placeholder="Please enter your enquires here" runat="server" Rows="5" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-9 col-lg-offset-2">
                                    <asp:button ID="reset" class="btn btn-default" runat="server" OnClick="reset_Click" Text="Cancel" />
                                    <asp:button ID="submit"  class="btn btn-primary" runat="server" OnClick="submit_Click" Text="Submit"/>
                                </div>
                            </div>
                        </fieldset>
                    </form>
                </div>

            </div>
				
        </div>

        </div>
        <!-- /.container -->
</body>
</html>
