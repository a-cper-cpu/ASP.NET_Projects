using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Bid
{
	public class wareDetails
	{
		public Int32 wareNo;
		public string wareName;
		public string wareDesc;
		public Double wareAsk;
		public Double wareNotify;
		public Int32 wareSellerID;
		public DateTime wareListingDate;
		public DateTime wareEndDate;
		public Char wareStatus;
	}

	/// <summary>
	/// ware ��ժҪ˵����
	/// </summary>
	public class ware
	{
		public ware()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public string Addware(string wareName
			,	string wareDesc
			,	Double wareAsk
			,	Double wareNotify
			,	Int32 wareSellerID
			,	DateTime wareEndDate)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_ware_isp", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmwareName = new SqlParameter("@name", SqlDbType.VarChar, 500);
			prmwareName.Value = wareName;
			myCommand.Parameters.Add(prmwareName);

			SqlParameter prmwareDesc = new SqlParameter("@desc", SqlDbType.VarChar, 1000);
			prmwareDesc.Value = wareDesc;
			myCommand.Parameters.Add(prmwareDesc);

			SqlParameter prmwareAsk = new SqlParameter("@ask", SqlDbType.Money);
			prmwareAsk.Value = wareAsk;
			myCommand.Parameters.Add(prmwareAsk);

			SqlParameter prmwareNotify = new SqlParameter("@notify", SqlDbType.Money);
			prmwareNotify.Value = wareNotify;
			myCommand.Parameters.Add(prmwareNotify);

			SqlParameter prmPersonID = new SqlParameter("@personid", SqlDbType.BigInt);
			prmPersonID.Value = wareSellerID;
			myCommand.Parameters.Add(prmPersonID);

			SqlParameter prmwareEndDate = new SqlParameter("@End", SqlDbType.DateTime);
			prmwareEndDate.Value = wareEndDate;
			myCommand.Parameters.Add(prmwareEndDate);

			try
			{
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				myConnection.Close();

				return "1";
			}
			catch (SqlException SQLexc)
			{
				return SQLexc.ToString();
			}
		}


		
		/// View wares for a particular seller
	
		public SqlDataReader Viewwares(Int32 intSellerID)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_ware_sel", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter prmSellerID = new SqlParameter("@sellerid", SqlDbType.BigInt);
			prmSellerID.Value = intSellerID;
			myCommand.Parameters.Add(prmSellerID);

			myConnection.Open();
			SqlDataReader Result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return Result;
		}


		
		/// ����ĳ����Ʒ����Ϣ
	
		public string Updateware(string strwareID
			, string strwareName
			, string strwareDesc 
			, string strAskPrice
			, string strNotifyPrice)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_ware_usp", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmwareID = new SqlParameter("@wareid", SqlDbType.BigInt);
			prmwareID.Value = Convert.ToInt32(strwareID);
			myCommand.Parameters.Add(prmwareID);

			SqlParameter prmwareName = new SqlParameter("@warename", SqlDbType.VarChar, 500);
			prmwareName.Value = strwareName;
			myCommand.Parameters.Add(prmwareName);

			SqlParameter prmwareDesc = new SqlParameter("@desc", SqlDbType.VarChar, 1000);
			prmwareDesc.Value = strwareDesc;
			myCommand.Parameters.Add(prmwareDesc);

			SqlParameter prmAsk = new SqlParameter("@ask", SqlDbType.Money);
			prmAsk.Value = Convert.ToDouble(strAskPrice);
			myCommand.Parameters.Add(prmAsk);

			SqlParameter prmNotify = new SqlParameter("@notify", SqlDbType.Money);
			prmNotify.Value = Convert.ToDouble(strNotifyPrice);
			myCommand.Parameters.Add(prmNotify);

			try
			{
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				myConnection.Close();

				return "1";
			}
			catch (SqlException SQLexc)
			{
				return SQLexc.ToString();
			}
		}

		
		/// Extract a list of wares for sale
	
		public SqlDataReader ViewwaresForSale()
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_wares_for_sale", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			myConnection.Open();
			SqlDataReader Result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return Result;
		}


		
		/// View a list of bids on a sale ware
		
		public SqlDataReader GetBidDetails(Int32 intwareID)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_Get_Bid_Details", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter prmwareID = new SqlParameter("@wareid", SqlDbType.BigInt);
			prmwareID.Value = intwareID;
			myCommand.Parameters.Add(prmwareID);

			myConnection.Open();
			SqlDataReader Result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return Result;
		}


		
		/// ���ĳ����Ʒ����߾���
		
		public string GetHighestBid(Int32 intwareID)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_get_highest_bid", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmwareID = new SqlParameter("@wareid", SqlDbType.BigInt);
			prmwareID.Value = intwareID.ToString();
			myCommand.Parameters.Add(prmwareID);

			SqlParameter prmHighBid = new SqlParameter("@highbid", SqlDbType.Money);
			prmHighBid.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmHighBid);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			if (Convert.IsDBNull(prmHighBid.Value))
				return "0";
			else
				return prmHighBid.Value.ToString();
		}


		
		/// Ϊĳ��Ʒ����һ��������Ϣ
		
		public string AddBid(Int32 wareID
			, Int32 BidderID
			, Double BidAmount)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_bid_isp", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmwareID = new SqlParameter("@wareid", SqlDbType.BigInt);
			prmwareID.Value = wareID;
			myCommand.Parameters.Add(prmwareID);

			SqlParameter prmBidderID = new SqlParameter("@bidderid", SqlDbType.BigInt);
			prmBidderID.Value = BidderID;
			myCommand.Parameters.Add(prmBidderID);

			SqlParameter prmBidAmount = new SqlParameter("@bidamount", SqlDbType.Money);
			prmBidAmount.Value = BidAmount;
			myCommand.Parameters.Add(prmBidAmount);

			SqlParameter prmStatus = new SqlParameter("@status", SqlDbType.Char, 1);
			prmStatus.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmStatus);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			return prmStatus.Value.ToString();
		}


		
		/// Ϊĳ��Ʒ����һ�γɹ��Ľ��׼�¼
		
		public string AddSale(Int32 wareID
			, Int32 BidID)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_sale_isp", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmwareID = new SqlParameter("@wareid", SqlDbType.BigInt);
			prmwareID.Value = wareID;
			myCommand.Parameters.Add(prmwareID);

			SqlParameter prmBidID = new SqlParameter("@bidid", SqlDbType.BigInt);
			prmBidID.Value = BidID;
			myCommand.Parameters.Add(prmBidID);

			try
			{
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				myConnection.Close();

				return "1";
			}
			catch (SqlException SQLexc)
			{
				return SQLexc.ToString();
			}
		}


		
		/// ����ĳ�û���ǰ���괦�����ȵ�λ��������Ʒ
	
		public SqlDataReader GetMyWinningBids(Int32 intPersonID)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_my_winning_bids", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter prmPersonID = new SqlParameter("@userid", SqlDbType.BigInt);
			prmPersonID.Value = intPersonID;
			myCommand.Parameters.Add(prmPersonID);

			myConnection.Open();
			SqlDataReader Result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return Result;
		}


	
		///һ����Ʒ�������
	
		public string CompleteSale(Int32 wareID
			, Double WinningBid)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_sale_complete", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmwareID = new SqlParameter("@wareid", SqlDbType.BigInt);
			prmwareID.Value = wareID;
			myCommand.Parameters.Add(prmwareID);

			SqlParameter prmWinningBidAmount = new SqlParameter("@bidamount", SqlDbType.Money);
			prmWinningBidAmount.Value = WinningBid;
			myCommand.Parameters.Add(prmWinningBidAmount);

			try
			{
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				myConnection.Close();

				return "1";
			}
			catch (SqlException SQLexc)
			{
				return SQLexc.ToString();
			}
		}


	
		/// ɾ��ĳ����Ʒ
	
		public string Deleteware(Int32 wareID)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_ware_dsp", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmwareID = new SqlParameter("@wareid", SqlDbType.BigInt);
			prmwareID.Value = wareID;
			myCommand.Parameters.Add(prmwareID);

			try
			{

				myConnection.Open();
				myCommand.ExecuteNonQuery();
				myConnection.Close();

				return "1";
			}
			catch (SqlException SQLexc)
			{
				return SQLexc.ToString();
			}
		}
	}
}

