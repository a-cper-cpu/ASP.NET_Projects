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
	/// orderdetails ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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

				MyError.Text = "û�з��ֶ�����";
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
