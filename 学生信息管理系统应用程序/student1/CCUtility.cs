namespace student1
{

	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SqlClient;
	using System.Drawing;
	using System.Web;
	using System.Web.SessionState;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;	

	//定义PositionData类
	public class PositionData 
	{
        
		private string name;
		private string CatID;

		public PositionData(string Name, string CategoryID) 
		{
			this.name = Name;
			this.CatID = CategoryID;
		}

		public string Name 
		{
			get 
			{
				return name;
			}
		}

		public string CategoryID 
		{
			get 
			{
				return CatID;
			}
		}
	}

	//定义CCUtility类
	public class CCUtility 
	{
		public const int FIELD_TYPE_Text = 0;
		public const int FIELD_TYPE_Number = 1;
		public const int FIELD_TYPE_Date = 2;
		public const int FIELD_TYPE_Memo = 3;
		protected HttpSessionState Session;
		protected HttpServerUtility Server;
		protected HttpRequest Request;
		protected HttpResponse Response;

		//转换为标准的SQL语句
		public static string ToSQL(string Param, int iType) 
		{
			if (Param == null || Param.Length == 0) 
			{
				return "Null";
			} 
			else 
			{
				string str = Quote(Param);
				if (iType == FIELD_TYPE_Number) 
				{
					return str.Replace(',','.');
				} 
				else 
				{
					return "\'" + str + "\'";
				}
			}
		}
		//构造函数
		public CCUtility(object parent)
		{
			DBOpen();
			try
			{
				Session=((System.Web.UI.Page)parent).Session;
				Server=((System.Web.UI.Page)parent).Server;
				Request=((System.Web.UI.Page)parent).Request;
				Response=((System.Web.UI.Page)parent).Response;
			}
			catch
			{
				Session=((System.Web.UI.UserControl)parent).Session;
				Server=((System.Web.UI.UserControl)parent).Server;
				Request=((System.Web.UI.UserControl)parent).Request;
				Response=((System.Web.UI.UserControl)parent).Response;
			}

		} 

		

		public String GetValFromLOV(String val, String[] arr) 
		{
			String ret = "";
			if (arr.Length % 2 == 0) 
			{
				int temp=Array.IndexOf(arr,val);
				ret=temp==-1?"":arr[temp+1];}
			return ret;
		}

		//判断数据类型是否为数值型

		public bool IsNumeric(object source, string value) 
		{
			try
			{
				Decimal temp=Convert.ToDecimal(value);
				return true;
			}
			catch 
			{
				return false;
			}
		}
		//单引号替换为双引号
		public static string Quote(string Param) 
		{
			if (Param == null || Param.Length == 0) 
			{
				return "";
			} 
			else 
			{
				return Param.Replace("'","''");
			}
		}
		//获得DataRow对象中row中的field值
		public static string GetValue(DataRow row, string field) 
		{
			if (row[field].ToString() == null)
				return "";
			else
				return row[field].ToString();
		}


		//与数据库连接方法的定义
		public SqlConnection Connection;
		//建立一个数据集
		public DataSet FillDataSet(string sSQL)
		{
			DataSet ds = new DataSet();
			SqlDataAdapter command = new SqlDataAdapter(sSQL, Connection);
			return ds;
		}
		//数据集中添加或刷新行
		public int FillDataSet(string sSQL,ref DataSet ds)
		{
			SqlDataAdapter command = new SqlDataAdapter(sSQL, Connection);
			return command.Fill(ds, "Table");
		}
		//
		public int FillDataSet(string sSQL,ref DataSet ds,int start, int count)
		{
			SqlDataAdapter command = new SqlDataAdapter(sSQL, Connection);
			return command.Fill(ds, start, count, "Table");
		}


		//打开数据库连接
		public void DBOpen()
		{
			//从Web.Config中获取连接数据库字符串	 			
			string sConnectionString = ConfigurationSettings.AppSettings["SQLConnectionString"];		
			//创建一个连接实例
			Connection = new SqlConnection(sConnectionString);
			Connection.Open();
	    
		}
		//关闭数据库连接
		public void DBClose()
		{
			Connection.Close();
		}

		public string GetParam(string ParamName) 
		{
			string Param = Request.QueryString[ParamName];
			if (Param == null)
				Param = Request.Form[ParamName];
			if (Param == null)
				return "";
			else 
				return Param;
		}
		//数据库查询，并将字符串数据结果返回
		public string Dlookup(string table, string field, string sWhere)
		{
			string sSQL = "SELECT " + field + " FROM " + table + " WHERE " + sWhere;

			SqlCommand command = new SqlCommand(sSQL, Connection);
			SqlDataReader reader=command.ExecuteReader(CommandBehavior.SingleRow);
			string sReturn;

			if (reader.Read()) 
			{
				sReturn = reader[0].ToString();
				if (sReturn == null)
					sReturn = "";
			} 
			else 
			{
				sReturn = "";
			}

			reader.Close();
			return sReturn;
		}
		//数据库查询，并返回数值型数据
		public int DlookupInt(string table, string field, string sWhere)
		{
			string sSQL = "SELECT " + field + " FROM " + table + " WHERE " + sWhere;

			SqlCommand command = new SqlCommand(sSQL, Connection);
			SqlDataReader reader=command.ExecuteReader(CommandBehavior.SingleRow);
			int iReturn = -1;

			if (reader.Read()) 
			{
				iReturn = reader.GetInt32(0);
			}

			reader.Close();
			return iReturn;
		}
		//执行语句
		public void Execute(string sSQL)
		{
			SqlCommand cmd = new SqlCommand(sSQL, Connection);
			cmd.ExecuteNonQuery();
		}
		//执行语句，将数据绑定到ListBox控件上

		public void buildListBox(ListItemCollection Items,string sSQL, string sId, string sTitle, string CustomInitialDisplayValue,string CustomInitialSubmitValue)
		{	
			Items.Clear();
			SqlCommand command = new SqlCommand(sSQL, Connection);
			SqlDataReader reader = command.ExecuteReader();
	
			if(CustomInitialDisplayValue!=null) Items.Add(new ListItem(CustomInitialDisplayValue,CustomInitialSubmitValue));

			while(reader.Read()) 
			{	
				if(sId==""&&sTitle=="")	
				{
					Items.Add(new ListItem(reader[1].ToString(),reader[0].ToString()));
				}
				else
				{
					Items.Add(new ListItem(reader[sTitle].ToString(),reader[sId].ToString()));
				}
			}
			reader.Close();
		}
		
		public void buildListBox(ListItemCollection Items,string[] values, string CustomInitialDisplayValue,string CustomInitialSubmitValue)
		{	
			Items.Clear();
			if(CustomInitialDisplayValue!=null) Items.Add(new ListItem(CustomInitialDisplayValue,CustomInitialSubmitValue));
			for(int i=0;i<values.Length;i+=2)Items.Add(new ListItem(values[i+1],values[i]));
		}


		public ICollection buildListBox(string sSQL, string sId, string sTitle, string CustomInitialDisplayValue,string CustomInitialSubmitValue)
		{
			DataRow row;

			SqlDataAdapter command = new SqlDataAdapter(sSQL, Connection);
			DataSet ds = new DataSet();
			ds.Tables.Add("lookup");

			DataColumn column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = sId;
			ds.Tables[0].Columns.Add(column);

			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = sTitle;
			ds.Tables[0].Columns.Add(column);

			if (CustomInitialDisplayValue!=null) 
			{
				row = ds.Tables[0].NewRow();
				row[0] = CustomInitialSubmitValue;
				row[1] = CustomInitialDisplayValue;
				ds.Tables[0].Rows.Add(row);}

			command.Fill(ds, "lookup");
			return new DataView(ds.Tables[0]);			
		}


		public static string getCheckBoxValue(string sVal, string CheckedValue, string UnCheckedValue, int iType) 
		{
			if (sVal.Length == 0) 
			{				
				return ToSQL(UnCheckedValue, iType);
			} 
			else 
			{				
				return ToSQL(CheckedValue, iType);
			}
		}
		//安全性验证

		public bool CheckSecurity(int iLevel) 
		{
			if (Session["UserID"] == null || Session["UserID"].ToString().Length == 0) 
			{
				return false;
			} 
			else 
			{
				if (Int16.Parse(Session["UserRights"].ToString()) < iLevel)
				{
					return false;
				}
				else return true;
			}
		}

	}

}