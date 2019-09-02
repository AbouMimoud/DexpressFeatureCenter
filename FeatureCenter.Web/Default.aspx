<%@ Page Language="C#" AutoEventWireup="true" Inherits="Default" EnableViewState="false"
    ValidateRequest="false" CodeBehind="Default.aspx.cs" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v19.1" Namespace="DevExpress.ExpressApp.Web.Templates"
    TagPrefix="cc3" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v19.1" Namespace="DevExpress.ExpressApp.Web.Controls"
    TagPrefix="cc4" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Main Page</title>
    <link rel="stylesheet" type="text/css" href="CodeFormatter.css" />
    <meta http-equiv="Expires" content="0" />
    <style type="text/css">
        .ShowMessageActionContainer .dxm-item .dxm-content .dx-vam {        
            background-color:#5cb85c;
            color:white;
            text-decoration:none;
        }
        .ShowMessageActionContainer .dxm-item .dxm-content,
        .ShowMessageActionContainer .dxm-item,
        .ShowMessageActionContainer .dxm-item.dxm-hovered {
            background-color:#5cb85c;
            background-image:none;
        }
    </style>
</head>
<body class="VerticalTemplate">
    <form id="form1" runat="server">
    <cc4:ASPxProgressControl ID="ProgressControl" runat="server" />
    <div runat="server" id="Content" />
    </form>
</body>
</html>
