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

public partial class DataViewFilter : System.Web.UI.Page 
{
	/// <summary>
	/// 获取链接字符串
	/// </summary>
	private string myConnectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;

	private static DataSet ds;

	protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///初始化过滤表达式列表
			InitFilterList();

			///使用DataAdapter和DataSet
			ds = GetDataSet();
		}
    }

	private void InitFilterList()
	{
		FilterList.Items.Clear();

		///添加过滤表达式
		char aChar = 'a';
		FilterList.Items.Add(new ListItem("all","-1"));
		for(int i = 0; i < 26; i++)
		{
			FilterList.Items.Add(new ListItem(((char)((int)aChar + i)).ToString(),i.ToString()));
		}
		FilterList.SelectedIndex = 0;
	}	

	private DataSet GetDataSet()
	{
		///创建SqlConnection
		SqlConnection myConnection = new SqlConnection(myConnectionString);

		string cmdText = "SELECT * FROM Users";
		SqlDataAdapter myda = new SqlDataAdapter(cmdText,myConnection);
		
		DataSet ds = new DataSet("UserDataSet");

		try
		{
			///打开连接
			myConnection.Open();			
		
			///填充DataSet
			myda.Fill(ds,"Users");

			///绑定UserList的数据
			UserList.DataSource = ds.Tables[0].DefaultView;
			///设置Text和Value
			UserList.DataTextField = "UserName";
			UserList.DataValueField = "UserID";
			///绑定数据
			UserList.DataBind();
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

		return (ds);
	}

	protected void FilterList_SelectedIndexChanged(object sender,EventArgs e)
	{
		///创建DataView
		DataView dv = ds.Tables[0].DefaultView;
		///设置数据过滤表达式
		if(FilterList.SelectedItem.Text == "all")
		{
			dv.RowFilter = "UserName LIKE '*'";
		}
		else
		{
			dv.RowFilter = "UserName LIKE '" + FilterList.SelectedItem.Text + "*'";
		}
		///绑定UserList的数据
		UserList.DataSource = dv;
		///设置Text和Value
		UserList.DataTextField = "UserName";
		UserList.DataValueField = "UserID";
		///绑定数据
		UserList.DataBind();
	}
}
