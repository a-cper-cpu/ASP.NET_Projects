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

public partial class CommandReader : System.Web.UI.Page 
{
	/// <summary>
	/// 获取链接字符串
	/// </summary>
	private string myConnectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
  
	protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///使用Command和DataReader
			TestCommandReader();
		}
    }

	private void TestCommandReader()
	{
		///创建SqlConnection
		SqlConnection myConnection = new SqlConnection(myConnectionString);

		string cmdText = "SELECT * FROM Users";
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		try
		{
			///打开连接
			myConnection.Open();

			SqlDataReader mydr = myCommand.ExecuteReader();
			///从DataReader中读取数据
			while(mydr.Read())
			{
				///向列表中添加Item项
				UserList.Items.Add(new ListItem(
					///读取UserName
					mydr["UserName"] + "--"
					///读取RealName
					+ mydr["RealName"] + "--"
					///读取Phone
					+ mydr["Phone"] + "--"
					///读取Mobile
					+ mydr["Mobile"] + "--"
					///读取CreateDate
					+ mydr["CreateDate"],mydr["UserID"].ToString()));
			}
			///关闭DataReader
			mydr.Close();

			SqlDataReader mydrOther = myCommand.ExecuteReader();
			///绑定UserOtherList的数据
			UserOtherList.DataSource = mydrOther;
			///设置Text和Value
			UserOtherList.DataTextField = "UserName";
			UserOtherList.DataValueField = "UserID";
			///绑定数据
			UserOtherList.DataBind();

			///关闭DataReader
			mydrOther.Close();
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
}
