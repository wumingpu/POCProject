<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="IndexPage.aspx.cs" Inherits="FirstDemoPage.IndexPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge;" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Bowser_component/sb-admin-2.css" rel="stylesheet" />
    <link href="Bowser_component/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Bowser_component/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Bowser_component/bootstrap/dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <%--<link href="Bowser_component/G2-Range.css" rel="stylesheet" />--%>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <script src="Bowser_component/jquery/dist/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <!-- Navigation -->

            <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <%--<span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>--%>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand"><b>Project POC</b></a>
                </div>
            </nav>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-info">
                    <div class="panel-body">
                        <%--<iframe id="UploadFrame" src="/Home/Index" width="50%" frameborder="0"></iframe>--%>
                        <%--<div class="btn btn-default" onclick="CallMLService()">Process Data</div>--%>
                        <asp:Button ID="btnProcessML" runat="server" Text="Process Data" CssClass="btn btn-primary" OnClick="btnProcessML_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Data of the machine learning
                    </div>
                    <div class="panel-body" id="MLResult" runat="server">
                        <%--<div class="row">
                                    <div class="col-lg-12">
                                        <button type="button" class="btn btn-default" onclick="RepaintChart()">Repaint fun test</button>
                                    </div>
                                </div>--%>
                        <asp:GridView ID="gvMLData" runat="server" CssClass="table table-condensed" OnRowDataBound="gvMLData_RowDataBound"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <%--<script type="text/javascript">
        function CallMLService() {
            //$.post("ashx/MLServiceHandler.ashx", {
            //    mode: 'GetMLResultFromAzure'
            //    //mode: 'Test'
            //}, function (data) {
            //    alert(111);
            //    //alert(data);
            //    //if (data!='fail') {
            //    //    $("#MLResult").html(data);
            //    //}
            //});
            $.ajax({
                async: true,
                type: "POST",
                dataType: "text",
                url: "ashx/MLServiceHandler.ashx",
                data: { mode: 'Test' },
                success: function (data) {
                    //if (json == 3) {
                    //    alert(" 等于3就是不让过")
                    //    return false;
                    //}
                    alert("111");
                }
            });
        }
    </script>--%>
</body>
</html>
