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
	/// EmpEdit 的摘要说明。
	/// </summary>
	public class EmpEdit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Tbx_id;
		protected System.Web.UI.WebControls.RequiredFieldValidator Rfv_id;
		protected System.Web.UI.WebControls.CustomValidator Cv_id;
		protected System.Web.UI.WebControls.DropDownList Ddl_kind;
		protected System.Web.UI.WebControls.TextBox tell;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.Button Btn_cancel;
		protected System.Web.UI.WebControls.TextBox Tbx_Email;
		protected System.Web.UI.WebControls.Label Lbl_note;
		protected System.Web.UI.WebControls.TextBox Tbx_name;
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
			this.Btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_ok_Click(object sender, System.EventArgs e)
		{
			
			if(Page.IsValid)
			{
				SqlCommand cm=new SqlCommand("AddEmp",cn);
				cm.CommandType=CommandType.StoredProcedure;
				cm.Parameters.Add(new SqlParameter("@Emp_Name",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@password",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@name",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@Email",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@tell",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@jb",SqlDbType.Int,4));
				cm.Parameters["@Emp_Name"].Value=Tbx_id.Text;
				cm.Parameters["@password"].Value=Tbx_id.Text;
				cm.Parameters["@name"].Value=Tbx_name.Text;
				cm.Parameters["@Email"].Value=Tbx_Email.Text;				
				cm.Parameters["@tell"].Value=tell.Text;
				cm.Parameters["@jb"].Value=Ddl_kind.SelectedItem.Value;
				cm.Connection.Open();
				try
				{
					cm.ExecuteNonQuery();
					Response.Redirect("Emp.aspx");
				
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
		Page.Response.Redirect("EmpEdit.aspx");
		}		
	}
}
