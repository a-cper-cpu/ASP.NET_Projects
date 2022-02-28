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
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		//����Default�ļ���ʹ�õı�����������
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.TextBox Pwd;
		protected System.Web.UI.WebControls.Button btnreg;
		protected System.Web.UI.WebControls.TextBox login;
		protected System.Web.UI.WebControls.Button btnOK;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				lblMsg.Text="";
				login.Text="";
				Pwd.Text="";
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnreg.Click += new System.EventHandler(this.btnreg_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//����������Դ������
			string sqlconn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			SqlConnection myConnection = new SqlConnection(sqlconn);
			string id=login.Text.ToString();
			string pass=Pwd.Text.ToString();
			string sql="select * from userreg where login='"+id+"'and password='"+pass+"'";
			SqlCommand cmd = new SqlCommand(sql, myConnection);
			//������
			myConnection.Open();
			//��ȡ���ݿ�����
			SqlDataReader rs=cmd.ExecuteReader();
			//��֤�û������
			if(rs.Read())
			{
				//���û���idֵ��ֵ��Session
				Session["uid"]=rs["id"].ToString();
				Page.Response.Redirect("school.aspx");
			}
			else
			{
				lblMsg.Text="�û��������������������룡";				
				Pwd.Text="";			
			}
			//�ر����ݿ�����
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
