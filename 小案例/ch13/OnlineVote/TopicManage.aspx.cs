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
using System.Drawing;

public partial class TopicManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			BindTopicData();
		}
    }

	private void BindTopicData()
	{   ///获取数据
		ITopic topic = new Topic();
		SqlDataReader dr = topic.GetTopics();
		///绑定数据
		TopicView.DataSource = dr;
		TopicView.DataBind();
		///关闭数据源
		dr.Close();
	}

	protected void AddBtn_Click(object sender,EventArgs e)
	{
		///跳转到添加页面
		Response.Redirect("~/AddTopic.aspx");
	}

	protected void TopicView_RowDeleting(object sender,GridViewDeleteEventArgs e)
	{
		///
	}
	protected void TopicView_RowDataBound(object sender,GridViewRowEventArgs e)
	{
		ImageButton deleteBtn = (ImageButton)e.Row.FindControl("DeleteBtn");
		if(deleteBtn != null)
		{
			deleteBtn.Attributes.Add("onclick","return confirm('你确定要删除所选择的数据项吗？');");
		}
	}
	protected void TopicView_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName == "delete")
		{
			try
			{   ///删除数据
				ITopic topic = new Topic();
				topic.DeleteTopic(Int32.Parse(e.CommandArgument.ToString()));

				///重新绑定控件的数据
				BindTopicData();
				Response.Write("<script>alert('" + "删除数据成功，请妥善保管好你的数据！" + "');</script>");
			}
			catch(Exception ex)
			{   ///跳转到异常错误处理页面
				Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
					+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
			}
		}
	}
}
