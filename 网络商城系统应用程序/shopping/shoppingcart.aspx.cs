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
	/// shoppingcart ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (Page.IsPostBack == false) 
			{
				PopulateShoppingCartList();
			}
		}

		#region Web ������������ɵĴ���
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
				MyError.Text = "��û�й�����Ʒ�����ܽ������ҳ�档";
			}
		}
		void PopulateShoppingCartList() 
		{

			shopping.IStoreDBO cart = new shopping.IStoreDBO();

			String cartId = cart.GetShoppingCartId();

			if (cart.CountShoppingCartItem(cartId) == 0) 
			{
				DetailsPanel.Visible = false;
				MyError.Text = "��ʱΪ�գ��빺�";
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

				//���ݿؼ���ʶ�����ҿؼ���Ȼ�����µ�TextBox�ؼ�
				TextBox quantityTxt = (TextBox) MyList.Items[i].FindControl("wareQuantity");
				
				CheckBox remove = (CheckBox) MyList.Items[i].FindControl("Remove");

				int quantity;
				try
				{
					quantity = Int32.Parse(quantityTxt.Text);

					//���ĳһ����Ʒ�������ı��˻���ɾ������Ʒ��Check�ؼ���ѡ���ˣ���ô������Ӧ�ķ����������ݿ�
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
					//�����쳣��ʾ������Ϣ
					MyError.Text = "�������������⡣";
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
