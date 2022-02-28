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

namespace school
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		//声明Default文件中使用的表格表单、变量。
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.TextBox Pwd;
		protected System.Web.UI.WebControls.Button btnreg;
		protected System.Web.UI.WebControls.TextBox login;
		protected System.Web.UI.WebControls.Button btnOK;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				lblMsg.Text="";
				login.Text="";
				Pwd.Text="";
			}					
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnreg.Click += new System.EventHandler(this.btnreg_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//建立与数据源的连接
			string sqlconn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			SqlConnection myConnection = new SqlConnection(sqlconn);
			string id=login.Text.ToString();
			string pass=Pwd.Text.ToString();
			string sql="select * from userreg where login='"+id+"'and password='"+pass+"'";
			SqlCommand cmd = new SqlCommand(sql, myConnection);
			//打开连接
			myConnection.Open();
			//读取数据库数据
			SqlDataReader rs=cmd.ExecuteReader();
			//验证用户的身份
			if(rs.Read())
			{
				//将用户的id值赋值给Session
				Session["uid"]=rs["id"].ToString();
				Page.Response.Redirect("school.aspx");
			}
			else
			{
				lblMsg.Text="用户名或口令错误！请重新输入！";				
				Pwd.Text="";			
			}
			//关闭数据库连接
			myConnection.Close();
		}

		private void btnreg_Click(object sender, System.EventArgs e)
		{
			lblMsg.Text="";
			login.Text="";
			Pwd.Text="";
			Page.Response.Redirect("regedit.aspx");
		}
	}
}
