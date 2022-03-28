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

public class ItemInformation
{
	public string VoteCount;
	public string SumVoteCount;
	public string Name;
}

/// <summary>
/// Item 的摘要说明
/// </summary>
public class Item : IItem
{
	private static readonly string GETITEMS = "SELECT * FROM Items";
	private static readonly string GETSINGLEITEM = "SELECT Items.*,Subjects.Name AS SubjectName "
		+ "FROM Items INNER JOIN Subjects ON Items.SubjectID = Subjects.SubjectID "
		+ "WHERE ItemID=";
	private static readonly string GETITEMBYTOPIC = "SELECT * FROM Items"
		+ " INNER JOIN Subjects ON Items.SubjectID = Subjects.SubjectID WHERE Subjects.TopicID=";
	private static readonly string GETITEMBYSUBJECT = "SELECT * FROM Items WHERE SubjectID=";
	private static readonly string ADDITEM = "INSERT INTO Items(Name,SubjectID,VoteCount)VALUES";
	private static readonly string UPDATEITEM = "UPDATE Items SET Name=";
	private static readonly string DELETEITEM = "DELETE Items WHERE ItemID=";

	public Item()
	{
		/// 
	}

	/// <summary>
	/// 获取所有选择项信息
	/// </summary>
	/// <returns></returns>
	public SqlDataReader GetItems()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlCommand myCommand = new SqlCommand(GETITEMS,myConnection);

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
	/// 获取投票主题的所有选择项
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	public SqlDataReader GetItemByTopic(int nTopicID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = GETITEMBYTOPIC + "'" + nTopicID.ToString() + "'";
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
	/// 获取投票项目的所有选择项
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <returns></returns>
	public SqlDataReader GetItemBySubject(int nSubjectID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = GETITEMBYSUBJECT + "'" + nSubjectID.ToString() + "'";
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
	/// 获取投票项目的所有选择项的票的总数
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <returns></returns>
	public SqlDataReader GetItemVoteCountBySubject(int nSubjectID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT SUM(VoteCount) AS SumVoteCount FROM Items WHERE SubjectID='"
			+ nSubjectID.ToString() + "'";
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
	/// 获取单个选择项信息
	/// </summary>
	/// <param name="nItemID"></param>
	/// <returns></returns>
	public SqlDataReader GetSingleItem(int nItemID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = GETSINGLEITEM + "'" + nItemID.ToString() + "'";
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
	/// 添加新的选择项
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int AddItem(string sName,int nSubjectID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = ADDITEM + "("
			+ "'" + sName + "',"
			+ "'" + nSubjectID.ToString() + "',"
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
	/// 修改选择项信息
	/// </summary>
	/// <param name="nItemID"></param>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	public int UpdateItem(int nItemID,string sName)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = UPDATEITEM
			+ "'" + sName + "'"			
			+ " WHERE ItemID=" + "'"
			+ nItemID.ToString() + "'";
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
	/// 增加一票
	/// </summary>
	/// <param name="nItemID"></param>
	/// <returns></returns>
	public int UpdateItemVoteCount(int nItemID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_UpdateItemVoteCount",myConnection);
		///设置为执行存储过程
		myCommand.CommandType = CommandType.StoredProcedure;

		///添加存储过程的参数
		SqlParameter pItemID = new SqlParameter("@ItemID",SqlDbType.Int,4);
		pItemID.Value = nItemID;
		myCommand.Parameters.Add(pItemID);

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
	/// 删除选择项
	/// </summary>
	/// <param name="nItemID"></param>
	/// <returns></returns>
	public int DeleteItem(int nItemID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = DELETEITEM
			+ "'" + nItemID.ToString() + "'";
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
