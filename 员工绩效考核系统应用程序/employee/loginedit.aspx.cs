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
using System.Threading;
using System.Globalization;

namespace employee
{
	/// <summary>
	/// loginedit 的摘要说明。
	/// </summary>
	public class loginedit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList team;
		protected System.Web.UI.WebControls.DropDownList Ddl_kind;
		protected System.Web.UI.WebControls.TextBox status;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.Label Lbl_note;
		protected System.Web.UI.WebControls.Button Btn_cancel;
		protected System.Web.UI.WebControls.TextBox show;
		SqlConnection cn;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			cn.Open();
			string sSQL="select team_name from Team";
			SqlCommand command = new SqlCommand(sSQL, cn);
			SqlDataReader reader = command.ExecuteReader();				

			while(reader.Read()) 
			{	
				team.Items.Add(new ListItem(reader[0].ToString(),reader[0].ToString()));					
				
			}
			reader.Close();
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
			this.Btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_ok_Click(object sender, System.EventArgs e)
		{
		
			if(Page.IsValid)
			{
				SqlCommand cm=new SqlCommand("Addlogin",cn);
				cm.CommandType=CommandType.StoredProcedure;
				DateTime dt=DateTime.Now;
				cm.Parameters.Add(new SqlParameter("@Emp_id",SqlDbType.Int,4));
				cm.Parameters.Add(new SqlParameter("@Team_name",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@status",SqlDbType.VarChar,200));
				cm.Parameters.Add(new SqlParameter("@work_date",SqlDbType.VarChar,4));
				cm.Parameters.Add(new SqlParameter("@sysdate",SqlDbType.DateTime,8));
				cm.Parameters.Add(new SqlParameter("@show",SqlDbType.VarChar,400));

				cm.Parameters["@Emp_id"].Value=Session["Emp_id"];
				cm.Parameters["@Team_name"].Value=team.SelectedValue.ToString();
				cm.Parameters["@status"].Value=status.Text;
				cm.Parameters["@work_date"].Value=Ddl_kind.SelectedValue.ToString();				
				cm.Parameters["@sysdate"].Value=dt;
				cm.Parameters["@show"].Value=show.Text;				
				try
				{
					cm.ExecuteNonQuery();
					Response.Redirect("loginedit.aspx");
				
				}
				catch(SqlException)
				{
					Lbl_note.Text="添加失败";
					Lbl_note.Style["color"]="red";
				}
				cm.Connection.Close();
			}
		}

		private void Btn_cancel_Click(object sender, System.EventArgs e)
		{
		Page.Response.Redirect("loginedit.aspx");
		}		
	}
}
