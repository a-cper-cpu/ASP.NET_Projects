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
	/// reusers 的摘要说明。
	/// </summary>
	public class reusers : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUserName;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DataGrid myWinningBids;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面			
			if (Bid.Tools.IsLoggedIn())
				lblUserName.Text = "Welcome <b>" +
					Request.Cookies["email"].Value + "</b><br/>";
			else
				Response.Redirect("Default.aspx");

			if (!Page.IsPostBack)
				BindGrid();

			lblStatus.Text = Request.QueryString["msg"];
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
			this.myWinningBids.ItemCreated  += new System.Web.UI.WebControls.DataGridItemEventHandler(this.myWinningBids_wareCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void BindGrid()
		{
			Int32 intUserID = Convert.ToInt32(Request.Cookies["UserID"].Value);
			Bid.ware objwareList = new Bid.ware();

			myWinningBids.DataSource = objwareList.GetMyWinningBids(intUserID);

			myWinningBids.DataBind();
		}

		public void myWinningBids_wareCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType  == ListItemType.Item ||e.Item.ItemType == ListItemType.AlternatingItem )
			{
				HyperLink temphypAcceptBid;
				temphypAcceptBid = (HyperLink)e.Item.FindControl("hypwareName");
				temphypAcceptBid.Attributes.Add("onclick",
					"return confirm('You are about to buy this product?');");
			}
		}

		public string FormatURL(Int32 intwareID	, Double dblWinningBid)
		{
			return "AcceptBid.aspx?wareid=" + intwareID + "&bid=" + dblWinningBid;
		}

	}
}
