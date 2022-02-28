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
	/// find_class3 的摘要说明。
	/// </summary>
	public class find_class3 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblNoCl;
		protected System.Web.UI.WebControls.DataGrid dgdCl;
		protected System.Web.UI.WebControls.TextBox txtClname;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtGrad;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.Button btnNext;
		SqlConnection cn;
		SqlCommand cmd;
		SqlDataReader dr;
		SqlDataAdapter da;
		DataSet ds;
		string strConn,strSQL,strUrl;
		int i;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");

			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			strSQL="select class_id,class_name,grad,class_num,admin1,admin2,admin3,type_id from class where school_id="+Page.Request["schid"].ToString();
			cn=new SqlConnection(strConn);
			cn.Open();
			da=new SqlDataAdapter(strSQL,cn);
			ds=new DataSet();
			da.Fill(ds,"cl");
			ds.Tables["cl"].Columns.Add("t_name");
			ds.Tables["cl"].Columns.Add("m1");
			ds.Tables["cl"].Columns.Add("m2");
			ds.Tables["cl"].Columns.Add("m3");
			for(i=0;i<ds.Tables["cl"].Rows.Count;i++)			
				if(ds.Tables["cl"].Rows[i]["type_id"].ToString()!="")
				{
					strSQL="select type_name from classtype where type_id="+ds.Tables["cl"].Rows[i]["type_id"].ToString();
					cmd=new SqlCommand(strSQL,cn);
					dr=cmd.ExecuteReader();
					while(dr.Read())				
						ds.Tables["cl"].Rows[i]["t_name"]=dr[0].ToString();
					dr.Close();
					cmd.Dispose();					
				}							
			for(i=0;i<ds.Tables["cl"].Rows.Count;i++)
			{
				if(ds.Tables["cl"].Rows[i]["admin1"].ToString()!="")
				{
					strSQL="select name from userreg where id="+ds.Tables["cl"].Rows[i]["admin1"].ToString();
					cmd=new SqlCommand(strSQL,cn);
					dr=cmd.ExecuteReader();
					while(dr.Read())
						ds.Tables["cl"].Rows[i]["m1"]=dr[0].ToString();
					dr.Close();
					cmd.Dispose();				
				}
			}

			for(i=0;i<ds.Tables["cl"].Rows.Count;i++)
			{
				if(ds.Tables["cl"].Rows[i]["admin2"].ToString()!="")
				{
					strSQL="select name from userreg where id="+ds.Tables["cl"].Rows[i]["admin2"].ToString();
					cmd=new SqlCommand(strSQL,cn);
					dr=cmd.ExecuteReader();
					while(dr.Read())
						ds.Tables["cl"].Rows[i]["m2"]=dr[0].ToString();
					dr.Close();
					cmd.Dispose();					
				}
			}
			for(i=0;i<ds.Tables["cl"].Rows.Count;i++)
			{
				if(ds.Tables["cl"].Rows[i]["admin3"].ToString()!="")
				{
					strSQL="select name from userreg where id="+ds.Tables["cl"].Rows[i]["admin3"].ToString();
					cmd=new SqlCommand(strSQL,cn);
					dr=cmd.ExecuteReader();
					while(dr.Read())
						ds.Tables["cl"].Rows[i]["m3"]=dr[0].ToString();
					dr.Close();
					cmd.Dispose();					
				}
			}

			dgdCl.DataSource=ds.Tables["Cl"].DefaultView;
			dgdCl.DataBind();

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
			string pid="";string cid="";string tid="";
			string rs="";
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			cn=new SqlConnection(strConn);			
			cn.Open();			
			string sql="select max(class_id)+1,count(*) from class";
			SqlCommand cmd1 = new SqlCommand(sql, cn);				
			SqlDataReader myReader;
			myReader = cmd1.ExecuteReader();								
			while (myReader.Read())
			{	
				if (myReader[1].ToString()!="0")
				{
				rs += myReader[0].ToString();					
				}
				else
				{
				rs="1";
				}
			}
			cn.Close();
			strSQL="select pro_id,city_id,type_id from school where sch_id="+Page.Request["schid"].ToString();
			cn=new SqlConnection(strConn);
			cn.Open();	
			cmd=new SqlCommand(strSQL,cn);			
			dr=cmd.ExecuteReader();
			while(dr.Read())
			{
				pid=dr[0].ToString();cid=dr[1].ToString();tid=dr[2].ToString();
			}
			dr.Close();
			cmd.Dispose();
			
			strSQL="Insert into class(class_name,class_id,pro_id,city_id,school_id,del_flag,admin1,admin2,admin3,type_id,class_num,grad) Values('";
			strSQL+=txtClname.Text+"','"+rs+"',"+pid+","+cid+","+Page.Request["schid"].ToString()+",0,"+Session["uid"].ToString()+",0,0,"+tid+",1,"+txtGrad.Text.ToString()+")";
			cmd=new SqlCommand(strSQL,cn);
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			myReader.Close();
			cmd1.Dispose();
			
			strUrl="findend.aspx?clid="+rs;
			cn.Close();
			Page.Response.Redirect(strUrl);
		}
	}
}
