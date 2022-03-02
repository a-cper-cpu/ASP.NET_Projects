using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace shopping
{
	public class UserDetails 
	{
		public String UserName;
		public String Email;
		public String Password;
		public String Name;
		public String IDCardNumber;
		public String TelephoneNumber;
	}


	public class wareDetails 
	{
		public String  ModelNumber;
		public String  ModelName;	
		public decimal UnitCost;
		public String  Description;
	}


	public class OrderDetails 
	{

		public DateTime  OrderDate;
		public decimal   OrderTotalCost;
		public DataSet   OrderItems;
	}
	
	/// <summary>
	/// IStoreDBO ��ժҪ˵����
	/// </summary>
	public class IStoreDBO
	{
		
		public IStoreDBO(){}

		public UserDetails GetUserDetails(String userID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UserInfo", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(userID);
			myCommand.Parameters.Add(parameterUserID);

			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterUserName.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterUserName);

			SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterPassword.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterPassword);

			SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterName.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterName);
			
			SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterEmail.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterEmail);

			SqlParameter parameterIDCardNumber = new SqlParameter("@IDCardNumber", SqlDbType.NVarChar, 50);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterIDCardNumber.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterIDCardNumber);

			SqlParameter parameterTelephoneNumber = new SqlParameter("@TelephoneNumber", SqlDbType.NVarChar, 50);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterTelephoneNumber.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterTelephoneNumber);
			
			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();

			//����UserDetails��Ķ���
			UserDetails myUserDetails = new UserDetails();

			//���ݴ洢���̵����������ֵ��myUserDetails������и�ֵ
			myUserDetails.UserName = (string)parameterUserName.Value;
			myUserDetails.Password = (string)parameterPassword.Value;
			myUserDetails.Name = (string)parameterName.Value;
			myUserDetails.Email = (string)parameterEmail.Value;
			myUserDetails.IDCardNumber = (string)parameterIDCardNumber.Value;
			myUserDetails.TelephoneNumber = (string)parameterTelephoneNumber.Value;

			return myUserDetails;
		}

	
	  // AddUser���������ݿ��������һ�����û��ļ�¼������Ψһ��"UserId"��
		
		public String AddUser(string UserName, string password, string fullName, string email, string IDCardNumber, string TelephoneNumber) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddUser", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
			parameterUserName.Value = UserName;
			myCommand.Parameters.Add(parameterUserName);

			SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
			//���洢������Ӳ���
			parameterPassword.Value = password;
			myCommand.Parameters.Add(parameterPassword);

			SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
			//���洢������Ӳ���
			parameterName.Value = fullName;
			myCommand.Parameters.Add(parameterName);

			SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
			//���洢������Ӳ���
			parameterEmail.Value = email;
			myCommand.Parameters.Add(parameterEmail);

			SqlParameter parameterIDCardNumber = new SqlParameter("@IDCardNumber", SqlDbType.NVarChar, 50);
			//���洢������Ӳ���
			parameterIDCardNumber.Value = IDCardNumber;
			myCommand.Parameters.Add(parameterIDCardNumber);

			SqlParameter parameterTelephoneNumber = new SqlParameter("@TelephoneNumber", SqlDbType.NVarChar, 50);
			//���洢������Ӳ���
			parameterTelephoneNumber.Value = TelephoneNumber;
			myCommand.Parameters.Add(parameterTelephoneNumber);

			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterUserID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterUserID);

			try 
			{
				//�����ݿ�����
				myConnection.Open();
				//�������ݿ����
				myCommand.ExecuteNonQuery();
				//�ر����ݿ�����
				myConnection.Close();

				//ʹ�ô洢���̵������������UserID
				int UserId = (int)parameterUserID.Value;

				return UserId.ToString();
			}
			catch 
			{
				return String.Empty;
			}
		}

		//UserLogin() ���������ж��û��ĵ�¼�Ƿ�Ϸ�
		public String UserLogin(string username, string password) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UserLogin", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUsername = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
			parameterUsername.Value = username;
			myCommand.Parameters.Add(parameterUsername);

			//���洢������Ӳ���
			SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
			parameterPassword.Value = password;
			myCommand.Parameters.Add(parameterPassword);

			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterUserID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterUserID);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();

			//ʹ�ô洢���̵������������UserID����ֵ��userId
			int userId = (int)(parameterUserID.Value);
			//�ж�userId��ֵ�����Ϊ����˵����¼ʧ�ܣ��������ؿ��ַ�����
			//��֮��userIdת��Ϊ�ַ������ء�
			if (userId == 0) 
			{
				return null;
			}
			else 
			{
				return userId.ToString();
			}
		}


		//Getwaretype() ������ȡ���������б�
		public SqlDataReader Getwaretype() 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("Listwaretype", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//�����ݿ�����
			myConnection.Open();
			//ִ�����ݲ�������
			//SqlDataReader��ȡ���ݵ���¼���󣬻��Զ��ر����ݿ������
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			//����DataReader�Ľ��
			return result;
		}
		
		// GetwareBytype��������ָ�������������Ʒ
		
		public SqlDataReader GetwareBytype(int categoryID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("wareByCategory", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterCategoryID = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
			parameterCategoryID.Value = categoryID;
			myCommand.Parameters.Add(parameterCategoryID);

			//�����ݿ�����
			myConnection.Open();
			//ִ�����ݲ�������
			//SqlDataReader��ȡ���ݵ���¼���󣬻��Զ��ر����ݿ������
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            
			//����DataReader�Ľ��
			return result;
		}

		
		//  GetwareDetails��������ָ����Ʒ����ϸ��Ϣ
		
		public wareDetails GetwareDetails(int wareID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("wareDetail", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterwareID = new SqlParameter("@wareID", SqlDbType.Int, 4);
			parameterwareID.Value = wareID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterUnitCost = new SqlParameter("@UnitCost", SqlDbType.Money, 8);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterUnitCost.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterUnitCost);

			SqlParameter parameterModelNumber = new SqlParameter("@ModelNumber", SqlDbType.NVarChar, 50);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterModelNumber.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterModelNumber);

			SqlParameter parameterModelName = new SqlParameter("@ModelName", SqlDbType.NVarChar, 50);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterModelName.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterModelName);

			

			SqlParameter parameterDescription = new SqlParameter("@wareshow", SqlDbType.NVarChar, 4000);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterDescription.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterDescription);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();

			//����wareDetails��Ķ���
			wareDetails mywareDetails = new wareDetails();
			//���ݴ洢���̵����������ֵ��mywareDetails������и�ֵ
			mywareDetails.ModelNumber = (string)parameterModelNumber.Value;
			mywareDetails.ModelName = (string)parameterModelName.Value;			
			mywareDetails.UnitCost = (decimal)parameterUnitCost.Value;
			mywareDetails.Description = ((string)parameterDescription.Value).Trim();

			return mywareDetails;
		}

		
		// ����������õ�10����Ʒ
		
		public SqlDataReader GetMostSoldware() 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("MostSoldware", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//�����ݿ�����
			myConnection.Open();
			//ִ�����ݲ�������
			//SqlDataReader��ȡ���ݵ���¼���󣬻��Զ��ر����ݿ������
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			//����DataReader�Ľ��
			return result;
		}

	
		
		// ���ڲ��ҷ�����������Ʒ
		
		public SqlDataReader SearchwareDescriptions(string searchString) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("Searchware", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterSearch = new SqlParameter("@Search", SqlDbType.NVarChar, 255);
			parameterSearch.Value = searchString;
			myCommand.Parameters.Add(parameterSearch);

			//ִ�����ݲ���������ؽ���ļ�¼��
			myConnection.Open();
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//����DataReader�Ľ��
			return result;
		}

		//GetUserOrders�������ڲ�ѯ�û������б�
		public SqlDataReader GetUserOrders(String UserID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("ListOrders", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(UserID);
			myCommand.Parameters.Add(parameterUserID);

			//�����ݿ�����
			myConnection.Open();
			//ִ�����ݲ�������
			//SqlDataReader��ȡ���ݵ���¼���󣬻��Զ��ر����ݿ������
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//����DataReader�Ľ��
			return result;
		}

		//GetOrderDetails�������ڲ�ѯ��������ϸ��Ϣ
		public OrderDetails GetOrderDetails(int orderID, string userID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlDataAdapter myCommand = new SqlDataAdapter("OrdersDetail", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
			parameterOrderID.Value = orderID;
			myCommand.SelectCommand.Parameters.Add(parameterOrderID);

			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(userID);
			myCommand.SelectCommand.Parameters.Add(parameterUserID);

			SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterOrderDate.Direction = ParameterDirection.Output;
			myCommand.SelectCommand.Parameters.Add(parameterOrderDate);

			SqlParameter parameterOrderTotalCost = new SqlParameter("@OrderTotalCost", SqlDbType.Money, 8);
			parameterOrderTotalCost.Direction = ParameterDirection.Output;
			myCommand.SelectCommand.Parameters.Add(parameterOrderTotalCost);

			//�������ݼ�
			DataSet myDataSet = new DataSet();
			//�����ݼ������������
			myCommand.Fill(myDataSet, "OrderItems");
            
			//����OrderDetails��Ķ���
			OrderDetails myOrderDetails = new OrderDetails();
			//���ô洢���̵Ĳ���������myOrderDetails��ֵ
			myOrderDetails.OrderDate = (DateTime)parameterOrderDate.Value;
			myOrderDetails.OrderTotalCost = (decimal)parameterOrderTotalCost.Value;
			myOrderDetails.OrderItems = myDataSet;

			//��������
			return myOrderDetails;
		}

		// PlaceOrder���������ݿ���������µĶ�����¼��ͬʱ��յ�ǰ��Ӧ�Ĺ��ﳵ�����������Ʒ
		
		public int PlaceOrder(string UserID, string cartID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddOrder", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(UserID);
			myCommand.Parameters.Add(parameterUserID);
			//���洢������Ӳ���
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);
			//���洢������Ӳ���
			SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
			parameterOrderDate.Value = DateTime.Now;
			myCommand.Parameters.Add(parameterOrderDate);
			
			SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterOrderID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterOrderID);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();

			//���ô洢���̵�OUTPUT��������OrderID
			return (int)parameterOrderID.Value;
		}
		
		// DisplayShoppingCart������ʾһ�����ﳵ����������������Ʒ���б�
		
		public SqlDataReader DisplayShoppingCart(string cartID) 
		{
			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("DisplayShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			//�����ݿ�����
			myConnection.Open();
			//ִ�����ݲ�������
			//SqlDataReader��ȡ���ݵ���¼���󣬻��Զ��ر����ݿ������
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//����DataReader�Ľ��
			return result;
		}
		
		// AddItemtoShoppingCart�������������ﳵ�������һ���µ���Ʒ
		
		public void AddItemtoShoppingCart(string cartID, int wareID, int quantity) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddItemtoShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterwareID = new SqlParameter("@wareID", SqlDbType.Int, 4);
			parameterwareID.Value = wareID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterQuantity = new SqlParameter("@wareQuantity", SqlDbType.Int, 4);
			parameterQuantity.Value = quantity;
			myCommand.Parameters.Add(parameterQuantity);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();
		}


		
		// ShoppingCartUpdate�������ڸ��¹��ﳵ��ĳ����Ʒ�Ĺ�������
		
		public void ShoppingCartUpdate(string cartID, int wareID, int quantity) 
		{			
			if (quantity < 0) 
			{
				throw new Exception("������Ʒ����������Ϊ����");
			}

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UpdateShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterShoppingCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterShoppingCartID.Value = cartID;
			myCommand.Parameters.Add(parameterShoppingCartID);

			SqlParameter parameterwareID = new SqlParameter("@wareID", SqlDbType.Int, 4);
			parameterwareID.Value = wareID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterwareQuantity = new SqlParameter("@wareQuantity", SqlDbType.Int, 4);
			parameterwareQuantity.Value = quantity;
			myCommand.Parameters.Add(parameterwareQuantity);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();
		}


		
		// ShoppingCartRemoveItem�������ڴӹ��ﳵ��ɾ��һ����Ʒ��
		
		public void ShoppingCartRemoveItem(string cartID, int wareID) 
		{
			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("RemoveShoppingCartItem", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterShoppingCartID = new SqlParameter("@ShoppingCartID", SqlDbType.Int, 4);
			parameterShoppingCartID.Value = cartID;
			myCommand.Parameters.Add(parameterShoppingCartID);

			SqlParameter parameterwareID = new SqlParameter("@wareID", SqlDbType.NVarChar, 50);
			parameterwareID.Value = wareID;
			myCommand.Parameters.Add(parameterwareID);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();
		}

		// CountShoppingCartItem�������ع��ﳵ����Ʒ���������
		
		public int CountShoppingCartItem(string cartID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("CountShoppingCartItem", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterItemCount = new SqlParameter("@ItemCount", SqlDbType.Int, 4);
			parameterItemCount.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterItemCount);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();

			//���ô洢���̵�OUTPUT��������ItemCount������Ʒ������
			return ((int)parameterItemCount.Value);
		}


		
		// ShoppingCartTotalCost�������ع��ﳵ��������Ʒ�ļ۸��ܶ�
		
		public decimal ShoppingCartTotalCost(string cartID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("ShoppingCartTotalCost", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterTotalCost = new SqlParameter("@TotalCost", SqlDbType.Money, 8);
			parameterTotalCost.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterTotalCost);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			//���ؼ۸��ܶ�
			if (parameterTotalCost.Value.ToString() != "") 
			{
				return (decimal)parameterTotalCost.Value;
			}
			else 
			{
				return 0;
			}
		}


		
		// TransplantShoppingCart�������ڰ�һ�����ﳵ�������Ʒת�Ƶ���һ�����ﳵ����ȥ��
	
		
		public void TransplantShoppingCart(String oldCartId, String newCartId) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("TransplantShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter cart1 = new SqlParameter("@OldShoppingCartId ", SqlDbType.NVarChar, 50);
			cart1.Value = oldCartId;
			myCommand.Parameters.Add(cart1);

			SqlParameter cart2 = new SqlParameter("@NewShoppingCartId ", SqlDbType.NVarChar, 50);
			cart2.Value = newCartId;
			myCommand.Parameters.Add(cart2);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}

		
		
		// ShoppingCartEmpty�����������һ�����ﳵ�����������Ʒ
	
		public void ShoppingCartEmpty(string cartID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("EmptyShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter cartid = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			cartid.Value = cartID;
			myCommand.Parameters.Add(cartid);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}


		
		// GetShoppingCartId������������һ�����ﳵID�����ٱ��̳ǵĹ˿͵Ĺ�����Ϊ
		
		public String GetShoppingCartId() 
		{
			
			System.Web.HttpContext thecontext = System.Web.HttpContext.Current;

			//����û��Ѿ�ͨ����¼��֤����ע����ϣ���ʹ�ø��û���UserID��Ϊ���ù��ﳵ��ID�����������ID
			if (thecontext.User.Identity.Name != "") 
			{
				return thecontext.User.Identity.Name;
			}			
			if (thecontext.Request.Cookies["IStore_CartID"] != null) 
			{
				return thecontext.Request.Cookies["IStore_CartID"].Value;
			}
			else 
			{
				//����һ���µ������GUID
				Guid tempShoppingCartId = Guid.NewGuid();

				//��tempCartId���͵��ͻ��ˣ�����Ϊһ��cookie��������
				thecontext.Response.Cookies["IStore_CartID"].Value = tempShoppingCartId.ToString();

				//�����������tempCartId
				return tempShoppingCartId.ToString();
			}
		}

	}

}

