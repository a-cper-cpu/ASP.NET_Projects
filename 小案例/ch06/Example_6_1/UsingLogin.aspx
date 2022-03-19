<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsingLogin.aspx.cs" Inherits="UsingLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Login ID="MyLogin" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99"
			BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnLoggingIn="MyLogin_LoggingIn">
			<TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
		</asp:Login>
    
    </div>
    </form>
</body>
</html>
