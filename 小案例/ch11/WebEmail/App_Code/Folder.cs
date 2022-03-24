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

public interface IFolder
{
	/// <summary>
	/// 获取所有邮箱
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetFolders();
	/// <summary>
	/// 获取单个邮箱
	/// </summary>
	/// <param name="nFolderID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleFolder(int nFolderID);
	/// <summary>
	/// 新建邮箱
	/// </summary>
	/// <param name="sName"></param>
	/// <returns></returns>
	int NewFolder(string sName);
	/// <summary>
	/// 重命名邮箱
	/// </summary>
	/// <param name="nFolderID"></param>
	/// <param name="sName"></param>
	/// <returns></returns>
	int RenameFolder(int nFolderID,string sName);
	/// <summary>
	/// 删除邮箱
	/// </summary>
	/// <param name="nFolderID"></param>
	/// <returns></returns>
	int DeleteFolder(int nFolderID);
}

/// <summary>
/// Folder 的摘要说明
/// </summary>
public class Folder:IFolder
{
	#region IFolder 成员

	public SqlDataReader GetFolders()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Folders";
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

	public SqlDataReader GetSingleFolder(int nFolderID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Folders WHERE FolderID='" + nFolderID.ToString() + "'";
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

	public int NewFolder(string sName)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "INSERT INTO Folders (Name,Total,NoReader,Contain,Flag,CreateDate)VALUES("
			+ "'" + sName + "',"
			+ "'0" + "',"
			+ "'0" + "',"
			+ "'0" + "',"
			+ "'1" + "',"
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

	public int RenameFolder(int nFolderID,string sName)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "UPDATE Folders SET Name ="
			+ "'" + sName + "'"
			+ " WHERE FolderID='" + nFolderID.ToString() + "'";
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

	public int DeleteFolder(int nFolderID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "Delete Folders "
			+ " WHERE FolderID='" + nFolderID.ToString() + "'";
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
