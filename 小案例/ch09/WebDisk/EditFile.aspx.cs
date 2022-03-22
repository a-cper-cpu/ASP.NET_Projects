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

public partial class EditFile : System.Web.UI.Page
{
	int nFileID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{
		///获取参数DirID的值
		if(Request.Params["DirID"] != null)
		{
			if(Int32.TryParse(Request.Params["DirID"].ToString(),out nFileID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{   ///显示目录的名称
			if(nFileID > -1)
			{
				BindFileData(nFileID);
			}
		}
	}
	private void BindFileData(int nDirID)
	{
		string sFileName = "";
		IDisk disk = new Disk();
		SqlDataReader dr = disk.GetSingleFile(nFileID);
		if(dr.Read())
		{   ///获取文件的名称（包含后缀）
			sFileName = dr["Name"].ToString();
		}
		dr.Close();
		///查找最后一个“.”
		int dotIndex = sFileName.LastIndexOf(".");
		if(dotIndex > -1)
		{   ///获取文件的名称（不包含后缀）
			Name.Text = sFileName.Substring(0,dotIndex);
		}
	}
	protected void EditBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			IDisk disk = new Disk();
			///执行数据库操作
			disk.EditFile(nFileID,Name.Text.Trim());
			Response.Write("<script>alert('" + "修改数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		///返回
		Response.Redirect("~/ShowDisk.aspx");
	}
}
