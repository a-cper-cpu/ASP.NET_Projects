namespace student1
{
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
	using System.Data.SqlClient;	

	public class _class : System.Web.UI.Page

	{ 

		//部门管理窗口自定义控件的声名
		protected CCUtility Utility;
	
		//数据表格表单、变量等的声名
		protected System.Web.UI.HtmlControls.HtmlTableRow class_no_records;
		protected string class_sSQL;
		protected string class_sCountSQL;
		protected int class_CountPage;	
		protected System.Web.UI.WebControls.LinkButton class_insert;
		protected System.Web.UI.WebControls.Repeater class_Repeater;
		protected int i_class_curpage=1;
		protected System.Web.UI.WebControls.Label ClassForm_Title;	

		//定义各表单事件保护字符串
		protected string class_FormAction="classedit.aspx?";
	
		//初始化事件对象
		public _class()
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
			Utility.CheckSecurity(3);
			// 完成窗口安全验证
			if (!IsPostBack)
			{
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.Unload += new System.EventHandler(this.Page_Unload);
			class_insert.Click += new System.EventHandler (this.class_insert_Click);					
		}

		//定义整体显示页面过程
		protected void Page_Show(object sender, EventArgs e)
		{
			class_Bind();
		}
		// classGrid Show end
		//完成表单初始化

		//定义每一页显示的部门记录数
		const int class_PAGENUM = 20;

		//查询数据库中部门记录数据集合
		ICollection class_CreateDataSource() 
		{

			class_sSQL = "";
			class_sCountSQL = "";	
				
			if(Utility.GetParam("Formdeps_Sorting").Length>0&&!IsPostBack)
			{
				ViewState["SortColumn"]=Utility.GetParam("Formdeps_Sorting");
				ViewState["SortDir"]="ASC";}			
	
			System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();
	
			class_sSQL = "select [d].[class_id] as d_class_id, " +
				"[d].[class] as d_name " +
				" from [class] d ";				
			if (class_sCountSQL.Length== 0) 
			{
				int iTmpI = class_sSQL.ToLower().IndexOf("select ");
				int iTmpJ = class_sSQL.ToLower().LastIndexOf(" from ")-1;
				class_sCountSQL = class_sSQL.Replace(class_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
				iTmpI = class_sCountSQL.ToLower().IndexOf(" order by");
				if (iTmpI > 1) class_sCountSQL = class_sCountSQL.Substring(0, iTmpI);
			}
	  
			//连接数据库
	
			SqlDataAdapter command = new SqlDataAdapter(class_sSQL, Utility.Connection);
			DataSet ds = new DataSet();
	
			command.Fill(ds, (i_class_curpage - 1) * class_PAGENUM, class_PAGENUM,"class");
			SqlCommand ccommand = new SqlCommand(class_sCountSQL, Utility.Connection);
			int PageTemp=(int)ccommand.ExecuteScalar();		
			DataView Source;
			Source = new DataView(ds.Tables[0]);

			if (ds.Tables[0].Rows.Count == 0)
			{
				class_no_records.Visible = true;
				}
			else
			{
				class_no_records.Visible = false;
				}
		
			
			return Source;
			//显示完成		
		}
	
	

		//绑定数据
		void class_Bind() 
		{
			class_Repeater.DataSource = class_CreateDataSource();
			class_Repeater.DataBind();
		
		}

		//插入按钮事件
		void class_insert_Click(Object Src, EventArgs E) 
		{
			string sURL = class_FormAction+"";
			Response.Redirect(sURL);
		}
	}
}