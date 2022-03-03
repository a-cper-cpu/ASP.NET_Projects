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
	/// Login 的摘要说明。
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		public SqlConnection MyConn;
		public SqlCommand com;
		public String UserName;
		public String Pass;
		public String CTime;
		public String sqlstring;
		public int check=0;
		public SqlDataReader dr;
		public TimeSpan TimeSp;

		private void Page_Load(object sender, System.EventArgs e)
		{
			UserName=Request.QueryString ["UserName"];
			Pass=Request.QueryString["Password"];
			CTime="2";
			//调用存储过程ChcekUser
			Forum SP_CheckUser = new Forum();
			dr = SP_CheckUser.UserLogin(UserName,Pass);
			while(dr.Read())
			{
				check++;
				if (dr["Pos"].ToString()=="管理员")
				{
					Session["au"]="yes";
				}
			}
			dr.Close();
			if (check==1)
			{
				HttpCookie cookie = new HttpCookie("Cookie");
				DateTime dt = DateTime.Now;
				TimeSp = new TimeSpan(0,23,0,0);
				cookie.Expires = dt.Add(TimeSp);
				cookie.Values.Add("UserName",UserName.ToString());
				cookie.Values.Add("Pass",Pass.ToString());   
				Response.AppendCookie(cookie);	
				Response.Redirect("Default.aspx");
			} 
			else 
			{
				Response.Redirect("Default.aspx");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
