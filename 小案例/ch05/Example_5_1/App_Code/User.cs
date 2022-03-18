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
/// User 的摘要说明
/// </summary>
public class UserInformation
{
	public int UserID;
	public string UserName;
	public string AliasName;
	public string Address;
	public string Phone;
	public string Mobile;
	public string Email;
	public DateTime CreateDate;
	public int Status;
	public int RoleID;
	public string Remark;

	public DataSet GetUsers()
	{		
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///创建Command
		SqlDataAdapter da = new SqlDataAdapter("Select * FROM Users",myConnection);

		///定义DataSet
		DataSet ds = new DataSet();
		try
		{
			///打开链接
			myConnection.Open();
			///读取数据
			da.Fill(ds,"Users");
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		finally
		{
			myConnection.Close();
		}
		///返回DataSet
		return (ds);
	}
}
