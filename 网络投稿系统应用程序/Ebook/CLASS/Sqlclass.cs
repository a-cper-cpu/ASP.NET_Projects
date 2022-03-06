using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Ebook.CLASS
{
	
	/// <summary>
	/// Sqlclass 的摘要说明。
	/// </summary>
	public class Sqlclass
	{
		private string MyConnString;
		private SqlConnection MyConn;
		public Sqlclass()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public  void Open()
		{
			MyConnString =ConfigurationSettings.AppSettings["ConnectionString"];
			MyConn = new SqlConnection(MyConnString);
			MyConn.Open();			
		}
		public SqlDataReader GetDataReader(string strCommandString)
		{
			SqlCommand cmdCommand=new SqlCommand(strCommandString,MyConn);
			SqlDataReader drDataReader=cmdCommand.ExecuteReader();			
			return drDataReader;
		}
		public int ExecuteSQL(string strCommandString)
		{
			SqlCommand cmdCommand=new SqlCommand(strCommandString,MyConn);
			int nAffected=cmdCommand.ExecuteNonQuery();
			return nAffected;
		}
		public void Close()
		{
			MyConn.Close();
		}
		
		public DataSet GetDataSet(string strCommandString,string strTableName)
		{
			SqlCommand cmdCommand=new SqlCommand(strCommandString,MyConn);
			
			SqlDataAdapter adAdapter = new SqlDataAdapter();
			adAdapter.SelectCommand=new SqlCommand(strCommandString,MyConn);
			
			DataSet dsDataSet=new DataSet();
			
			adAdapter.Fill(dsDataSet,strTableName);
			return dsDataSet;							
		}		
				
		public DataView GetDataView(string strCommandString,string strTableName)
		{
			DataSet dsDataSet;
			dsDataSet=this.GetDataSet(strCommandString,strTableName);
			if(dsDataSet!=null)
			{				
				return new DataView(dsDataSet.Tables[strTableName]);
			} 
			else
				return null;
		}
	}
}
