namespace student1
{

	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SqlClient;
	using System.Drawing;
	using System.Web;
	using System.Web.SessionState;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	public class stuDetail : System.Web.UI.Page
	
	{ 



		//职工信息窗口定义控件的声名
		protected CCUtility Utility;
		
		//职工记录表单、变量等的声名		
		protected System.Web.UI.HtmlControls.HtmlInputButton Record_cancel;
		protected System.Web.UI.WebControls.Label Record_name;
		protected System.Web.UI.WebControls.Label Record_email;
		protected System.Web.UI.WebControls.Label Record_address;
		protected System.Web.UI.WebControls.Label Record_student_id;
		protected System.Web.UI.WebControls.Label Record_sex;
		protected System.Web.UI.WebControls.Label Record_business;
		protected System.Web.UI.WebControls.Label Record_class_id;
		protected System.Web.UI.WebControls.Label Record_work_ph;
		protected System.Web.UI.WebControls.Label Record_mobile_ph;
		protected System.Web.UI.WebControls.Label Record_home_ph;
		
		
		//定义各表单事件保护字符串
		
		protected System.Web.UI.HtmlControls.HtmlInputHidden p_Record_student_id;

		//初始化事件	
		public stuDetail()
		{
			this.Init += new System.EventHandler(Page_Init);
		}
		//AdminMenu中的自定义包含控件结束

		public void ValidateNumeric(object source, ServerValidateEventArgs args) 
		{
			try
			{
				Decimal temp=Decimal.Parse(args.Value);
				args.IsValid=true;
			}
			catch
			{
				args.IsValid=false;	}
		}

		//定义登录窗口显示控件过程
		//初始化页面过程，创建一个Utility实例，并调用其相应的各方法
		protected void Page_Load(object sender, EventArgs e)
		{	
			Utility=new CCUtility(this);

			if (!IsPostBack)
			{
			
				p_Record_student_id.Value = Utility.GetParam("student_id");
				Page_Show(sender, e);
			}
		}

		//页面关闭过程
		protected void Page_Unload(object sender, EventArgs e)
		{
			if(Utility!=null) Utility.DBClose();
		}

		//窗口中控件定义事件处理过程
		protected void Page_Init(object sender, EventArgs e)
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.Record_cancel.ServerClick += new System.EventHandler(this.Record_cancel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		//定义整体显示页面过程
		protected void Page_Show(object sender, EventArgs e)
		{
			Record_Show();
		
		}



		// EmpDetail Show end
		//完成表单初始化


		//职工信息显示过程
		void Record_Show() 
		{
	
			bool ActionInsert=true;
	
			if (p_Record_student_id.Value.Length > 0 ) 
			{
				string sWhere = "";
		
				sWhere += "student_id=" + CCUtility.ToSQL(p_Record_student_id.Value, CCUtility.FIELD_TYPE_Number);
				string sSQL = "select * from stu where " + sWhere;
				SqlDataAdapter dsCommand = new SqlDataAdapter(sSQL, Utility.Connection);
				DataSet ds = new DataSet();
				DataRow row;

				if (dsCommand.Fill(ds, 0, 1, "Record") > 0) 
				{
					row = ds.Tables[0].Rows[0];
					//显示数据				
					Record_student_id.Text =Server.HtmlEncode(CCUtility.GetValue(row, "student_id").ToString());
					Record_name.Text =Server.HtmlEncode(CCUtility.GetValue(row, "name").ToString());
					Record_sex.Text =Server.HtmlEncode(CCUtility.GetValue(row, "sex").ToString());
					Record_business.Text =Server.HtmlEncode(CCUtility.GetValue(row, "business").ToString());
					Record_class_id.Text =Server.HtmlEncode(	Utility.Dlookup("class", "class", "class_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "class_id"), CCUtility.FIELD_TYPE_Number)).ToString());
					Record_email.Text =CCUtility.GetValue(row, "email");
					Record_work_ph.Text =Server.HtmlEncode(CCUtility.GetValue(row, "work_ph").ToString());
					Record_mobile_ph.Text =Server.HtmlEncode(CCUtility.GetValue(row, "mobile_ph").ToString());
					Record_home_ph.Text =Server.HtmlEncode(CCUtility.GetValue(row, "home_ph").ToString());
					Record_address.Text =Server.HtmlEncode(CCUtility.GetValue(row, "address").ToString());
					
					ActionInsert=false;
		
				}
			}

			if(ActionInsert)
			{

				String pValue;

				pValue = Utility.GetParam("name");
				Record_name.Text = pValue;
				pValue = Utility.GetParam("class_id");
				if (pValue.Length>0){Record_class_id.Text = Utility.Dlookup("class", "class", "class_id=" + pValue);}
				pValue = Utility.GetParam("email");Record_email.Text = pValue;
			}

			//Email的超链接
			Record_email.Text="<a href=\"mailto:" + Record_email.Text + "\">" + Record_email.Text + "</a>";
		}
	

		private void Record_cancel_ServerClick(object sender, System.EventArgs e)
		{
			Response.Redirect("default.aspx");
		}
		//事件结束



	}
}