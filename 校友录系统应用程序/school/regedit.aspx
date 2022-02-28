<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="regedit.aspx.cs" AutoEventWireup="false" Inherits="school.regedit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>用户信息注册</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="school.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<H:HEADER id="Header" runat="server"></H:HEADER>
			<table align="center">
				<tr>
					<td><asp:panel id="step1" Runat="server" Width="760"><FONT face="宋体">
								<TABLE borderColor="silver" cellSpacing="0" width="760" align="center" bgColor="#ffffff"
									border="1">
									<TR>
										<TD align="left" width="22%" bgColor="silver" colSpan="2">注意标记(**)项目为必填项</TD>
									</TR>
									<TR>
										<TD align="right">请输入您的登录名：</TD>
										<TD>
											<asp:TextBox id="txtAccount" Runat="server" CssClass="textbox"></asp:TextBox>(**)
											<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="此项不能为空" ControlToValidate="txtAccount"></asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="请检查输入的格式" ControlToValidate="txtAccount"
												ValidationExpression="\w+([-+.]\w+)*"></asp:RegularExpressionValidator><BR>
											请注意您输入的登录名必须是属于(a-z),(A-Z),(0-9)中的任意字符
										</TD>
									<TR>
										<TD align="right" width="22%">请设置登录口令：</TD>
										<TD>
											<asp:TextBox id="txtUpwd" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>(**)
											<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="您不能输入空密码" ControlToValidate="txtUpwd"></asp:RequiredFieldValidator></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">确认口令：</TD>
										<TD>
											<asp:TextBox id="txtUpwd2" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>(**)
											<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="请您再次输入口令" ControlToValidate="txtUpwd"
												ControlToCompare="txtUpwd2"></asp:CompareValidator></TD>
									</TR>
									<TR>
										<TD align="right">&nbsp;</TD>
										<TD>											
											<asp:Label id="lblStep2" Runat="server" ForeColor="red"></asp:Label>
											<asp:Label id="lblPwd" Runat="server" Visible="False"></asp:Label></TD>
									</TR>
								</TABLE>
							</FONT><FONT face="宋体">
								<TABLE borderColor="lightgrey" cellSpacing="0" cellPadding="1" width="760" align="center"
									border="1">
									<TR>
										<TD align="left" width="22%" bgColor="silver" colSpan="2">请输入您的具体信息</TD>
									</TR>
									<TR>
										<TD align="right" width="22%">姓名：</TD>
										<TD>
											<asp:TextBox id="txtUname" runat="server" CssClass="textbox"></asp:TextBox>(**)
											<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="请输入您的真实性名" ControlToValidate="txtUname"></asp:RequiredFieldValidator></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 12px" align="right" width="22%">性别：</TD>
										<TD style="HEIGHT: 12px" vAlign="top">
											<asp:RadioButtonList id="rltSex" Runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="男" Selected="True">男</asp:ListItem>
												<asp:ListItem Value="女">女</asp:ListItem>
											</asp:RadioButtonList></TD>
									<TR>
										<TD align="right" width="22%">生日：</TD>
										<TD>
											<asp:DropDownList id="ddlYear" runat="server" CssClass="textbox" AutoPostBack="True"></asp:DropDownList>年
											<asp:DropDownList id="ddlMonth" runat="server" CssClass="textbox" AutoPostBack="True"></asp:DropDownList>月
											<asp:DropDownList id="ddlDay" runat="server" CssClass="textbox"></asp:DropDownList>日
										</TD>
									</TR>
									<TR>
										<TD align="right" width="22%">E_mail：</TD>
										<TD>
											<asp:TextBox id="txtUemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
											<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="请输入正确E_mail地址" ControlToValidate="txtUemail"
												ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">办公电话：</TD>
										<TD>
											<asp:TextBox id="txtUtel1" runat="server" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">家庭电话：</TD>
										<TD>
											<asp:TextBox id="txtUtel2" runat="server" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">移动电话：</TD>
										<TD>
											<asp:TextBox id="txtUtel3" runat="server" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">工作单位：</TD>
										<TD>
											<asp:TextBox id="txtUjob" runat="server" Width="393px" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">通讯地址：</TD>
										<TD>
											<asp:TextBox id="txtUaddr" runat="server" Width="389px" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">邮政编码：</TD>
										<TD>
											<asp:TextBox id="txtUzip" runat="server" Width="110px" CssClass="textbox"></asp:TextBox>
											<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="请输入六位邮政编码" ControlToValidate="txtUzip"
												ValidationExpression="\d{6}"></asp:RegularExpressionValidator></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="2">
											<asp:Button id="btnOK" Runat="server" CssClass="button" Text="确认"></asp:Button></TD>
									</TR>
								</TABLE>
							</FONT>
						</asp:panel>
						<asp:panel id="step2" Runat="server" Width="760"><SPAN id="span1" runat="server"></SPAN>
							<TABLE borderColor="black" cellSpacing="0" borderColorDark="black" cellPadding="2" width="760"
								align="center" bgColor="#e3ebfe" borderColorLight="white" border="0">
								<TR>
									<TD align="center" width="42%" bgColor=Silver>请再次确认您输入的数据
									</TD>
									<TD align="left"  bgColor=Silver>
										<asp:Button id="btnSave" Runat="server" CssClass="button" Text="确定"></asp:Button>&nbsp;
										<asp:Button id="btnReturn" Runat="server" CssClass="button" Text="返回"></asp:Button></TD>
								</TR>
								<TR>
									<TD colSpan="2"  bgColor=Silver>
										<asp:Label id="lblOK" runat="server"></asp:Label></TD>
								</TR>
							</TABLE>
						</asp:panel></td>
				</tr>
			</table>
		</form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
