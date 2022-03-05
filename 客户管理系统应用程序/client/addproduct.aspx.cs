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
	/// addproduct ��ժҪ˵����
	/// </summary>
	public class addproduct : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Tbx_id;
		protected System.Web.UI.WebControls.RequiredFieldValidator Rfv_id;
		protected System.Web.UI.WebControls.CustomValidator Cv_id;
		protected System.Web.UI.WebControls.TextBox Tbx_name;
		protected System.Web.UI.WebControls.TextBox tell;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.Button Btn_cancel;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
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
				SqlCommand cm=new SqlCommand("Addproduct",cn);

				cm.CommandType=CommandType.StoredProcedure;
				cm.Parameters.Add(new SqlParameter("@Product_id",SqlDbType.Char,10));	
				cm.Parameters.Add(new SqlParameter("@Product_name",SqlDbType.VarChar,50));
				cm.Parameters.Add(new SqlParameter("@Product_descnbe",SqlDbType.VarChar,50));

				cm.Parameters["@Product_id"].Value=Tbx_id.Text;
				cm.Parameters["@Product_name"].Value=Tbx_name.Text;
				cm.Parameters["@Product_descnbe"].Value=tell.Text;

				cm.Connection.Open();
				try
				{
					cm.ExecuteNonQuery();
					Response.Redirect("product.aspx");
				
				}
				catch(SqlException)
				{
					Lbl_note.Text="���ʧ��";
					Lbl_note.Style["color"]="red";
				}
				cm.Connection.Close();
			}
		}

		private void Btn_cancel_Click(object sender, System.EventArgs e)
		{
		Page.Response.Redirect("addproduct.aspx");
		}
	}
}
