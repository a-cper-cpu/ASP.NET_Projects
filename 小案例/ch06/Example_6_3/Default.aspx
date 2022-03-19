<%@ Page Language="C#" Theme="Control" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID" DataSourceID="MySqlDS" SkinID="gridviewSkin">
			<Columns>
				<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" InsertVisible="False"
					ReadOnly="True" SortExpression="CategoryID" />
				<asp:BoundField DataField="Desn" HeaderText="Desn" SortExpression="Desn" />
				<asp:BoundField DataField="ParentID" HeaderText="ParentID" SortExpression="ParentID" />
				<asp:BoundField DataField="OrderBy" HeaderText="OrderBy" SortExpression="OrderBy" />
				<asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
			</Columns>
		</asp:GridView>
		<asp:SqlDataSource ID="MySqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCONNECTIONSTRING %>"
			SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
