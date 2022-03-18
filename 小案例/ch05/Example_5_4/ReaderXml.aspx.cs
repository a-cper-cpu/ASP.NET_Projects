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

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{   ///从数据库读取XML数据
			ReaderXmlData();
		}
    }

	private void ReaderXmlData()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///定义SQL语句
		string cmdText = "SELECT * FROM Users FOR XML AUTO";
		///创建Command
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
		Response.End();
	}
}
