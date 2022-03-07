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

namespace employee
{
	/// <summary>
	/// Emp ��ժҪ˵����
	/// </summary>
	public class Emp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid Dgd_user;
		protected System.Web.UI.WebControls.Button Btn_exit;
		protected System.Web.UI.WebControls.Label Lbl_note;
	    SqlConnection cn;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session["jb"].ToString()=="0")
			{
			}
			else 
			{
				Response.Write ("�����ǺϷ��û����������ٲ�����<a href='default.aspx'>����</a>");
				Page.Response.End();
			}
						
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			if(!IsPostBack)		BindGrid();
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
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
			this.Btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_exit_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("default.aspx");
		}
		public void DataGrid_page(object sender,DataGridPageChangedEventArgs e)
		{
			Dgd_user.CurrentPageIndex=e.NewPageIndex;
			BindGrid();
		}
		public void BindGrid()
		{
			SqlDataAdapter da=new SqlDataAdapter("select * from Employee",cn);
			DataSet ds=new DataSet();
			da.Fill(ds);
			Dgd_user.DataSource=ds;
			Dgd_user.DataBind();
		}
		public void DataGrid_cancel(object sender,DataGridCommandEventArgs e)
		{
			
			Dgd_user.EditItemIndex=-1;
			BindGrid();
			
		}
		public void DataGrid_edit(object sender,DataGridCommandEventArgs e)
		{
			
			Dgd_user.EditItemIndex=(int)e.Item.ItemIndex;
		
			BindGrid();
			
		}
		public void DataGrid_update(object sender,DataGridCommandEventArgs e)
		{
			SqlCommand cm=new SqlCommand("UpdateEmp",cn);
			cm.CommandType=CommandType.StoredProcedure;
							
			cm.Parameters.Add(new SqlParameter("@Email",SqlDbType.VarChar,50));			
			cm.Parameters.Add(new SqlParameter("@tell",SqlDbType.VarChar,50));
			cm.Parameters.Add(new SqlParameter("@jb",SqlDbType.Int,4));
			cm.Parameters.Add(new SqlParameter("@Emp_id",SqlDbType.Int,4));

			string colvalue=((TextBox)e.Item.Cells[4].Controls[0]).Text;
			cm.Parameters["@Email"].Value=colvalue;	
		
			colvalue=((TextBox)e.Item.Cells[5].Controls[0]).Text;
			cm.Parameters["@jb"].Value=colvalue;

			colvalue=((TextBox)e.Item.Cells[6].Controls[0]).Text;
			cm.Parameters["@tell"].Value=colvalue;	
					
			cm.Parameters["@Emp_id"].Value=Dgd_user.DataKeys[(int)e.Item.ItemIndex];
			cm.Connection.Open();
			try
			{
				cm.ExecuteNonQuery();
				Lbl_note.Text="�༭�ɹ�";
				Dgd_user.EditItemIndex=-1;
			}
			catch(SqlException)
			{
				Lbl_note.Text="�༭ʧ��";
				Lbl_note.Style["color"]="red";
			}
			cm.Connection.Close();		
			BindGrid();
			
		}
		
		public void DataGrid_delete(object sender,DataGridCommandEventArgs e)
		{
			
			SqlCommand cm=new SqlCommand("deleteEmp",cn);
			cm.CommandType=CommandType.StoredProcedure;

			cm.Parameters.Add(new SqlParameter("@Empid",SqlDbType.Int,4));
			cm.Parameters["@Empid"].Value=Dgd_user.DataKeys[(int)e.Item.ItemIndex];
			
			cm.Connection.Open();
			try
			{
				cm.ExecuteNonQuery();
				Lbl_note.Text="ɾ���ɹ�";
				
			}
			catch(SqlException)
			{
				Lbl_note.Text="ɾ��ʧ��";
				Lbl_note.Style["color"]="red";
			}
			cm.Connection.Close();			
			BindGrid();
		}
	}
}
