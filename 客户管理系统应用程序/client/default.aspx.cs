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
			string strsql="select * from users where Userid='"+Tbx_id.Text+"' and password='"+Tbx_pwd.Text+"'";
			SqlCommand cm=new SqlCommand(strsql,conn);
			SqlDataReader dr=cm.ExecuteReader();
			if(dr.Read())
			{
				//保存用户权限
				Session["branch"]=dr["branch"];
				if(Session["branch"].ToString()=="0")
				{
					//系统管理员登录
					Response.Redirect("users.aspx");
				}
				else if(Session["branch"].ToString()=="1")
				{
					//合同部登录
					Response.Redirect("contract.aspx");
				}
				else if(Session["branch"].ToString()=="2")
				{
					//销售部登录
					Response.Redirect("contract_stat.aspx");
				}
				else 
				{
					//客户部登录
					Response.Redirect("client.apx");
				}
				
			}
			else
			{
				Lbl_note.Text="登录失败，请检查用户名、密码输入！";
			}
		}
	}
}
