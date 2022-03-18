<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataList.aspx.cs" Inherits="_DataList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_5_2:Repeater控件和DataList控件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:DataList ID="MyDataList" runat="server" BorderColor="#FFCC99" BorderWidth="1px"
			CellPadding="0" CellSpacing="1" DataKeyField="UserID" DataSourceID="MySqlDS"
			GridLines="Both">
			<ItemTemplate>
				UserID:
				<asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("UserID") %>'></asp:Label><br />
				UserName:
				<asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>'></asp:Label><br />
				RealName:
				<asp:Label ID="RealNameLabel" runat="server" Text='<%# Eval("RealName") %>'></asp:Label><br />
				Password:
				<asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>'></asp:Label><br />
				Address:
				<asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>'></asp:Label><br />
				RoleID:
				<asp:Label ID="RoleIDLabel" runat="server" Text='<%# Eval("RoleID") %>'></asp:Label><br />
				Status:
				<asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>'></asp:Label><br />
				CreateDate:
				<asp:Label ID="CreateDateLabel" runat="server" Text='<%# Eval("CreateDate") %>'></asp:Label><br />
				Email:
				<asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>'></asp:Label><br />
				Mobile:
				<asp:Label ID="MobileLabel" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label><br />
				Phone:
				<asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>'></asp:Label><br />
				Remark:
				<asp:Label ID="RemarkLabel" runat="server" Text='<%# Eval("Remark") %>'></asp:Label><br />
				<br />
			</ItemTemplate>
			<AlternatingItemStyle BackColor="#FF9933" Font-Bold="True" Font-Italic="False" Font-Names="宋体"
				Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#9966FF" />
			<HeaderStyle BackColor="#6699CC" Font-Bold="True" Font-Italic="False" Font-Names="楷体_GB2312"
				Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#993366"
				HorizontalAlign="Center" />
		</asp:DataList><asp:SqlDataSource ID="MySqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDBConnectionString %>"
			SelectCommand="SELECT TOP 10 [UserID], [UserName], [RealName], [Password], [Address], [RoleID], [Status], [CreateDate], [Email], [Mobile], [Phone], [Remark] FROM [Users] ORDER BY [CreateDate]">
		</asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
