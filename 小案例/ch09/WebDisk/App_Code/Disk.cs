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

public interface IDisk
{
	/// <summary>
	/// 目录的接口设计
	/// </summary>
	SqlDataReader GetAllDirectoryFile();
	/// <summary>
	/// 获取子目录和文件信息
	/// </summary>
	/// <param name="nParentID"></param>
	/// <returns></returns> 
	SqlDataReader GetDirectoryFile(int nParentID);
	/// <summary>
	/// 获取所有目录信息
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetDirectorys();

	/// <summary>
	/// 获取子目录信息
	/// </summary>
	/// <param name="nParentID"></param>
	/// <returns></returns> 
	SqlDataReader GetDirectory(int nParentID);
	/// <summary>
	/// 获取单个目录信息
	/// </summary>
	/// <param name="nDirID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleDirectory(int nDirID);
	/// <summary>
	/// 新建一个目录
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="nParentID"></param>
	/// <returns></returns>
	int AddDirectory(string sName,int nParentID);
	/// <summary>
	/// 重命名目录
	/// </summary>
	/// <param name="nDirID"></param>
	/// <param name="sName"></param>
	/// <returns></returns>
	int EditDirectory(int nDirID,string sName);
	/// <summary>
	/// 删除一个目录
	/// </summary>
	/// <param name="nDirID"></param>
	/// <returns></returns>
	int DeleteDirectory(int nDirID);
	/// <summary>
	/// 移动一个目录
	/// </summary>
	/// <param name="nDirID"></param>
	/// <param name="nParentID"></param>
	/// <returns></returns>
	int MoveDirectory(int nDirID,int nParentID);

	/// <summary>
	/// 获取所有文件
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetFiles();
	/// <summary>
	/// 获取给定目录下的所有文件
	/// </summary>
	/// <param name="nParentID"></param>
	/// <returns></returns>
	SqlDataReader GetFile(int nParentID);
	/// <summary>
	/// 获取单个文件
	/// </summary>
	/// <param name="nFileID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleFile(int nFileID);
	/// <summary>
	/// 上载一个文件
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="nParentID"></param>
	/// <param name="nContain"></param>
	/// <param name="sUrl"></param>
	/// <param name="sType"></param>
	/// <returns></returns>
	int AddFile(string sName,int nParentID,int nContain,string sUrl,string sType);
	/// <summary>
	/// 修改文件的名称
	/// </summary>
	/// <param name="nFileID"></param>
	/// <param name="sName"></param>
	/// <returns></returns>
	int EditFile(int nFileID,string sName);
	/// <summary>
	/// 删除一个文件
	/// </summary>
	/// <param name="nFileID"></param>
	/// <returns></returns>
	int DeleteFile(int nFileID);
	/// <summary>
	/// 移动文件
	/// </summary>
	/// <param name="nFileID"></param>
	/// <param name="nParentID"></param>
	/// <returns></returns>
	int MoveFile(int nFileID,int nParentID);

	/// <summary>
	/// 搜索文件
	/// </summary>
	/// <param name="sKey"></param>
	/// <returns></returns>
	SqlDataReader SearchFiles(string sKey);
}

/// <summary>
/// Disk 的摘要说明
/// </summary>
public class Disk : IDisk
{
	public void ShowDirectory(DropDownList dirList,int nParentID)
	{
		DataTable dataTable = SystemTools.ConvertDataReaderToDataTable(GetDirectorys());
		dirList.Items.Clear();     ///清空所有节点

		DataRow[] rowList = dataTable.Select("ParentID='-1'");
		if(rowList.Length <= 0) return;

		///创建、添加根节点
		dirList.Items.Add(new ListItem("/",rowList[0]["DirID"].ToString()));

		///创建其他节点
		CreateChildNode(dirList,dataTable,Int32.Parse(rowList[0]["DirID"].ToString()),"/");
	}

	private void CreateChildNode(DropDownList dirList,DataTable dataTable,int nParentID,string sParentName)
	{		
		///选择数据时，添加了排序表达式OrderBy
		DataRow[] rowList = dataTable.Select("ParentID='" + nParentID.ToString() + "'","CreateDate DESC");
		foreach(DataRow row in rowList)
		{
			string sName = sParentName + row["Name"].ToString() + "/";
			///创建新节点
			dirList.Items.Add(new ListItem(sName,row["DirID"].ToString()));

			///递归调用，创建其他节点
			CreateChildNode(dirList,dataTable,Int32.Parse(row["DirID"].ToString()),sName);
		}
	}

	#region IDisk 成员
	public SqlDataReader GetAllDirectoryFile()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Directory";
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

	public SqlDataReader GetDirectorys()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Directory WHERE Flag='1'";
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

	public SqlDataReader GetFiles()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Directory WHERE Flag='0'";
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

	public SqlDataReader GetDirectoryFile(int nParentID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT Directory.*,Url.Url,Url.Type "
			+ "FROM Directory Left JOIN Url ON Directory.DirID = Url.DirID "
			+  "WHERE ParentID='" + nParentID.ToString() + "'";
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

	public SqlDataReader GetDirectory(int nParentID)
	{		
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		
		///定义SQL语句
		string cmdText = "SELECT * FROM Directory WHERE Flag='1' AND ParentID='" + nParentID.ToString() + "'";
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

	public SqlDataReader GetSingleDirectory(int nDirID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Directory WHERE DirID='" + nDirID.ToString() + "'";
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

	public int AddDirectory(string sName,int nParentID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "INSERT INTO Directory (Name,ParentID,Contain,DirCount,FileCount,Flag,CreateDate)VALUES("
			+ "'" + sName + "',"
			+ "'" + nParentID.ToString() + "',"
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
			///修改目录的数量
			cmdText = "UPDATE Directory SET DirCount = DirCount + 1 WHERE DirID='" + nParentID.ToString() + "'";
			myCommand.CommandText = cmdText;
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

	public int EditDirectory(int nDirID,string sName)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "UPDATE Directory SET Name ="
			+ "'" + sName + "'"
			+ " WHERE DirID='" + nDirID.ToString() + "'";			
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

	public int DeleteDirectory(int nDirID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义返回值
		int nResult = -1;
		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_DeleteDirectory",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pDirID = new SqlParameter("@DirID",SqlDbType.Int,4);
		pDirID.Value = nDirID;
		myCommand.Parameters.Add(pDirID);	

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

	public int MoveDirectory(int nDirID,int nParentID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义返回值
		int nResult = -1;

		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_MoveDirectory",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pDirID = new SqlParameter("@DirID",SqlDbType.Int,4);
		pDirID.Value = nDirID;
		myCommand.Parameters.Add(pDirID);
		SqlParameter pParentID = new SqlParameter("@ParentID",SqlDbType.Int,4);
		pParentID.Value = nParentID;
		myCommand.Parameters.Add(pParentID);

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

	public SqlDataReader GetFile(int nParentID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT Directory.*,Url.Url,Url.Type "
			+ "FROM Directory Left JOIN Url ON Directory.DirID = Url.DirID "
			+ "WHERE Flag='0' AND ParentID='" + nParentID.ToString() + "'";
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

	public SqlDataReader GetSingleFile(int nFileID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT Directory.*,Url.Url,Url.Type "
			+ "FROM Directory Left JOIN Url ON Directory.DirID = Url.DirID WHERE Directory.DirID='"
			+ nFileID.ToString() + "'";
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

	public int AddFile(string sName,int nParentID,int nContain,string sUrl,string sType)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		/////定义SQL语句
		//string cmdText = "INSERT INTO Directory (Name,ParentID,Contain,DirCount,FileCount,Flag,CreateDate)VALUES("
		//    + "'" + sName + "',"
		//    + "'" + nParentID.ToString() + "',"
		//    + "'" + nContain.ToString() + "',"
		//    + "'0" + "',"
		//    + "'0" + "',"
		//    + "'0" + "',"
		//    + "GetDate()"
		//    + ")";
		/////创建Command
		//SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		/////定义返回值
		//int nResult = -1;

		//try
		//{
		//    ///打开链接
		//    myConnection.Open();
		//    ///执行SQL语句
		//    nResult = myCommand.ExecuteNonQuery();
		//    if(nResult > -1)
		//    {   ///添加文件属性的SQL语句
		//        cmdText = "INSERT INTO Url (Url,Type,DirID,CreateDate)VALUES("
		//            + "'" + sUrl + "',"
		//            + "'" + sType + "',"
		//            + "'" + nResult.ToString() + "',"
		//            + "GetDate()"
		//            + ")";
		//        ///执行上载文件
		//        myCommand.CommandText = cmdText;
		//        nResult = myCommand.ExecuteNonQuery();
		//    }
		//    else
		//    {   ///删除已经创建的文件
		//        DeleteDirectory(nResult);
		//    }
		//}
		SqlCommand myCommand = new SqlCommand("Pr_AddFile",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pName = new SqlParameter("@Name",SqlDbType.VarChar,200);
		pName.Value = sName;
		myCommand.Parameters.Add(pName);		
		SqlParameter pParentID = new SqlParameter("@ParentID",SqlDbType.Int,4);
		pParentID.Value = nParentID;
		myCommand.Parameters.Add(pParentID);		
		SqlParameter pContain = new SqlParameter("@Contain",SqlDbType.Int,4);
		pContain.Value = nContain;
		myCommand.Parameters.Add(pContain);
		SqlParameter pUrl = new SqlParameter("@Url",SqlDbType.VarChar,255);
		pUrl.Value = sUrl;
		myCommand.Parameters.Add(pUrl);
		SqlParameter pType = new SqlParameter("@Type",SqlDbType.VarChar,200);
		pType.Value = sType;
		myCommand.Parameters.Add(pType);

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

	public int EditFile(int nFileID,string sName)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "UPDATE Directory SET Name ="
			+ "'" + sName + "'"
			+ " WHERE DirID='" + nFileID.ToString() + "'";
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

	public int DeleteFile(int nFileID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		
		///定义返回值
		int nResult = -1;

		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_DeleteFile",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pDirID = new SqlParameter("@DirID",SqlDbType.Int,4);
		pDirID.Value = nFileID;
		myCommand.Parameters.Add(pDirID);		

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

	public int MoveFile(int nFileID,int nParentID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义返回值
		int nResult = -1;

		///创建Command
		SqlCommand myCommand = new SqlCommand("Pr_MoveFile",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pDirID = new SqlParameter("@DirID",SqlDbType.Int,4);
		pDirID.Value = nFileID;
		myCommand.Parameters.Add(pDirID);
		SqlParameter pParentID = new SqlParameter("@ParentID",SqlDbType.Int,4);
		pParentID.Value = nParentID;
		myCommand.Parameters.Add(pParentID);

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

	public SqlDataReader SearchFiles(string sKey)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT Directory.*,Url.Url,Url.Type "
			+ "FROM Directory Left JOIN Url ON Directory.DirID = Url.DirID WHERE Flag = '0' AND Name like '%"
			+ sKey + "%' ORDER BY Directory.CREATEDATE DESC";
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

	#endregion
}
