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

public partial class DataAdapterDataSet : System.Web.UI.Page 
{
	/// <summary>
	/// 获取链接字符串
	/// </summary>
	private string myConnectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
  
	protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///使用DataAdapter和DataSet
			TestDataAdapterDataSet();
		}
    }

	private void TestDataAdapterDataSet()
	{
		///创建SqlConnection
		SqlConnection myConnection = new SqlConnection(myConnectionString);

		string cmdText = "SELECT * FROM Users";
		SqlDataAdapter myda = new SqlDataAdapter(cmdText,myConnection);

		try
		{
			///打开连接
			myConnection.Open();

			DataSet ds = new DataSet("UserDataSet");
		
			///填充DataSet
			myda.Fill(ds,"Users");
		
			///从DataSet中读取数据
			foreach(DataRow row in ds.Tables[0].Rows)
			{
				///向列表中添加Item项
				UserList.Items.Add(new ListItem(
					///读取UserName
					row["UserName"] + "--"
					///读取RealName
					+ row["RealName"] + "--"
					///读取Phone
					+ row["Phone"] + "--"
					///读取Mobile
					+ row["Mobile"] + "--"
					///读取CreateDate
					+ row["CreateDate"],row["UserID"].ToString()));
			}			

			///绑定UserOtherList的数据
			UserOtherList.DataSource = ds;
			///设置Text和Value
			UserOtherList.DataTextField = "UserName";
			UserOtherList.DataValueField = "UserID";
			///绑定数据
			UserOtherList.DataBind();
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
