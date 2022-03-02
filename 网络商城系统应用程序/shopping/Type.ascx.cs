namespace shopping
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Type 的摘要说明。
	/// </summary>
	public class Type : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataList MyList;
		public Type() 
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			String selectedId = Request.Params["selection"];

			if (selectedId != null)
			{
				MyList.SelectedIndex = Int32.Parse(selectedId);
			}

			//调用数据库访问类获取商品类别信息并绑定到控件
			shopping.IStoreDBO  info = new shopping.IStoreDBO();
			MyList.DataSource  = info.Getwaretype();
			MyList.DataBind(); 
		}
		private void Page_Init(object sender, EventArgs e) 
		{
			
			InitializeComponent();
		}

		#region Web 窗体设计器生成的代码
		
		
		/// <summary>
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
