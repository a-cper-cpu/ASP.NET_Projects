<%@ register tagprefix="T" tagname="Top" src="Top.ascx"%>
<%@ Page language="c#" Codebehind="adminadd.aspx.cs" AutoEventWireup="false" Inherits="Forum.adminadd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminadd</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<T:TOP id="Top" runat="server"></T:TOP>
		<table class="font" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
			<% display();%>
			<tr>
				<form name="form1" action="Adminattribu.aspx?action=addclass1" method="get">
					<td align="center" bgColor="#ffcc66" colSpan="3"><input type="text" name="TopicName">
						<input type=hidden value="" name=Beg> 
						<input type="submit" value="添加讨论区" name="Submit">(添加讨论区只能由系统管理员操作！)
					</td>
				</form>
			</tr>
		</table>
	</body>
</HTML>
