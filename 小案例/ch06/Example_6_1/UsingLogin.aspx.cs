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

public partial class UsingLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
	protected void MyLogin_LoggingIn(object sender,LoginCancelEventArgs e)
	{
		SqlDataReader dr = GetUserLogin(MyLogin.UserName,MyLogin.Password);
		string sUserID = "";
		if(dr.Read())
		{   ///获取登录信息
			sUserID = dr["UserID"].ToString();
		}
		dr.Close();
		if(sUserID.Length > 0)
		{   ///登录成功
			Response.Redirect("~/UsingTreeView.aspx");
		}		
	}
}
