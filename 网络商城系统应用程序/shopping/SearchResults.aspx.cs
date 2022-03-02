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
	/// SearchResults 的摘要说明。
	/// </summary>
	public class SearchResults : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Search;
		protected System.Web.UI.WebControls.Button SearchButton;
		protected System.Web.UI.WebControls.Panel SearchPanel;
		protected System.Web.UI.WebControls.DataList MyList;
		protected System.Web.UI.WebControls.Label ErrorMsg;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		public SearchResults() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			SearchPanel.Visible = true;
			MyList.Visible = false;
		}
		private void Page_Init(object sender, EventArgs e) 
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web 窗体设计器生成的代码
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SearchButton_Click(object sender, System.EventArgs e)
		{
			SearchPanel.Visible = false;
			MyList.Visible = true;

			shopping.IStoreDBO IStoreDB = new shopping.IStoreDBO();
			MyList.DataSource = IStoreDB.SearchwareDescriptions(Search.Text);
			MyList.DataBind();

			if (MyList.Items.Count == 0) 
			{
				ErrorMsg.Text = "没有任何商品匹配你的查询字符串。";
			}
		}
	}
}
