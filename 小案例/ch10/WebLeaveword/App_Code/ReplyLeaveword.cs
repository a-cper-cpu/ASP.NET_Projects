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
/// ReplyLeaveword的说明信息
/// </summary>
public class ReplyLeaveword : IReplyLeaveword
{
	/// <summary>
	/// 根据留言获取回复
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <returns></returns>
	public SqlDataReader GetReplyByLeaveword(int nLeavewordID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT Replies.* FROM Replies LEFT JOIN ReplyLeaveword ON Replies.ReplyID = ReplyLeaveword.ReplyID "
			+ " WHERE ReplyLeaveword.LeavewordID='" + nLeavewordID.ToString() + "'";
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
	/// 添加留言的回复
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <param name="nReplyID"></param>
	/// <returns></returns>
	public int AddLeavewordReply(int nLeavewordID,int nReplyID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		
		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_AddLeavewordReply",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;

		///添加参数
		SqlParameter pLeavewordID = new SqlParameter("@LeavewordID",SqlDbType.Int);
		pLeavewordID.Value = nLeavewordID;
		myCommand.Parameters.Add(pLeavewordID);

		SqlParameter pReplyID = new SqlParameter("@ReplyID",SqlDbType.Int,4);
		pReplyID.Value = nReplyID;
		myCommand.Parameters.Add(pReplyID);

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
	/// 删除留言的回复
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <param name="nReplyID"></param>
	/// <returns></returns>
	public int DeleteLeavewordReply(int nLeavewordID,int nReplyID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "DELETE ReplyLeaveword "
			+ " WHERE LeavewordID='" + nLeavewordID.ToString() + "' AND "
			+ " ReplyID = '" + nReplyID.ToString() + "'";
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