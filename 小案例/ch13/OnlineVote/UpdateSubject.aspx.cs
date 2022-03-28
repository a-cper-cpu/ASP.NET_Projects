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

public partial class UpdateSubject : System.Web.UI.Page
{
	private int nSubjectID = -1;
    protected void Page_Load(object sender, EventArgs e)
	{   ///获取参数TopicID的值
		if(Request.Params["SubjectID"] != null)
		{
			if(Int32.TryParse(Request.Params["SubjectID"].ToString(),out nSubjectID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{   ///显示数据
			BindTopicData();
			if(nSubjectID > -1)
			{
				BindSubjectData(nSubjectID);
			}
		}		
		UpdateBtn.Enabled = TopicList.Items.Count > 0 ? true : false;
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
	private void BindSubjectData(int nSubjectID)
	{   ///获取数据
		ISubject subject = new Subject();
		SqlDataReader dr = subject.GetSingleSubject(nSubjectID);
		///读取数据
		if(dr.Read())
		{
			Name.Text = dr["Name"].ToString();
			///设置列表的选择项
			SystemTools.SetListBoxItem(TopicList,dr["TopicID"].ToString());
			SystemTools.SetListBoxItem(ModeList,dr["Mode"].ToString(),true);
		}
		///关闭数据源
		dr.Close();
	}
	protected void UpdateBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			ISubject subject = new Subject();
			///执行数据库操作
			subject.UpdateSubject(nSubjectID,Name.Text.Trim(),Int32.Parse(ModeList.SelectedValue));
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
		Response.Redirect("~/SubjectManage.aspx");
	}
}
