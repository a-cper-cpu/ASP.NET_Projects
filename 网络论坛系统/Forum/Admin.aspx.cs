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

namespace Forum
{
	/// <summary>
	/// Admin ��ժҪ˵����
	/// </summary>
	public class Admin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid MyGrid;
		protected System.Web.UI.WebControls.TextBox td1;
		protected System.Web.UI.WebControls.TextBox td2;
		protected System.Web.UI.WebControls.TextBox td3;
		protected System.Web.UI.WebControls.TextBox td4;
		protected System.Web.UI.WebControls.TextBox td5;
		protected System.Web.UI.WebControls.TextBox td6;
		public SqlConnection MyConn;
		public SqlDataReader dr;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			Forum ForumDBO= new Forum();
			MyConn=ForumDBO.Open();
			if (ForumDBO.adminck()=="Wrong")
			{
				Response.Redirect("Exceptions.aspx?ms=9");
			}
			if(!Page.IsPostBack)
			{
				BindGrid();
			}
		}
		ICollection CreateTable()
		{
			string strSel = "select * from ForumInform order by id desc";
			DataSet ds = new DataSet();

			SqlDataAdapter MyAdapter = new SqlDataAdapter(strSel,MyConn);
			MyAdapter.Fill(ds,"main");

			return ds.Tables["main"].DefaultView;
		}
		public void BindGrid()
		{
			MyGrid.DataSource = CreateTable();
			MyGrid.DataBind();
		}
		public void DataGrid_EditCommand(Object sender,DataGridCommandEventArgs e)
		{
			string id2=e.Item.Cells[1].Text;
			string str ="select * from ForumInform where id="+id2;
			SqlCommand MyComm = new SqlCommand(str,MyConn);
			dr=MyComm.ExecuteReader();
			while(dr.Read())
			{
				td1.Text=dr["Beg"].ToString();
				td2.Text=dr["End"].ToString();
				td3.Text=dr["TopicDes"].ToString();
				td4.Text=dr["des"].ToString();
				td5.Text=dr["Flag"].ToString();
				td6.Text=dr["Toastmaster"].ToString();
			}
			dr.Close();
			MyGrid.EditItemIndex = (int)e.Item.ItemIndex;
			BindGrid();
		}


		public void DataGrid_CancelCommand(Object sender,DataGridCommandEventArgs e)
		{
			string id=e.Item.Cells[1].Text;
			string del="delete from ForumInform where id="+id;
			SqlCommand MyComm = new SqlCommand(del,MyConn);
			MyComm.ExecuteNonQuery();
			MyComm.CommandText=del;
			del="drop table a"+e.Item.Cells[2].Text+"Topic"+e.Item.Cells[3].Text;
			MyComm.CommandText=del;
			MyComm.ExecuteNonQuery();
			del="drop table a"+e.Item.Cells[2].Text+"Reply"+e.Item.Cells[3].Text;
			MyComm.CommandText=del;
			MyComm.ExecuteNonQuery();
			BindGrid();
		}


		public void DataGrid_UpdateCommand(Object sender,DataGridCommandEventArgs e)
		{

			string Beg = td1.Text.ToString().Replace("'","''");
			string End = td2.Text.ToString().Replace("'","''");
			string name = td3.Text.ToString().Replace("'","''");
			string des  = td4.Text.ToString().Replace("'","''");
			string logo = td5.Text.ToString().Replace("'","''");
			string Toastmaster  = td6.Text.ToString().Replace("'","''");
			string id=e.Item.Cells[1].Text;
			string strUpdate = "update ForumInform set Begin1="+Beg+",end1="+End+",TopicDes='"+name+"',Des='"+des+"',Toastmaster='"+Toastmaster+"' where  id="+id;
			SqlCommand MyComm = new SqlCommand(strUpdate,MyConn);
			MyComm.ExecuteNonQuery();	
			MyGrid.EditItemIndex = -1;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
