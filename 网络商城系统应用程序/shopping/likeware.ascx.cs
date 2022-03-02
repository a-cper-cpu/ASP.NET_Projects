namespace shopping
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		likeware ��ժҪ˵����
	/// </summary>
	public class likeware : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater MostPopularwareList;
		public int WareID;
		public likeware() 
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			shopping.IStoreDBO myIStoreDBO = new shopping.IStoreDBO();
			MostPopularwareList.DataSource = myIStoreDBO.GetMostSoldware();
			MostPopularwareList.DataBind();			
            
			if (MostPopularwareList.Items.Count==0)
			{
				MostPopularwareList.Visible = false;
			}
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
