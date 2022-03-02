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
	/// wareList ��ժҪ˵����
	/// </summary>
	public class wareList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList MyList;
		protected System.Web.UI.WebControls.HyperLink BackHyperLink;
		public wareList() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			int categoryId = Int32.Parse(Request.Params["CategoryID"]);

			shopping.IStoreDBO GoodsCataloguesInfo = new shopping.IStoreDBO();
        
			MyList.DataSource = GoodsCataloguesInfo.GetwareBytype(categoryId);
			MyList.DataBind();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
