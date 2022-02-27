

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
	/// <summary>
	/// studentedit 的摘要说明。
	/// </summary>
	public class studentedit : System.Web.UI.Page
	{
	
		//更新窗口定义控件的声名
		protected CCUtility Utility;
		
		//更新记录表单、变量等的声名
		protected System.Web.UI.WebControls.Label stu_ValidationSummary;
		protected System.Web.UI.HtmlControls.HtmlInputButton stu_insert;
		protected System.Web.UI.HtmlControls.HtmlInputButton stu_update;
		protected System.Web.UI.HtmlControls.HtmlInputButton stu_delete;
		protected System.Web.UI.HtmlControls.HtmlInputButton stu_cancel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden stu_student_id;
		protected System.Web.UI.WebControls.TextBox stu_name;
		protected System.Web.UI.WebControls.TextBox stu_sex;
		protected System.Web.UI.WebControls.TextBox stu_business;
		protected System.Web.UI.WebControls.TextBox stu_student_login;
		protected System.Web.UI.WebControls.TextBox stu_student_password;
		protected System.Web.UI.WebControls.DropDownList stu_student_level;
		protected System.Web.UI.WebControls.DropDownList stu_class_id;
		protected System.Web.UI.WebControls.TextBox stu_address;
		protected System.Web.UI.WebControls.TextBox stu_email;
		protected System.Web.UI.WebControls.TextBox stu_work_phone;
		protected System.Web.UI.WebControls.TextBox stu_home_phone;
		protected System.Web.UI.WebControls.TextBox stu_mobile_phone;
		protected System.Web.UI.WebControls.CheckBox stu_super;
		protected System.Web.UI.WebControls.TextBox stu_age;
		
		//定义各表单事件保护字符串
		protected string stu_FormAction="student.aspx?";
		protected System.Web.UI.HtmlControls.HtmlInputHidden p_stu_student_id;
		protected String[] stu_student_level_lov = "0;None;3;Admin".Split(new Char[] {';'});

		//初始化事件	
		public studentedit()
		{
			this.Init += new System.EventHandler(Page_Init);
		}

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
			
				p_stu_student_id.Value = Utility.GetParam("student_id");Page_Show(sender, e);
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
			stu_insert.ServerClick += new System.EventHandler (this.stu_Action);
			stu_update.ServerClick += new System.EventHandler (this.stu_Action);
			stu_delete.ServerClick += new System.EventHandler (this.stu_Action);
			stu_cancel.ServerClick += new System.EventHandler (this.stu_Action);
		
		}

		//定义整体显示页面过程
		protected void Page_Show(object sender, EventArgs e)
		{
			emps_Show();
		
		}
		
		//完成表单初始化


		//定义控制函数，控制按钮的的显示与否		
		private bool emps_Validate()
		{
			bool result=true;
			stu_ValidationSummary.Text="";

			for(int i=0;i<Page.Validators.Count;i++)
			{
				if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("stu"))
				{
					if(!Page.Validators[i].IsValid)
					{
						stu_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
						result=false;
					}
				}
			}

			stu_ValidationSummary.Visible=(!result);
			return result;
		}

		//更新记录显示过程
		void emps_Show() 
		{
	
			Utility.buildListBox(stu_student_level.Items,stu_student_level_lov,null,"");
			Utility.buildListBox(stu_class_id.Items,"select class_id,class from class order by 2","class_id","class",null,"");

			bool ActionInsert=true;
	
			if (p_stu_student_id.Value.Length > 0 ) 
			{
				string sWhere = "";
		
				sWhere += "student_id=" + CCUtility.ToSQL(p_stu_student_id.Value, CCUtility.FIELD_TYPE_Number);
		
				string sSQL = "select * from stu where " + sWhere;
				SqlDataAdapter dsCommand = new SqlDataAdapter(sSQL, Utility.Connection);
				DataSet ds = new DataSet();
				DataRow row;

				if (dsCommand.Fill(ds, 0, 1, "stu") > 0) 
				{
					row = ds.Tables[0].Rows[0];
				
					stu_student_id.Value = CCUtility.GetValue(row, "student_id");
					stu_name.Text = CCUtility.GetValue(row, "name");
					stu_sex.Text = CCUtility.GetValue(row, "sex");
					stu_business.Text = CCUtility.GetValue(row, "business");
					stu_student_login.Text = CCUtility.GetValue(row, "login");
					stu_student_password.Text = CCUtility.GetValue(row, "password");
	
				{
						string s;
					s=CCUtility.GetValue(row, "stu_level");
		
					try 
					{
						stu_student_level.SelectedIndex=stu_student_level.Items.IndexOf(stu_student_level.Items.FindByValue(s));
					}
					catch{}
					}
		

	
				{
						string s;
					s=CCUtility.GetValue(row, "class_id");
		
					try 
					{
						stu_class_id.SelectedIndex=stu_class_id.Items.IndexOf(stu_class_id.Items.FindByValue(s));
					}
					catch{}
					}
		

					stu_address.Text = CCUtility.GetValue(row, "address");
		

					stu_email.Text = CCUtility.GetValue(row, "email");
					stu_work_phone.Text = CCUtility.GetValue(row, "work_ph");
					stu_home_phone.Text = CCUtility.GetValue(row, "home_ph");
					stu_mobile_phone.Text = CCUtility.GetValue(row, "mobile_ph");
					stu_super.Checked=CCUtility.GetValue(row, "super").ToLower().Equals("1".ToLower());
	
					stu_age.Text = CCUtility.GetValue(row, "age");
					stu_insert.Visible=false;
					ActionInsert=false;

				}
				}

			if(ActionInsert)
			{

				String pValue;

				pValue = Utility.GetParam("student_id");stu_student_id.Value = pValue;
				stu_delete.Visible=false;
				stu_update.Visible=false;
	
			}
		}

		//插入新记录事件代码
		bool stu_insert_Click(Object Src, EventArgs E) 
		{
			string sSQL="";
			bool bResult=emps_Validate();
		
		{
				int iCount = Utility.DlookupInt("stu", "count(*)", "login=" + CCUtility.ToSQL(Utility.GetParam("stu_student_login"), CCUtility.FIELD_TYPE_Text));
			if (iCount!=0)
			{
				stu_ValidationSummary.Visible=true;
				stu_ValidationSummary.Text+="The value in field Login is already in database."+"<br>";
				bResult=false;}
			}
		
			if(bResult)
			{	
		        
				string zh_id="";
				string sql;	
				string zh_name=CCUtility.ToSQL(Utility.GetParam("stu_name"), CCUtility.FIELD_TYPE_Text) ;
				string zh_sex=CCUtility.ToSQL(Utility.GetParam("stu_sex"), CCUtility.FIELD_TYPE_Text) ;
				string zh_age=CCUtility.ToSQL(Utility.GetParam("stu_age"), CCUtility.FIELD_TYPE_Text) ;
				string zh_business=CCUtility.ToSQL(Utility.GetParam("stu_business"), CCUtility.FIELD_TYPE_Text) ;
				string zh_login=CCUtility.ToSQL(Utility.GetParam("stu_student_login"), CCUtility.FIELD_TYPE_Text) ;
				string zh_password=CCUtility.ToSQL(Utility.GetParam("stu_student_password"), CCUtility.FIELD_TYPE_Text) ;
				string zh_level=CCUtility.ToSQL(Utility.GetParam("stu_student_level"), CCUtility.FIELD_TYPE_Number) ;
				string zh_class_id=CCUtility.ToSQL(Utility.GetParam("stu_class_id"), CCUtility.FIELD_TYPE_Number) ;
				string zh_address=CCUtility.ToSQL(Utility.GetParam("stu_address"), CCUtility.FIELD_TYPE_Text) ;
				string zh_email=CCUtility.ToSQL(Utility.GetParam("stu_email"), CCUtility.FIELD_TYPE_Text) ;
				string zh_work_phone=CCUtility.ToSQL(Utility.GetParam("stu_work_phone"), CCUtility.FIELD_TYPE_Text) ;
				string zh_home_phone=CCUtility.ToSQL(Utility.GetParam("stu_home_phone"), CCUtility.FIELD_TYPE_Text) ;
				string zh_mobile_phone=CCUtility.ToSQL(Utility.GetParam("stu_mobile_phone"), CCUtility.FIELD_TYPE_Text) ;
				string zh_super=CCUtility.getCheckBoxValue(Utility.GetParam("stu_super"), "1", "0", CCUtility.FIELD_TYPE_Number) ;				
				sql="select max(student_id)+1 from stu";
				SqlCommand comm = new SqlCommand(sql, Utility.Connection);				
				SqlDataReader myReader;
				myReader = comm.ExecuteReader();								
				while (myReader.Read())
				{	
					zh_id += myReader[0].ToString();
					
				}	
				sSQL= "insert into stu (student_id,name,age,sex,login,password,stu_level,business,class_id,address,"+
					"email,work_ph,home_ph,mobile_ph,super) values (" +				
					zh_id+ "," +
					zh_name + "," + 
					zh_age + "," + 
					zh_sex + "," + 
					zh_login + "," + 
					zh_password + "," + 
					zh_level + "," + 
					zh_business + "," + 
					zh_class_id + "," + 
					zh_address + "," + 
					zh_email + "," + 
					zh_work_phone + "," + 
					zh_home_phone + "," + 
					zh_mobile_phone + "," + 
					zh_super + ")";
				myReader.Close();
				SqlCommand cmd = new SqlCommand(sSQL, Utility.Connection);
				try 
				{
					cmd.ExecuteNonQuery();
				} 
				catch(Exception e) 
				{
					stu_ValidationSummary.Text += e.Message;
					stu_ValidationSummary.Visible = true;
					return false;
				}
			}
			return bResult;
		}



		//更新记录事件代码
		bool stu_update_Click(Object Src, EventArgs E) 
		{
			string sWhere = "";
			string sSQL ="";
		
			bool bResult=emps_Validate();
			if(bResult)
			{
		
				if (p_stu_student_id.Value.Length > 0) 
				{
					sWhere = sWhere + "student_id=" + CCUtility.ToSQL(p_stu_student_id.Value, CCUtility.FIELD_TYPE_Number);
				}
		
			{
					int iCount = Utility.DlookupInt("stu", "count(*)", "login=" + CCUtility.ToSQL(Utility.GetParam("stu_student_login"), CCUtility.FIELD_TYPE_Text) + " and not(" + sWhere + ")");
				if (iCount!=0)
				{
					stu_ValidationSummary.Visible=true;
					stu_ValidationSummary.Text+="The value in field Login is already in database."+"<br>";
					bResult=false;}
				}
		
				if (bResult)
				{
		
					sSQL = "update stu set " +
						"[name]=" +CCUtility.ToSQL(Utility.GetParam("stu_name"),CCUtility.FIELD_TYPE_Text)  +
						",[sex]=" +CCUtility.ToSQL(Utility.GetParam("stu_business"),CCUtility.FIELD_TYPE_Text)  +
						",[login]=" +CCUtility.ToSQL(Utility.GetParam("stu_student_login"),CCUtility.FIELD_TYPE_Text)  +
						",[password]=" +CCUtility.ToSQL(Utility.GetParam("stu_student_password"),CCUtility.FIELD_TYPE_Text)  +
						",[stu_level]=" +CCUtility.ToSQL(Utility.GetParam("stu_student_level"),CCUtility.FIELD_TYPE_Number)  +
						",[class_id]=" +CCUtility.ToSQL(Utility.GetParam("stu_class_id"),CCUtility.FIELD_TYPE_Number)  +
						",[address]=" +CCUtility.ToSQL(Utility.GetParam("stu_address"),CCUtility.FIELD_TYPE_Text)  +
						",[email]=" +CCUtility.ToSQL(Utility.GetParam("stu_email"),CCUtility.FIELD_TYPE_Text)  +
						",[work_ph]=" +CCUtility.ToSQL(Utility.GetParam("stu_work_phone"),CCUtility.FIELD_TYPE_Text)  +
						",[home_ph]=" +CCUtility.ToSQL(Utility.GetParam("stu_home_phone"),CCUtility.FIELD_TYPE_Text)  +
						",[mobile_ph]=" +CCUtility.ToSQL(Utility.GetParam("stu_mobile_phone"),CCUtility.FIELD_TYPE_Text)  +
						",[super]=" +CCUtility.getCheckBoxValue(Utility.GetParam("stu_super"),"1","0",CCUtility.FIELD_TYPE_Number)  +
						",[age]=" +CCUtility.ToSQL(Utility.GetParam("stu_age"),CCUtility.FIELD_TYPE_Text) +
						",[business]=" +CCUtility.ToSQL(Utility.GetParam("stu_business"),CCUtility.FIELD_TYPE_Text) ;

		
					sSQL = sSQL + " where " + sWhere;
		
					//创建与数据库联结的命令集
					SqlCommand cmd = new SqlCommand(sSQL, Utility.Connection);
					try 
					{
						cmd.ExecuteNonQuery();
					} 
					catch(Exception e) 
					{
						stu_ValidationSummary.Text += e.Message;
						stu_ValidationSummary.Visible = true;
						return false;
					}
				}
			}
			return bResult;
		}

		//删除记录代码
		bool stu_delete_Click(Object Src, EventArgs E) 
		{
			string sWhere = "";
	
			if (p_stu_student_id.Value.Length > 0) 
			{
				sWhere += "student_id=" + CCUtility.ToSQL(p_stu_student_id.Value, CCUtility.FIELD_TYPE_Number);
			}
	
			string sSQL = "delete from stu where " + sWhere;
			SqlCommand cmd = new SqlCommand(sSQL, Utility.Connection);
			try 
			{
				cmd.ExecuteNonQuery();
			} 
			catch(Exception e) 
			{
				stu_ValidationSummary.Text += e.Message;
				stu_ValidationSummary.Visible = true;
				return false;
			}
			return true;
		}

		//取消更新代码
		bool stu_cancel_Click(Object Src, EventArgs E) 
		{
			return true;
		}


		//为各按钮点击事件参数函数代码
		void stu_Action(Object Src, EventArgs E) 
		{
			bool bResult=true;
			if(((HtmlInputButton)Src).ID.IndexOf("insert")>0) bResult=stu_insert_Click(Src,E);
			if(((HtmlInputButton)Src).ID.IndexOf("update")>0) bResult=stu_update_Click(Src,E);
			if(((HtmlInputButton)Src).ID.IndexOf("delete")>0) bResult=stu_delete_Click(Src,E);
			if(((HtmlInputButton)Src).ID.IndexOf("cancel")>0) bResult=stu_cancel_Click(Src,E);

			if(bResult)Response.Redirect(stu_FormAction+"");
		}

	}
}