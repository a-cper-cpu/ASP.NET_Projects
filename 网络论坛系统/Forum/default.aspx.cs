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
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		public SqlConnection MyConn;
		public DateTime StartTime ;
		public DateTime StopTime ;
		public TimeSpan TimeSp ;
		public SqlDataReader dr;
		public String Beg;
		protected System.Web.UI.WebControls.TextBox username;
		protected System.Web.UI.WebControls.TextBox pass;
		protected System.Web.UI.WebControls.Button Login;
		public string sqlstring;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			DateTime now = DateTime.Now;
			StartTime= DateTime.Now;
			sqlstring = "ForumInfo";
			Forum ForumDBO = new Forum();
			MyConn = ForumDBO.Open();
			dr = ForumDBO.GetDataReader(sqlstring);
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
			this.Login.Click += new System.EventHandler(this.Login_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public void Display()
		{
			int Beg;
			int End;
			int n=0;
			String TopicName;
			String TopicDes;		
			String Toastmaster;
			String ReplyTotal;
			String TopicTotal;
			String des;
			while(dr.Read())
			{
				Beg=(int)dr["Begin1"];
				End=(int)dr["End1"];
				TopicName=dr["TopicName"].ToString();
				TopicDes=dr["TopicDes"].ToString();			
				Toastmaster=dr["Toastmaster"].ToString();
				ReplyTotal=dr["ReplyTotal"].ToString();
				des=dr["des"].ToString();
				TopicTotal=dr["TopicTotal"].ToString();
				if (n==Beg)
				{
					Response.Write("<tr  class=tablemaiStopTime><td width='8%' align=center class=tablemaiStartTime></td><td colspan=2>");
					Response.Write("<table width='90%' border='3' align='center' cellpadding='0' cellspacing='10'  class=font><tr>");
					Response.Write("<td width='70%'>");
					Response.Write("<a href='Thread.aspx?Beg="+Beg.ToString()+"&End="+End.ToString()+"&page=1"+"'>『<b>"+TopicDes+"</b>』</a><br>"+"&nbsp;&nbsp;"+des);
					Response.Write("</td>");
					Response.Write("<td width='30%'>");
					Response.Write("版主："+Toastmaster+"<br>");
					Response.Write("主题："+TopicTotal+"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
					Response.Write("回复："+ReplyTotal+"<br>");
					Response.Write("</td>");
					Response.Write("</tr></table>");
					Response.Write("</td></tr>");  
				}
				else 
				{
					Response.Write("<tr ><td  colspan=3 class=tablemaiTimeSp height=10><b>"+"&nbsp;&nbsp;"+TopicName+"</b></a></td></tr>");
					Response.Write("<tr class=tablemaiStopTime><td width='8%' class=tablemaiStartTime align=center></td><td colspan=2>");
					Response.Write("<table width='90%' border='3' align='center' cellpadding='0' cellspacing='10'  class=font><tr>");
					Response.Write("<td width='70%'>");
					Response.Write("<a href='Thread.aspx?Beg="+Beg.ToString()+"&End="+End.ToString()+"&page=1"+"'>『<b>"+TopicDes+" </b>』</a><br>"+"&nbsp;&nbsp;"+des);
					Response.Write("</td>");
					Response.Write("<td width='30%'>");
					Response.Write("版主："+Toastmaster+"<br>");
					Response.Write("主题："+TopicTotal+"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
					Response.Write("回复："+ReplyTotal+"<br>");
					Response.Write("</td>");
					Response.Write("</tr></table>");
					Response.Write("</td></tr>");
					n=Beg;           
				}
			}
			dr.Close();
			StopTime= DateTime.Now;
			TimeSp=StopTime-StartTime;
			MyConn.Close();
		}

		public void Page_Unload(Object src,EventArgs e)
		{
			MyConn.Close();
		}

		private void Login_Click(object sender, System.EventArgs e)
		{
			string user,password;
			user = username.Text.ToString();
			password = pass.Text.ToString();
			Response.Redirect("login.aspx?username="+user+"&password="+password);
		}

	}
}

