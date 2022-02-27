
namespace student1
{
	/// <summary>
	/// student 的摘要说明。
	/// </summary>
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

	public class student : System.Web.UI.Page
	{
	 

		//学生管理窗口定义控件的声名
		protected CCUtility Utility;
		
		//表格表单，学生变量等的声名
		protected System.Web.UI.HtmlControls.HtmlTableRow emps_no_records;
		protected string emps_sSQL;
		protected string emps_sCountSQL;
		protected int emps_CountPage;		
		protected System.Web.UI.WebControls.LinkButton emps_insert;
		protected System.Web.UI.WebControls.Repeater emps_Repeater;
		protected int i_emps_curpage=1;	
	
		//查询表单、变量等的声名
		protected System.Web.UI.WebControls.Button Search_search_button;
		protected System.Web.UI.WebControls.TextBox Search_emp_login;
		protected System.Web.UI.WebControls.TextBox Search_name;
		
		//定义各表单事件保护字符串
		protected string emps_FormAction="studentedit.aspx?";
		protected System.Web.UI.WebControls.Label SearchForm_Title;
		protected System.Web.UI.WebControls.Label InfoForm_Title;
		protected System.Web.UI.WebControls.Label emps_Column_emp_id;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList Search_class;
		
		protected string Search_FormAction="student.aspx?";
		

		//初始化事件	
		public student()
		{
			this.Init += new System.EventHandler(Page_Init);
		}
	
		// EmpsGrid中的自定义包含控件结束

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

		//窗口中控件定义事件处理过程
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
			this.Search_search_button.Click += new System.EventHandler(this.Search_search_Click);
			this.emps_insert.Click += new System.EventHandler(this.emps_insert_Click);
			this.Unload += new System.EventHandler(this.Page_Unload);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		//定义整体显示页面过程
		protected void Page_Show(object sender, EventArgs e)
		{
			emps_Bind();
			Search_Show();
		
		}
     	// EmpsGrid Show end
		//完成表单初始化

		//定义表格每页显示学生记录条数
		const int emps_PAGENUM = 20;

		//创建数据库种学生数据记录的数据源集合
		ICollection emps_CreateDataSource() 
		{

       
			//开始定义查询数据Sql字符串
			emps_sSQL = "";
			emps_sCountSQL = "";
			string sWhere = "", sOrder = "";

			bool HasParam = false;

			//建立排序方式
			sOrder = " order by e.name Asc";
			if(Utility.GetParam("Formemps_Sorting").Length>0&&!IsPostBack)
			{
					ViewState["SortColumn"]=Utility.GetParam("Formemps_Sorting");
				ViewState["SortDir"]="ASC";}
			if(ViewState["SortColumn"]!=null) sOrder = " ORDER BY " + ViewState["SortColumn"].ToString()+" "+ViewState["SortDir"].ToString();
	
			//建立学生属性
			System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();
	
	
			if(!Params.ContainsKey("login"))
			{
				string temp=Utility.GetParam("login");
				Params.Add("login",temp);}
	
			if(!Params.ContainsKey("class_id"))
			{
				string temp=Utility.GetParam("class_id");
				if (Utility.IsNumeric(null,temp) && temp.Length>0) { temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);} 
				else {temp = "";}
				Params.Add("class_id",temp);}
	
			if(!Params.ContainsKey("name"))
			{
				string temp=Utility.GetParam("name");
				Params.Add("name",temp);}
	
			if (Params["login"].Length>0) 
			{
				HasParam = true;
				sWhere +="e.[login] like '%" + Params["login"].Replace( "'", "''") +  "%'";
			}
			if (Params["class_id"].Length>0) 
			{
				if (sWhere.Length >0) sWhere +=" and ";
				HasParam = true;
				sWhere +="e.[class_id]=" + Params["class_id"];
			}
			if (Params["name"].Length>0) 
			{
				if (sWhere.Length >0) sWhere +=" and ";
				HasParam = true;
				sWhere +="e.[name] like '%" + Params["name"].Replace( "'", "''") +  "%'";
			}

	
			if(HasParam)
				sWhere = " WHERE (" + sWhere + ")";

			//定制Sql语句

			emps_sSQL = "select [e].[student_id] as e_emp_id, " +
				"[e].[sex] as e_sex, " +
				"[e].[login] as e_emp_login, " +
				"[e].[business] as e_business, " +
				"[e].[name] as e_name " +
				" from [stu] e ";
	
			//装配出完整的Sql语句

			emps_sSQL = emps_sSQL + sWhere + sOrder;
			if (emps_sCountSQL.Length== 0) 
			{
				int iTmpI = emps_sSQL.ToLower().IndexOf("select ");
				int iTmpJ = emps_sSQL.ToLower().LastIndexOf(" from ")-1;
				emps_sCountSQL = emps_sSQL.Replace(emps_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
				iTmpI = emps_sCountSQL.ToLower().IndexOf(" order by");
				if (iTmpI > 1) emps_sCountSQL = emps_sCountSQL.Substring(0, iTmpI);
			}
	  
	  
			//联结数据库，读取数据	
			SqlDataAdapter command = new SqlDataAdapter(emps_sSQL, Utility.Connection);
			DataSet ds = new DataSet();
	
			command.Fill(ds, (i_emps_curpage - 1) * emps_PAGENUM, emps_PAGENUM,"stu");
			SqlCommand ccommand = new SqlCommand(emps_sCountSQL, Utility.Connection);
			int PageTemp=(int)ccommand.ExecuteScalar();
			
			
	
			DataView Source;
			Source = new DataView(ds.Tables[0]);

			if (ds.Tables[0].Rows.Count == 0)
			{
				emps_no_records.Visible = true;
				}
			else
			{
					emps_no_records.Visible = false;
				}
		
			
			return Source;
		
		}

		
		//绑定数据
		void emps_Bind() 
		{
			emps_Repeater.DataSource = emps_CreateDataSource();
			emps_Repeater.DataBind();
		
		}

		//加入新学生记录过程
		void emps_insert_Click(Object Src, EventArgs E) 
		{
			string sURL = emps_FormAction+"login=" + Server.UrlEncode(Utility.GetParam("login")) + "&class_id=" + Server.UrlEncode(Utility.GetParam("class_id")) + "&name=" + Server.UrlEncode(Utility.GetParam("name")) + "&";
			Response.Redirect(sURL);
		}
		
		//查询显示过程
		void Search_Show() 
		{			
			string s;

			s=Utility.GetParam("login");
			Search_emp_login.Text = s;
	
			s=Utility.GetParam("name");
			Search_name.Text = s;
	
			

			Utility.buildListBox(Search_class.Items,"select class_id,class from class order by 2","class_id","class","ALL Class","");
		
			s=Utility.GetParam("class_id");

			try 
			{
				Search_class.SelectedIndex=Search_class.Items.IndexOf(Search_class.Items.FindByValue(s));
			}
			catch{}			
			
		}

		//查询过程事件
		void Search_search_Click(Object Src, EventArgs E) 
		{
			string sURL = Search_FormAction + "login="+Search_emp_login.Text+"&"
				+ "name="+Search_name.Text+"&"
				+ "class_id="+Search_class.SelectedItem.Value+"&"
				;
			sURL += "";
			Response.Redirect(sURL);
		}

	}
}