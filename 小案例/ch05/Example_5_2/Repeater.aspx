<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Repeater.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_5_2:Repeater控件和DataList控件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Repeater ID="RepeaterList" runat="server" DataSourceID="MySqlDS">
			<HeaderTemplate>
				<table border="1" style="border-color:Blue" cellpadding="0" cellspacing="0">
					<tr>
						<td style="border-width:1;border-color:Blue">UserID</td>
						<td style="border-width:1;border-color:Blue">UserName</td>
						<td style="border-width:1;border-color:Blue">RealName</td>
						<td style="border-width:1;border-color:Blue">Address</td>
						<td style="border-width:1;border-color:Blue">Phone</td>
						<td style="border-width:1;border-color:Blue">Mobile</td>
						<td style="border-width:1;border-color:Blue">Email</td>
						<td style="border-width:1;border-color:Blue">CreateDate</td>
						<td style="border-width:1;border-color:Blue">Status</td>
						<td style="border-width:1;border-color:Blue">Remark</td>
					</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"UserID")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"UserName")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"RealName")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"Address")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"Phone")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"Mobile")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"Email")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"CreateDate")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"Status")%></td>
						<td style="border-width:1;border-color:Blue"><%# DataBinder.Eval(Container.DataItem,"Remark")%></td>
					</tr>
				</ItemTemplate>				
				<AlternatingItemTemplate>
					<tr>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"UserID")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"UserName")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"RealName")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"Address")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"Phone")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"Mobile")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"Email")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"CreateDate")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"Status")%></td>
						<td style="border-width:1;border-color:Blue;color:Green;font-weight:bold"><%# DataBinder.Eval(Container.DataItem,"Remark")%></td>
					</tr>
				</AlternatingItemTemplate>
				<FooterTemplate>
					</table>
				</FooterTemplate>		
		</asp:Repeater>
		<asp:SqlDataSource ID="MySqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDBConnectionString %>"
			SelectCommand="SELECT [UserID], [UserName], [RealName], [Password], [Address], [RoleID], [Status], [CreateDate], [Email], [Mobile], [Phone], [Remark] FROM [Users] ORDER BY [UserID]"></asp:SqlDataSource>
		</div>
    </form>
</body>
</html>
