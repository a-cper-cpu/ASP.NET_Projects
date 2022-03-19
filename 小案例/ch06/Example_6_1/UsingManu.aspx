<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsingManu.aspx.cs" Inherits="UsingManu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Menu ID="MyMenu" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
			Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
			<StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
			<DynamicHoverStyle BackColor="#990000" ForeColor="White" />
			<DynamicMenuStyle BackColor="#FFFBD6" />
			<StaticSelectedStyle BackColor="#FFCC66" />
			<DynamicSelectedStyle BackColor="#FFCC66" />
			<DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
			<Items>
				<asp:MenuItem Text="根" Value="-1">
					<asp:MenuItem Text="TreeView控件" Value="0" NavigateUrl="~/UsingTreeView.aspx"></asp:MenuItem>
					<asp:MenuItem Text="用户Login控件" Value="1" NavigateUrl="~/UsingLogin.aspx"></asp:MenuItem>
				</asp:MenuItem>
			</Items>
			<StaticHoverStyle BackColor="#990000" ForeColor="White" />
		</asp:Menu>
    
    </div>
    </form>
</body>
</html>
