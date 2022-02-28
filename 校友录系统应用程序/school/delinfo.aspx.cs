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
	/// delinfo 的摘要说明。
	/// </summary>
	/// SqlConnection cn;
	
	public class delinfo : System.Web.UI.Page
	{
		SqlConnection cn;
		SqlCommand cmd;		
		SqlDataReader dr;
		string strConn,strSQL;	
		public string strClid;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			cn=new SqlConnection(strConn);
			cn.Open();

			strSQL="select class_id from info where info_id="+Page.Request["infoid"].ToString();
			SqlCommand cmd1=new SqlCommand(strSQL,cn);
			dr=cmd1.ExecuteReader();
			while(dr.Read())
				
					strClid=dr["class_id"].ToString();
					dr.Close();
					cn.Close();
				
			dr.Close();
			//将删除信息标志字段置为1，信息不显示
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			strSQL="Update info SET del_flag='1' where info_id="+Page.Request["infoid"].ToString();
			cn=new SqlConnection(strConn);
			cn.Open();
			cmd=new SqlCommand(strSQL,cn);
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			cn.Close();			
			Page.Response.Redirect("info.aspx?clid="+strClid);
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
