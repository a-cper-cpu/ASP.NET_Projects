using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml;

public partial class CreateXml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{   ///创建XML文件
			CreateXmlFile();
		}
    }

	private void CreateXmlFile()
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
			///读取XML数据
			XmlReader myxmlReader = myCommand.ExecuteXmlReader();

			XmlDocument doc = new XmlDocument();
			string xmlstr = "";
			///添加XML文件的标志
			xmlstr += "<?xml version='1.0'?>";
			xmlstr += "<Users>";
			///移动到XML元素处
			myxmlReader.MoveToElement();
			///读取从数据库中获取的数据
			while(myxmlReader.IsStartElement())
			{
				xmlstr += myxmlReader.ReadOuterXml();
			}
			///关闭XMLReader
			myxmlReader.Close();
			///添加XML文件的标志
			xmlstr += "</Users>";
			///保存文件
			doc.LoadXml(xmlstr);
			doc.Save(Server.MapPath("xmlfile.xml"));			
		}
		catch(Exception ex)
		{
			///显示链接错误的消息
			Response.Write(ex.Message + "<br>");
		}
		finally
		{
			///关闭数据库的链接
			myConnection.Close();
		}
	}
}
