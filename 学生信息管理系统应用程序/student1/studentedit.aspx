<%@ Page language="c#" Codebehind="studentedit.aspx.cs" AutoEventWireup="false" Inherits="student1.studentedit" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<HTML>
	<HEAD>
		<title>ѧ����Ϣά��</title>
		<link href="student.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body text="#000000" link="#000080" vlink="#000080" alink="#000080">
		<form method="post" runat="server" ID="Form1">
			<H:Header id="Header" runat="server" />
			<input type="hidden" id="p_stu_student_id" runat="server" NAME="p_stu_student_id">
			<table align="center" width="600">
				<tr>
					<td width="100%" valign="top" align="center">
						<table id="emps_holder" runat="Server" border="0" cellspacing="1" cellpadding="0" width="100%"
							class="tableBorder1">
							<tr>
								<th background="images/sds01_r2_c8.gif" align="center" height="25">
									<asp:label id="GridForm_Title" runat="server">ѧ����Ϣά��</asp:label></th>
							</tr>
							<tr>
								<td background="images/sds01_r2_c8.gif">
									<table>
										<tr>
											<td colspan="2">
												<asp:Label id="stu_ValidationSummary" runat="server" Visible="false"></asp:Label>
												<input type="hidden" id="stu_student_id" runat="server" NAME="stu_student_id">
											</td>
										</tr>
										<tr>
											<td bgcolor=Silver>����
												<asp:RequiredFieldValidator id="stu_name_Validator_Req" runat="server" ErrorMessage="������������" ControlToValidate="stu_name"
													display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
											<td>
												<asp:TextBox id="stu_name" Columns="50" MaxLength="100" runat="server" />
											</td>
										</tr>
										<tr>
											<td bgcolor=Silver>�Ա�&nbsp;
												<asp:RequiredFieldValidator id="stu_sex_Validator_Req" runat="server" ErrorMessage="�������Ա�" ControlToValidate="stu_sex"
													display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
											<td>
												<asp:TextBox id="stu_sex" Columns="50" MaxLength="100" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>����&nbsp;
												<asp:RequiredFieldValidator id="stu_age_Validator_Req" runat="server" ErrorMessage="���������䣡" ControlToValidate="stu_age"
													display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
											<td>
												<asp:TextBox id="stu_age" Columns="50" MaxLength="100" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>ְ��
												<asp:RequiredFieldValidator id="stu_business_Validator_Req" runat="server" ErrorMessage="������ְ��" ControlToValidate="stu_business"
													display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
											<td>
												<asp:TextBox id="stu_business" Columns="50" MaxLength="50" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>�ʺ�
												<asp:RequiredFieldValidator id="stu_student_login_Validator_Req" runat="server" ErrorMessage="The value in field Login is required."
													ControlToValidate="stu_student_login" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
											<td>
												<asp:TextBox id="stu_student_login" Columns="20" MaxLength="20" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>����
												<asp:RequiredFieldValidator id="stu_student_password_Validator_Req" runat="server" ErrorMessage="The value in field Password is required."
													ControlToValidate="stu_student_password" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
											<td>
												<asp:TextBox id="stu_student_password" TextMode="Password" Columns="20" MaxLength="20" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>����
												<asp:RequiredFieldValidator id="stu_student_level_Validator_Req" runat="server" ErrorMessage="The value in field Level is required."
													ControlToValidate="stu_student_level" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
												<asp:CustomValidator id="stu_student_level_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
													EnableClientScript="False" ErrorMessage="The value in field Level is incorrect." ControlToValidate="stu_student_level"
													display="None"></asp:CustomValidator></td>
											<td>
												<asp:DropDownList id="stu_student_level" DataTextField="" DataValueField="" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>�༶
												<asp:RequiredFieldValidator id="stu_class_id_Validator_Req" runat="server" ErrorMessage="The value in field Department is required."
													ControlToValidate="stu_class_id" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
												<asp:CustomValidator id="stu_class_id_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
													EnableClientScript="False" ErrorMessage="The value in field Department is incorrect." ControlToValidate="stu_class_id"
													display="None"></asp:CustomValidator></td>
											<td>
												<asp:DropDownList id="stu_class_id" DataTextField="name" DataValueField="dep_id" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>��ַ</td>
											<td>
												<asp:TextBox id="stu_address" TextMode="MultiLine" Rows="2" Columns="50" runat="server"></asp:TextBox>
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>Email</td>
											<td>
												<asp:TextBox id="stu_email" Columns="50" MaxLength="50" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>����绰</td>
											<td>
												<asp:TextBox id="stu_work_phone" Columns="50" MaxLength="50" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>��ͥ�绰</td>
											<td>
												<asp:TextBox id="stu_home_phone" Columns="50" MaxLength="50" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>�ƶ��绰</td>
											<td>
												<asp:TextBox id="stu_mobile_phone" Columns="50" MaxLength="50" runat="server" />
												&nbsp;</td>
										</tr>
										<tr>
											<td bgcolor=Silver>ÿ��֮��</td>
											<td>
												<asp:CheckBox id="stu_super" runat="server" />
												&nbsp;</td>
										</tr>
										
										<tr>
											<td align="right" colspan="2">
												<input type="button" id="stu_insert" Value="���" runat="server" NAME="stu_insert">
												<input type="button" id="stu_update" Value="�޸�" runat="server" NAME="stu_update">
												<input type="button" id="stu_delete" Value="ɾ��" runat="server" NAME="stu_delete">
												<input type="button" id="stu_cancel" Value="ȡ��" runat="server" NAME="stu_cancel">
											</td>
										</tr>
									</table>
									<SCRIPT Language="JavaScript" type="text/javascript">
if (document.forms["emps"])
  document.emps.onsubmit=delconf;
function delconf() {
if (document.emps.FormAction.value == 'delete')
  return confirm('Delete record?');
}
									</SCRIPT>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<center>
			<F:Footer id="Footer" runat="server" /></center>
	</body>
</HTML>
