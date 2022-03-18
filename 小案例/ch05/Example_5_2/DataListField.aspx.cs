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

public partial class DataListField : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			BindData();
		}
    }

	private void BindData()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///定义SQL语句
		string cmdText = "SELECT TOP 10 * FROM Users";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);
		///定义DataReader
		SqlDataReader dr = null;
		try
		{	///打开链接
			myConnection.Open();
			///读取数据
			dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch(SqlException ex)
		{	///抛出异常
			throw new Exception(ex.Message,ex);
		}

		MyDataList.DataSource = dr;
		MyDataList.DataBind();

		dr.Close();
	}
	protected void MyDataList_ItemCommand(object source,DataListCommandEventArgs e)
	{
		if(e.CommandName.ToLower() == "information")
		{   ///显示选择行的信息
			LabelMsg.Text = ((DataBoundLiteralControl)e.Item.Controls[0]).Text;
		}
	}
}
