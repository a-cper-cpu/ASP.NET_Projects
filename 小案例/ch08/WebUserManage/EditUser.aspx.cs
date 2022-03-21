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

public partial class EditUser : System.Web.UI.Page
{
	private int nUserID = -1;

	protected void Page_Load(object sender,EventArgs e)
	{
		///获取参数nUserID的值
		if(Request.Params["UserID"] != null)
		{
			///获取参数nUserID的值
			if(Int32.TryParse(Request.Params["UserID"].ToString(),out nUserID) == false)
			{
				
				return;
			}
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
			Email.Text = dr["Email"].ToString();
			UserName.Text = dr["UserName"].ToString();
		}
		///关闭数据源
		dr.Close();
	}
	protected void UpdateBtn_Click(object sender,EventArgs e)
	{
		if(Page.IsValid)
		{   ///定义对象
			IUser user = new User();

			try
			{   ///更新数据
				user.UpdateUser(nUserID,Email.Text.Trim());
				Response.Write("<script>alert('" + "更新数据成功，请妥善保管好数据！" + "');</script>");
			}
			catch(Exception ex)
			{   ///跳转到异常错误处理页面
				Response.Redirect("~/ErrorPage.aspx?ErrorMsg=" + ex.Message + "&ErrorUrl=" + Request.Url.ToString());
			}
		}
	}

	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/UserManage.aspx");
	}
}
