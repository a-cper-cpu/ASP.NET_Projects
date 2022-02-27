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

	public class classedit : System.Web.UI.Page
	
	{ 

		//更新窗口定义控件的声名
		protected CCUtility Utility;
		
		//更新记录表单、变量等的声名
		protected System.Web.UI.WebControls.Label cl_ValidationSummary;
		protected System.Web.UI.HtmlControls.HtmlInputButton cl_insert;
		protected System.Web.UI.HtmlControls.HtmlInputButton cl_update;
		protected System.Web.UI.HtmlControls.HtmlInputButton cl_delete;
		protected System.Web.UI.HtmlControls.HtmlInputButton cl_cancel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden cl_class_id;
		protected System.Web.UI.WebControls.TextBox cl_name;
		
		//定义各表单事件保护字符串

		protected string deps_FormAction="class.aspx?";
		protected System.Web.UI.HtmlControls.HtmlInputHidden p_cl_class_id;

		//初始化事件
		public classedit()
		{
			this.Init += new System.EventHandler(Page_Init);
		}
		//classRecord中的自定义包含控件结束

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
			
				p_cl_class_id.Value = Utility.GetParam("class_id");
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
			cl_insert.ServerClick += new System.EventHandler (this.deps_Action);
			cl_update.ServerClick += new System.EventHandler (this.deps_Action);
			cl_delete.ServerClick += new System.EventHandler (this.deps_Action);
			cl_cancel.ServerClick += new System.EventHandler (this.deps_Action);
		
		}

		//定义整体显示页面过程
		protected void Page_Show(object sender, EventArgs e)
		{
			deps_Show();
		
		}
		// classRecord Show end
		//完成表单初始化

		//定义控制函数，控制按钮的的显示与否
		//如，当插入记录时，应显示插入、取消按钮，而修改时应显示修改、删除、取消按钮
		private bool deps_Validate()
		{
			bool result=true;
			cl_ValidationSummary.Text="";

			for(int i=0;i<Page.Validators.Count;i++)
			{
				if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("class"))
				{
					if(!Page.Validators[i].IsValid)
					{
						cl_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
						result=false;
					}
				}
			}
			cl_ValidationSummary.Visible=(!result);
			return result;
		}

		//更新记录的显示过程
		void deps_Show() 
		{
	
			bool ActionInsert=true;
	
			if (p_cl_class_id.Value.Length > 0 ) 
			{
				string sWhere = "";		
				sWhere += "class_id=" + CCUtility.ToSQL(p_cl_class_id.Value, CCUtility.FIELD_TYPE_Number);		
				string sSQL = "select * from class where " + sWhere;
				SqlDataAdapter dsCommand = new SqlDataAdapter(sSQL, Utility.Connection);
				DataSet ds = new DataSet();
				DataRow row;

				if (dsCommand.Fill(ds, 0, 1, "class") > 0) 
				{
					row = ds.Tables[0].Rows[0];				
					cl_class_id.Value = CCUtility.GetValue(row, "class_id");		
					cl_name.Text = CCUtility.GetValue(row, "class");
					cl_insert.Visible=false;
					ActionInsert=false;
				}
				}

			if(ActionInsert)
			{

				String pValue;
				pValue = Utility.GetParam("class_id");
				cl_class_id.Value = pValue;
				cl_delete.Visible=false;
				cl_update.Visible=false;

			}

		}
	
		//插入新记录事件代码
		bool cl_insert_Click(Object Src, EventArgs E) 
		{
			string sSQL="";
			string sql;					
			bool bResult=deps_Validate();
			string rs="";
			if(bResult)
			{			        			
				string p2_name=CCUtility.ToSQL(Utility.GetParam("cl_name"), CCUtility.FIELD_TYPE_Text) ;
				sql="select max(class_id)+1 from class";
				SqlCommand comm = new SqlCommand(sql, Utility.Connection);
				
				SqlDataReader myReader;
				myReader = comm.ExecuteReader();								
				while (myReader.Read())
				{	
					rs += myReader[0].ToString();
					
				}	
				sSQL = "insert into class (class_id,class) values ("+ rs +","+ p2_name + ")";
				myReader.Close();
				SqlCommand cmd = new SqlCommand(sSQL, Utility.Connection);
				try 
				{
					cmd.ExecuteNonQuery();
				} 
				catch(Exception e) 
				{
					cl_ValidationSummary.Text += e.Message;
					cl_ValidationSummary.Visible = true;
					return false;
				}
			}
			return bResult;
		}



		//更新记录事件代码
		bool cl_update_Click(Object Src, EventArgs E) 
		{
			string sWhere = "";
			string sSQL ="";
		
			bool bResult=deps_Validate();
			if(bResult)
			{
		
				if (p_cl_class_id.Value.Length > 0) 
				{
					sWhere = sWhere + "class_id=" + CCUtility.ToSQL(p_cl_class_id.Value, CCUtility.FIELD_TYPE_Number);
				}
		
				if (bResult)
				{
		
					sSQL = "update class set " +
						"[class]=" +CCUtility.ToSQL(Utility.GetParam("cl_name"),CCUtility.FIELD_TYPE_Text) ;

		
					sSQL = sSQL + " where " + sWhere;
		
					SqlCommand cmd = new SqlCommand(sSQL, Utility.Connection);
					try 
					{
						cmd.ExecuteNonQuery();
					} 
					catch(Exception e) 
					{
						cl_ValidationSummary.Text += e.Message;
						cl_ValidationSummary.Visible = true;
						return false;
					}
				}

			}
			return bResult;
		}

		//删除记录代码
		bool cl_delete_Click(Object Src, EventArgs E) 
		{
			string sWhere = "";
	
			if (p_cl_class_id.Value.Length > 0) 
			{
				sWhere += "class_id=" + CCUtility.ToSQL(p_cl_class_id.Value, CCUtility.FIELD_TYPE_Number);
			}
	
			string sSQL = "delete from class where " + sWhere;
	
			SqlCommand cmd = new SqlCommand(sSQL, Utility.Connection);
			try 
			{
				cmd.ExecuteNonQuery();
			} 
			catch(Exception e) 
			{
				cl_ValidationSummary.Text += e.Message;
				cl_ValidationSummary.Visible = true;
				return false;
			}
			return true;
		}

		//取消更新代码
		bool cl_cancel_Click(Object Src, EventArgs E) 
		{
			return true;
		}

		//为各按钮点击事件参数函数代码
		void deps_Action(Object Src, EventArgs E) 
		{
			bool bResult=true;
			if(((HtmlInputButton)Src).ID.IndexOf("insert")>0) bResult=cl_insert_Click(Src,E);
			if(((HtmlInputButton)Src).ID.IndexOf("update")>0) bResult=cl_update_Click(Src,E);
			if(((HtmlInputButton)Src).ID.IndexOf("delete")>0) bResult=cl_delete_Click(Src,E);
			if(((HtmlInputButton)Src).ID.IndexOf("cancel")>0) bResult=cl_cancel_Click(Src,E);
			if(bResult)Response.Redirect(deps_FormAction+"");
		}

	}
}