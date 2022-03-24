<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sender.aspx.cs" Inherits="Sender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第11章：网络邮件管理系统===发送邮件</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
     <script language="javascript" type="text/javascript">		
		function addFile()
        {		
            var filebutton = '<br><input type="file" size="50" name="File" class="ButtonCss" />';
            document.getElementById('FileList').insertAdjacentHTML("beforeEnd",filebutton);
        }
	</script>
</head>
<body style="margin-left:0;margin-top:0;margin-left:0">
    <form id="form1" runat="server" method="post">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellspacing="0"
		cellpadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">发送邮件:</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:155px" align="right">收件人:</td>
			<td><asp:textbox id="To" runat="server" Width="300px" CssClass="InputCss"></asp:textbox>		
				<asp:RequiredFieldValidator ID="rfN" runat="server" ControlToValidate="To"
					CssClass="GbText" Display="Dynamic" ErrorMessage="收件人不能为空！"></asp:RequiredFieldValidator></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:155px" align="right">抄送:</td>
			<td><asp:textbox id="CC" runat="server" Width="300px" CssClass="InputCss"></asp:textbox>		</td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:155px" align="right">主题:</td>
			<td><asp:textbox id="Title" runat="server" Width="300px" CssClass="InputCss"></asp:textbox>		</td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:155px" align="right">邮件格式:</td>
			<td><input id="HtmlCB" type="checkbox" runat="server" class="GbText" />HTML格式</td>
		</tr>	
		<tr style="line-height:2;">
			<td style="width:155px" align="right" valign="top">内容:</td>
			<td><asp:textbox id="Body" runat="server" Width="400px" CssClass="InputCss" Height="200px" TextMode="MultiLine"></asp:textbox>		</td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:155px" align="right">邮件附件:</td>
			<td><input type="button" value="增加附件" class="ButtonCss" onclick="addFile()" />
			</td>
		</tr>	
		<tr style="line-height:2;">
			<td style="width:155px" align="right"></td>
			<td><p id="FileList"><input type="file" runat="server" size="50" name="File" class="ButtonCss" /></p></td>
		</tr>			
		<tr style="line-height:2;">
			<td style="width:155px" align="right"></td>
			<td align="left"><font face="宋体">&nbsp;</font><asp:Button ID="SenderBtn" runat="server" Text="发送" Width="100px" CssClass="ButtonCss" OnClick="NewBtn_Click" /><font face="宋体">&nbsp;</font><asp:Button ID="ReturnBtn" runat="server" Text="返回" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" CausesValidation="False" /></td>
		</tr>
		<tr>
			<td style="width: 155px"></td>
		</tr>
    </table>
    </form>  
</body>
</html>
