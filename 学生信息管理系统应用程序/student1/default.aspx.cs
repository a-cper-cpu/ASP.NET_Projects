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

	public class Default : System.Web.UI.Page

	{ 



		//����Ĭ�Ͽؼ�����
		protected CCUtility Utility;
		//��¼���������ȵ�����
		protected System.Web.UI.WebControls.TextBox Login_name;
		protected System.Web.UI.WebControls.TextBox Login_password;
		protected System.Web.UI.WebControls.Button Login_login;
		protected System.Web.UI.HtmlControls.HtmlTableRow Login_trname;
		protected System.Web.UI.HtmlControls.HtmlTableRow Login_trpassword;
		protected System.Web.UI.WebControls.Label Login_labelname;
		protected System.Web.UI.WebControls.Label Login_message;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Login_querystring;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Login_ret_page; 

		//��������ؿ��Ʊ�������
		protected System.Web.UI.HtmlControls.HtmlTableRow Grid_no_records;
		protected System.Web.UI.HtmlControls.HtmlTableRow AdminList_Title;
		protected System.Web.UI.HtmlControls.HtmlTableRow AdminStu_Title;
		protected System.Web.UI.HtmlControls.HtmlTableRow AdminClass_Title;
		protected string Grid_sSQL;
		protected string Grid_sCountSQL;
		protected int Grid_CountPage;
	
		protected System.Web.UI.WebControls.Repeater Grid_Repeater;
		protected int i_Grid_curpage=1;	

		//��ѯ������ؿ��Ʊ�������
		protected System.Web.UI.WebControls.Button Search_search_button;
		protected System.Web.UI.WebControls.DropDownList Search_class_id;
		protected System.Web.UI.WebControls.TextBox Search_name;
		protected System.Web.UI.WebControls.TextBox Search_business;
	
		//ÿ��֮��ѧ����¼������ر�������
		protected System.Web.UI.HtmlControls.HtmlTableRow EmpMonth_no_records;
		protected string EmpMonth_sSQL;
		protected string EmpMonth_sCountSQL;
		protected int EmpMonth_CountPage;
	
		protected System.Web.UI.WebControls.Repeater EmpMonth_Repeater;
		protected int i_EmpMonth_curpage=1;	

		//ÿ����Ӧ���¼������ַ���
		protected string Grid_FormAction=".aspx?";
		protected string Search_FormAction="Default.aspx?";
		protected System.Web.UI.WebControls.Label LoginForm_Title;
		protected System.Web.UI.WebControls.HyperLink Form_Field2;
		protected System.Web.UI.WebControls.HyperLink Form_Field1;
		protected System.Web.UI.WebControls.Label SearchForm_Title;
		protected System.Web.UI.WebControls.Label EmpMonthForm_Title;
		protected string EmpMonth_FormAction=".aspx?";

		public Default()
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		//Ĭ���Զ���ؼ���������

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

		// Default Show begin
		protected void Page_Load(object sender, EventArgs e)
		{	
			Utility=new CCUtility(this);
			if (Session["UserID"] != null && Int16.Parse(Session["UserID"].ToString()) > 0)
				Login_logged = true;
			//�������װ��ҳ�棬ִ��Page_Show
			if (!IsPostBack)
			{
				AdminList_Title.Visible = false;
				AdminStu_Title.Visible = false;
				AdminClass_Title.Visible = false;		
				Page_Show(sender, e);
			}
		}

		//�ر�ҳ�����
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
			this.Login_login.Click += new System.EventHandler(this.Login_login_Click);
			this.Search_search_button.Click += new System.EventHandler(this.Search_search_Click);
			this.Unload += new System.EventHandler(this.Page_Unload);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		//ҳ���е�������ʾ����
		protected void Page_Show(object sender, EventArgs e)
		{
			Grid_Bind();
			Search_Show();
			EmpMonth_Bind();
			Login_Show();
		}

		// Default Show end
		//��ɱ���ʼ��

		//�����¼�Ŀ��Ʊ�������ʼֵΪfalse����֤��ȫ����
		protected bool Login_logged = false;
		//��¼����ʾ���̺���
		void Login_Show() 
		{
			if (Login_logged) 
			{
				//��¼�ɹ��Ĵ���		
				Login_login.Text = "�˳�";
				Login_trpassword.Visible = false;
				Login_trname.Visible = false;
				Login_labelname.Visible = true;
				Login_labelname.Text = Utility.Dlookup("stu", "login", "student_id=" + Session["UserID"]) + "&nbsp;&nbsp;&nbsp;";
				Utility=new CCUtility(this);
				if (Utility.CheckSecurity(3))
				{
					AdminList_Title.Visible = true;
					AdminStu_Title.Visible = true;
					AdminClass_Title.Visible = true;	
				}
			} 
			else 
			{
				//δ��¼�Ĵ���
				Login_login.Text = "��¼";
				Login_trpassword.Visible = true;
				Login_trname.Visible = true;
				Login_labelname.Visible = false;
				AdminList_Title.Visible = false;
				AdminStu_Title.Visible = false;
				AdminClass_Title.Visible = false;
			}
		}

		//��֤��¼�¼�
		void Login_login_Click(Object Src, EventArgs E) 
		{
			if (Login_logged) 
			{
				//�Ѿ���¼�ɹ����˳���¼
				Login_logged = false;
				Session["UserID"] = 0;
				Session["UserRights"] = 0;
				Login_Show();
	
			} 
			else 
			{
				//���е�¼��֤
				int iPassed = Convert.ToInt32(Utility.Dlookup("stu", "count(*)", "login ='" + Login_name.Text + "' and password='" + CCUtility.Quote(Login_password.Text) + "'"));
				if (iPassed > 0) 
				{
					Login_message.Visible = false;
					Session["UserID"] = Convert.ToInt32(Utility.Dlookup("stu", "student_id", "login ='" + Login_name.Text + "' and password='" + CCUtility.Quote(Login_password.Text) +"'"));
					Login_logged = true;
		
					Session["UserRights"] = Convert.ToInt32(Utility.Dlookup("stu", "stu_level", "login ='" + Login_name.Text + "' and password='" + CCUtility.Quote(Login_password.Text) + "'"));
		
					string sQueryString = Utility.GetParam("querystring");
					string sPage = Utility.GetParam("ret_page");
					if (! sPage.Equals(Request.ServerVariables["SCRIPT_NAME"]) && sPage.Length > 0) 
					{
						Response.Redirect(sPage + "?" + sQueryString);
					} 
					else 
					{
			
						Response.Redirect(Search_FormAction);
					}
				} 
				else 
				{
					Login_message.Visible = true;
				}
			

			}
		}

		//����ÿҳ��ʾ��¼����
		const int Grid_PAGENUM = 10;

		public void Grid_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
		{

			
			if (e.Item.ItemType==ListItemType.Item  || e.Item.ItemType==ListItemType.AlternatingItem   )
			{
				((Label)e.Item.FindControl("Grid_email")).Text ="<a href=\"mailto:" + ((DataRowView)e.Item.DataItem )["e_email"].ToString() + "\">" + ((DataRowView)e.Item.DataItem )["e_email"].ToString() + "</a>";
			}
		
		}


		ICollection Grid_CreateDataSource() 
		{

    
			//��ʼ������ʾ����
			Grid_sSQL = "";
			Grid_sCountSQL = "";

			string sWhere = "", sOrder = "";


			bool HasParam = false;

			//��������ʽ
			sOrder = " order by e.name Asc";
			if(Utility.GetParam("FormGrid_Sorting").Length>0&&!IsPostBack)
			{
					ViewState["SortColumn"]=Utility.GetParam("FormGrid_Sorting");
				ViewState["SortDir"]="ASC";}
			if(ViewState["SortColumn"]!=null) sOrder = " ORDER BY " + ViewState["SortColumn"].ToString()+" "+ViewState["SortDir"].ToString();

			//����ѧ������
			System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();


			if(!Params.ContainsKey("class_id"))
			{
				string temp=Utility.GetParam("class_id");
				if (Utility.IsNumeric(null,temp) && temp.Length>0) { temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);} 
				else {temp = "";}
				Params.Add("class_id",temp);}

			if(!Params.ContainsKey("email"))
			{
				string temp=Utility.GetParam("business");
				Params.Add("business",temp);}

			if(!Params.ContainsKey("name"))
			{
				string temp=Utility.GetParam("name");
				Params.Add("name",temp);}

			if (Params["class_id"].Length>0) 
			{
				HasParam = true;
				sWhere +="e.[class_id]=" + Params["class_id"];
			}
			if (Params["business"].Length>0) 
			{
				if (sWhere.Length >0) sWhere +=" and ";
				HasParam = true;
				sWhere +="e.[business] like '%" + Params["business"].Replace( "'", "''") +  "%'";
			}
			if (Params["name"].Length>0) 
			{
				if (sWhere.Length >0) sWhere +=" and ";
				HasParam = true;
				sWhere +="e.[name] like '%" + Params["name"].Replace( "'", "''") +  "%'";
			}


			if(HasParam)
				sWhere = " AND (" + sWhere + ")";

			//����Sql���

			Grid_sSQL = "select [e].[class_id] as e_class_id, " +
				"[e].[email] as e_email, " +
				"[e].[student_id] as e_student_id, " +
				"[e].[name] as e_name, " +
				"[e].[sex] as e_no, " +
				"[e].[business] as e_business, " +	
				"[e].[work_ph] as e_work_ph, " +
				"[d].[class_id] as d_class_id, " +
				"[d].[class] as d_class " +
				" from [stu] e, [class] d" +
				" where [d].[class_id]=e.[class_id]  ";

			//װ���������Sql���
			Grid_sSQL = Grid_sSQL + sWhere + sOrder;

			SqlDataAdapter command = new SqlDataAdapter(Grid_sSQL, Utility.Connection);
			DataSet ds = new DataSet();
	
			command.Fill(ds, 0, Grid_PAGENUM, "Grid");
			DataView Source;
			Source = new DataView(ds.Tables[0]);

			if (ds.Tables[0].Rows.Count == 0)
			{
				Grid_no_records.Visible = true;
			}
			else
			{
					Grid_no_records.Visible = false;
			}
	
	
			return Source;
			//�����ʾ�������		
		}

		//���ݰ󶨹���
		void Grid_Bind() 
		{
			Grid_Repeater.DataSource = Grid_CreateDataSource();
			Grid_Repeater.DataBind();
	
		}
		//��¼����ʽ�ı�

		//��ѯ��ʾʱ��ȡ���ݹ���
		void Search_Show() 
		{


			Utility.buildListBox(Search_class_id.Items,"select class_id,class from class order by 2","class_id","class","ALL Class","");
			string s;

			s=Utility.GetParam("class_id");

			try 
			{
				Search_class_id.SelectedIndex=Search_class_id.Items.IndexOf(Search_class_id.Items.FindByValue(s));
			}
			catch{}

			s=Utility.GetParam("name");
			Search_name.Text = s;

			s=Utility.GetParam("business");
			Search_business.Text = s;
		}

		//��ѯ�ύ����
		void Search_search_Click(Object Src, EventArgs E) 
		{
			string sURL;
			sURL = Search_FormAction + "class_id="+Search_class_id.SelectedItem.Value+"&"
				+ "name="+Search_name.Text+"&"
				+ "business="+Search_business.Text+"&";
			//���Ʋ�ѯ���
			sURL += "";
			Response.Redirect(sURL);
		}



		//�����ʾ��¼��
		const int EmpMonth_PAGENUM = 20;


		//��ѯ���ϡ�ÿ��֮�ǡ�ѧ���ļ�¼����
		ICollection EmpMonth_CreateDataSource() 
		{

    
			EmpMonth_sSQL = "";
			EmpMonth_sCountSQL = "";

			string sWhere = "", sOrder = "";


			System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();

			//�����Ӧ�Ĳ�ѯSql���
			sWhere = " WHERE super=1";

			EmpMonth_sSQL = "select [e].[name] as e_name, [e].[student_id] as e_student_id," +
				"[e].[sex] as e_sex " +
				" from [stu] e ";

			EmpMonth_sSQL = EmpMonth_sSQL + sWhere + sOrder;

			//�������ݿ⣬ʵ�ֲ�ѯ	
			SqlDataAdapter command = new SqlDataAdapter(EmpMonth_sSQL, Utility.Connection);
			DataSet ds = new DataSet();
	
			command.Fill(ds, 0, EmpMonth_PAGENUM, "EmpMonth");
			DataView Source;
			Source = new DataView(ds.Tables[0]);

			if (ds.Tables[0].Rows.Count == 0)
			{
				EmpMonth_no_records.Visible = true;
			}
			else
			{
					EmpMonth_no_records.Visible = false;
			}
	
	
			return Source;
	
		}

		//�󶨲�ѯ���
		void EmpMonth_Bind() 
		{
			EmpMonth_Repeater.DataSource = EmpMonth_CreateDataSource();
			EmpMonth_Repeater.DataBind();
	
		}		
	}
}