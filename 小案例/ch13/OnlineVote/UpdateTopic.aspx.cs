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

public partial class UpdateTopic : System.Web.UI.Page
{
	private int nTopicID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {   ///获取参数TopicID的值
		if(Request.Params["TopicID"] != null)
		{
			if(Int32.TryParse(Request.Params["TopicID"].ToString(),out nTopicID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{   ///显示数据
			if(nTopicID > -1)
			{
				BindTopicData(nTopicID);
			}
		}
    }

	private void BindTopicData(int nTopicID)
	{   ///获取数据
		ITopic topic = new Topic();
		SqlDataReader dr = topic.GetSingleTopic(nTopicID);
		///读取数据
		if(dr.Read())
		{
			Name.Text = dr["Name"].ToString();
			Body.Text = dr["Body"].ToString();
		}		
		///关闭数据源
		dr.Close();
	}
	protected void UpdateBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			ITopic topic = new Topic();
			///执行数据库操作
			topic.UpdateTopic(nTopicID,Name.Text.Trim(),Body.Text);
			Response.Write("<script>alert('" + "修改数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{	///跳转到管理页面
		Response.Redirect("~/TopicManage.aspx");
	}
}
