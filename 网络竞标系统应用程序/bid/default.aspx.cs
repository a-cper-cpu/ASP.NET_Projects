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


namespace bid
{
	/// <summary>
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Pwd;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnsel;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.Button btnreg;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				lblMsg.Text="";
				txtEmail.Text="";
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
			this.btnsel.Click += new System.EventHandler(this.btnsel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				Bid.user obj = new Bid.user();
				Bid.UserDetails myUserDetails = new Bid.UserDetails();

				myUserDetails = obj.Login(txtEmail.Text, Pwd.Text);

				if (myUserDetails.user_id != 0)
				{
					Response.Cookies["email"].Value = txtEmail.Text;
					Response.Cookies["Login"].Value = myUserDetails.login;
					Response.Cookies["UserID"].Value = myUserDetails.user_id.ToString();
					Response.Redirect("ReUsers.Aspx");
				}
				else
					lblMsg.Text = "��¼ʧ�ܣ������û���������.";
			}
		}

		private void btnreg_Click(object sender, System.EventArgs e)
		{
			lblMsg.Text="";
			txtEmail.Text="";
			Pwd.Text="";
			Page.Response.Redirect("Register.aspx");
		}

		private void btnsel_Click(object sender, System.EventArgs e)
		{
			lblMsg.Text="";
			txtEmail.Text="";
			Pwd.Text="";
			Page.Response.Redirect("Browse.aspx");
		}
	}
}
