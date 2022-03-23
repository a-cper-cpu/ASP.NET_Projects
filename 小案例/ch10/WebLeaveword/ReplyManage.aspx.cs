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

public partial class ReplyManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{   ///显示留言的数据
			BindLeavewordData();
			if(LeavewordList.Items.Count > 0)
			{
				LeavewordList.SelectedIndex = 0;
				///显示回复的数据
				BindReplyData(Int32.Parse(LeavewordList.SelectedValue));
			}
		}	
	}
	private void BindLeavewordData()
	{   ///获取数据
		ILeaveword word = new Leaveword();
		SqlDataReader dr = word.GetLeavewords();
		///绑定数据
		///绑定数据
		LeavewordList.DataSource = dr;
		///设置Text属性和Value属性的值
		LeavewordList.DataTextField = "Title";
		LeavewordList.DataValueField = "LeavewordID";
		LeavewordList.DataBind();
		///关闭数据源
		dr.Close();
	}	
	private void BindReplyData(int nLeavewordID)
	{   ///获取数据
		IReplyLeaveword replyword = new ReplyLeaveword();
		SqlDataReader dr = replyword.GetReplyByLeaveword(nLeavewordID);
		///绑定数据
		ReplyView.DataSource = dr;
		ReplyView.DataBind();
		///关闭数据源
		dr.Close();
	}

	protected void ReplyView_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName == "delete")
		{
			try
			{   ///删除数据
				IReply reply = new Reply();
				reply.DeleteReply(Int32.Parse(e.CommandArgument.ToString()));

				///重新绑定控件的数据
				BindReplyData(Int32.Parse(LeavewordList.SelectedValue));
				Response.Write("<script>alert('" + "删除数据成功，请妥善保管好你的数据！" + "');</script>");
			}
			catch(Exception ex)
			{   ///跳转到异常错误处理页面
				Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
					+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
			}
		}
	}
	protected void ReplyView_RowDeleting(object sender,GridViewDeleteEventArgs e)
	{
		///
	}
	protected void ReplyView_RowDataBound(object sender,GridViewRowEventArgs e)
	{
		ImageButton deleteBtn = (ImageButton)e.Row.FindControl("DeleteBtn");
		if(deleteBtn != null)
		{
			deleteBtn.Attributes.Add("onclick","return confirm('你确定要删除所选择的数据项吗？');");
		}
	}
	protected void LeavewordList_SelectedIndexChanged(object sender,EventArgs e)
	{
		///显示回复的数据
		BindReplyData(Int32.Parse(LeavewordList.SelectedValue));
	}
}
