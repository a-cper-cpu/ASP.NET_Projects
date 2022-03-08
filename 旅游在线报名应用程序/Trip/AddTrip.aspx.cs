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

namespace Trip
{
	/// <summary>
	/// AddTrip 的摘要说明。
	/// </summary>
	public class AddTrip : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox show;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.Button Btn_cancel;
		protected System.Web.UI.WebControls.TextBox Num;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.DropDownList line;
		protected System.Web.UI.WebControls.TextBox Tell;
		protected System.Web.UI.WebControls.TextBox Address;
		protected System.Web.UI.WebControls.Label Lbl_note;
		SqlConnection cn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			cn.Open();
			string sSQL="select line from arrange";
			SqlCommand command = new SqlCommand(sSQL,cn);
			SqlDataReader reader = command.ExecuteReader();				

			while(reader.Read()) 
			{	
				line.Items.Add(new ListItem(reader[0].ToString(),reader[0].ToString()));					
				
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
				SqlCommand cm=new SqlCommand("Add_Trip",cn);
				cm.CommandType=CommandType.StoredProcedure;
				DateTime dt=DateTime.Now;
				cm.Parameters.Add(new SqlParameter("@name",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@line",SqlDbType.VarChar,100));
				cm.Parameters.Add(new SqlParameter("@Num",SqlDbType.Char,8));
				cm.Parameters.Add(new SqlParameter("@Address",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@Tell",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@show",SqlDbType.VarChar,500));
				cm.Parameters.Add(new SqlParameter("@systime",SqlDbType.DateTime,8));
				

				cm.Parameters["@name"].Value=name.Text;
				cm.Parameters["@line"].Value=line.SelectedValue.ToString();
				cm.Parameters["@Num"].Value=Num.Text;								
				cm.Parameters["@Address"].Value=Address.Text;
				cm.Parameters["@Tell"].Value=Tell.Text;	
				cm.Parameters["@show"].Value=show.Text;	
				cm.Parameters["@systime"].Value=dt;
				
			
				try
				{
					cm.ExecuteNonQuery();
					Response.Redirect("default.aspx");
				
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
		Page.Response.Redirect("addtrip.aspx");
		}
	}
}
