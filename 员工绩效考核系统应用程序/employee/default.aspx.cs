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
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Tbx_id;
		protected System.Web.UI.WebControls.TextBox Tbx_pwd;
		protected System.Web.UI.WebControls.Button Btn_login;
		protected System.Web.UI.WebControls.Label Lbl_note;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.Btn_login.Click += new System.EventHandler(this.Btn_login_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_login_Click(object sender, System.EventArgs e)
		{
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection(strconn);
			conn.Open();
			string strsql="select * from Employee where Emp_name='"+Tbx_id.Text+"' and password='"+Tbx_pwd.Text+"'";
			SqlCommand cm=new SqlCommand(strsql,conn);
			SqlDataReader dr=cm.ExecuteReader();
			if(dr.Read())
			{
				//保存用户权限
				Session["jb"]=dr["jb"];
				Session["Emp_id"]=dr["Emp_id"];
				if(Session["jb"].ToString()=="0")
				{
					//系统管理员登录
					Response.Redirect("Emp.aspx");
				}
				else if(Session["jb"].ToString()=="1")
				{
					//员工登录
					Response.Redirect("loginEdit.aspx");
				}
				else if(Session["jb"].ToString()=="2")
				{
					//领导登录
					Response.Redirect("Login.aspx");
				}
				else 
				{
					//错误登录
					Response.Redirect("Error.apx");
				}
				
			}
			else
			{
				Lbl_note.Text="登录失败，请检查用户名、密码输入！";
			}
		}
	}
}
