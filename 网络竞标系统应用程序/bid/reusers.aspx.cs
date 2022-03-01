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
	/// reusers ��ժҪ˵����
	/// </summary>
	public class reusers : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUserName;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DataGrid myWinningBids;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��			
			if (Bid.Tools.IsLoggedIn())
				lblUserName.Text = "Welcome <b>" +
					Request.Cookies["email"].Value + "</b><br/>";
			else
				Response.Redirect("Default.aspx");

			if (!Page.IsPostBack)
				BindGrid();

			lblStatus.Text = Request.QueryString["msg"];
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
