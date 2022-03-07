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
	/// updatepwd ��ժҪ˵����
	/// </summary>
	public class updatepwd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox newpass;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.Button Btn_cancel;
		protected System.Web.UI.WebControls.Label Lbl_note;
		SqlConnection cn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
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
			this.Btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
			this.Btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_ok_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				SqlCommand cm=new SqlCommand("UpdatePASS",cn);
				cm.CommandType=CommandType.StoredProcedure;

				cm.Parameters.Add(new SqlParameter("@emp_id",SqlDbType.Int,4));
				cm.Parameters["@emp_id"].Value=Session["Emp_id"];

				cm.Parameters.Add(new SqlParameter("@password",SqlDbType.VarChar,50));
				cm.Parameters["@password"].Value=newpass.Text;
			
				
				cm.Connection.Open();
				try
				{
					cm.ExecuteNonQuery();
					Response.Redirect("default.aspx");
				
				}
				catch(SqlException)
				{
					Lbl_note.Text="�޸�ʧ��";
					Lbl_note.Style["color"]="red";
				}
				cm.Connection.Close();
			}
		}

		private void Btn_cancel_Click(object sender, System.EventArgs e)
		{
		Page.Response.Redirect("updatepwd.aspx");
		}
	}
}
