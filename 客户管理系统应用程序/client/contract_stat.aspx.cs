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

namespace client
{
	/// <summary>
	/// contract_stat 的摘要说明。
	/// </summary>
	public class contract_stat : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid Dgd_contract;
		protected System.Web.UI.WebControls.Label Lbl_note;
		protected System.Web.UI.WebControls.Button Btn_back;
		SqlConnection cn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			if(!IsPostBack)
				BindGrid();
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
			this.Btn_back.Click += new System.EventHandler(this.Btn_back_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public void BindGrid()
		{
			string mysql="select Product_id,Contract_id,Product_num,Product_price from con_detail order by product_id";
			SqlDataAdapter da=new SqlDataAdapter(mysql,cn);
			DataSet ds=new DataSet();
			da.Fill(ds);
			Dgd_contract.DataSource=ds;
			Dgd_contract.DataBind();
		}
		public void DataGrid_Page(object sender,DataGridPageChangedEventArgs e)
		{
			Dgd_contract.CurrentPageIndex=e.NewPageIndex;
			BindGrid();
		}

		private void Btn_back_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("default.aspx");
		}
	}
}
