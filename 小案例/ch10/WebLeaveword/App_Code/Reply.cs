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
/// Reply 的摘要说明
/// </summary>
public class Reply : IReply
{
	private static readonly string GETREPLYS = "SELECT * FROM Replies";
	private static readonly string GETSINGLEREPLY = "SELECT * FROM Replies WHERE ReplyID=";
	private static readonly string UPDATEREPLY = "UPDATE Replies SET Body=";
	private static readonly string DELETEREPLY = "DELETE Replies WHERE ReplyID=";

	public Reply()
	{
		///
	}

	/// <summary>
	/// 获取所有留言回复
	/// </summary>
	/// <returns></returns>
	public SqlDataReader GetReplys()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlCommand myCommand = new SqlCommand(GETREPLYS,myConnection);

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
	/// 获取单个留言回复
	/// </summary>
	/// <param name="nReplyID"></param>
	/// <returns></returns>
	public SqlDataReader GetSingleReply(int nReplyID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = GETSINGLEREPLY + "'" + nReplyID.ToString() + "'";
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
	/// 添加新的留言回复
	/// </summary>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int AddReply(string sBody)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_AddReply",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;

		///添加参数
		SqlParameter pBody = new SqlParameter("@Body",SqlDbType.Text);
		pBody.Value = sBody;
		myCommand.Parameters.Add(pBody);

		SqlParameter pReplyID = new SqlParameter("@ReplyID",SqlDbType.Int,4);
		pReplyID.Direction = ParameterDirection.ReturnValue;
		myCommand.Parameters.Add(pReplyID);

		try
		{
			///打开链接
			myConnection.Open();
			///执行SQL语句
			myCommand.ExecuteNonQuery();
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
		///返回
		return (int)myCommand.Parameters[1].Value;	
	}

	/// <summary>
	/// 修改留言回复
	/// </summary>
	/// <param name="nReplyID"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int UpdateReply(int nReplyID,string sBody)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = UPDATEREPLY
			+ "'" + sBody + "'"			
			+ " WHERE ReplyID=" + "'"
			+ nReplyID.ToString() + "'";
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
	/// 删除留言回复
	/// </summary>
	/// <param name="nReplyID"></param>
	/// <returns></returns>
	public int DeleteReply(int nReplyID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = DELETEREPLY
			+ "'" + nReplyID.ToString() + "'";
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
