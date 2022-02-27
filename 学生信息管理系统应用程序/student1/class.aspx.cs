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

		//���Ź������Զ���ؼ�������
		protected CCUtility Utility;
	
		//���ݱ����������ȵ�����
		protected System.Web.UI.HtmlControls.HtmlTableRow class_no_records;
		protected string class_sSQL;
		protected string class_sCountSQL;
		protected int class_CountPage;	
		protected System.Web.UI.WebControls.LinkButton class_insert;
		protected System.Web.UI.WebControls.Repeater class_Repeater;
		protected int i_class_curpage=1;
		protected System.Web.UI.WebControls.Label ClassForm_Title;	

		//��������¼������ַ���
		protected string class_FormAction="classedit.aspx?";
	
		//��ʼ���¼�����
		public _class()
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		//AdminMenu�е��Զ�������ؼ�����
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
		//�����¼������ʾ�ؼ�����
		//��ʼ��ҳ����̣�����һ��Utilityʵ��������������Ӧ�ĸ�����
		protected void Page_Load(object sender, EventArgs e)
		{	
			Utility=new CCUtility(this);
			Utility.CheckSecurity(3);
			// ��ɴ��ڰ�ȫ��֤
			if (!IsPostBack)
			{
				Page_Show(sender, e);
			}
		}

		//ҳ��رչ���
		protected void Page_Unload(object sender, EventArgs e)
		{

			if(Utility!=null) Utility.DBClose();
		}

		//�����пؼ������¼��������
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

		//����������ʾҳ�����
		protected void Page_Show(object sender, EventArgs e)
		{
			class_Bind();
		}
		// classGrid Show end
		//��ɱ���ʼ��

		//����ÿһҳ��ʾ�Ĳ��ż�¼��
		const int class_PAGENUM = 20;

		//��ѯ���ݿ��в��ż�¼���ݼ���
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
	  
			//�������ݿ�
	
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
			//��ʾ���		
		}
	
	

		//������
		void class_Bind() 
		{
			class_Repeater.DataSource = class_CreateDataSource();
			class_Repeater.DataBind();
		
		}

		//���밴ť�¼�
		void class_insert_Click(Object Src, EventArgs E) 
		{
			string sURL = class_FormAction+"";
			Response.Redirect(sURL);
		}
	}
}