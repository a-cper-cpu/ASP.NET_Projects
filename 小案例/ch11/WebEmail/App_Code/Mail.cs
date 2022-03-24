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
using System.Net.Mail;

public class WebMailProfile
{
	public string UserName;
	public string AliasName;
	public string Email;
	public string MailServerIP;
	public int MailServerPort;
}

public interface IMail
{
	/// <summary>
	/// 获取系统配置信息
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetWebMailProfile();
	/// <summary>
	/// 修改系统的配置信息
	/// </summary>
	/// <param name="sUserName"></param>
	/// <param name="sAliasName"></param>
	/// <param name="sEmail"></param>
	/// <param name="sMailServerIP"></param>
	/// <param name="nMailServerPort"></param>
	/// <returns></returns>
	int WebMailProfile(string sUserName,string sAliasName,string sEmail,string sMailServerIP,
		int nMailServerPort);

	/// <summary>
	/// 获取所有邮件
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetMails();
	/// <summary>
	/// 获取某个邮箱的邮件
	/// </summary>
	/// <param name="nFolderID"></param>
	/// <returns></returns>
	SqlDataReader GetMailsByFloder(int nFolderID);
	/// <summary>
	/// 获取单个邮件的记录
	/// </summary>
	/// <param name="nMailID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleMail(int nMailID);

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <returns></returns>
	int SenderMail(MailMessage mail);	

	/// <summary>
	/// 添加发送的邮件到邮件箱中
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <param name="sFrom"></param>
	/// <param name="sTo"></param>
	/// <param name="sCC"></param>
	/// <param name="bHtmlFormat"></param>
	/// <param name="nContain"></param>
	/// <param name="bAttachmentFlag"></param>
	/// <returns></returns>
	int SaveAsMail(string sName,string sBody,string sFrom,string sTo,
		string sCC,bool bHtmlFormat,int nContain,bool bAttachmentFlag);
	
	/// <summary>
	/// 添加邮件的附件
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="sUrl"></param>
	/// <param name="sType"></param>
	/// <param name="nContain"></param>
	/// <param name="MailID"></param>
	/// <returns></returns>
	int SaveAsMailAttachment(string sName,string sUrl,string sType,
		int nContain,int nMailID);
	/// <summary>
	/// 移动邮件
	/// </summary>
	/// <param name="nMailID"></param>
	/// <param name="nFolderID"></param>
	/// <returns></returns>
	int MoveMail(int nMailID,int nFolderID);
	/// <summary>
	/// 删除邮件
	/// </summary>
	/// <param name="nMailID"></param>
	/// <returns></returns>
	int DeleteMail(int nMailID);
	/// <summary>
	/// 获取邮件的附件
	/// </summary>
	/// <param name="nMailID"></param>
	/// <returns></returns>
	SqlDataReader GetAttachmentsByMail(int nMailID);
}

/// <summary>
/// Mail 的摘要说明
/// </summary>
public class Mail:IMail
{
	#region IMail 成员

	public SqlDataReader GetWebMailProfile()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM WebMailProfile WHERE WebMailID = 1";
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

	public int WebMailProfile(string sUserName,string sAliasName,string sEmail,string sMailServerIP,
		int nMailServerPort)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "UPDATE WebMailProfile SET"
			+ " UserName='" + sUserName + "',"
			+ " AliasName='" + sAliasName + "',"
			+ " Email='" + sEmail + "',"
			+ " MailServerIP='" + sMailServerIP + "',"
			+ " MailServerPort='" + nMailServerPort.ToString() + "'"
			+ " WHERE WebMailID=1";
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

	public SqlDataReader GetMails()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Mails";
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

	public SqlDataReader GetMailsByFloder(int nFolderID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT Mails.* FROM Mails WHERE FolderID='" + nFolderID.ToString() + "'";
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

	public SqlDataReader GetSingleMail(int nMailID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Mails WHERE MailID='" + nMailID.ToString() + "'";
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

	public int SenderMail(MailMessage mail)
	{
		///定义发送邮件的Client
		SmtpClient client = new SmtpClient();
		///设置邮件服务器主机的IP地址
		client.Host = ((WebMailProfile)HttpContext.Current.Application["WebMailProfile"]).MailServerIP;
		///设置邮件服务器的端口
		client.Port = ((WebMailProfile)HttpContext.Current.Application["WebMailProfile"]).MailServerPort;
		///配置发送邮件的属性
		client.DeliveryMethod = SmtpDeliveryMethod.Network;
		client.UseDefaultCredentials = false;
		///发送邮件
		client.Send(mail);		
		return (0);
	}		

	public int SaveAsMail(string sTitle,string sBody,string sFrom,string sTo,
		string sCC,bool bHtmlFormat,int nContain,bool bAttachmentFlag)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		SqlCommand myCommand = new SqlCommand("Pr_SaveAsMail",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pTitle = new SqlParameter("@Title",SqlDbType.VarChar,200);
		pTitle.Value = sTitle;
		myCommand.Parameters.Add(pTitle);
		SqlParameter pBody = new SqlParameter("@Body",SqlDbType.Text,2147483647);
		pBody.Value = sBody;
		myCommand.Parameters.Add(pBody);
		SqlParameter pFrom = new SqlParameter("@FromAddress",SqlDbType.Text,2147483647);
		pFrom.Value = sFrom;
		myCommand.Parameters.Add(pFrom);
		SqlParameter pTo = new SqlParameter("@ToAddress",SqlDbType.Text,2147483647);
		pTo.Value = sTo;
		myCommand.Parameters.Add(pTo);
		SqlParameter pCC = new SqlParameter("@CCAddress",SqlDbType.Text,2147483647);
		pCC.Value = sCC;
		myCommand.Parameters.Add(pCC);

		SqlParameter pHtmlFormat = new SqlParameter("@HtmlFormat",SqlDbType.Bit,1);
		pHtmlFormat.Value = bHtmlFormat.ToString();
		myCommand.Parameters.Add(pHtmlFormat);
		SqlParameter pContain = new SqlParameter("@Contain",SqlDbType.Int,4);
		pContain.Value = nContain;
		myCommand.Parameters.Add(pContain);
		SqlParameter pAttachmentFlag = new SqlParameter("@AttachmentFlag",SqlDbType.Bit,1);
		pAttachmentFlag.Value = bAttachmentFlag.ToString();
		myCommand.Parameters.Add(pAttachmentFlag);

		SqlParameter pMailID = new SqlParameter("@MailID",SqlDbType.Int,4);
		pMailID.Direction = ParameterDirection.ReturnValue;
		myCommand.Parameters.Add(pMailID);

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
		return(int)myCommand.Parameters[8].Value;
	}

	public int SaveAsMailAttachment(string sName,string sUrl,string sType,
		int nContain,int nMailID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "INSERT INTO Attachments (Name,Url,Type,Contain,MailID)VALUES("
			+ "'" + sName + "',"
			+ "'" + sUrl + "',"
			+ "'" + sType + "',"		
			+ "'" + nContain.ToString() + "',"
			+ "'" + nMailID.ToString() + "'"
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

	public int MoveMail(int nMailID,int nFolderID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		SqlCommand myCommand = new SqlCommand("Pr_MoveMail",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pMailID = new SqlParameter("@MailID",SqlDbType.Int,4);
		pMailID.Value = nMailID;
		myCommand.Parameters.Add(pMailID);

		SqlParameter pFolderID = new SqlParameter("@FolderID",SqlDbType.Int,4);
		pFolderID.Value = nFolderID;
		myCommand.Parameters.Add(pFolderID);
		
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

	public int DeleteMail(int nMailID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		SqlCommand myCommand = new SqlCommand("Pr_DeleteMail",myConnection);
		myCommand.CommandType = CommandType.StoredProcedure;
		///添加存储过程的参数
		SqlParameter pMailID = new SqlParameter("@MailID",SqlDbType.Int,4);
		pMailID.Value = nMailID;
		myCommand.Parameters.Add(pMailID);

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
	
	public SqlDataReader GetAttachmentsByMail(int nMailID)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Attachments WHERE MailID='" + nMailID.ToString() + "'";
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
