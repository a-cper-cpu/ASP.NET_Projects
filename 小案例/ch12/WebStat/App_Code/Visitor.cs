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

public interface IVisitor
{
	/// <summary>
	/// 获取所有访问记录
	/// </summary>
	/// <returns></returns>
    SqlDataReader GetVisitors();
	/// <summary>
	/// 根据年份获取访问记录
	/// </summary>
	/// <param name="dDate"></param>
	/// <returns></returns>
	SqlDataReader GetVisitorsByYear(DateTime dDate);
	/// <summary>
	/// 根据月份获取访问记录
	/// </summary>
	/// <param name="dDate"></param>
	/// <returns></returns>
	SqlDataReader GetVisitorsByMonth(DateTime dDate);
	/// <summary>
	/// 添加新的访问记录
	/// </summary>
	/// <param name="sIP"></param>
	/// <param name="sOS"></param>
	/// <param name="sBrowser"></param>
	/// <param name="sVision"></param>
	/// <param name="sLanguage"></param>
	/// <param name="bIsCookie"></param>
	/// <returns></returns>
     int AddVisitor(string sIP,string sOS,string sBrowser,string sVision,string sLanguage,
		bool bIsCookie);	
}

/// <summary>
/// 统计信息类
/// </summary>
public class VisitStat
{
	/// <summary>
	/// 统计项目的名称
	/// </summary>
	public string Name;
	/// <summary>
	/// 统计项目的数量
	/// </summary>
	public int Number;
	/// <summary>
	/// 统计项目所占百分比
	/// </summary>
	public int Percent;
}

/// <summary>
/// Visitor 的摘要说明
/// </summary>
public class Visitor:IVisitor
{
	#region IVisitor 成员

	public SqlDataReader GetVisitors()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Visitors";
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

	public SqlDataReader GetVisitorsByYear(DateTime dDate)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_GetVisitorByYear",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pDate = new SqlParameter("@Date",SqlDbType.DateTime);
		pDate.Value = dDate;
		myCommand.Parameters.Add(pDate);

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

	public SqlDataReader GetVisitorsByMonth(DateTime dDate)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_GetVisitorByMonth",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pDate = new SqlParameter("@Date",SqlDbType.DateTime);
		pDate.Value = dDate;
		myCommand.Parameters.Add(pDate);

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
	
	public int AddVisitor(string sIP,string sOS,string sBrowser,string sVision,string sLanguage,bool bIsCookie)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "INSERT INTO Visitors (IP,OS,Browser,Vision,Language,IsCookie,VisitDate)VALUES("
			+ "'" + sIP + "',"
			+ "'" + sOS + "',"
			+ "'" + sBrowser + "',"
			+ "'" + sVision + "',"
			+ "'" + sLanguage + "',"
			+ "'" + (bIsCookie == true ? 1 : 0).ToString() + "',"
			+ "GetDate()"
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

	#endregion
}
