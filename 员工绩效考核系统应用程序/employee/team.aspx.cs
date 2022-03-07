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
	/// team 的摘要说明。
	/// </summary>
	public class team : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Btn_exit;
		protected System.Web.UI.WebControls.Label Lbl_note;
		protected System.Web.UI.WebControls.DataGrid Dgd_user;
		SqlConnection cn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			if(!IsPostBack)		BindGrid();
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
			this.Btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_exit_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("default.aspx");
		}
		public void DataGrid_page(object sender,DataGridPageChangedEventArgs e)
		{
			Dgd_user.CurrentPageIndex=e.NewPageIndex;
			BindGrid();
		}
		public void BindGrid()
		{
			SqlDataAdapter da=new SqlDataAdapter("select * from Team",cn);
			DataSet ds=new DataSet();
			da.Fill(ds);
			Dgd_user.DataSource=ds;
			Dgd_user.DataBind();
		}
		public void DataGrid_cancel(object sender,DataGridCommandEventArgs e)
		{
			
			Dgd_user.EditItemIndex=-1;
			BindGrid();
			
		}
		public void DataGrid_edit(object sender,DataGridCommandEventArgs e)
		{
			
			Dgd_user.EditItemIndex=(int)e.Item.ItemIndex;
		
			BindGrid();
			
		}
		public void DataGrid_update(object sender,DataGridCommandEventArgs e)
		{
			SqlCommand cm=new SqlCommand("UpdateTeam",cn);
			cm.CommandType=CommandType.StoredProcedure;
							
			cm.Parameters.Add(new SqlParameter("@team_id",SqlDbType.Int,4));
			cm.Parameters.Add(new SqlParameter("@teamname",SqlDbType.VarChar,50));			
			

			string colvalue=((TextBox)e.Item.Cells[1].Controls[0]).Text;
			cm.Parameters["@teamname"].Value=colvalue;			
					
			cm.Parameters["@team_id"].Value=Dgd_user.DataKeys[(int)e.Item.ItemIndex];
			cm.Connection.Open();
			try
			{
				cm.ExecuteNonQuery();
				Lbl_note.Text="编辑成功";
				Dgd_user.EditItemIndex=-1;
			}
			catch(SqlException)
			{
				Lbl_note.Text="编辑失败";
				Lbl_note.Style["color"]="red";
			}
			cm.Connection.Close();		
			BindGrid();
			
		}
		
		public void DataGrid_delete(object sender,DataGridCommandEventArgs e)
		{
			
			SqlCommand cm=new SqlCommand("deleteTeam",cn);
			cm.CommandType=CommandType.StoredProcedure;

			cm.Parameters.Add(new SqlParameter("@team_id",SqlDbType.Int,4));
			cm.Parameters["@team_id"].Value=Dgd_user.DataKeys[(int)e.Item.ItemIndex];
			
			cm.Connection.Open();
			try
			{
				cm.ExecuteNonQuery();
				Lbl_note.Text="删除成功";
				
			}
			catch(SqlException)
			{
				Lbl_note.Text="删除失败";
				Lbl_note.Style["color"]="red";
			}
			cm.Connection.Close();			
			BindGrid();
		}
	}
}
