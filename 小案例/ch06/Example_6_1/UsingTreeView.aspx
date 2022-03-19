<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsingTreeView.aspx.cs" Inherits="UsingTreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style="margin-left:0;margin-top:0">
		<form id="MyForm" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse;" width="100%">
				<tr style="height: 30px;">
					<td class="Text" style="background-color: #6666ff; width: 3%;"><font color="#006699" size="3"><img alt="" src="../../Images/moduleheaher.gif" width="16" height="16"></font></td>
					<td class="Text" style="background-color: #6666ff;"><b>使用TreeView控件</b></td>
				</tr>
			</table>
			<table class="Text" bordercolor="#006699" style="border-collapse:collapse;border-color:ActiveCaption;border-width:1" width="100%" border="1">
				<tr>
					<td style="width:100%;">
						<asp:TreeView ID="CategoryView" runat="server" Width="100%" ShowLines="True" CssClass="Text" BackColor="#5A7DD1" ForeColor="White" EnableClientScript="False">
							 <NodeStyle BackColor="#5A7DD1" ForeColor="White" Font-Bold="True" CssClass="Text" />							
							 <RootNodeStyle BackColor="Transparent" Font-Bold="True" ForeColor="White" />
							 <SelectedNodeStyle BackColor="#5A7DD1" CssClass="Text" Font-Bold="True" ForeColor="DarkRed" />
						</asp:TreeView>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>

