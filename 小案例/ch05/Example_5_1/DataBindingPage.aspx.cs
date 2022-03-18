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

public partial class DataBindingPage : System.Web.UI.Page
{
	/// <summary>
	/// 获取链接字符串
	/// </summary>
	private string myConnectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;

	protected string sLabelData;
	protected string sTextBoxData;
	protected string sButtonData;

	protected void Page_Load(object sender,EventArgs e)
	{
		///		
	}
	
	private void GetData()
	{
		///创建SqlConnection
		SqlConnection myConnection = new SqlConnection(myConnectionString);

		string cmdText = "SELECT TOP 1 * FROM Users WHERE UserID > 10";
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		try
		{
			///打开连接
			myConnection.Open();

			SqlDataReader mydr = myCommand.ExecuteReader();
			///从DataReader中读取数据
			while(mydr.Read())
			{
				///读取UserName
				sLabelData = mydr["UserName"].ToString();
				///读取RealName
				sTextBoxData = mydr["RealName"].ToString();
				///读取CreateDate
				sButtonData = mydr["CreateDate"].ToString();				
			}
			///关闭DataReader
			mydr.Close();
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

	protected void DataBindBtn_Click(object sender,EventArgs e)
	{
		///获取数据
		GetData();

		///绑定控件的数据
		LabelData.DataBind();
		TextBoxData.DataBind();
		ButtonData.DataBind();
	}
}
