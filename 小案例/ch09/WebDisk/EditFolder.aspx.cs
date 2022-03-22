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

public partial class EditFolder : System.Web.UI.Page
{
	int nDirID = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
		///获取参数DirID的值
		if(Request.Params["DirID"] != null)
		{
			if(Int32.TryParse(Request.Params["DirID"].ToString(),out nDirID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{   ///显示目录的名称
			if(nDirID > -1)
			{
				BindDirectoryData(nDirID);
			}
		}
    }

	private void BindDirectoryData(int nDirID)
	{
		IDisk disk = new Disk();
		SqlDataReader dr = disk.GetSingleDirectory(nDirID);
		if(dr.Read())
		{
			Name.Text = dr["Name"].ToString();
		}
		dr.Close();
	}
	
	protected void EditBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			IDisk disk = new Disk();
			///执行数据库操作
			disk.EditDirectory(nDirID,Name.Text.Trim());
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
