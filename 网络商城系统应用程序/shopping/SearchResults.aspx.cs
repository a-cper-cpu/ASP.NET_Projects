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
	/// SearchResults ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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

		#region Web ������������ɵĴ���
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
				ErrorMsg.Text = "û���κ���Ʒƥ����Ĳ�ѯ�ַ�����";
			}
		}
	}
}
