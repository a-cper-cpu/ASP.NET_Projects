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
	/// product 的摘要说明。
	/// </summary>
	public class product : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Lbl_note;
		protected System.Web.UI.WebControls.LinkButton Lbtn_add;
		protected System.Web.UI.WebControls.DataGrid Dgd_Product;
		protected System.Web.UI.WebControls.Button Btn_back;
		SqlConnection cn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			if(!IsPostBack)
				BindGrid();
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
			this.Lbtn_add.Click += new System.EventHandler(this.Lbtn_add_Click);
			this.Btn_back.Click += new System.EventHandler(this.Btn_back_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Lbtn_add_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Session["branch"].ToString ()=="0"||Session["branch"].ToString ()=="2")
					Response.Redirect("addproduct.aspx");
			}
			catch
			{
				Response.Write ("您不是合法用户，请登入后再操作，<a href='default.aspx'>返回</a>");
				Response.End ();
			}
		}

		private void Btn_back_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("default.aspx");
		}
		public void BindGrid()
		{
			string mysql="select Product_id,Product_name,Product_descnbe from Product";
			SqlDataAdapter da=new SqlDataAdapter(mysql,cn);
			DataSet ds=new DataSet();
			da.Fill(ds);
			Dgd_Product.DataSource=ds;
			Dgd_Product.DataBind();
		}
		public void DataGrid_Page(object sender,DataGridPageChangedEventArgs e)
		{
			Dgd_Product.CurrentPageIndex=e.NewPageIndex;
			BindGrid();
		}
		public void DataGrid_cancel(object sender,DataGridCommandEventArgs e)
		{
			
			Dgd_Product.EditItemIndex=-1;
			BindGrid();
			
		}
		
		public void DataGrid_edit(object sender,DataGridCommandEventArgs e)
		{
			if(Session["branch"].ToString()=="0")
			{
			
				Dgd_Product.EditItemIndex=(int)e.Item.ItemIndex;		
				BindGrid();
			}	
		}
		public void DataGrid_update(object sender,DataGridCommandEventArgs e)
		{
			SqlCommand cm=new SqlCommand("Updateproduct",cn);
			cm.CommandType=CommandType.StoredProcedure;			
			
			cm.Parameters.Add(new SqlParameter("@Product_id",SqlDbType.Char,10));
			cm.Parameters.Add(new SqlParameter("@Product_name",SqlDbType.VarChar,50));					
			cm.Parameters.Add(new SqlParameter("@Product_descnbe",SqlDbType.VarChar,50));

			string colvalue=((TextBox)e.Item.Cells[1].Controls[0]).Text;
			cm.Parameters["@Product_name"].Value=colvalue;

			colvalue=((TextBox)e.Item.Cells[2].Controls[0]).Text;
			cm.Parameters["@Product_descnbe"].Value=colvalue;			

			cm.Parameters["@Product_id"].Value=Dgd_Product.DataKeys[(int)e.Item.ItemIndex];
							
			cm.Connection.Open();
			try
			{
				cm.ExecuteNonQuery();
				Lbl_note.Text="编辑成功";
				Dgd_Product.EditItemIndex=-1;
			}
			catch
			{
				Lbl_note.Text="编辑失败";
				Lbl_note.Style["color"]="red";
			}
			cm.Connection.Close();		
			BindGrid();			
		}
		
		public void DataGrid_delete(object sender,DataGridCommandEventArgs e)
		{
			if(Session["branch"].ToString()=="0")
			{
				string strsql="delete from Product where Product_id=@Product_id";
				SqlCommand cm=new SqlCommand(strsql,cn);
				cm.Parameters.Add(new SqlParameter("@Product_id",SqlDbType.Char,10));
				cm.Parameters["@Product_id"].Value=Dgd_Product.DataKeys[(int)e.Item.ItemIndex];
				cm.Connection.Open();
				try
				{
					cm.ExecuteNonQuery();
					Lbl_note.Text="删除成功";
				}
				catch(SqlException)
				{
					Lbl_note.Text="删除失败";
					Lbl_note.Style["color"]="red";
				}
				cm.Connection.Close();			
				BindGrid();
			}
		}
	}
}
