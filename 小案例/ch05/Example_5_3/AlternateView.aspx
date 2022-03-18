<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlternateView.aspx.cs" Inherits="AlternateView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_5_3:GridView控件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID"
			DataSourceID="MySqlDS">
			<Columns>				
				<asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True"
					SortExpression="UserID" />
				<asp:TemplateField HeaderText="UserName" ItemStyle-BackColor="DeepSkyBlue" ItemStyle-ForeColor="blue">
					<AlternatingItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"UserName") %>
					</AlternatingItemTemplate>
				</asp:TemplateField>				
				<asp:BoundField DataField="RealName" HeaderText="RealName" SortExpression="RealName" />
				<asp:TemplateField HeaderText="Address" ItemStyle-BackColor="DeepSkyBlue" ItemStyle-ForeColor="blue">
					<AlternatingItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"Address") %>
					</AlternatingItemTemplate>
				</asp:TemplateField>
				<asp:CheckBoxField DataField="Status" HeaderText="Status" SortExpression="Status" />
				<asp:TemplateField HeaderText="CreateDate" ItemStyle-BackColor="DeepSkyBlue" ItemStyle-ForeColor="blue">
					<AlternatingItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"CreateDate") %>
					</AlternatingItemTemplate>
				</asp:TemplateField>
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
				<asp:TemplateField HeaderText="Mobile" ItemStyle-BackColor="DeepSkyBlue" ItemStyle-ForeColor="blue">
					<AlternatingItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"Mobile")%>
					</AlternatingItemTemplate>
				</asp:TemplateField>
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
				<asp:TemplateField HeaderText="Remark" ItemStyle-BackColor="DeepSkyBlue" ItemStyle-ForeColor="blue">
					<AlternatingItemTemplate>
						<%# DataBinder.Eval(Container.DataItem,"Remark") %>
					</AlternatingItemTemplate>
				</asp:TemplateField>
			</Columns>
		<AlternatingRowStyle BackColor="#FFC080" ForeColor="Green" />
		</asp:GridView>
		<asp:SqlDataSource ID="MySqlDS" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDBConnectionString %>"
			SelectCommand="SELECT [UserID], [UserName], [RealName], [Address], [RoleID], [Status], [CreateDate], [Email], [Mobile], [Phone], [Remark] FROM [Users]">
		</asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
