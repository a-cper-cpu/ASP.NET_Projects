using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;

public partial class ConnectionODBC : System.Web.UI.Page 
{
	/// <summary>
	/// 获取链接字符串
	/// </summary>
	private string myConnectionString = ConfigurationManager.ConnectionStrings["ODBCCONNECTIONSTRING"].ConnectionString;
  
	protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///链接ODBC数据源
			TestConnectionODBC();

			Response.End();
		}
    }

	private void TestConnectionODBC()
	{
		///创建SqlConnection
		OdbcConnection myConnection = new OdbcConnection(myConnectionString);

		try
		{
			///打开连接
			myConnection.Open();

			///显示链接的属性
			Response.Write("链接状态：\t\t" + (myConnection.State == ConnectionState.Open ? "链接成功！" : "链接失败！") + "<br>");
			Response.Write("链接字符串：\t" + myConnection.ConnectionString + "<br>");
			Response.Write("ConnectionTimeout：\t" + myConnection.ConnectionTimeout.ToString() + "<br>");
			Response.Write("Database：\t" + myConnection.Database + "<br>");
			Response.Write("DataSource：\t" + myConnection.DataSource + "<br>");
			Response.Write("Driver：\t" + myConnection.Driver + "<br>");
			Response.Write("ServerVersion：\t" + myConnection.ServerVersion + "<br>");			
		}
		catch(OdbcException odbcex)
		{
			///显示链接错误的消息
			Response.Write(odbcex.Message + "<br>");
		}
		finally
		{
			///关闭数据库的链接
			myConnection.Close();
		}
	}
}
