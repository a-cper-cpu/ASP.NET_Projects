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

namespace shopping
{
	/// <summary>
	/// login ��ժҪ˵����
	/// </summary>
	public class login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.TextBox email;
		protected System.Web.UI.WebControls.RequiredFieldValidator UserNameRequired;
		protected System.Web.UI.WebControls.TextBox password;
		protected System.Web.UI.WebControls.RequiredFieldValidator passwordRequired;
		protected System.Web.UI.WebControls.ImageButton LoginBtn;
		protected System.Web.UI.WebControls.HyperLink BackHyperLink;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		public login() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
		}		

		private void Page_Init(object sender, EventArgs e) 
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web ������������ɵĴ���
		
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.LoginBtn.Click += new System.Web.UI.ImageClickEventHandler(this.LoginBtn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoginBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Page.IsValid == true) 
			{

				shopping.IStoreDBO shoppingCart = new shopping.IStoreDBO();
				String tempCartID = shoppingCart.GetShoppingCartId();

				shopping.IStoreDBO accountSystem = new shopping.IStoreDBO();
				String userId = accountSystem.UserLogin(email.Text, password.Text);

				if (userId != null) 
				{

					shoppingCart.TransplantShoppingCart(tempCartID, userId);

					shopping.UserDetails userDetails = accountSystem.GetUserDetails(userId);

					Response.Cookies["IStore_UserName"].Value = userDetails.UserName;

					
				}
				else 
				{
					Message.Text = "��¼ʧ�ܣ�";
				}
			}
		}
	}
}
