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
	/// wareDetails1 的摘要说明。
	/// </summary>
	public class wareDetails1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label ModelName;		
		protected System.Web.UI.WebControls.Label UnitCost;
		protected System.Web.UI.WebControls.Label ModelNumber;
		protected System.Web.UI.WebControls.HyperLink addToCart;
		protected System.Web.UI.WebControls.Label desc;
		protected System.Web.UI.WebControls.Image GoodsImage;
		protected System.Web.UI.WebControls.HyperLink BackHyperLink;

		public wareDetails1() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			int wareID = Int32.Parse(Request.Params["wareID"]);
			// 在此处放置用户代码以初始化页面
			shopping.IStoreDBO wareDetail = new shopping.IStoreDBO();
			shopping.wareDetails mywareDetails = wareDetail.GetwareDetails(wareID);
						
			desc.Text = mywareDetails.Description;
			UnitCost.Text = String.Format("{0:c}", mywareDetails.UnitCost);
			ModelName.Text = mywareDetails.ModelName;
			ModelNumber.Text = mywareDetails.ModelNumber.ToString();			
			addToCart.NavigateUrl = "AddToCart.aspx?wareID=" + wareID;
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
