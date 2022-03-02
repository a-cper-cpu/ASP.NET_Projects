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
	/// OrderList 的摘要说明。
	/// </summary>
	public class OrderList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label MyError;
		protected System.Web.UI.WebControls.DataGrid MyList;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		public OrderList() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//String UserID = User.Identity.Name;
			String UserID="1";
			shopping.IStoreDBO orderHistory = new shopping.IStoreDBO();
        
			MyList.DataSource = orderHistory.GetUserOrders(UserID);
			MyList.DataBind();

			if (MyList.Items.Count == 0) 
			{
				MyError.Text = "您目前没有订单可以显示。";
				MyList.Visible = false;
			}
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
