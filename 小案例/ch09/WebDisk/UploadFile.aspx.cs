using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Net;

public partial class UploadFile : System.Web.UI.Page
{
	int nParentID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{
		///获取参数DirID的值
		if(Request.Params["DirID"] != null)
		{
			if(Int32.TryParse(Request.Params["DirID"].ToString(),out nParentID) == false)
			{
				return;
			}
		}
		///设置上载按钮是否可用
		SureBtn.Enabled = nParentID <= -1 ? false : true;
    }

	private void UploadFiles(int nParentID)
	{	///获取上载文件的列表
		HttpFileCollection fileList = HttpContext.Current.Request.Files;
		///定义显示的消息
		StringBuilder uploadMsg = new StringBuilder("上载的文件如下：" + "<br>");
		IDisk disk = new Disk();
		try
		{	///上载文件列表中的每一个文件
			for(int i = 0; i < fileList.Count; i++)
			{	///获取当前上载的文件
				HttpPostedFile hPostedFile = fileList[i];
				string fileName;
				///获取上载文件的文件名称
				fileName = Path.GetFileName(hPostedFile.FileName);
				if(fileName != null)
				{	///上载文件
					hPostedFile.SaveAs(MapPath("WebDisk/") + fileName);
					///添加文件到数据库中
					disk.AddFile(fileName,nParentID,hPostedFile.ContentLength,"WebDisk/" + fileName,hPostedFile.ContentType);
					uploadMsg.Append("文件名称：" + fileName + "<br>");
				}
			}
			///显示上载文件的操作成功消息
			StatusMsg.Text = uploadMsg.ToString();
		}
		catch(Exception ex)
		{
			///显示上载文件的操作失败消息
			StatusMsg.Text = ex.Message;
		}
	}
	protected void SureBtn_Click(object sender,EventArgs e)
	{   ///上载所有文件
		UploadFiles(nParentID);
	}
}


//function addFile()
//        {
//            var str = '<input type="file" size="50" name="File" />';
//            document.getElementById('MyFile').insertAdjacentHTML("beforeEnd",str);
			
//            var spanobj = '<span name="fileSpan"><input type="file" size="50" name="File" /><input id="delete" type="button" value="delete" onclick="deletefile()" /></span>';
			
//            document.getElementById('MyFile').appendChild(document.createElement(str));
//            document.getElementById('MyFile').removeChild(document.getElementById('file'));
//        }
//        function deletefile()
//        {
//            document.getElementById('MyFile').removeChild(document.getElementById('fileSpan'));
//        }
//var isIE = (navigator.userAgent.indexOf("MSIE") != -1);
//var fileIndex = 0;

//function addFile() {
//    var spanId = "filespan";
//    var fileId = "uploadfile" + (fileIndex++);
//    addInputFile(spanId, fileId);
//}

//function addInputFile(spanId, fileId) {
//    var span = document.getElementById(spanId);
//    if (span != null) {
//        var divObj = document.createElement("div"), fileObj, delObj;
//        divObj.id = fileId;
//        if (isIE) {
//            fileObj = document.createElement("<input type=file onchange=changeFile(form)>");
//            delObj = document.createElement("<input type=button onclick=delInputFile('" + spanId + "','" + fileId + "')>");
//        } else {
//            fileObj = document.createElement("input");
//            fileObj.type = "file";
//            fileObj.setAttribute("onchange", "changeFile(form)", 0);
//            delObj = document.createElement("input");
//            delObj.type = "button";
//            delObj.setAttribute("onclick", "delInputFile('" + spanId + "','" + fileId + "')", 0);
//        }
//        fileObj.name = fileId;
//        fileObj.size = "40";
//        fileObj.className = "input";
//        delObj.value = RES_BT_DELETE;
//        divObj.appendChild(fileObj);
//        divObj.appendChild(document.createTextNode(" "));
//        divObj.appendChild(delObj);
//        span.appendChild(divObj);
//    }
//}

//function delInputFile(spanId, fileId) {
//    var span = document.getElementById(spanId);
//    var divObj = document.getElementById(fileId);
//    if (span != null && divObj != null) {
//        span.removeChild(divObj);
//    }
//}

