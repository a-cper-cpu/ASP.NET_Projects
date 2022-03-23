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

/// <summary>
/// Leaveword 的摘要说明
/// </summary>
public class Leaveword : ILeaveword
{
	private static readonly string GETLEAVEWORDS = "SELECT Leavewords.*,Replies.Body AS ReplyBody FROM Leavewords "
		+ "LEFT JOIN ReplyLeaveword ON Leavewords.LeavewordID = ReplyLeaveword.LeavewordID "
		+ "LEFT JOIN Replies ON Replies.ReplyID = ReplyLeaveword.ReplyID "
		+ " ORDER BY Leavewords.CreateTime DESC";
	private static readonly string GETSINGLELEAVEWORD = "SELECT * FROM Leavewords WHERE LeavewordID=";
	private static readonly string ADDLEAVEWORD = "INSERT INTO Leavewords(Title,Body,CreateTime)VALUES";
	private static readonly string UPDATELEAVEWORD = "UPDATE Leavewords SET Title=";
	private static readonly string DELETELEAVEWORD = "DELETE Leavewords WHERE LeavewordID=";
	
	public Leaveword()
	{
		///
	}

	/// <summary>
	/// 获取所有留言
	/// </summary>
	/// <returns></returns>
	public SqlDataReader GetLeavewords()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlCommand myCommand = new SqlCommand(GETLEAVEWORDS,myConnection);

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

	/// <summary>
	/// 获取单个留言
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <returns></returns>
	public SqlDataReader GetSingleLeaveword(int nLeavewordID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = GETSINGLELEAVEWORD + "'" + nLeavewordID.ToString() + "'";
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

	/// <summary>
	/// 添加新的留言
	/// </summary>
	/// <param name="sTitle"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int AddLeaveword(string sTitle,string sBody)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = ADDLEAVEWORD + "("
			+ "'" + sTitle + "',"			
			+ "'" + sBody + "',"
			+ "GETDATE()"
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

	/// <summary>
	/// 修改留言
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <param name="sTitle"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int UpdateLeaveword(int nLeavewordID,string sTitle,string sBody)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = UPDATELEAVEWORD
			+ "'" + sTitle + "',"
			+ "Body='" + sBody + "'"
			+ " WHERE LeavewordID=" + "'"
			+ nLeavewordID.ToString() + "'";
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
	
	/// <summary>
	/// 删除留言
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <returns></returns>
	public int DeleteLeaveword(int nLeavewordID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = DELETELEAVEWORD
			+ "'" + nLeavewordID.ToString() + "'";
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
