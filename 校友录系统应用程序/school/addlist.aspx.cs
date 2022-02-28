using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace school
{
	/// <summary>
	/// addlist 的摘要说明。
	/// </summary>
	public class addlist : System.Web.UI.Page
	{
		int i,j;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		string strSQL;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");
			string class_id=Request["clid"].ToString();
			j=5-class_id.Length;
			for(i=0;i<j;i++)
				class_id="0"+class_id;
			string sqlconn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			SqlConnection myConnection = new SqlConnection(sqlconn);
			myConnection.Open();
			strSQL="select * from userreg where class_id LIKE '%"+class_id+"%'";
			
			SqlDataAdapter comm =new SqlDataAdapter(strSQL,myConnection);
			DataSet ds = new DataSet();
			comm.Fill(ds,"list");			
			DataGrid1.DataSource=ds.Tables["list"].DefaultView;
			DataGrid1.DataBind();
			comm.Dispose();
			myConnection.Close();

		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
