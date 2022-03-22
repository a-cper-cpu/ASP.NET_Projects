<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="UploadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>第九章：网络硬盘===上载文件</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
    <script language="javascript" type="text/javascript">		
		function addFile()
        {		
            var filebutton = '<br><input type="file" size="50" name="File" class="ButtonCss" />';
            document.getElementById('FileList').insertAdjacentHTML("beforeEnd",filebutton);
        }
	</script>
</head>
 <body>
		<form id="form" method="post" runat="server" enctype="multipart/form-data">
			<center>
				<asp:Label Runat="server" ID="Header" CssClass="HeaderText" Text="上载文件"></asp:Label>
				<hr style="size:1" />
				<p id="FileList"><input type="file" size="50" name="File" class="ButtonCss" /></p>
				<p>
					<input type="button" value="增加上载文件" class="ButtonCss" onclick="addFile()" />
					<asp:Button Runat="server" CssClass="ButtonCss" Text="上传所有文件" ID="SureBtn" OnClick="SureBtn_Click"></asp:Button>
				</p>
			</center>
			<p align="center">
				<asp:Label id="StatusMsg" runat="server" CssClass="GbText" ForeColor="red" Width="100%"></asp:Label>
			</p>
		</form>
	</body>
</html>
