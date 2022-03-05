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
	/// Addclient 的摘要说明。
	/// </summary>
	public class Addclient : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Tbx_id;
		protected System.Web.UI.WebControls.TextBox Tbx_name;
		protected System.Web.UI.WebControls.TextBox Tbx_person;
		protected System.Web.UI.WebControls.TextBox Tbx_introduce;
		protected System.Web.UI.WebControls.DropDownList Ddl_level;
		protected System.Web.UI.WebControls.Button Btn_add;
		protected System.Web.UI.WebControls.Button Btn_reset;
		protected System.Web.UI.WebControls.Label Lbl_note;
		protected System.Web.UI.WebControls.CustomValidator Cv_id;
		protected System.Web.UI.WebControls.TextBox Email;
		protected System.Web.UI.WebControls.TextBox Tell;
		protected System.Web.UI.WebControls.Button Btn_exit;
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
			this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
			this.Btn_reset.Click += new System.EventHandler(this.Btn_reset_Click);
			this.Btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_add_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				SqlCommand cm=new SqlCommand("Addclient",cn);
				cm.CommandType=CommandType.StoredProcedure;
				cm.Parameters.Add(new SqlParameter("@client_id",SqlDbType.Char,10));
				cm.Parameters.Add(new SqlParameter("@client_name",SqlDbType.Char,10));
				cm.Parameters.Add(new SqlParameter("@client_charge",SqlDbType.Char,10));
				cm.Parameters.Add(new SqlParameter("@client_introduce",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@client_level",SqlDbType.Int,4));
				cm.Parameters.Add(new SqlParameter("@client_email",SqlDbType.VarChar,20));
				cm.Parameters.Add(new SqlParameter("@client_tell",SqlDbType.VarChar,20));
				cm.Parameters["@client_id"].Value=Tbx_id.Text;
				cm.Parameters["@client_name"].Value=Tbx_name.Text;
				cm.Parameters["@client_charge"].Value=Tbx_person.Text;
				cm.Parameters["@client_introduce"].Value=Tbx_introduce.Text;
				cm.Parameters["@client_level"].Value=Ddl_level.SelectedItem.Value;
				cm.Parameters["@client_email"].Value=Email.Text;
				cm.Parameters["@client_tell"].Value=Tell.Text;
				cm.Connection.Open();
				try
				{
					cm.ExecuteNonQuery();
					Lbl_note.Text="添加成功";
					Response.Redirect("client.aspx");
				}
				catch(SqlException)
				{
					Lbl_note.Text="添加失败";
					Lbl_note.Style["color"]="red";
				}
				cm.Connection.Close();
			}
		}

		private void Btn_reset_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("addclientr.aspx");
		}

		private void Btn_exit_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("client.aspx");
		}
		private void Cv_id_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			cn.Open();
			SqlCommand cm=new SqlCommand("select * from client where client_id=@client_id",cn);
			cm.Parameters.Add("@client_id",SqlDbType.Char,10);
			cm.Parameters["@client_id"].Value=Tbx_id.Text;
			SqlDataReader dr=cm.ExecuteReader();
			if(dr.Read())
			{
				args.IsValid=false;
			}
			else
			{
				args.IsValid=true;
			}
			cn.Close();
		}

	}
}
