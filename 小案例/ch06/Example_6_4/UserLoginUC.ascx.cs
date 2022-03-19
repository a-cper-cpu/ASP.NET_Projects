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

public partial class UserLoginUC : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void LoginBtn_Click1(object sender,EventArgs e)
	{

		if(UserName.Text == null || UserName.Text == "" || UserName.Text.Length <= 0)
		{
			ShowMessage("用户名称为空，请输入用户名称！");
			return;
		}

		if(Password.Text == null || Password.Text == "" || Password.Text.Length <= 0)
		{
			ShowMessage("用户密码为空，请输入用户密码！");
			return;
		}

		String userId = "";

		///定义类并获取用户的登陆信息            
		SqlDataReader recu = GetUserLogin(UserName.Text.Trim(),Password.Text.Trim());

		///判断用户是否合法
		if(recu.Read())
		{
			userId = recu["UserID"].ToString();
		}
		recu.Close();

		///验证用户合法性，并跳转到系统平台
		if((userId != null) && (userId != ""))
		{
			Session["UserID"] = userId;

			//显示登录之后的消息
			ShowMessage("用用户登录成功！！！");
		}
		else
		{
			///显示错误信息
			ShowMessage("你输入的用户名称/密码有误，请重新输入！");
		}
	}

	private void ShowMessage(string sMsg)
	{
		///显示操作结果信息
		Response.Write("<script>window.alert('" + sMsg + "')</script>");
	}

	public SqlDataReader GetUserLogin(string sUserName,string sPassword)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT UserID FROM Users WHERE UserName ="
			+ "'" + sUserName.ToString() + "'"
			+ " AND Password ="
			+ "'" + sPassword.ToString() + "'";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		///定义DataReader
		SqlDataReader dr = null;
		try
		{
			///打开链接
			myConnection.Open();
			///读取数据
			dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		///返回DataReader
		return dr;
	}

}
