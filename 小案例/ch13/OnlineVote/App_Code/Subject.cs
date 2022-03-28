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
/// Subject 的摘要说明
/// </summary>
public class Subject : ISubject
{
	private static readonly string GETSUBJECTS = "SELECT * FROM Subjects";
	private static readonly string GETSINGLESUBJECT = "SELECT * FROM Subjects WHERE SubjectID=";
	private static readonly string GETSUBJECTBYTOPIC = "SELECT * FROM Subjects WHERE TopicID=";
	private static readonly string ADDSUBJECT = "INSERT INTO Subjects(Name,Mode,TopicID)VALUES";
	private static readonly string UPDATESUBJECT = "UPDATE Subjects SET Name=";
	private static readonly string DELETESUBJECT = "DELETE Subjects WHERE SubjectID=";

	public Subject()
	{
		///
	}

	/// <summary>
	/// 获取所有投票项目信息
	/// </summary>
	/// <returns></returns>
	public SqlDataReader GetSubjects()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlCommand myCommand = new SqlCommand(GETSUBJECTS,myConnection);

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
	/// 获取投票项目的所有投票主题
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	public SqlDataReader GetSubjectByTopic(int nTopicID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = GETSUBJECTBYTOPIC + "'" + nTopicID.ToString() + "'";
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
	/// 获取单个投票项目信息
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <returns></returns>
	public SqlDataReader GetSingleSubject(int nSubjectID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = GETSINGLESUBJECT + "'" + nSubjectID.ToString() + "'";
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
	/// 添加新的投票项目
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int AddSubject(string sName,int nMode,int nTopicID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = ADDSUBJECT + "("
			+ "'" + sName + "',"
			+ "'" + nMode.ToString() + "',"
			+ "'" + nTopicID.ToString() + "'"
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
	/// 修改投票项目
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int UpdateSubject(int nSubjectID,string sName,int nMode)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = UPDATESUBJECT
			+ "'" + sName + "',"
			+ "Mode='" + nMode.ToString() + "'"
			+ " WHERE SubjectID=" + "'"
			+ nSubjectID.ToString() + "'";
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
	/// 删除投票项目
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <returns></returns>
	public int DeleteSubject(int nSubjectID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = DELETESUBJECT
			+ "'" + nSubjectID.ToString() + "'";
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
