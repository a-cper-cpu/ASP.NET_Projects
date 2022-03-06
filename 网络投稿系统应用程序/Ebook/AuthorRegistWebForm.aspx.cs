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

namespace Ebook
{
	/// <summary>
	/// AuthorRegistWebForm 的摘要说明。
	/// </summary>
	public class AuthorRegistWebForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Tbx_id;
		protected System.Web.UI.WebControls.RequiredFieldValidator Rfv_id;
		protected System.Web.UI.WebControls.CustomValidator Cv_id;
		protected System.Web.UI.WebControls.TextBox Tbx_name;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.Button Btn_cancel;
		protected System.Web.UI.WebControls.TextBox card;
		protected System.Web.UI.WebControls.TextBox sex;
		protected System.Web.UI.WebControls.TextBox age;
		protected System.Web.UI.WebControls.TextBox address;
		protected System.Web.UI.WebControls.TextBox phone;
		protected System.Web.UI.WebControls.TextBox zipcode;
		protected System.Web.UI.WebControls.TextBox city;
		protected System.Web.UI.WebControls.TextBox country;
		protected System.Web.UI.WebControls.TextBox mobile;
		protected System.Web.UI.WebControls.TextBox question;
		protected System.Web.UI.WebControls.TextBox answer;
		protected System.Web.UI.WebControls.TextBox note;
		protected System.Web.UI.WebControls.Label Lbl_note;
		protected System.Web.UI.WebControls.TextBox Email;
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
				SqlCommand cm=new SqlCommand("Add_Author",cn);
				cm.CommandType=CommandType.StoredProcedure;

				cm.Parameters.Add(new SqlParameter("@UserName",SqlDbType.VarChar,12));
				cm.Parameters.Add(new SqlParameter("@password",SqlDbType.Char,32));
				cm.Parameters.Add(new SqlParameter("@name",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@Card",SqlDbType.Char,18));
				cm.Parameters.Add(new SqlParameter("@Sex",SqlDbType.Char,2));
				cm.Parameters.Add(new SqlParameter("@Age",SqlDbType.Int,4));
				cm.Parameters.Add(new SqlParameter("@Address",SqlDbType.VarChar,100));
				cm.Parameters.Add(new SqlParameter("@ZipCode",SqlDbType.Char,6));
				cm.Parameters.Add(new SqlParameter("@City",SqlDbType.VarChar,100));
				cm.Parameters.Add(new SqlParameter("@Country",SqlDbType.VarChar,100));							
				cm.Parameters.Add(new SqlParameter("@Email",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@phone",SqlDbType.Char,15));
				cm.Parameters.Add(new SqlParameter("@mobile",SqlDbType.Char,15));
				cm.Parameters.Add(new SqlParameter("@Question",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@Answer",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@Note",SqlDbType.VarChar,255));

				cm.Parameters["@UserName"].Value=Tbx_id.Text;
				cm.Parameters["@password"].Value=Tbx_id.Text;
				cm.Parameters["@name"].Value=Tbx_name.Text;
				cm.Parameters["@Card"].Value=card.Text;		
				cm.Parameters["@Sex"].Value=sex.Text;	
				cm.Parameters["@Age"].Value=age.Text;	
				cm.Parameters["@Address"].Value=address.Text;	
				cm.Parameters["@ZipCode"].Value=zipcode.Text;	
				cm.Parameters["@City"].Value=city.Text;	
				cm.Parameters["@Country"].Value=country.Text;	
				cm.Parameters["@Email"].Value=Email.Text;	
				cm.Parameters["@phone"].Value=phone.Text;	
				cm.Parameters["@mobile"].Value=mobile.Text;	
				cm.Parameters["@Question"].Value=question.Text;	
				cm.Parameters["@Answer"].Value=answer.Text;	
				cm.Parameters["@Note"].Value=note.Text;	


				cm.Connection.Open();
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
		Page.Response.Redirect("authorregistwebform.aspx");
		}
	}
}
