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

public partial class AddTopic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void AddBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			ITopic topic = new Topic();
			///执行数据库操作
			topic.AddTopic(Name.Text.Trim(),Body.Text);
			Response.Write("<script>alert('" + "添加数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}

	protected void ReturnBtn_Click(object sender,EventArgs e)
	{   ///跳转到管理页面
		Response.Redirect("~/TopicManage.aspx");
	}
}
