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

namespace Bid
{
	/// <summary>
	/// register 的摘要说明。
	/// </summary>
	public class register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtLogin;
		protected System.Web.UI.WebControls.TextBox txtAdd1;
		protected System.Web.UI.WebControls.TextBox txtAdd2;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		protected System.Web.UI.WebControls.TextBox txtPwdConfirm;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnReset;
		private string Process;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (Bid.Tools.IsLoggedIn())
			{
				Process = "MODIFY";

				Bid.UserDetails myuserDetails = new Bid.UserDetails();
				Bid.user  obj = new Bid.user();

				myuserDetails = obj.GetuserDetails(Request.Cookies["email"].Value);
				txtName.Text = myuserDetails.Name;
				txtLogin.Text = myuserDetails.login;
				txtEmail.Text = Request.Cookies["email"].Value;
				txtPwd.Text = myuserDetails.Password;
				txtAdd1.Text = myuserDetails.Address1;
				txtAdd2.Text = myuserDetails.Address2;
				txtCity.Text = myuserDetails.City;
				txtState.Text = myuserDetails.State;
				txtZip.Text = myuserDetails.yb;
				txtCountry.Text = myuserDetails.Country;
				txtEmail.Enabled = false;
				obj = null;				
			}
			else
			{
				Process = "ADD";				
			}
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				Bid.user  obj = new Bid.user();
				string strStatus;

				if (Process == "ADD")
				{					
					strStatus = obj.AddCustomer(
						txtName.Text,
						txtLogin.Text,
						txtEmail.Text,
						txtPwd.Text,
						txtAdd1.Text,
						txtAdd2.Text,
						txtCity.Text,
						txtState.Text,
						txtZip.Text,
						txtCountry.Text);

					try
					{
						Int32.Parse(strStatus);
						Response.Cookies["Name"].Value = txtName.Text;
						Response.Cookies["email"].Value = txtEmail.Text;
						Response.Cookies["user_id"].Value = strStatus;
						Response.Redirect("ReUsers.aspx");
					}
					catch
					{
						lblMsg.Text = strStatus;
					}
				}
				else
				{
					// Code for Update goes here
					strStatus = obj.ModifyCustomer(txtLogin.Text,
						txtName.Text,
						txtEmail.Text,
						txtPwd.Text,
						txtAdd1.Text,
						txtAdd2.Text,
						txtCity.Text,
						txtState.Text,
						txtZip.Text,
						txtCountry.Text);

					if (strStatus == "1")
					{
						Response.Cookies["Name"].Value = Request.Form["txtName"];
						Response.Cookies["email"].Value = txtEmail.Text;
						Response.Redirect("ReUsers.Aspx");
					}
					else if(strStatus.Length > 1)
					{
						lblMsg.Text = "更新失败! " + strStatus;
					}
				}
			}
		}

		

	}
}

