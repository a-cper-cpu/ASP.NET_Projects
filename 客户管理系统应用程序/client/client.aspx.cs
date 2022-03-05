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

namespace client
{
	/// <summary>
	/// client ��ժҪ˵����
	/// </summary>
	public class client : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Lbl_note;
		protected System.Web.UI.WebControls.LinkButton Lbtn_add;
		protected System.Web.UI.WebControls.DataGrid Dgd_client;
		protected System.Web.UI.WebControls.Button Btn_back;
		SqlConnection cn;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			if(!IsPostBack)
				BindGrid();
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
			this.Lbtn_add.Click += new System.EventHandler(this.Lbtn_add_Click);
			this.Btn_back.Click += new System.EventHandler(this.Btn_back_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_back_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("default.aspx");
		}
		public void BindGrid()
		{
			string mysql="select client_id,client_name,client_charge,client_level,client_email,client_tell from client";
			SqlDataAdapter da=new SqlDataAdapter(mysql,cn);
			DataSet ds=new DataSet();
			da.Fill(ds);
			Dgd_client.DataSource=ds;
			Dgd_client.DataBind();
		}
		public void DataGrid_Page(object sender,DataGridPageChangedEventArgs e)
		{
			Dgd_client.CurrentPageIndex=e.NewPageIndex;
			BindGrid();
		}
		public void DataGrid_cancel(object sender,DataGridCommandEventArgs e)
		{
			
			Dgd_client.EditItemIndex=-1;
			BindGrid();
			
		}
		
		public void DataGrid_edit(object sender,DataGridCommandEventArgs e)
		{
			if(Session["branch"].ToString()=="0")
			{
			
				Dgd_client.EditItemIndex=(int)e.Item.ItemIndex;		
				BindGrid();
			}	
		}
		public void DataGrid_update(object sender,DataGridCommandEventArgs e)
		{
			SqlCommand cm=new SqlCommand("updateclient",cn);
			cm.CommandType=CommandType.StoredProcedure;			
			
			cm.Parameters.Add(new SqlParameter("@client_id",SqlDbType.Char,10));
			cm.Parameters.Add(new SqlParameter("@client_name",SqlDbType.Char,10));
			cm.Parameters.Add(new SqlParameter("@client_charge",SqlDbType.Char,10));
			cm.Parameters.Add(new SqlParameter("@client_level",SqlDbType.Int,4));
			cm.Parameters.Add(new SqlParameter("@client_email",SqlDbType.VarChar,20));				
			cm.Parameters.Add(new SqlParameter("@client_tell",SqlDbType.VarChar,20));

			string colvalue=((TextBox)e.Item.Cells[1].Controls[0]).Text;
			cm.Parameters["@client_name"].Value=colvalue;

			colvalue=((TextBox)e.Item.Cells[2].Controls[0]).Text;
			cm.Parameters["@client_charge"].Value=colvalue;

			colvalue=((TextBox)e.Item.Cells[3].Controls[0]).Text;
			cm.Parameters["@client_level"].Value=colvalue;

			colvalue=((TextBox)e.Item.Cells[4].Controls[0]).Text;
			cm.Parameters["@client_email"].Value=colvalue;	
		
			colvalue=((TextBox)e.Item.Cells[5].Controls[0]).Text;
			cm.Parameters["@client_tell"].Value=colvalue;

			cm.Parameters["@client_id"].Value=Dgd_client.DataKeys[(int)e.Item.ItemIndex];
							
			cm.Connection.Open();
			try
			{
				cm.ExecuteNonQuery();
				Lbl_note.Text="�༭�ɹ�";
				Dgd_client.EditItemIndex=-1;
			}
			catch
			{
				Lbl_note.Text="�༭ʧ��";
				Lbl_note.Style["color"]="red";
			}
			cm.Connection.Close();		
			BindGrid();			
		}
		
		public void DataGrid_delete(object sender,DataGridCommandEventArgs e)
		{
			if(Session["branch"].ToString()=="0")
			{
				string strsql="delete from client where client_id=@clientid";
				SqlCommand cm=new SqlCommand(strsql,cn);
				cm.Parameters.Add(new SqlParameter("@clientid",SqlDbType.Char,10));
				cm.Parameters["@clientid"].Value=Dgd_client.DataKeys[(int)e.Item.ItemIndex];
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

		private void Lbtn_add_Click(object sender, System.EventArgs e)
		{
		
			try
			{
				if(Session["branch"].ToString ()=="0"||Session["branch"].ToString ()=="3")
					Response.Redirect("addclient.aspx");
			}
			catch
			{
				Response.Write ("�����ǺϷ��û����������ٲ�����<a href='default.aspx'>����</a>");
				Response.End ();
			}
		}
	}
}
