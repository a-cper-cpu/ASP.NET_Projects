namespace shopping
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Type ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
			String selectedId = Request.Params["selection"];

			if (selectedId != null)
			{
				MyList.SelectedIndex = Int32.Parse(selectedId);
			}

			//�������ݿ�������ȡ��Ʒ�����Ϣ���󶨵��ؼ�
			shopping.IStoreDBO  info = new shopping.IStoreDBO();
			MyList.DataSource  = info.Getwaretype();
			MyList.DataBind(); 
		}
		private void Page_Init(object sender, EventArgs e) 
		{
			
			InitializeComponent();
		}

		#region Web ������������ɵĴ���
		
		
		/// <summary>
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
