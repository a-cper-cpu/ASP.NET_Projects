<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewField.aspx.cs" Inherits="ViewField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_5_3:GridView控件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID"
			DataSourceID="MySqlDS" OnRowCommand="MyGridView_RowCommand">
			<Columns>				
				<asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True"
					SortExpression="UserID" />
				<asp:TemplateField HeaderText="UserName">
					<ItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"UserName") %>
					</ItemTemplate>
					<ItemStyle BackColor="DeepSkyBlue" ForeColor="Blue" />
				</asp:TemplateField>				
				<asp:BoundField DataField="RealName" HeaderText="RealName" SortExpression="RealName" />
				<asp:TemplateField HeaderText="Address">
					<ItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"Address") %>
					</ItemTemplate>
					<ItemStyle BackColor="DeepSkyBlue" ForeColor="Blue" />
				</asp:TemplateField>
				<asp:CheckBoxField DataField="Status" HeaderText="Status" SortExpression="Status" />
				<asp:TemplateField HeaderText="CreateDate">
					<ItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"CreateDate") %>
					</ItemTemplate>
					<ItemStyle BackColor="DeepSkyBlue" ForeColor="Blue" />
				</asp:TemplateField>
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
				<asp:TemplateField HeaderText="Mobile">
					<ItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"Mobile")%>
					</ItemTemplate>
					<ItemStyle BackColor="DeepSkyBlue" ForeColor="Blue" />
				</asp:TemplateField>
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
				<asp:TemplateField HeaderText="Remark">
					<ItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"Remark") %>
					</ItemTemplate>
					<ItemStyle BackColor="DeepSkyBlue" ForeColor="Blue" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="操作">
					<ItemTemplate>
						<asp:Button ID="ShowInformation" runat="server" CommandName="information" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserID") %>' Text="显示信息" />
 					</ItemTemplate>
					<ItemStyle BackColor="DeepSkyBlue" ForeColor="Blue" />
				</asp:TemplateField>
			</Columns>
		<AlternatingRowStyle BackColor="#FFC080" ForeColor="Green" />
		</asp:GridView>
		<asp:SqlDataSource ID="MySqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDBConnectionString %>"
			SelectCommand="SELECT TOP 10 [UserID], [UserName], [RealName], [Address], [RoleID], [Status], [CreateDate], [Email], [Mobile], [Phone], [Remark] FROM [Users]">
		</asp:SqlDataSource>
		<br />
		<asp:Label ID="LabelMsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>

