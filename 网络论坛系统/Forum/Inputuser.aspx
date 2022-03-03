<%@ register tagprefix="T" tagname="Top" src="Top.ascx"%>
<%@ Page language="c#" Codebehind="Inputuser.aspx.cs" AutoEventWireup="false" Inherits="Forum.Inputuser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Inputuser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<T:TOP id="Top" runat="server"></T:TOP>
		<P><FONT class="font"></FONT>&nbsp;</P>
		<P><FONT class="font"></FONT>
		</P>
		<form name="form1" method="post" action="Adminuser.aspx">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="228" align="center" border="0"
				height="38">
				<TR>
					<TD width="273"><FONT size="2">请输入用户名：</FONT></TD>
				</TR>
				<TR>
					<TD width="273">
						<INPUT id="username" type="text" name="username">&nbsp;&nbsp;&nbsp;&nbsp; <INPUT type="submit" value="提交" name="Submit"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
