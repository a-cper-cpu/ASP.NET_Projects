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
using System.Text;

public partial class LeavewordManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			BindLeavewordData();
		}
	}

	private void BindLeavewordData()
	{   ///获取数据
		ILeaveword word = new Leaveword();
		SqlDataReader dr = word.GetLeavewords();
		///绑定数据
		LeavewordView.DataSource = dr;
		LeavewordView.DataBind();
		///关闭数据源
		dr.Close();
	}	
	
	protected void LeavewordView_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName == "delete")
		{
			try
			{   ///删除数据
				ILeaveword word = new Leaveword();
				word.DeleteLeaveword(Int32.Parse(e.CommandArgument.ToString()));

				///重新绑定控件的数据
				BindLeavewordData();
				Response.Write("<script>alert('" + "删除数据成功，请妥善保管好你的数据！" + "');</script>");
			}
			catch(Exception ex)
			{   ///跳转到异常错误处理页面
				Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
					+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
			}
		}
	}
	protected void LeavewordView_RowDeleting(object sender,GridViewDeleteEventArgs e)
	{
		///
	}
	protected void LeavewordView_RowDataBound(object sender,GridViewRowEventArgs e)
	{
		ImageButton deleteBtn = (ImageButton)e.Row.FindControl("DeleteBtn");
		if(deleteBtn != null)
		{
			deleteBtn.Attributes.Add("onclick","return confirm('你确定要删除所选择的数据项吗？');");
		}
	}
	protected void ReplyBtn_Click(object sender,EventArgs e)
	{
		StringBuilder sb = new StringBuilder();
		foreach(GridViewRow row in LeavewordView.Rows)
		{
			CheckBox checkItem = (CheckBox)row.FindControl("CheckItem");
			if(checkItem != null)
			{
				if(checkItem.Checked == true)
				{
					sb.Append(LeavewordView.DataKeys[row.DataItemIndex].Value.ToString());
					sb.Append("|");
				}
			}
		}
		if(sb.Length < 1)
		{
			Response.Write("<script>alert('你没有选择需要回复的留言，请重新选择！');</script>");
			return;
		}
		sb.Remove(sb.Length - 1,1);
		Response.Redirect("~/AddMutilReply.aspx?LeavewordID=" + sb.ToString());
	}
}
