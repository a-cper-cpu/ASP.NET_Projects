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

public partial class LeavewordPage : System.Web.UI.Page
{
	public String IPAddress = "";
	protected static bool IsShowReply = false;

	protected void Page_Load(object sender,System.EventArgs e)
	{
		///获取用户登录的IP地址
		IPAddress = Request.UserHostAddress;

		if(!Page.IsPostBack)
		{   ///显示数据
			BindLeavewordData();
		}
	}

	private void BindLeavewordData()
	{   ///获取留言的数据
		ILeaveword word = new Leaveword();
		SqlDataReader dr = word.GetLeavewords();
		///绑定控件数据
		LeavewordList.DataSource = dr;
		LeavewordList.DataBind();
		///关闭数据读取器
		dr.Close();
	}

	protected void SureBtn_Click(object sender,System.EventArgs e)
	{	///检测留言长度是否正确	
		if(Body.Text.Length <= 10)
		{
			Response.Write("<script>alert('留言长度不能小于10，请重新留言！');</script>");
			return;
		}

		try
		{
			ILeaveword word = new Leaveword();
			///添加新的留言
			word.AddLeaveword(Title.Text.Trim(),Body.Text.Trim());
			///重新绑定留言版的数据
			BindLeavewordData();
			Response.Write("<script>alert('留言成功，请妥善保管好你的数据！');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}

	protected String FormatBody(String sBody)
	{
		return (sBody.Replace("\n","<br>"));
	}
	protected void ShowReplyBtn_Click(object sender,EventArgs e)
	{
		IsShowReply = !IsShowReply;
		ShowReplyBtn.Text = IsShowReply ? "隐藏留言的回复" : "展开留言的回复";

		///重新绑定留言版的数据
		BindLeavewordData();		
	}
}
