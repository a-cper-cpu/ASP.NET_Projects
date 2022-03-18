<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XmlDS.aspx.cs" Inherits="XmlDS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		&nbsp; &nbsp;
		<asp:TreeView ID="TreeView1" runat="server" DataSourceID="MyXmlDS">
		</asp:TreeView>
		<asp:XmlDataSource ID="MyXmlDS" runat="server" DataFile="~/App_Data/Book.xml"></asp:XmlDataSource>
    
    </div>
    </form>
</body>
</html>
