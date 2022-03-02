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
	/// orderdetails 的摘要说明。
	/// </summary>
	public class orderdetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label MyError;
		protected System.Web.UI.WebControls.Label lblOrderNumber;
		protected System.Web.UI.WebControls.Label lblOrderDate;
		protected System.Web.UI.WebControls.DataGrid GridControl1;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.HtmlControls.HtmlTable detailsTable;
	
		public orderdetails() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			int OrderID = Int32.Parse(Request.Params["OrderID"]);

			string UserId="1";
			//string UserId = User.Identity.Name;

			shopping.IStoreDBO order = new shopping.IStoreDBO();
			shopping.OrderDetails myOrderDetails = order.GetOrderDetails(OrderID, UserId);

			if (myOrderDetails != null) 
			{

				GridControl1.DataSource = myOrderDetails.OrderItems;
				GridControl1.DataBind();

				lblTotal.Text = String.Format( "{0:c}", myOrderDetails.OrderTotalCost);
				lblOrderNumber.Text = OrderID.ToString();
				lblOrderDate.Text = myOrderDetails.OrderDate.ToShortDateString();
			}
			else 
			{

				MyError.Text = "没有发现订单！";
				detailsTable.Visible = false;
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
