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

public partial class ShowVote : System.Web.UI.Page
{
	private static string sHeadText = "";
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///显示当前投票主题的信息
			BindSubjectData(GetCurrentTopic());
		}
		VoteView.HeaderRow.Cells[0].Text = sHeadText;
	}
	private int GetCurrentTopic()
	{
		ITopic topic = new Topic();
		SqlDataReader dr = topic.GetCurrentTopic();

		int nCurrentTopicID = -1;
		if(dr.Read())
		{
			nCurrentTopicID = Int32.Parse(dr["TopicID"].ToString());
			sHeadText = dr["Name"].ToString();
		}
		dr.Close();
		return (nCurrentTopicID);
	}
	private void BindSubjectData(int nTopicID)
	{   ///获取数据
		ISubject subject = new Subject();
		SqlDataReader dr = subject.GetSubjectByTopic(nTopicID);
		///绑定数据
		VoteView.DataSource = dr;
		VoteView.DataBind();
		///关闭数据源
		dr.Close();
	}
	private void BindItemData(GridView ItemView,int nSubjectID)
	{   ///获取数据
		IItem item = new Item();
		SqlDataReader dr = item.GetItemBySubject(nSubjectID);
		///绑定数据
		ItemView.DataSource = dr;
		ItemView.DataBind();
		///关闭数据源
		dr.Close();
	}
	protected void VoteView_RowDataBound(object sender,GridViewRowEventArgs e)
	{
		GridView voteInofView = (GridView)e.Row.FindControl("VoteInfoView");
		if(voteInofView != null)
		{
			BindItemData(voteInofView,Int32.Parse(VoteView.DataKeys[e.Row.RowIndex].Value.ToString()));
		}
	}
}
