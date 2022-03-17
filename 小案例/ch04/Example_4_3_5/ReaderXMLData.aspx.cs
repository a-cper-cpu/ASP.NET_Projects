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
using System.Xml;

public partial class ReaderXMLData : System.Web.UI.Page 
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
			TestReaderXMLData();

			Response.End();
		}
    }

	private void TestReaderXMLData()
	{
		///创建SqlConnection
		SqlConnection myConnection = new SqlConnection(myConnectionString);

		string cmdText = "SELECT * FROM Users FOR XML AUTO";
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		try
		{
			///打开连接
			myConnection.Open();

			XmlReader myxmlReader = myCommand.ExecuteXmlReader();

			///移动到XML元素处
			myxmlReader.MoveToElement();
			///输出XML文件的标志
			Response.Write("<?xml version='1.0'?>");
			///输出父节点
			Response.Write("<Users>");
			///读取从数据库中获取的数据
			while(myxmlReader.IsStartElement())
			{
				///显示从数据库中获取的数据
				Response.Write(myxmlReader.ReadOuterXml());
			}
			Response.Write("</Users>");
			///关闭XMLReader
			myxmlReader.Close();			
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
