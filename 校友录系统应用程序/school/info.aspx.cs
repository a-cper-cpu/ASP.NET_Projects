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
	/// info 的摘要说明。
	/// </summary>
	public class info : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList dltBoard;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.TextBox txtTheme;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtContent;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Button btnOK;
		SqlConnection cn;
		SqlCommand cmd;
		SqlDataReader dr;
		SqlDataAdapter da;
		DataSet ds;
		int i;
		string strConn,strSQL;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			strSQL="select info_id,info_title,id,editer,info_cnt from info where class_id="+Page.Request["clid"].ToString()+" and del_flag='0' ORDER BY info_id DESC";
			cn=new SqlConnection(strConn);
			cn.Open();
			da=new SqlDataAdapter(strSQL,cn);
			ds=new DataSet();
			da.Fill(ds,"info");
			ds.Tables["info"].Columns.Add("editinfo");
			ds.Tables["info"].Columns.Add("editurl");
			ds.Tables["info"].Columns.Add("delurl");
			ds.Tables["info"].Columns.Add("name");						

			for(i=0;i<ds.Tables[0].Rows.Count;i++)
			{
				strSQL="select name from userreg where id="+ds.Tables[0].Rows[i]["id"].ToString();
				cmd=new SqlCommand(strSQL,cn);
				dr=cmd.ExecuteReader();
				while(dr.Read())
					ds.Tables[0].Rows[i]["name"]=dr[0].ToString();
				cmd.Dispose();
				dr.Close();
			}

			for(i=0;i<ds.Tables[0].Rows.Count;i++)
				
			strSQL="select admin1,admin2,admin3 from class where class_id="+Page.Request["clid"].ToString();
			cmd=new SqlCommand(strSQL,cn);
			dr=cmd.ExecuteReader();
			while(dr.Read())
			{
			
				for(i=0;i<ds.Tables[0].Rows.Count;i++)
				{
					
					if(Session["uid"].ToString()==dr[0].ToString()|Session["uid"].ToString()==dr[1].ToString())//为管理员添加固顶选项											

							
					if(ds.Tables[0].Rows[i]["id"].ToString()==Session["uid"].ToString()|Session["uid"].ToString()==dr[0].ToString()|Session["uid"].ToString()==dr[1].ToString())//为管理员和贴子作者添加编辑删除选项
					{
						ds.Tables[0].Rows[i]["editurl"]="<A href=editinfo.aspx?infoid="+ds.Tables[0].Rows[i]["info_id"].ToString()+">[编辑]</A>";
						ds.Tables[0].Rows[i]["delurl"]="<A href=delinfo.aspx?infoid="+ds.Tables[0].Rows[i]["info_id"].ToString()+">[删除]</A>";					
					}
				}
				
			}
			cmd.Dispose();
			dr.Close();

			strSQL="select name from userreg where id="+Session["uid"].ToString();
			cmd=new SqlCommand(strSQL,cn);
			dr=cmd.ExecuteReader();
			while(dr.Read())
				lblName.Text=dr[0].ToString();
			cmd.Dispose();
			dr.Close();

			
			dltBoard.DataSource=ds.Tables["info"].DefaultView;
			dltBoard.DataBind();
			ds.Dispose();
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string rs="";
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			cn=new SqlConnection(strConn);			
			cn.Open();			
			string sql="select max(info_id)+1,count(*) from info";
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
			strSQL="Insert INTO info(info_id,info_title,id,info_cnt,del_flag,class_id,editer) Values ('"+rs+"','"+txtTheme.Text.Replace("<","&lt").Replace(">","&gt").Replace(" ","&nbsp;").Replace("\n","<br>")+"',"+Session["uid"].ToString()+",'"+txtContent.Text+"','0',"+Page.Request["clid"].ToString()+",0)";			
			myReader.Close();
			cmd=new SqlCommand(strSQL,cn);			
			cmd.ExecuteNonQuery();
			
			cmd1.Dispose();
			cmd.Dispose();
			cn.Close();
			Page.Response.Redirect("info.aspx?clid="+Page.Request["clid"].ToString());
		}
	}
}
