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
	/// findend ��ժҪ˵����
	/// </summary>
	public class findend : System.Web.UI.Page
	{
		SqlConnection cn;
		SqlCommand cmd;		
		SqlDataAdapter da;
		DataSet ds;
		string strConn,strSQL,strOldCl,strCl2;
		int i,j;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");

			strCl2=Page.Request.QueryString["clid"].ToString();
			j=5-strCl2.Length;
			for(i=0;i<j;i++)
				strCl2="0"+strCl2;
			
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			strSQL="select class_id from userreg where id="+Session["uid"].ToString();
			cn=new SqlConnection(strConn);
			cn.Open();
			da=new SqlDataAdapter(strSQL,cn);
			ds=new DataSet();
			da.Fill(ds,"class_id");
			strOldCl=ds.Tables[0].Rows[0][0].ToString();
			da.Dispose();			

			if(strOldCl.IndexOf(strCl2)<0)
			{	
				if(strOldCl=="")
					strOldCl=strCl2;
				else
					strOldCl+="&"+strCl2;
				strSQL="Update userreg Set class_id='"+strOldCl+"' where id="+Session["uid"].ToString();
				cmd=new SqlCommand(strSQL,cn);
				cmd.ExecuteNonQuery();
				cmd.Dispose();				
			}
			cn.Close();
			
			Page.Response.Redirect("school.aspx");
		}	

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
