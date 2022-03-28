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

public partial class Vote : System.Web.UI.Page
{
	private static string sHeadText = "";
	protected void Page_Load(object sender, EventArgs e)
    {   ///显示当前投票主题的信息
		BindSubjectData(GetCurrentTopic());
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
	private void BindItemData(RadioButtonList radioList,int nSubjectID)
	{   ///获取数据
		IItem item = new Item();
		SqlDataReader dr = item.GetItemBySubject(nSubjectID);
		///绑定数据
		radioList.DataSource = dr;
		radioList.DataTextField = "Name";
		radioList.DataValueField = "ItemID";
		radioList.DataBind();
		///关闭数据源
		dr.Close();
	}
	private void BindItemData(CheckBoxList checkList,int nSubjectID)
	{   ///获取数据
		IItem item = new Item();
		SqlDataReader dr = item.GetItemBySubject(nSubjectID);
		///绑定数据
		checkList.DataSource = dr;
		checkList.DataTextField = "Name";
		checkList.DataValueField = "ItemID";
		checkList.DataBind();
		///关闭数据源
		dr.Close();
	}

	protected void VoteView_RowDataBound(object sender,GridViewRowEventArgs e)
	{   ///找到添加控件的Panel
		Panel ItemPanel = (Panel)e.Row.FindControl("ItemPanel");
		if(ItemPanel != null)
		{   ///获取显示的模式（包括单选和多选）
			if(VoteView.DataKeys[e.Row.RowIndex].Values["Mode"].ToString().ToLower() == "false")
			{   ///单选模式
				///创建控件
				RadioButtonList radioList = new RadioButtonList();
				radioList.ID = "radioList";
				///绑定控件的数据
				BindItemData(radioList,Int32.Parse(VoteView.DataKeys[e.Row.RowIndex].Values["SubjectID"].ToString()));
				///显示控件
				ItemPanel.Controls.Add(radioList);
				if(radioList.Items.Count <= 0)
				{   ///显示“无选项”提示信息
					ItemPanel.Controls.Add(new LiteralControl("<font class=GbText color=red>没有提供选择项！</font>"));
				}
			}
			if(VoteView.DataKeys[e.Row.RowIndex].Values["Mode"].ToString().ToLower() == "true")
			{   ///多选模式
				///创建控件
				CheckBoxList checkList = new CheckBoxList();
				checkList.ID = "checkList";
				///绑定控件的数据
				BindItemData(checkList,Int32.Parse(VoteView.DataKeys[e.Row.RowIndex].Values["SubjectID"].ToString()));
				///显示控件
				ItemPanel.Controls.Add(checkList);
				if(checkList.Items.Count <= 0)
				{   ///显示“无选项”提示信息
					ItemPanel.Controls.Add(new LiteralControl("<font class=GbText color=red>没有提供选择项！</font>"));
				}
			}
		}		
	}
	protected void VoteBtn_Click(object sender,EventArgs e)
	{
		if(Session["IsRepeatVote"] != null && Session["Vote"] != null)
		{
			if(Session["IsRepeatVote"].ToString().ToLower() == "false" && Session["Vote"].ToString() == "true")
			{
				Response.Write("<script>alert('" + "您已经投票，不能重复投票！" + "');</script>");
				return;
			}
		}

		foreach(GridViewRow row in VoteView.Rows)
		{   ///找到添加控件的Panel
			Panel ItemPanel = (Panel)row.FindControl("ItemPanel");
			if(ItemPanel == null){continue;}
			///处理每一个投票项目
			IItem item = new Item();
			foreach(Control control in ItemPanel.Controls)
			{	///处理单选投票项目
				if(control is RadioButtonList)
				{	///检查被投票的选择项
					foreach(ListItem listItem in ((RadioButtonList)control).Items)
					{   ///如果被选择，则更新票数
						if(listItem.Selected == true)
						{
							try
							{   ///投票
								item.UpdateItemVoteCount(Int32.Parse(listItem.Value));
							}
							catch(Exception ex)
							{   ///跳转到异常错误处理页面
								Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
									+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
							}						
							break;
						}
					}
				}
				///处理多选投票项目
				if(control is CheckBoxList)
				{	///检查被投票的选择项
					foreach(ListItem listItem in ((CheckBoxList)control).Items)
					{   ///如果被选择，则更新票数
						if(listItem.Selected == true)
						{
							try
							{   ///投票
								item.UpdateItemVoteCount(Int32.Parse(listItem.Value));
							}
							catch(Exception ex)
							{   ///跳转到异常错误处理页面
								Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
									+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
							}
						}
					}
				}
			}
		}
		Session["Vote"] = "true";
		Response.Write("<script>alert('" + "投票成功，请妥善保管好你的数据！" + "');</script>");
	}
}
