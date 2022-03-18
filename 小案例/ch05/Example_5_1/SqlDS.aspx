<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SqlDS.aspx.cs" Inherits="SqlDS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PictureID"
			DataSourceID="MySqlDS">
			<Columns>
				<asp:BoundField DataField="PictureID" HeaderText="PictureID" InsertVisible="False"
					ReadOnly="True" SortExpression="PictureID" />
				<asp:BoundField DataField="Desn" HeaderText="Desn" SortExpression="Desn" />
				<asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
				<asp:BoundField DataField="Data" HeaderText="Data" />
			</Columns>
		</asp:GridView>
		<asp:SqlDataSource ID="MySqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDBConnectionString %>"
			SelectCommand="SELECT [PictureID], [Desn], [Type], [Data] FROM [Pictures] ORDER BY [PictureID]">
		</asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
