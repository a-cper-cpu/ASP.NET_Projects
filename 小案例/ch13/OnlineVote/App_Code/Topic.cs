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
/// Topic 的摘要说明
/// </summary>
public class Topic : ITopic
{
	private static readonly string GETTOPICS = "SELECT * FROM Topics";
	private static readonly string GETCURRENTTOPIC = "SELECT * FROM Topics WHERE IsCurrent=1";
	private static readonly string GETSINGLETOPIC = "SELECT * FROM Topics WHERE TopicID=";
	private static readonly string ADDTOPIC = "INSERT INTO Topics(Name,Body,IsCurrent)VALUES";
	private static readonly string UPDATETOPIC = "UPDATE Topics SET Name=";
	private static readonly string DELETETOPIC = "DELETE Topics WHERE TopicID=";
	
	public Topic()
	{
		///
	}

	/// <summary>
	/// 获取所有投票主题信息
	/// </summary>
	/// <returns></returns>
	public SqlDataReader GetTopics()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlCommand myCommand = new SqlCommand(GETTOPICS,myConnection);

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
	/// 获取当前投票主题
	/// </summary>
	/// <returns></returns>
	public SqlDataReader GetCurrentTopic()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlCommand myCommand = new SqlCommand(GETCURRENTTOPIC,myConnection);

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
	/// 获取单个投票主题信息
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	public SqlDataReader GetSingleTopic(int nTopicID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = GETSINGLETOPIC + "'" + nTopicID.ToString() + "'";
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
	/// 添加新的投票主题
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int AddTopic(string sName,string sBody)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = ADDTOPIC + "("
			+ "'" + sName + "',"			
			+ "'" + sBody + "',"
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

	/// <summary>
	/// 修改投票主题信息
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int UpdateTopic(int nTopicID,string sName,string sBody)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = UPDATETOPIC
			+ "'" + sName + "',"
			+ "Body='" + sBody + "'"
			+ " WHERE TopicID=" + "'"
			+ nTopicID.ToString() + "'";
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
	/// 设置投票主题为当前投票主题
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	public int UpdateTopicCurrent(int nTopicID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_UpdateTopicCurrent",myConnection);
		///设置为执行存储过程
		myCommand.CommandType = CommandType.StoredProcedure;

		///添加存储过程的参数
		SqlParameter pTopicID = new SqlParameter("@TopicID",SqlDbType.Int,4);
		pTopicID.Value = nTopicID;
		myCommand.Parameters.Add(pTopicID);

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
	/// 删除投票主题
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	public int DeleteTopic(int nTopicID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = DELETETOPIC
			+ "'" + nTopicID.ToString() + "'";
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
