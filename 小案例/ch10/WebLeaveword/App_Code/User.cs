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

public interface IUser
{
	/// <summary>
	/// 使用存储过程实现用户登录
	/// </summary>
	/// <param name="sUserName"></param>
	/// <param name="sPassword"></param>
	/// <returns></returns>
	SqlDataReader GetUserLogin(string sUserName,string sPassword);

	/// <summary>
	/// 获取所有用户信息
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetUsers();

	/// <summary>
	/// 获取单个用户信息
	/// </summary>
	/// <param name="nUserID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleUser(int nUserID);

	/// <summary>
	/// 注册一个新用户
	/// </summary>
	/// <param name="sUserName"></param>
	/// <param name="sPassword"></param>
	/// <param name="sEmail"></param>
	/// <returns></returns>
	int AddUser(string sUserName,string sPassword,string sEmail);

	/// <summary>
	/// 修改用户的信息
	/// </summary>
	/// <param name="nUserID"></param>
	/// <param name="sEmail"></param>
	/// <returns></returns>
	int UpdateUser(int nUserID,string sEmail);

	/// <summary>
	/// 修改用户密码
	/// </summary>
	/// <param name="nUserID"></param>
	/// <param name="sPassword"></param>
	/// <returns></returns>
	int UpdateUserPwd(int nUserID,string sPassword);	

	/// <summary>
	/// 删除用户
	/// </summary>
	/// <param name="nUserID"></param>
	/// <returns></returns>
	int DeleteUser(int nUserID);
}

/// <summary>
/// User 的摘要说明
/// </summary>
public class User : IUser
{
	private static readonly string GETUSERS = "SELECT * FROM Users";
	private static readonly string GETSINGLEUSER = "SELECT * FROM Users WHERE UserID=";
	private static readonly string ADDUSER = "INSERT INTO Users(UserName,Password,Email,IsAdmin)VALUES";
	private static readonly string UPDATEUSER = "UPDATE Users SET Email=";
	private static readonly string UPDATEUSERADMIN = "UPDATE Users SET IsAdmin=";
	private static readonly string UPDATEUSERPASSWORD = "UPDATE Users SET Password=";
	private static readonly string DELETEUSER = "DELETE Users WHERE UserID=";
	private static readonly string GETUSERLOGINBYSQL = "SELECT UserID FROM Users WHERE UserName =";
	
	public User()
	{
		///
	}

	public SqlDataReader GetUserLogin(string sUserName,string sPassword)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_GetUserLogin",myConnection);
		///设置为执行存储过程
		myCommand.CommandType = CommandType.StoredProcedure;

		///添加存储过程的参数
		SqlParameter pUserName = new SqlParameter("@UserName",SqlDbType.VarChar,200);
		pUserName.Value = sUserName;
		myCommand.Parameters.Add(pUserName);

		SqlParameter pPassword = new SqlParameter("@Password",SqlDbType.VarChar,255);
		pPassword.Value = sPassword;
		myCommand.Parameters.Add(pPassword);

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

	public SqlDataReader GetUsers()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlCommand myCommand = new SqlCommand(GETUSERS,myConnection);

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

	public SqlDataReader GetSingleUser(int nUserID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		
		///定义SQL语句
		string cmdText = GETSINGLEUSER + "'" + nUserID.ToString() + "'";
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

	public int AddUser(string sUserName,string sPassword,string sEmail)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = ADDUSER + "("
			+ "'" + sUserName + "',"
			+ "'" + sPassword + "',"
		    + "'" + sEmail + "',"
			+ "'0'"
			+ ")";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		///定义返回值
		int nResult = -1;

		try
		{
			///打开链接
			myConnection.Open();
			///执行SQL语句
			nResult = myCommand.ExecuteNonQuery();
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		finally
		{   ///关闭链接
			myConnection.Close();
		}
		///返回nResult
		return nResult;
	}

	public int UpdateUser(int nUserID,string sEmail)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = UPDATEUSER
			+ "'" + sEmail + "'"
			+ " WHERE UserID=" + "'"
			+ nUserID.ToString() + "'";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		///定义返回值
		int nResult = -1;

		try
		{
			///打开链接
			myConnection.Open();
			///执行SQL语句
			nResult = myCommand.ExecuteNonQuery();
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		finally
		{   ///关闭链接
			myConnection.Close();
		}
		///返回nResult
		return nResult;
	}

	public int UpdateUserPwd(int nUserID,string sPassword)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = UPDATEUSERPASSWORD
			+ "'" + sPassword + "'"
			+ " WHERE UserID=" + "'"
			+ nUserID.ToString() + "'";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		///定义返回值
		int nResult = -1;

		try
		{
			///打开链接
			myConnection.Open();
			///执行SQL语句
			nResult = myCommand.ExecuteNonQuery();
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		finally
		{   ///关闭链接
			myConnection.Close();
		}
		///返回nResult
		return nResult;
	}

	public int UpdateUserAdmin(int nUserID,bool bIsAdmin)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = UPDATEUSERADMIN
			+ "'" + (bIsAdmin ? 1 : 0).ToString() + "'"
			+ " WHERE UserID=" + "'"
			+ nUserID.ToString() + "'";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		///定义返回值
		int nResult = -1;

		try
		{
			///打开链接
			myConnection.Open();
			///执行SQL语句
			nResult = myCommand.ExecuteNonQuery();
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		finally
		{   ///关闭链接
			myConnection.Close();
		}
		///返回nResult
		return nResult;
	}

	public int DeleteUser(int nUserID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = DELETEUSER
			+ "'" + nUserID.ToString() + "'";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		///定义返回值
		int nResult = -1;

		try
		{
			///打开链接
			myConnection.Open();
			///执行SQL语句
			nResult = myCommand.ExecuteNonQuery();
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		finally
		{   ///关闭链接
			myConnection.Close();
		}
		///返回nResult
		return nResult;
	}
}
