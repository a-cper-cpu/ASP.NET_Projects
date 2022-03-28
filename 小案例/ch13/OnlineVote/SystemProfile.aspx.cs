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

public partial class SystemProfile : System.Web.UI.Page
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
	protected void SetCurrentBtn_Click(object sender,EventArgs e)
	{
		ITopic topic = new Topic();
		try
		{
			///设置为当前投票主题
			topic.UpdateTopicCurrent(Int32.Parse(TopicView.DataKeys[TopicView.SelectedRow.RowIndex].Value.ToString()));
			///重新显示数据
			BindTopicData();
			Response.Write("<script>alert('" + "设置数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}
	protected void SetRepeatBtn_Click(object sender,EventArgs e)
	{
		SystemTools st = new SystemTools();
		try
		{
			///设置能否重复投票
			st.SetRepeatVote(RepeatList.SelectedValue);
			Response.Write("<script>alert('" + "设置数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}

	}
}
