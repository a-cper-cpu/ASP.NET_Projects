<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditView.aspx.cs" Inherits="EditView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_5_3:GridView控件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID"
			DataSourceID="MySqlDS" OnRowUpdating="MyGridView_RowUpdating" OnRowUpdated="MyGridView_RowUpdated">
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True"
					SortExpression="UserID" />
				<asp:BoundField DataField="RealName" HeaderText="RealName" SortExpression="RealName" />
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
				<asp:CheckBoxField DataField="Status" HeaderText="Status" SortExpression="Status" />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
				<asp:CommandField ShowEditButton="True" ButtonType="Button" />
				<asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
			</Columns>
			<EditRowStyle BackColor="#FFC080" ForeColor="Teal" />
			<SelectedRowStyle BackColor="#8080FF" ForeColor="#C0C0FF" />
		</asp:GridView>
		<asp:SqlDataSource ID="MySqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDBConnectionString %>"
			SelectCommand="SELECT TOP 10 [UserID], [UserName], [RealName], [Address], [RoleID], [Status], [CreateDate], [Email], [Mobile], [Phone], [Remark] FROM [Users]" DeleteCommand="DELETE FROM Users WHERE UserID = @UserID" UpdateCommand="UPDATE Users SET RealName = @RealName, Address = @Address, Phone = @Phone, Email = @Email, Status = @Status WHERE UserID = @UserID">
			<DeleteParameters>
				<asp:Parameter Name="UserID" />
			</DeleteParameters>
			<UpdateParameters>
				<asp:Parameter Name="UserID" />
				<asp:Parameter Name="RealName" Type="String" Size="50" />
				<asp:Parameter Name="Address" Type="String" Size="50" />
				<asp:Parameter Name="Status" Type="Boolean" Size="10" />
				<asp:Parameter Name="Email" Type="String" Size="255" />
				<asp:Parameter Name="Phone" Type="String" Size="50" />
			</UpdateParameters>
		</asp:SqlDataSource>  
    </div>
    </form>
</body>
</html>
