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

public partial class NewFolder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void NewBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			IFolder folder = new Folder();
			///执行数据库操作
			folder.NewFolder(Name.Text.Trim());
			Response.Write("<script>alert('" + "添加数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}		
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{   ///返回到邮件列表页面
		Response.Redirect("~/MailDesktop.aspx");
	}	
}
