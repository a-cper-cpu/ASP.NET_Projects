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

public partial class AddSubject : System.Web.UI.Page
{
	protected void Page_Load(object sender,EventArgs e)
	{   
		if(!Page.IsPostBack)
		{   ///显示数据
			BindTopicData();
		}
		AddBtn.Enabled = TopicList.Items.Count > 0 ? true : false;
	}
	private void BindTopicData()
	{   ///获取数据
		ITopic topic = new Topic();
		SqlDataReader dr = topic.GetTopics();
		///绑定数据
		TopicList.DataSource = dr;
		///设置Text属性和Value属性的值
		TopicList.DataTextField = "Name";
		TopicList.DataValueField = "TopicID";
		TopicList.DataBind();
		///关闭数据源
		dr.Close();
	}
	protected void AddBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			ISubject subject = new Subject();
			///执行数据库操作
			subject.AddSubject(Name.Text.Trim(),
				Int32.Parse(ModeList.SelectedValue),
				Int32.Parse(TopicList.SelectedValue));
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
		Response.Redirect("~/SubjectManage.aspx");
	}
}
