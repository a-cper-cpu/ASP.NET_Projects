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
			string strsql="select * from Employee where Emp_name='"+Tbx_id.Text+"' and password='"+Tbx_pwd.Text+"'";
			SqlCommand cm=new SqlCommand(strsql,conn);
			SqlDataReader dr=cm.ExecuteReader();
			if(dr.Read())
			{
				//�����û�Ȩ��
				Session["jb"]=dr["jb"];
				Session["Emp_id"]=dr["Emp_id"];
				if(Session["jb"].ToString()=="0")
				{
					//ϵͳ����Ա��¼
					Response.Redirect("Emp.aspx");
				}
				else if(Session["jb"].ToString()=="1")
				{
					//Ա����¼
					Response.Redirect("loginEdit.aspx");
				}
				else if(Session["jb"].ToString()=="2")
				{
					//�쵼��¼
					Response.Redirect("Login.aspx");
				}
				else 
				{
					//�����¼
					Response.Redirect("Error.apx");
				}
				
			}
			else
			{
				Lbl_note.Text="��¼ʧ�ܣ������û������������룡";
			}
		}
	}
}
