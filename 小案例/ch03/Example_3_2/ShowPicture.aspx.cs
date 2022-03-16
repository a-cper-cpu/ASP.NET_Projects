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

public partial class ShowPicture:System.Web.UI.Page
{
	protected void Page_Load(object sender,EventArgs e)
	{	///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		///定义SQL语句
		string cmdText = "SELECT * FROM Pictures WHERE PictureID='1'";
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
		///定义保存数据的byte数组
		byte[] Data = null;
		while(dr.Read())
		{   ///读取数据
			Data = (byte[])dr["Data"];
			Response.ContentType = dr["Type"].ToString();
		}
		dr.Close();
		//显示图片数据
		this.EnableViewState = false;
		///输出文件头
		Response.AppendHeader("Content-Length",Data.Length.ToString());
		///输出文件的数据
		Response.BinaryWrite(Data);
		///结束输出
		Response.End();
	}
}
