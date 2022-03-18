<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectDS.aspx.cs" Inherits="ObjectDS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:GridView ID="GridView1" runat="server" DataSourceID="MyObjectDS">
		</asp:GridView>
		<asp:ObjectDataSource ID="MyObjectDS" runat="server" SelectMethod="GetUsers" TypeName="UserInformation">
		</asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
