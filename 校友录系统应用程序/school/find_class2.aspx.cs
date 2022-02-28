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
using System.Configuration;

namespace school
{
	/// <summary>
	/// find_class2 的摘要说明。
	/// </summary>
	public class find_class2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblNoSchool;
		protected System.Web.UI.WebControls.DataGrid dgdSch;
		protected System.Web.UI.WebControls.TextBox txtSchname;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtScherea;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox txtSchzip;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.TextBox txtSchhttp;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.Button btnNext;
		SqlConnection cn;
		SqlCommand cmd;
		SqlDataReader dr;
		SqlDataAdapter da;
		DataSet ds;		
		string strConn,strSQL,strUrl;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			strSQL="select school.sch_id,school.sch_name,province.pro_name,city.city_name,school.sch_erea,sch_num,classtype.type_name from school,province,classtype,city";
			strSQL+=" where city.city_id="+Page.Request["cid"].ToString();
			strSQL+=" and classtype.type_id="+Page.Request["typ"].ToString();
			strSQL+=" and province.pro_id="+Page.Request["pid"].ToString();	
			strSQL+=" and school.city_id="+Page.Request["cid"].ToString();
			strSQL+=" and school.type_id="+Page.Request["typ"].ToString();
			strSQL+=" and school.pro_id="+Page.Request["pid"].ToString();
			strSQL+=" and school.sch_name like '%"+Page.Request["kywd"].ToString()+"%'";
			cn=new SqlConnection(strConn);
			cn.Open();
			da=new SqlDataAdapter(strSQL,cn);
			ds=new DataSet();
			da.Fill(ds,"school");
			
			dgdSch.DataSource=ds.Tables["school"].DefaultView;
			dgdSch.DataBind();

			da.Dispose();
			cn.Close();
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			string rs="";
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			cn=new SqlConnection(strConn);			
			cn.Open();			
			string sql="select max(sch_id)+1,count(*) from school";
			SqlCommand cmd1 = new SqlCommand(sql, cn);				
			SqlDataReader myReader;
			myReader = cmd1.ExecuteReader();								
			while (myReader.Read())
			{	
				if(myReader[1].ToString()!="0")
				{
					rs += myReader[0].ToString();	
				}
				else
				{
					rs="1";
				}
			
					
			}	
			strSQL="INSERT INTO school(sch_name,pro_id,city_id,sch_erea,type_id,sch_num,yb,sch_http,del_flag,sch_id,sch_who) VALUES('";			
			strSQL+=txtSchname.Text+"',";
			strSQL+=Page.Request["pid"].ToString()+","+Page.Request["cid"].ToString()+",'"+txtScherea.Text+"',"+Page.Request["typ"].ToString()+",0,'";
			strSQL+=txtSchzip.Text+"','"+txtSchhttp.Text+"','0','"+rs+"',"+Session["uid"].ToString()+")";
						
			myReader.Close();
			cn=new SqlConnection(strConn);
			cmd=new SqlCommand(strSQL,cn);
			cn.Open();
			cmd.ExecuteNonQuery();
			cmd.Dispose();


			strSQL="select sch_id from school where sch_who="+Session["uid"].ToString()+" ORDER BY sch_id DESC";
			cmd=new SqlCommand(strSQL,cn);
			dr=cmd.ExecuteReader();
			dr.Read();
			strUrl="find_class3.aspx?schid="+dr[0].ToString();
			cn.Close();
			Page.Response.Redirect(strUrl);
		}
	}
}
