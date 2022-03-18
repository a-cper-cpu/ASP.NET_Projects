<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPage.aspx.cs" Inherits="ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_5_3:GridView控件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID"
			DataSourceID="MySqlDS" AllowPaging="True" PageSize="5" OnPageIndexChanged="MyGridView_PageIndexChanged">
			<Columns>
				<asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True"
					SortExpression="UserID" />
				<asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
				<asp:BoundField DataField="RealName" HeaderText="RealName" SortExpression="RealName" />
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
				<asp:BoundField DataField="RoleID" HeaderText="RoleID" SortExpression="RoleID" />
				<asp:CheckBoxField DataField="Status" HeaderText="Status" SortExpression="Status" />
				<asp:BoundField DataField="CreateDate" HeaderText="CreateDate" SortExpression="CreateDate" />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
				<asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
				<asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
			</Columns>
			<PagerStyle BackColor="#8080FF" ForeColor="Crimson" />
		</asp:GridView>
		<asp:SqlDataSource ID="MySqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDBConnectionString %>"
			SelectCommand="SELECT [UserID], [UserName], [RealName], [Address], [RoleID], [Status], [CreateDate], [Email], [Mobile], [Phone], [Remark] FROM [Users]">
		</asp:SqlDataSource>    
		<br />
		<asp:Label ID="LabelMsg" runat="server" Text="当前页码为:1" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
