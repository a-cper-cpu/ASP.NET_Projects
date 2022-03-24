<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftTree.aspx.cs" Inherits="LeftTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style="margin-bottom:0;margin-left:0;margin-right:0;margin-top:0">
    <form id="form1" runat="server">
    <div>
    <asp:TreeView ID="OperationView" Width="100%" runat="server" ImageSet="BulletedList3" CssClass="GbText" ShowLines="True">
		<ParentNodeStyle Font-Bold="False" />
		<HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
		<SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
			VerticalPadding="0px" />
		<NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
			NodeSpacing="0px" VerticalPadding="0px" />
		<Nodes>
			<asp:TreeNode Target="Main" Text="功能列表" Value="-1">
				<asp:TreeNode NavigateUrl="~/MailDesktop.aspx" Text="邮件文件夹" Value="0" Target="Desktop">
				</asp:TreeNode>
				<asp:TreeNode NavigateUrl="~/Sender.aspx" Text="新邮件" Value="6" Target="Desktop"></asp:TreeNode>
				<asp:TreeNode NavigateUrl="~/NewFolder.aspx" Target="Desktop" Text="新建文件夹" Value="7">
				</asp:TreeNode>
				<asp:TreeNode NavigateUrl="~/SystemProfile.aspx" Target="Desktop" Text="邮件系统配置" Value="8">
				</asp:TreeNode>
			</asp:TreeNode>
		</Nodes>
		<RootNodeStyle Font-Bold="True" ForeColor="Maroon" />
	</asp:TreeView>
    </div>
    </form>
</body>
</html>
