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
	/// Login ��ժҪ˵����
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
			//���ô洢����ChcekUser
			Forum SP_CheckUser = new Forum();
			dr = SP_CheckUser.UserLogin(UserName,Pass);
			while(dr.Read())
			{
				check++;
				if (dr["Pos"].ToString()=="����Ա")
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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
