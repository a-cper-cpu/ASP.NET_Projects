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

namespace Forum
{
	/// <summary>
	/// userinfo 的摘要说明。
	/// </summary>
	public class register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox username;
		protected System.Web.UI.WebControls.TextBox Pass;
		protected System.Web.UI.WebControls.TextBox pass2;
		protected System.Web.UI.WebControls.TextBox email;
		protected System.Web.UI.WebControls.TextBox QQ;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.TextBox sex;
		protected System.Web.UI.WebControls.TextBox sign;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnReset;
		public SqlConnection MyConn;
		public SqlDataReader dr;
		public String Name;
		public String Pass1;
		public String Sex;
		public String mail;
		public String QQ1;		
		public String Sign1;
		
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			
			
			Name = username.Text;
			Pass1 = Pass.Text;
			QQ1 = QQ.Text;
			mail = email.Text;
			Sign1 = sign.Text;		
			Sex = sex.Text ;
			Forum ForumDBO = new Forum();
			MyConn = ForumDBO.Open();
			Forum SP_ChekUserName = new Forum();
			dr = SP_ChekUserName.CheckUserName(Name);
			if(dr.Read()==false)
			{
				Forum SP_AddUser = new Forum();
				SP_AddUser.AddUser (Name,Pass1,Int32.Parse(QQ1),Sex,mail,Sign1);
				Page.Response.Redirect("default.aspx");
			}		
		}
	}
}
