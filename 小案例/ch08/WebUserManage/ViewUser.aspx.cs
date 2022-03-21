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

public partial class ViewUser : System.Web.UI.Page
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
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/UserManage.aspx");
	}
}
