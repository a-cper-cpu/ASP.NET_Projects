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

namespace Ebook
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbWelcomeMessage;
		protected System.Web.UI.WebControls.HyperLink FrontPageHL;
		protected System.Web.UI.WebControls.HyperLink AuthorContractQueryHL;
		protected System.Web.UI.WebControls.HyperLink AuthorPublishEbookHL;
		protected System.Web.UI.WebControls.HyperLink EditInfoHL;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label Status1NumberLabel;
		protected System.Web.UI.WebControls.Label Status2NumberLabel;
		protected System.Web.UI.WebControls.Label Status3NumberLabel;
		protected System.Web.UI.WebControls.Label Status4NumberLabel;		
		protected Ebook.AuthorService WebReferences = null;
	
				
		public Default()
		{
			Page.Init += new System.EventHandler(Page_Init);
			try	
			{
				WebReferences = new Ebook.AuthorService();
			}
			catch {	}
			if (WebReferences == null)
			{
				Page.Response.Redirect("error.aspx");
			}
			
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			lbWelcomeMessage.Text=User.Identity.Name + "张军，您好！";
			Status1NumberLabel.Text = WebReferences.AE_Status1(User.Identity.Name).Tables[0].Rows[0][0].ToString();
			Status2NumberLabel.Text = WebReferences.AE_Status2(User.Identity.Name).Tables[0].Rows[0][0].ToString();
			Status3NumberLabel.Text = WebReferences.AE_Status3(User.Identity.Name).Tables[0].Rows[0][0].ToString();
			Status4NumberLabel.Text = WebReferences.AE_Status4(User.Identity.Name).Tables[0].Rows[0][0].ToString();			

		}

		private void Page_Init(object sender, EventArgs e)
		{
			
			InitializeComponent();
		}

		#region Web 窗体设计器生成的代码
		
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
