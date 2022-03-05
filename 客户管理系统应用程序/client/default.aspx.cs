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
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Tbx_id;
		protected System.Web.UI.WebControls.TextBox Tbx_pwd;
		protected System.Web.UI.WebControls.Button Btn_login;
		protected System.Web.UI.WebControls.Label Lbl_note;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
				//�����û�Ȩ��
				Session["branch"]=dr["branch"];
				if(Session["branch"].ToString()=="0")
				{
					//ϵͳ����Ա��¼
					Response.Redirect("users.aspx");
				}
				else if(Session["branch"].ToString()=="1")
				{
					//��ͬ����¼
					Response.Redirect("contract.aspx");
				}
				else if(Session["branch"].ToString()=="2")
				{
					//���۲���¼
					Response.Redirect("contract_stat.aspx");
				}
				else 
				{
					//�ͻ�����¼
					Response.Redirect("client.apx");
				}
				
			}
			else
			{
				Lbl_note.Text="��¼ʧ�ܣ������û������������룡";
			}
		}
	}
}
