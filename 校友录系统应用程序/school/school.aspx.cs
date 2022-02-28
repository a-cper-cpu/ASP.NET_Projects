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
	/// school 的摘要说明。
	/// </summary>
	public class school : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblNo;
		protected System.Web.UI.WebControls.DropDownList ddlProve;
		protected System.Web.UI.WebControls.Button btnNext;
		string strConn,strSQL;
		int uid;
		char[] de={'&'};
		string[] strCl={};
		string scl;
		int i;
		SqlConnection cn;
		SqlDataAdapter da;
		DataSet ds;
		SqlDataReader dr;
		SqlCommand cmd;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");


			uid=Convert.ToInt32(Session["uid"].ToString());						
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			strSQL="Select class_id from userreg where id="+uid.ToString();
			cn=new SqlConnection(strConn);
			cmd=new SqlCommand(strSQL,cn);
			cn.Open();
			dr=cmd.ExecuteReader();
			
			while(dr.Read())
			{
				scl=dr["class_id"].ToString();
				strCl=scl.Split(de);				
			}
			dr.Close();
			if(!Page.IsPostBack)
			{

				strSQL="select pro_name from province";			
				da=new SqlDataAdapter(strSQL,cn);
				ds=new DataSet();
				da.Fill(ds,"province");
				for(i=0;i<ds.Tables["province"].Rows.Count;i++)
					ddlProve.Items.Add(ds.Tables["province"].Rows[i]["pro_name"].ToString());
				da.Dispose();
			}
			if(strCl[0].ToString()!="")
			{
				strSQL="select class_name,admin1,admin2,admin3,class_id,school_id from class where class_id=";
				for(i=0;i<strCl.Length;i++)
				{

					if(i==strCl.Length-1)
						strSQL+=strCl[i].ToString();
					else
						strSQL+=strCl[i].ToString()+" or class_id=";
				}

				ds=new DataSet();
				da=new SqlDataAdapter(strSQL,cn);
				da.Fill(ds,"clinfo");
				ds.Tables["clinfo"].Columns.Add("A1");
				ds.Tables["clinfo"].Columns.Add("A2");				
				for(i=0;i<strCl.Length;i++)
					ds.Tables["clinfo"].Rows[i]["A1"]=i+1;
				for(i=0;i<strCl.Length;i++)
				{
					strSQL="select name from userreg where id="+ds.Tables[0].Rows[i]["admin1"].ToString();
					cmd=new SqlCommand(strSQL,cn);
					dr=cmd.ExecuteReader();
					while(dr.Read())
						ds.Tables["clinfo"].Rows[i]["A2"]="正:"+dr[0].ToString();				
					dr.Close();

					strSQL="select name from userreg where id="+ds.Tables[0].Rows[i]["admin2"].ToString();
					cmd=new SqlCommand(strSQL,cn);
					dr=cmd.ExecuteReader();
					while(dr.Read())
						ds.Tables["clinfo"].Rows[i]["A2"]+="&nbsp;&nbsp;&nbsp;&nbsp;副:"+dr[0].ToString();
					dr.Close();

					strSQL="select name from userreg where id="+ds.Tables[0].Rows[i]["admin3"].ToString();
					cmd=new SqlCommand(strSQL,cn);
					dr=cmd.ExecuteReader();
					while(dr.Read())
						ds.Tables["clinfo"].Rows[i]["A2"]+="&nbsp;&nbsp;&nbsp;&nbsp;副:"+dr[0].ToString();
					dr.Close();
				}
				ds.Tables["clinfo"].Columns.Add("A3");
				for(i=0;i<strCl.Length;i++)
				{
					strSQL="select sch_name from school where sch_id="+ds.Tables["clinfo"].Rows[i]["school_id"].ToString();
					cmd=new SqlCommand(strSQL,cn);
					dr=cmd.ExecuteReader();
					while(dr.Read())
						ds.Tables["clinfo"].Rows[i]["A3"]=dr[0].ToString()+"-----"+ds.Tables["clinfo"].Rows[i]["class_name"].ToString();
					dr.Close();
				}

				DataGrid1.DataSource=ds.Tables["clinfo"].DefaultView;
				DataGrid1.DataBind();
				cn.Close();
			}
			else
			{
				lblNo.Visible=true;
				cn.Close();
			}
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
			string strPam="";
			strPam=Convert.ToString(ddlProve.SelectedIndex+1);
			Page.Response.Redirect("find_class.aspx?pid="+strPam);
		}
	}
}
