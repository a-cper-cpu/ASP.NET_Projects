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

public partial class DataQuery : System.Web.UI.Page 
{
	/// <summary>
	/// 获取链接字符串
	/// </summary>
	private string myConnectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
  
	protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///链接SQL Server数据库
			TestDataQuery();

			Response.End();
		}
    }

	private void TestDataQuery()
	{
		///创建SqlConnection
		SqlConnection myConnection = new SqlConnection(myConnectionString);

		string cmdText = "INSERT INTO Users(UserName,RealName,Password)VALUES('newuser','he is a new user.','newuser')";
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		SqlDataReader mydr;
		string drcmdText = "SELECT TOP 5 * FROM Users ORDER BY UserID DESC";

		try
		{
			///打开连接
			myConnection.Open();

			///插入数据
			int nCount = myCommand.ExecuteNonQuery();
			Response.Write("插入" + nCount.ToString() + "条新的数据.<br>");
			///显示数据
			myCommand.CommandText = drcmdText;
			mydr = myCommand.ExecuteReader();
			PrintData(mydr);			

			///修改数据
			cmdText = "UPDATE Users SET UserName = 'He is a new user.' WHERE UserName = 'newUser'";
			myCommand.CommandText = cmdText;
			myCommand.ExecuteNonQuery();
			Response.Write("修改" + nCount.ToString() + "条数据.<br>");
			///显示数据
			myCommand.CommandText = drcmdText;
			mydr = myCommand.ExecuteReader();
			PrintData(mydr);

			///删除数据
			cmdText = "DELETE Users WHERE UserName = 'He is a new user.'";
			myCommand.CommandText = cmdText;
			myCommand.ExecuteNonQuery();
			Response.Write("删除" + nCount.ToString() + "条数据.<br>");
			///显示数据
			myCommand.CommandText = drcmdText;
			mydr = myCommand.ExecuteReader();
			PrintData(mydr);
		}
		catch(SqlException sqlex)
		{
			///显示链接错误的消息
			Response.Write(sqlex.Message + "<br>");
		}
		finally
		{
			///关闭数据库的链接
			myConnection.Close();
		}
	}

	private void PrintData(SqlDataReader mydr)
	{
		while(mydr.Read())
		{
			///向列表中添加Item项
			Response.Write(mydr["UserID"] + "----"
				///读取UserName
				+ mydr["UserName"] + "--"
				///读取RealName
				+ mydr["RealName"] + "--"
				///读取Phone
				+ mydr["Phone"] + "--"
				///读取Mobile
				+ mydr["Mobile"] + "--"
				///读取CreateDate
				+ mydr["CreateDate"] + "<br>");
		}
		mydr.Close();
	}
}
