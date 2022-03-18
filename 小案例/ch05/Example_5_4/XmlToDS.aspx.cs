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
using System.Xml;

public partial class XmlToDS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///获取数据
			DataSet ds = GetDataSet();
			///绑定控件的数据
			MyGridView.DataSource = ds;
			MyGridView.DataBind();
		}
    }

	private DataSet GetDataSet()
	{   ///创建DataSet
		DataSet ds = new DataSet();
		///创建DataTable
		DataTable dataTable = new DataTable("Users");
		dataTable.Columns.Add("UserID",typeof(int));
		dataTable.Columns.Add("UserName");
		dataTable.Columns.Add("RealName");
		dataTable.Columns.Add("CreateDate",typeof(DateTime));	

		try
		{   ///导入XML文件
			XmlDocument doc = new XmlDocument();
			doc.Load(Server.MapPath("xmlfile.xml"));
			if(doc == null)
			{
				return null;
			}
			///读取XML文件
			XmlNodeList nodeList = doc.SelectNodes("/Users/Users");
			foreach(XmlNode node in nodeList)
			{   ///读取每一行的数据
				DataRow row = dataTable.NewRow();
				row["UserID"] = Convert.ToInt32(node.Attributes["UserID"].Value);
				row["UserName"] = node.Attributes["UserName"].Value;
				row["RealName"] = node.Attributes["RealName"].Value;
				row["CreateDate"] = Convert.ToDateTime(node.Attributes["CreateDate"].Value);
				dataTable.Rows.Add(row);
			}
		}
		catch(Exception ex)
		{   ///抛出异常
			throw new Exception(ex.Message,ex);
		}
		ds.Tables.Add(dataTable);
		return (ds);
	}
}
