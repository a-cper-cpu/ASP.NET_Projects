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
	/// adminuser ��ժҪ˵����
	/// </summary>
	public class adminuser : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label id;
		protected System.Web.UI.WebControls.TextBox UserNametext;
		protected System.Web.UI.WebControls.TextBox Signtext;
		protected System.Web.UI.WebControls.TextBox Passtext;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		public SqlConnection MyConn;
		public SqlDataReader dr;
		public SqlCommand comm;
		public string UserName;
		public string sqlstring;		
		public string Sign;
		public string Pass;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			Forum ForumDBO= new Forum();
			MyConn=ForumDBO.Open();
			if (ForumDBO.adminck()=="Wrong")
			{
				Response.Redirect("Exceptions.aspx");
			}
			if(!Page.IsPostBack)
			{
				UserName=Request.Form["username"];
				getuser();
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			sqlstring="update users set Sign='"+Signtext.Text+"',Password='"+Passtext.Text+"' where UserName='"+UserNametext.Text+"'";
			comm = new SqlCommand(sqlstring,MyConn);
			comm.ExecuteNonQuery();
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			sqlstring="delete from users where UserName='"+UserNametext.Text+"'";
			Response.Write(sqlstring);
			comm = new SqlCommand(sqlstring,MyConn);
			comm.ExecuteNonQuery();
		}
		public void getuser()
		{

			sqlstring="select * from users where UserName='"+UserName+"'";
			comm = new SqlCommand(sqlstring,MyConn);
			dr=comm.ExecuteReader();
			while(dr.Read())
			{
				
				
				Sign=dr["Sign"].ToString();
				Pass=dr["Password"].ToString();
				id.Text=dr["id"].ToString();
			}
			dr.Close();			
			Signtext.Text=Sign;
			Passtext.Text=Pass;
			UserNametext.Text=UserName;
		}
	}
}
