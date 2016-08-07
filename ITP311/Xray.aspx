<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xray.aspx.cs" Inherits="WebApplication2.Xray" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Drawing" %>

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

    <!-- javascript -->
    <script src="js/jquery-2.2.4.min.js"></script>
    <script src="js/adminlogin.js"></script>
    <script src="js/bootstrap.min.js"></script>
    
    <script type="text/javascript">
        function LoadDiv(url) {
            var img = new Image();
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            var imgLoader = document.getElementById("imgLoader");
            imgLoader.style.display = "block";
            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
            };
            img.src = url;
            var width = document.body.clientWidth;
            if (document.body.clientHeight > document.body.scrollHeight) {
                bcgDiv.style.height = document.body.clientHeight + "px";
            }
            else {
                bcgDiv.style.height = document.body.scrollHeight + "px";
            }
            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";

            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;
        }
        function HideDiv() {
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            if (bcgDiv != null) {
                bcgDiv.style.display = "none";
                imgDiv.style.display = "none";
                imgFull.style.display = "none";
            }
        }

        function downloadImage() {
            var link = document.createElement('a');
            link.href = document.getElementById("imgFull").src;
            link.download = 'Download.jpg';
            document.body.appendChild(link);
            link.click();
            //document.getElementById("imgFull").click();
        }
    </script>

    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .modal {
            display: none;
            position: absolute;
            top: 0px;
            left: 0px;
            background-color: black;
            z-index: 100;
            opacity: 0.8;
            filter: alpha(opacity=60);
            -moz-opacity: 0.8;
            min-height: 100%;
        }

        #divImage {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: White;
            height: 550px;
            width: 600px;
            padding: 3px;
            border: solid 1px black;
        }
    </style>



</head>

<body>
    
<div id="divBackground" class="modal">
</div>
<div id="divImage">
<table style="height: 100%; width: 100%">
    <tr>
        <td valign="middle" align="center">
            <img id="imgLoader" alt="" src="images/loader.gif" />
            <img id="imgFull" alt="" src="" style="display: none; height: 500px; width: 590px" />
        </td>
    </tr>
    <tr>
        <td align="center" valign="bottom">
            <!--<i class="btn fa fa fa-download fa-fw" onclick="downloadImage()"></i>-->
            <i class="btn fa fa fa-download fa-fw" onclick="downloadImage()"></i>
            <i class="btn fa fa-times fa-fw" onclick="HideDiv()"></i>
        </td>
        <!--
        <td align="center" valign="bottom">
            <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
        </td>
        -->
    </tr>
</table>
</div>

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
        </div>
        <!--/.row-->

        <div class="row">
           
            </div>


        <br /><br /><br /><br />
            <div class="row">
            <div class="col-md-12">

            <asp:GridView ID="GridView1" class="table table-striped table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" Width="648px">
                <Columns>
                    <asp:BoundField DataField="PatientIC" HeaderText="PatientIC" SortExpression="PatientIC" ReadOnly="True" />
                    <asp:BoundField DataField="PatientName" HeaderText="PatientName" SortExpression="PatientName" ReadOnly="True" />
                    <asp:BoundField DataField="PatientDOB" HeaderText="PatientDOB" SortExpression="PatientDOB" ReadOnly="True" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                     <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>


                         <%-- 
                            <img src='data:image/jpg;base64,<%# Eval("Image") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("Image")) : string.Empty %>' alt="image" height="150" width="150" onclick="return LoadDiv(this.src);"/>
                         --%>

                            
                                <%-- 
                                 try 
                                 { 
                                     Bitmap bmp= new Bitmap(new MemoryStream((byte[])Eval("Image"));
                                     Graphics graphics = Graphics.FromImage(bmp);
                                     Brush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255));
                                     Point postionWaterMark = new Point((bmp.Width / 2), (bmp.Height * 9 / 10));
                                     graphics.DrawString(Session["LoggedIn"].ToString(), new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), brush, postionWaterMark);
   
                                     using(MemoryStream imageWithWaterMark = new MemoryStream())
                                     { 
                                        bmp.Save(imageWithWaterMark, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        Response.Write("<img src=\"data:image/jpg;base64, ");
                                        Response.Write(Convert.ToBase64String(imageWithWaterMark.ToArray()));
                                        Response.Write(" alt=\"image\" height=\"150\" width=\"150\" onclick=\"return LoadDiv(this.src);");
                                     }
                                  }
                                  catch(Exception e)
                                  {
                                    
                                  }
                                --%>

   
                                                      
                           <%--
                           public string waterMarkWithImage(byte[] raw)
                           {
                                try 
                                { 
                                    Bitmap bmp= new Bitmap(new MemoryStream(raw));
                                    Graphics graphics = Graphics.FromImage(bmp);
                                    Brush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255));
                                    Point postionWaterMark = new Point((bmp.Width / 2), (bmp.Height * 9 / 10));
                                    graphics.DrawString(Session["LoggedIn"].ToString(), new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), brush, postionWaterMark);
   
                                    using(MemoryStream imageWithWaterMark = new MemoryStream())
                                    { 
                                    bmp.Save(imageWithWaterMark, System.Drawing.Imaging.ImageFormat.Jpeg);
                                         
                                    return Convert.ToBase64String(imageWithWaterMark.ToArray());
                                    }
                                
                                    
                                }
                                catch(Exception e)
                                {
                                    return "";
                                }
                            }
                            --%>



                            <img src='data:image/jpg;base64,<%# Eval("Image") != System.DBNull.Value ? waterMarkWithImage((byte[])Eval("Image")) : string.Empty %>' alt="image" height="150" width="150" onclick="return LoadDiv(this.src);"/>

                        </ItemTemplate>

                     </asp:TemplateField>
                   
                    <asp:BoundField DataField="DateTimeAdded" HeaderText="DateTimeAdded" ReadOnly="True" SortExpression="DateTimeAdded" />
                   
                    <asp:CommandField ShowEditButton="True"/>
                    <asp:CommandField ShowDeleteButton="True"/>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MYDBConnection %>" SelectCommand="SELECT * FROM [Xray]" UpdateCommand="UPDATE Xray SET Description = @Description WHERE (PatientIC = @original_PatientIC) AND (Description = @original_Description)" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM Xray WHERE (PatientIC = @original_PatientIC) AND (Description = @original_Description)" InsertCommand="INSERT INTO [Xray] ([Image], [PatientIC], [PatientName], [PatientDOB], [Description], [DateTimeAdded]) VALUES (@Image, @PatientIC, @PatientName, @PatientDOB, @Description, @DateTimeAdded)" OldValuesParameterFormatString="original_{0}">
                <DeleteParameters>
                    <asp:Parameter Name="original_PatientIC" Type="String" />
                    <asp:Parameter Name="original_Description" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Image" Type="Object" />
                    <asp:Parameter Name="PatientIC" Type="String" />
                    <asp:Parameter Name="PatientName" Type="String" />
                    <asp:Parameter DbType="Date" Name="PatientDOB" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="DateTimeAdded" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="original_PatientIC" Type="String" />
                    <asp:Parameter Name="original_Description" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        </div>

        <!--/.row-->

        <div class="row">
            <div class="col-md-12">
                <a class="btn btn-primary btn-lg" href="AddXray.aspx">+ </a>
            </div>
            
            


        </div>
        <!--/.row-->




</div>
    </form>
</body></html>