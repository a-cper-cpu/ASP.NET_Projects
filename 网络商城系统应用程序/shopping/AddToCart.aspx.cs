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
	/// AddToCart ��ժҪ˵����
	/// </summary>
	public class AddToCart : System.Web.UI.Page
	{
		
		public AddToCart() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (Request.Params["wareID"] != null) 
			{
        
				shopping.IStoreDBO cart = new shopping.IStoreDBO();
            
				// Obtain current user's shopping cart ID  
				String cartId = cart.GetShoppingCartId();   
            
				// Add Product Item to Cart
				cart.AddItemtoShoppingCart(cartId, Int32.Parse(Request.Params["wareID"]), 1);
			}  
        
			Response.Redirect("ShoppingCart.aspx");
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
