<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="regedit.aspx.cs" AutoEventWireup="false" Inherits="school.regedit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�û���Ϣע��</title>
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
					<td><asp:panel id="step1" Runat="server" Width="760"><FONT face="����">
								<TABLE borderColor="silver" cellSpacing="0" width="760" align="center" bgColor="#ffffff"
									border="1">
									<TR>
										<TD align="left" width="22%" bgColor="silver" colSpan="2">ע����(**)��ĿΪ������</TD>
									</TR>
									<TR>
										<TD align="right">���������ĵ�¼����</TD>
										<TD>
											<asp:TextBox id="txtAccount" Runat="server" CssClass="textbox"></asp:TextBox>(**)
											<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="�����Ϊ��" ControlToValidate="txtAccount"></asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="��������ĸ�ʽ" ControlToValidate="txtAccount"
												ValidationExpression="\w+([-+.]\w+)*"></asp:RegularExpressionValidator><BR>
											��ע��������ĵ�¼������������(a-z),(A-Z),(0-9)�е������ַ�
										</TD>
									<TR>
										<TD align="right" width="22%">�����õ�¼���</TD>
										<TD>
											<asp:TextBox id="txtUpwd" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>(**)
											<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="���������������" ControlToValidate="txtUpwd"></asp:RequiredFieldValidator></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">ȷ�Ͽ��</TD>
										<TD>
											<asp:TextBox id="txtUpwd2" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>(**)
											<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="�����ٴ��������" ControlToValidate="txtUpwd"
												ControlToCompare="txtUpwd2"></asp:CompareValidator></TD>
									</TR>
									<TR>
										<TD align="right">&nbsp;</TD>
										<TD>											
											<asp:Label id="lblStep2" Runat="server" ForeColor="red"></asp:Label>
											<asp:Label id="lblPwd" Runat="server" Visible="False"></asp:Label></TD>
									</TR>
								</TABLE>
							</FONT><FONT face="����">
								<TABLE borderColor="lightgrey" cellSpacing="0" cellPadding="1" width="760" align="center"
									border="1">
									<TR>
										<TD align="left" width="22%" bgColor="silver" colSpan="2">���������ľ�����Ϣ</TD>
									</TR>
									<TR>
										<TD align="right" width="22%">������</TD>
										<TD>
											<asp:TextBox id="txtUname" runat="server" CssClass="textbox"></asp:TextBox>(**)
											<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="������������ʵ����" ControlToValidate="txtUname"></asp:RequiredFieldValidator></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 12px" align="right" width="22%">�Ա�</TD>
										<TD style="HEIGHT: 12px" vAlign="top">
											<asp:RadioButtonList id="rltSex" Runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="��" Selected="True">��</asp:ListItem>
												<asp:ListItem Value="Ů">Ů</asp:ListItem>
											</asp:RadioButtonList></TD>
									<TR>
										<TD align="right" width="22%">���գ�</TD>
										<TD>
											<asp:DropDownList id="ddlYear" runat="server" CssClass="textbox" AutoPostBack="True"></asp:DropDownList>��
											<asp:DropDownList id="ddlMonth" runat="server" CssClass="textbox" AutoPostBack="True"></asp:DropDownList>��
											<asp:DropDownList id="ddlDay" runat="server" CssClass="textbox"></asp:DropDownList>��
										</TD>
									</TR>
									<TR>
										<TD align="right" width="22%">E_mail��</TD>
										<TD>
											<asp:TextBox id="txtUemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
											<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="��������ȷE_mail��ַ" ControlToValidate="txtUemail"
												ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">�칫�绰��</TD>
										<TD>
											<asp:TextBox id="txtUtel1" runat="server" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">��ͥ�绰��</TD>
										<TD>
											<asp:TextBox id="txtUtel2" runat="server" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">�ƶ��绰��</TD>
										<TD>
											<asp:TextBox id="txtUtel3" runat="server" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">������λ��</TD>
										<TD>
											<asp:TextBox id="txtUjob" runat="server" Width="393px" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">ͨѶ��ַ��</TD>
										<TD>
											<asp:TextBox id="txtUaddr" runat="server" Width="389px" CssClass="textbox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" width="22%">�������룺</TD>
										<TD>
											<asp:TextBox id="txtUzip" runat="server" Width="110px" CssClass="textbox"></asp:TextBox>
											<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="��������λ��������" ControlToValidate="txtUzip"
												ValidationExpression="\d{6}"></asp:RegularExpressionValidator></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="2">
											<asp:Button id="btnOK" Runat="server" CssClass="button" Text="ȷ��"></asp:Button></TD>
									</TR>
								</TABLE>
							</FONT>
						</asp:panel>
						<asp:panel id="step2" Runat="server" Width="760"><SPAN id="span1" runat="server"></SPAN>
							<TABLE borderColor="black" cellSpacing="0" borderColorDark="black" cellPadding="2" width="760"
								align="center" bgColor="#e3ebfe" borderColorLight="white" border="0">
								<TR>
									<TD align="center" width="42%" bgColor=Silver>���ٴ�ȷ�������������
									</TD>
									<TD align="left"  bgColor=Silver>
										<asp:Button id="btnSave" Runat="server" CssClass="button" Text="ȷ��"></asp:Button>&nbsp;
										<asp:Button id="btnReturn" Runat="server" CssClass="button" Text="����"></asp:Button></TD>
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
