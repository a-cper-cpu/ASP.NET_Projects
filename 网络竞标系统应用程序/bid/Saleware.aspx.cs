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

namespace bid
{
	/// <summary>
	/// Saleware 的摘要说明。
	/// </summary>
	public class Saleware : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUserName;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DataGrid myItems;
		protected System.Web.UI.WebControls.Label lblNote1;
		protected System.Web.UI.WebControls.Label lblNote2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!Page.IsPostBack)
			{
				BindGrid();
				lblUserName.Text = "Welcome <b>" +
					Request.Cookies["email"].Value + "</b><br/><br/>";

				if (Request.QueryString["msg"] == "1")
					lblStatus.Text = "出价成功";

				if (Request.QueryString["msg"] == "0")
					lblStatus.Text = "出价失败";
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void BindGrid()
		{
			Int32 intSellerID = Convert.ToInt32(Request.Cookies["UserID"].Value);
			Bid.ware objItemList = new Bid.ware();

			myItems.DataSource = objItemList.Viewwares (intSellerID);

			myItems.DataBind();
		}

		public void myItems_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item ||	e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HyperLink temphypAcceptBid;
				temphypAcceptBid = (HyperLink)e.Item.FindControl("hypAcceptBid");
				temphypAcceptBid.Attributes.Add("onclick",
					"return confirm('你确认此价位吗？');");
			}
		}

		public void myItems_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			myItems.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
			BindGrid();
		}

		public void myItems_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			myItems.EditItemIndex = -1;
			BindGrid();
		}

		public void myItems_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string strItemID = myItems.DataKeys[e.Item.ItemIndex].ToString();
			string strItemName = ((TextBox)e.Item.FindControl("txtItemName")).Text;
			string strItemDesc = ((TextBox)e.Item.FindControl("txtDescription")).Text;
			string strAskingPrice = ((TextBox)e.Item.FindControl("txtAskPrice")).Text;
			string strNotifyPrice = ((TextBox)e.Item.FindControl("txtNotifyPrice")).Text;

			Bid.ware  myItem = new Bid.ware();
			string strResult;

			strResult = myItem.Updateware (strItemID, strItemName, strItemDesc,
				strAskingPrice, strNotifyPrice);

			if (strResult == "1")
				lblStatus.Text = "更新成功";
			else if (strResult.Length > 1)
				lblStatus.Text = "更新失败 " + strResult;
			
			myItems.EditItemIndex = -1;
			BindGrid();
		}


		public void myItems_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Int32 intItemID = Convert.ToInt32(myItems.DataKeys[e.Item.ItemIndex]);
			Bid.ware  myItem = new Bid.ware();
			string strResult;

			strResult = myItem.Deleteware(intItemID);

			if (strResult == "1")
				lblStatus.Text = "更新成功";
			else if (strResult.Length > 1)
				lblStatus.Text = "更新失败 " + strResult;

			myItems.EditItemIndex = -1;
			BindGrid();
		}

		public string FormatUrl(Double dblHighestBid
			, Int32 intItemID
			, Int32 intBidID)
		{
			if (dblHighestBid == 0)
				return "";
			else
				return "AcceptBid.aspx?itemid=" + intItemID + "&bidid=" + intBidID;
		}

		public string ShowText(Double dblHighestBid)
		{
			if (dblHighestBid == 0)
				return "";
			else
				return "同意价位";
		}

		public string FormatHighBid(Double dblHighBidAmount)
		{
			if (dblHighBidAmount > 0)
				return dblHighBidAmount.ToString();
			else
				return "Yet to be bid on";
		}

		public string FormatBidderID(Int32 intBidderID)
		{
			if (intBidderID > 0)
				return "<a href=ShowuserDetails.aspx?bidid=" +
					intBidderID + ">" + intBidderID + "</a>";
			else
				return "Yet to be bid on";
		}

		public string IsPending(string strItemStatus)
		{
			if (strItemStatus.ToUpper().Trim() == "PENDING")
			{
				lblNote1.Visible = true;
				lblNote2.Visible = true;
				return "*";
			}
			else
				return "";
		}

	}
}

