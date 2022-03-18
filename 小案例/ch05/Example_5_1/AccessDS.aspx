<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccessDS.aspx.cs" Inherits="AccessDS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="B_Code"
			DataSourceID="MyAccessDS">
			<Columns>
				<asp:BoundField DataField="B_Code" HeaderText="B_Code" ReadOnly="True" SortExpression="B_Code" />
				<asp:BoundField DataField="B_Title" HeaderText="B_Title" SortExpression="B_Title" />
				<asp:BoundField DataField="B_Type" HeaderText="B_Type" SortExpression="B_Type" />
				<asp:BoundField DataField="B_Class" HeaderText="B_Class" SortExpression="B_Class" />
				<asp:BoundField DataField="B_Order" HeaderText="B_Order" SortExpression="B_Order" />
				<asp:BoundField DataField="B_AllowSelect" HeaderText="B_AllowSelect" SortExpression="B_AllowSelect" />
			</Columns>
		</asp:GridView>
		<asp:AccessDataSource ID="MyAccessDS" runat="server" DataFile="~/database/AccessDB.mdb"
			SelectCommand="SELECT [B_Code], [B_Title], [B_Type], [B_Class], [B_Order], [B_AllowSelect] FROM [Button] ORDER BY [B_Order]">
		</asp:AccessDataSource>
    
    </div>
    </form>
</body>
</html>
