<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataListField.aspx.cs" Inherits="DataListField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_5_2:Repeater控件和DataList控件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:DataList ID="MyDataList" runat="server" DataKeyField="UserID" BorderColor="#FF8000" BorderWidth="1px" OnItemCommand="MyDataList_ItemCommand">
			<HeaderTemplate>
			    <table border="1" cellpadding="0" cellspacing="0">
					<tr>
						<td style="width:80px">UserName</td>
						<td style="width:250px">RealName</td>
						<td style="width:100px">操作</td>
					</tr>
				</table>
			</HeaderTemplate>			
			<ItemTemplate>
				<table border="1" cellpadding="0" cellspacing="0">
					<tr>
						<td style="width:80px"><%# DataBinder.Eval(Container.DataItem,"UserName") %></td>
						<td style="width:250px"><%# DataBinder.Eval(Container.DataItem,"RealName") %></td>
						<td style="width:100px"><asp:Button ID="ShowInformation" CommandName="information" runat="server" Text="显示信息" /></td>
					</tr>
				</table>
			</ItemTemplate>
			<SeparatorTemplate></SeparatorTemplate>
			<AlternatingItemTemplate>
				<table border="1" cellpadding="0" cellspacing="0">
					<tr>
						<td style="width:80px"><%# DataBinder.Eval(Container.DataItem,"UserName") %></td>
						<td style="width:250px"><%# DataBinder.Eval(Container.DataItem,"RealName") %></td>
						<td style="width:100px"><asp:Button ID="ShowInformation" CommandName="information" runat="server" Text="显示信息" /></td>
					</tr>
				</table>
			</AlternatingItemTemplate>
			<AlternatingItemStyle BackColor="GradientInactiveCaption" ForeColor="RoyalBlue" />
			<SeparatorStyle BackColor="Teal" ForeColor="Purple" Height="5px" Width="2px" />
			<SelectedItemStyle BackColor="#C0C0FF" ForeColor="#804040" />
			<HeaderStyle BorderColor="#FFC0C0" BorderWidth="0px" Font-Bold="True" ForeColor="BlueViolet" />
		</asp:DataList><br />
		<asp:Label ID="LabelMsg" runat="server" BackColor="LightSteelBlue"></asp:Label>
    </div>
    </form>
</body>
</html>
