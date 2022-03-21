using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class UserManage : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			BindUserData();
		}
    }

	private void BindUserData()
	{
		///获取用户数据
		IUser user = new User();
		SqlDataReader dr = user.GetUsers();

		///设置GridView的数据源，并绑定数据
		UserView.DataSource = dr;
		UserView.DataBind();

		///关闭数据读取器
		dr.Close();
	}
	protected void UserView_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		///获取参数
		string commandName = e.CommandName;		
		int nUserID = -1;
		if(Int32.TryParse(e.CommandArgument.ToString(),out nUserID) == false || commandName == "")
		{
			return;
		}
		///创建User实例
		IUser user = new User();
		switch(commandName)
		{
			case "delete":
				{
					///删除选择的用户
					user.DeleteUser(nUserID);

					///重新绑定GridView的数据
					Response.Write("<script>alert('" + "删除用户成功，请检查数据库是否吻合！！！" + "');</script>");
					BindUserData();
					break;
				}
			case "admin":
				{   ///管理员的权限设置
					Button button = (Button)e.CommandSource;
					if(button == null)
					{
						break;
					}
					user.UpdateUserAdmin(nUserID,button.Text == "取消管理员权限" ? false : true);

					///重新绑定GridView的数据
					Response.Write("<script>alert('" + "设置管理员权限成功，请检查数据库是否吻合！！！" + "');</script>");
					BindUserData();
					break;
				}
			default:
				break;
		}
	}
	protected void UserView_RowDeleting(object sender,GridViewDeleteEventArgs e)
	{
		///
	}
	protected void AddBtn_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/AddUser.aspx");
	}	
}
