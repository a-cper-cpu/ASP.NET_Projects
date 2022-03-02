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
	/// shoppingcart 的摘要说明。
	/// </summary>
	public class shoppingcart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label MyError;
		protected System.Web.UI.WebControls.DataGrid MyList;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.WebControls.ImageButton UpdateBtn;
		protected System.Web.UI.WebControls.ImageButton CheckoutBtn;
		protected System.Web.UI.WebControls.Panel DetailsPanel;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		public shoppingcart() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (Page.IsPostBack == false) 
			{
				PopulateShoppingCartList();
			}
		}

		#region Web 窗体设计器生成的代码
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.UpdateBtn.Click += new System.Web.UI.ImageClickEventHandler(this.UpdateBtn_Click);
			this.CheckoutBtn.Click += new System.Web.UI.ImageClickEventHandler(this.CheckoutBtn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void UpdateBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			UpdateShoppingCartDatabase();
			PopulateShoppingCartList();
		}

		private void CheckoutBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			UpdateShoppingCartDatabase();

			shopping.IStoreDBO cart = new shopping.IStoreDBO();

			String cartId = cart.GetShoppingCartId();

			if (cart.CountShoppingCartItem(cartId) !=0) 
			{
				Response.Redirect("Checkout.aspx");
			}
			else 
			{
				MyError.Text = "您没有购买商品，不能进入结账页面。";
			}
		}
		void PopulateShoppingCartList() 
		{

			shopping.IStoreDBO cart = new shopping.IStoreDBO();

			String cartId = cart.GetShoppingCartId();

			if (cart.CountShoppingCartItem(cartId) == 0) 
			{
				DetailsPanel.Visible = false;
				MyError.Text = "暂时为空，请购物。";
			}
			else 
			{

				MyList.DataSource = cart.DisplayShoppingCart(cartId);
				MyList.DataBind();

				lblTotal.Text = String.Format( "{0:c}", cart.ShoppingCartTotalCost(cartId));
			}
		}

		void UpdateShoppingCartDatabase() 
		{

			shopping.IStoreDBO cart = new shopping.IStoreDBO();

			String cartId = cart.GetShoppingCartId();

			for (int i=0; i < MyList.Items.Count; i++) 
			{

				//根据控件标识符查找控件，然后构造新的TextBox控件
				TextBox quantityTxt = (TextBox) MyList.Items[i].FindControl("wareQuantity");
				
				CheckBox remove = (CheckBox) MyList.Items[i].FindControl("Remove");

				int quantity;
				try
				{
					quantity = Int32.Parse(quantityTxt.Text);

					//如果某一项商品的数量改变了或者删除该商品的Check控件被选择了，那么调用相应的方法更新数据库
					if (quantity != (int)MyList.DataKeys[i] || remove.Checked == true)
					{

						Label lblProductID = (Label) MyList.Items[i].FindControl("wareID");

						if (quantity == 0 || remove.Checked == true)
						{
							cart.ShoppingCartRemoveItem(cartId, Int32.Parse(lblProductID.Text));
						}
						else
						{
							cart.ShoppingCartUpdate(cartId, Int32.Parse(lblProductID.Text), quantity);
						}
					}
				}
				catch
				{
					//出现异常显示错误信息
					MyError.Text = "您的输入有问题。";
				}
			}
		}

		private void Page_Init(object sender, EventArgs e) 
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
	}
}
