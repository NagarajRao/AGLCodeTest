<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchDataFromJson.aspx.cs" Async="true" Inherits="TestingCode.AGL.FetchDataFromJson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AGL-Test Coding Skills</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="JsonValuPH" runat="server"></asp:PlaceHolder>  
            <asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
