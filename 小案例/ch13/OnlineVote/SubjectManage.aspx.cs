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

public partial class SubjectManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{   ///显示主题的数据
			BindTopicData();
			if(TopicList.Items.Count > 0)
			{
				TopicList.SelectedIndex = 0;
				///显示项目的数据
				BindSubjectData(Int32.Parse(TopicList.SelectedValue));
			}
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
	private void BindSubjectData(int nTopicID)
	{   ///获取数据
		ISubject subject = new Subject();
		SqlDataReader dr = subject.GetSubjectByTopic(nTopicID);
		///绑定数据
		SubjectView.DataSource = dr;		
		SubjectView.DataBind();
		///关闭数据源
		dr.Close();
	}

	protected void TopicList_SelectedIndexChanged(object sender,EventArgs e)
	{   ///重新绑定控件的数据
		BindSubjectData(Int32.Parse(TopicList.SelectedValue));
	}
	protected void AddBtn_Click(object sender,EventArgs e)
	{	///跳转到添加页面
		Response.Redirect("~/AddSubject.aspx");
	}
	protected void SubjectView_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName == "delete")
		{
			try
			{   ///删除数据
				ISubject subject = new Subject();
				subject.DeleteSubject(Int32.Parse(e.CommandArgument.ToString()));

				///重新绑定控件的数据
				BindSubjectData(Int32.Parse(TopicList.SelectedValue));
				Response.Write("<script>alert('" + "删除数据成功，请妥善保管好你的数据！" + "');</script>");
			}
			catch(Exception ex)
			{   ///跳转到异常错误处理页面
				Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
					+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
			}
		}
	}
	protected void SubjectView_RowDeleting(object sender,GridViewDeleteEventArgs e)
	{
		///
	}
	protected void SubjectView_RowDataBound(object sender,GridViewRowEventArgs e)
	{
		ImageButton deleteBtn = (ImageButton)e.Row.FindControl("DeleteBtn");
		if(deleteBtn != null)
		{
			deleteBtn.Attributes.Add("onclick","return confirm('你确定要删除所选择的数据项吗？');");
		}
	}
}
