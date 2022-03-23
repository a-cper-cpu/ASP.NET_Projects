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

public partial class AddMutilReply : System.Web.UI.Page
{
	private static string[] leaveIdList;
	protected void Page_Load(object sender,EventArgs e)
	{   ///获取参数TopicID的值
		if(Request.Params["LeavewordID"] != null)
		{
			string leaveIdString = Request.Params["LeavewordID"].ToString();
			string split = "|";
			leaveIdList = leaveIdString.Split(split.ToCharArray());			
		}		
	}

	protected void AddBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			IReply reply = new Reply();
			IReplyLeaveword replyword = new ReplyLeaveword();

			///执行数据库操作
			int nReplyID = reply.AddReply(Body.Text);
			if(nReplyID > -1)
			{
				for(int i = 0; i < leaveIdList.Length; i++)
				{///添加回复
					replyword.AddLeavewordReply(Int32.Parse(leaveIdList[i].ToString().Trim()),nReplyID);
				}
			}
			Response.Write("<script>alert('" + "添加数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/LeavewordManage.aspx");
	}
}
