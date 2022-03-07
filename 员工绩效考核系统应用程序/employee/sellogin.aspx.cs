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

namespace employee
{
	/// <summary>
	/// sellogin 的摘要说明。
	/// </summary>
	public class sellogin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox begin;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.TextBox end;
		protected System.Web.UI.WebControls.DataGrid datagrid1;
		SqlConnection cn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			
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
			this.Btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_ok_Click(object sender, System.EventArgs e)
		{
			SqlCommand cm=new SqlCommand("selectlogin",cn);
			cm.CommandType=CommandType.StoredProcedure;
							
			cm.Parameters.Add(new SqlParameter("@startdate",SqlDbType.DateTime ,8));
			cm.Parameters.Add(new SqlParameter("@enddate",SqlDbType.DateTime,8));			
			cm.Parameters.Add(new SqlParameter("@empid",SqlDbType.Int,4));

			
			cm.Parameters["@startdate"].Value=begin.Text;
			cm.Parameters["@enddate"].Value=end.Text;
			cm.Parameters["@empid"].Value=Session["Emp_id"];
								
			

			try
			{
				SqlDataAdapter myAdapter = new SqlDataAdapter();

				myAdapter.SelectCommand = cm;

				DataSet ds = new DataSet();

				myAdapter.Fill(ds);
				datagrid1.DataSource=ds;
				datagrid1.DataBind();
				
			}
			catch
			{}
			
		}		
	}
}
