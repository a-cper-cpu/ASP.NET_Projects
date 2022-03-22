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

public partial class AddFolder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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

	protected void AddBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			IDisk disk = new Disk();
			///执行数据库操作
			disk.AddDirectory(Name.Text.Trim(),Int32.Parse(DirList.SelectedValue));
			Response.Write("<script>alert('" + "添加数据成功，请妥善保管好你的数据！" + "');</script>");
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
