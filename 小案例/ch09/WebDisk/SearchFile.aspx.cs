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
using System.Data.SqlClient;

public partial class SearchFile : System.Web.UI.Page
{
	protected void Page_Load(object sender,EventArgs e)
	{
		if(!Page.IsPostBack)
		{   ///显示目录列表的信息
			BindDirectoryData();
		}
	}
	private void BindDirectoryData()
	{   ///显示目录列表信息
		Disk disk = new Disk();
		disk.ShowDirectory(DirList,-1);
	}
	protected string FormatImageUrl(bool bFlag,string sType)
	{
		if(bFlag == true)
		{   ///文件类型
			return ("~/Images/folder.gif");
		}
		else
		{
			switch(sType)
			{   ///bmp文件
				case "image/bmp": return ("~/Images/bmp.bmp");
				///exe文件
				case "application/octet-stream": return ("~/Images/exe.bmp");
				default: return ("~/Images/other.gif");
			}
		}
		return ("");
	}
	protected string FormatHerf(int nDirID,int nParentID,bool bFlag)
	{
		if(bFlag == true)
		{
			return ("ShowDisk.aspx?DirID=" + nDirID.ToString() + "&ParentID=" + nParentID.ToString());
		}
		else
		{
			return ("ViewDisk.aspx?DirID=" + nDirID.ToString() + "&ParentID=" + nParentID.ToString());
		}
	}
	protected void SearchBtn_Click(object sender,EventArgs e)
	{
		///定义对象
		IDisk disk = new Disk();
		///执行数据库操作
		SqlDataReader dr = disk.SearchFiles(Name.Text.Trim());		
		FileView.DataSource = dr;
		FileView.DataBind();
		dr.Close();

	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		///返回
		Response.Redirect("~/ShowDisk.aspx");
	}
}
