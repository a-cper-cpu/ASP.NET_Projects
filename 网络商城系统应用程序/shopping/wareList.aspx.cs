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
	/// wareList 的摘要说明。
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
			// 在此处放置用户代码以初始化页面
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
