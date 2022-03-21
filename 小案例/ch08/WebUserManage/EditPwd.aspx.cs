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

public partial class EditPwd : System.Web.UI.Page
{
	private int nUserID = -1;

	protected void Page_Load(object sender,EventArgs e)
	{
		///获取参数nUserID的值
		if(Session["UserID"] != null)
		{
			///获取参数nUserID的值
			if(Int32.TryParse(Session["UserID"].ToString(),out nUserID) == false)
			{
				return;
			}
		}
		else
		{
			Response.Redirect("~/Default.aspx");
		}
		if(!Page.IsPostBack)
		{   ///判断参数是否正确
			if(nUserID > -1)
			{   ///从数据库中读取数据，并显示
				BindUserData(nUserID);
			}
			else
			{
				UpdateBtn.Enabled = false;
			}
		}
	}

	private void BindUserData(int nUserID)
	{
		///获取数据
		IUser user = new User();
		SqlDataReader dr = user.GetSingleUser(nUserID);

		if(dr.Read())
		{   ///读取数据
			UserName.Text = dr["UserName"].ToString();
		}
		///关闭数据源
		dr.Close();
	}

	protected void UpdateBtn_Click(object sender,EventArgs e)
	{   ///获取用户数据
		IUser user = new User();
		///SqlDataReader dr = user.GetUserLoginByProc(UserName.Text.Trim(),OldPassword.Text.Trim());
		///2006.12.7 zhengyd修改了该行程序代码：
		SqlDataReader dr = user.GetUserLoginByProc(UserName.Text.Trim(),user.Encrypt(OldPassword.Text.Trim()));

		///读取UserID的值
		string sUserID = "";
		if(dr.Read())
		{
			sUserID = dr["UserID"].ToString();
		}
		///关闭数据源
		dr.Close();

		///判断用户输入的旧密码是否正确
		if(sUserID == null || sUserID == "" || sUserID.Length < 0)
		{
			Response.Write("<script>alert('" + "旧密码输入错误，请重新输入密码！" + "');</script>");
			return;
		}

		try
		{   ///修改用户密码
			///user.UpdateUserPwd(nUserID,NewPassword.Text.Trim());
            
            ///2006.12.7 zhengyd修改了该行程序代码：
            user.UpdateUserPwd(nUserID,user.Encrypt(NewPassword.Text.Trim()));
           	Response.Write("<script>alert('" + "修改密码成功，请妥善保管好数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("~/ErrorPage.aspx?ErrorMsg=" + ex.Message + "&ErrorUrl=" + Request.Url.ToString());
		}
	}

	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/UserManage.aspx");
	}
}
