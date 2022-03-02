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
	/// IStoreDBO 的摘要说明。
	/// </summary>
	public class IStoreDBO
	{
		
		public IStoreDBO(){}

		public UserDetails GetUserDetails(String userID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UserInfo", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(userID);
			myCommand.Parameters.Add(parameterUserID);

			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
			//指出该参数是存储过程的OUTPUT参数
			parameterUserName.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterUserName);

			SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
			//指出该参数是存储过程的OUTPUT参数
			parameterPassword.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterPassword);

			SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
			//指出该参数是存储过程的OUTPUT参数
			parameterName.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterName);
			
			SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
			//指出该参数是存储过程的OUTPUT参数
			parameterEmail.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterEmail);

			SqlParameter parameterIDCardNumber = new SqlParameter("@IDCardNumber", SqlDbType.NVarChar, 50);
			//指出该参数是存储过程的OUTPUT参数
			parameterIDCardNumber.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterIDCardNumber);

			SqlParameter parameterTelephoneNumber = new SqlParameter("@TelephoneNumber", SqlDbType.NVarChar, 50);
			//指出该参数是存储过程的OUTPUT参数
			parameterTelephoneNumber.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterTelephoneNumber);
			
			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();

			//产生UserDetails类的对象
			UserDetails myUserDetails = new UserDetails();

			//根据存储过程的输出参数的值对myUserDetails对象进行赋值
			myUserDetails.UserName = (string)parameterUserName.Value;
			myUserDetails.Password = (string)parameterPassword.Value;
			myUserDetails.Name = (string)parameterName.Value;
			myUserDetails.Email = (string)parameterEmail.Value;
			myUserDetails.IDCardNumber = (string)parameterIDCardNumber.Value;
			myUserDetails.TelephoneNumber = (string)parameterTelephoneNumber.Value;

			return myUserDetails;
		}

	
	  // AddUser方法往数据库里面插入一条新用户的记录。返回唯一的"UserId"号
		
		public String AddUser(string UserName, string password, string fullName, string email, string IDCardNumber, string TelephoneNumber) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddUser", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
			parameterUserName.Value = UserName;
			myCommand.Parameters.Add(parameterUserName);

			SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
			//给存储过程添加参数
			parameterPassword.Value = password;
			myCommand.Parameters.Add(parameterPassword);

			SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
			//给存储过程添加参数
			parameterName.Value = fullName;
			myCommand.Parameters.Add(parameterName);

			SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
			//给存储过程添加参数
			parameterEmail.Value = email;
			myCommand.Parameters.Add(parameterEmail);

			SqlParameter parameterIDCardNumber = new SqlParameter("@IDCardNumber", SqlDbType.NVarChar, 50);
			//给存储过程添加参数
			parameterIDCardNumber.Value = IDCardNumber;
			myCommand.Parameters.Add(parameterIDCardNumber);

			SqlParameter parameterTelephoneNumber = new SqlParameter("@TelephoneNumber", SqlDbType.NVarChar, 50);
			//给存储过程添加参数
			parameterTelephoneNumber.Value = TelephoneNumber;
			myCommand.Parameters.Add(parameterTelephoneNumber);

			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			//指出该参数是存储过程的OUTPUT参数
			parameterUserID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterUserID);

			try 
			{
				//打开数据库连接
				myConnection.Open();
				//进行数据库操作
				myCommand.ExecuteNonQuery();
				//关闭数据库连接
				myConnection.Close();

				//使用存储过程的输出参数返回UserID
				int UserId = (int)parameterUserID.Value;

				return UserId.ToString();
			}
			catch 
			{
				return String.Empty;
			}
		}

		//UserLogin() 方法用于判断用户的登录是否合法
		public String UserLogin(string username, string password) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UserLogin", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterUsername = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
			parameterUsername.Value = username;
			myCommand.Parameters.Add(parameterUsername);

			//给存储过程添加参数
			SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
			parameterPassword.Value = password;
			myCommand.Parameters.Add(parameterPassword);

			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			//指出该参数是存储过程的OUTPUT参数
			parameterUserID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterUserID);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();

			//使用存储过程的输出参数返回UserID并赋值给userId
			int userId = (int)(parameterUserID.Value);
			//判断userId的值，如果为零则说明登录失败，函数返回空字符串，
			//反之把userId转换为字符串返回。
			if (userId == 0) 
			{
				return null;
			}
			else 
			{
				return userId.ToString();
			}
		}


		//Getwaretype() 方法获取货物类型列表
		public SqlDataReader Getwaretype() 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("Listwaretype", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//打开数据库连接
			myConnection.Open();
			//执行数据操作命令
			//SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			//返回DataReader的结果
			return result;
		}
		
		// GetwareBytype方法返回指定种类的所有商品
		
		public SqlDataReader GetwareBytype(int categoryID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("wareByCategory", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterCategoryID = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
			parameterCategoryID.Value = categoryID;
			myCommand.Parameters.Add(parameterCategoryID);

			//打开数据库连接
			myConnection.Open();
			//执行数据操作命令
			//SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            
			//返回DataReader的结果
			return result;
		}

		
		//  GetwareDetails方法返回指定商品的详细信息
		
		public wareDetails GetwareDetails(int wareID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("wareDetail", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterwareID = new SqlParameter("@wareID", SqlDbType.Int, 4);
			parameterwareID.Value = wareID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterUnitCost = new SqlParameter("@UnitCost", SqlDbType.Money, 8);
			//指出该参数是存储过程的OUTPUT参数
			parameterUnitCost.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterUnitCost);

			SqlParameter parameterModelNumber = new SqlParameter("@ModelNumber", SqlDbType.NVarChar, 50);
			//指出该参数是存储过程的OUTPUT参数
			parameterModelNumber.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterModelNumber);

			SqlParameter parameterModelName = new SqlParameter("@ModelName", SqlDbType.NVarChar, 50);
			//指出该参数是存储过程的OUTPUT参数
			parameterModelName.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterModelName);

			

			SqlParameter parameterDescription = new SqlParameter("@wareshow", SqlDbType.NVarChar, 4000);
			//指出该参数是存储过程的OUTPUT参数
			parameterDescription.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterDescription);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();

			//产生wareDetails类的对象
			wareDetails mywareDetails = new wareDetails();
			//根据存储过程的输出参数的值对mywareDetails对象进行赋值
			mywareDetails.ModelNumber = (string)parameterModelNumber.Value;
			mywareDetails.ModelName = (string)parameterModelName.Value;			
			mywareDetails.UnitCost = (decimal)parameterUnitCost.Value;
			mywareDetails.Description = ((string)parameterDescription.Value).Trim();

			return mywareDetails;
		}

		
		// 返回销量最好的10种商品
		
		public SqlDataReader GetMostSoldware() 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("MostSoldware", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//打开数据库连接
			myConnection.Open();
			//执行数据操作命令
			//SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			//返回DataReader的结果
			return result;
		}

	
		
		// 用于查找符合条件的商品
		
		public SqlDataReader SearchwareDescriptions(string searchString) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("Searchware", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterSearch = new SqlParameter("@Search", SqlDbType.NVarChar, 255);
			parameterSearch.Value = searchString;
			myCommand.Parameters.Add(parameterSearch);

			//执行数据操作命令并返回结果的记录集
			myConnection.Open();
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//返回DataReader的结果
			return result;
		}

		//GetUserOrders方法用于查询用户订单列表
		public SqlDataReader GetUserOrders(String UserID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("ListOrders", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(UserID);
			myCommand.Parameters.Add(parameterUserID);

			//打开数据库连接
			myConnection.Open();
			//执行数据操作命令
			//SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//返回DataReader的结果
			return result;
		}

		//GetOrderDetails方法用于查询订单的详细信息
		public OrderDetails GetOrderDetails(int orderID, string userID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlDataAdapter myCommand = new SqlDataAdapter("OrdersDetail", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
			parameterOrderID.Value = orderID;
			myCommand.SelectCommand.Parameters.Add(parameterOrderID);

			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(userID);
			myCommand.SelectCommand.Parameters.Add(parameterUserID);

			SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
			//指出该参数是存储过程的OUTPUT参数
			parameterOrderDate.Direction = ParameterDirection.Output;
			myCommand.SelectCommand.Parameters.Add(parameterOrderDate);

			SqlParameter parameterOrderTotalCost = new SqlParameter("@OrderTotalCost", SqlDbType.Money, 8);
			parameterOrderTotalCost.Direction = ParameterDirection.Output;
			myCommand.SelectCommand.Parameters.Add(parameterOrderTotalCost);

			//创建数据集
			DataSet myDataSet = new DataSet();
			//往数据集里面填充数据
			myCommand.Fill(myDataSet, "OrderItems");
            
			//创建OrderDetails类的对象
			OrderDetails myOrderDetails = new OrderDetails();
			//利用存储过程的参数给对象myOrderDetails赋值
			myOrderDetails.OrderDate = (DateTime)parameterOrderDate.Value;
			myOrderDetails.OrderTotalCost = (decimal)parameterOrderTotalCost.Value;
			myOrderDetails.OrderItems = myDataSet;

			//返回数据
			return myOrderDetails;
		}

		// PlaceOrder方法往数据库里面添加新的订单记录，同时清空当前对应的购物车里面的所有商品
		
		public int PlaceOrder(string UserID, string cartID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddOrder", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(UserID);
			myCommand.Parameters.Add(parameterUserID);
			//给存储过程添加参数
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);
			//给存储过程添加参数
			SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
			parameterOrderDate.Value = DateTime.Now;
			myCommand.Parameters.Add(parameterOrderDate);
			
			SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
			//指出该参数是存储过程的OUTPUT参数
			parameterOrderID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterOrderID);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();

			//利用存储过程的OUTPUT参数返回OrderID
			return (int)parameterOrderID.Value;
		}
		
		// DisplayShoppingCart方法显示一个购物车的所包含的所有商品的列表
		
		public SqlDataReader DisplayShoppingCart(string cartID) 
		{
			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("DisplayShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			//打开数据库连接
			myConnection.Open();
			//执行数据操作命令
			//SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//返回DataReader的结果
			return result;
		}
		
		// AddItemtoShoppingCart方法负责往购物车里面添加一个新的商品
		
		public void AddItemtoShoppingCart(string cartID, int wareID, int quantity) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddItemtoShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterwareID = new SqlParameter("@wareID", SqlDbType.Int, 4);
			parameterwareID.Value = wareID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterQuantity = new SqlParameter("@wareQuantity", SqlDbType.Int, 4);
			parameterQuantity.Value = quantity;
			myCommand.Parameters.Add(parameterQuantity);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();
		}


		
		// ShoppingCartUpdate方法用于更新购物车里某件商品的购买数量
		
		public void ShoppingCartUpdate(string cartID, int wareID, int quantity) 
		{			
			if (quantity < 0) 
			{
				throw new Exception("购买商品的数量不能为负数");
			}

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UpdateShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterShoppingCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterShoppingCartID.Value = cartID;
			myCommand.Parameters.Add(parameterShoppingCartID);

			SqlParameter parameterwareID = new SqlParameter("@wareID", SqlDbType.Int, 4);
			parameterwareID.Value = wareID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterwareQuantity = new SqlParameter("@wareQuantity", SqlDbType.Int, 4);
			parameterwareQuantity.Value = quantity;
			myCommand.Parameters.Add(parameterwareQuantity);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();
		}


		
		// ShoppingCartRemoveItem方法用于从购物车中删除一种商品。
		
		public void ShoppingCartRemoveItem(string cartID, int wareID) 
		{
			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("RemoveShoppingCartItem", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterShoppingCartID = new SqlParameter("@ShoppingCartID", SqlDbType.Int, 4);
			parameterShoppingCartID.Value = cartID;
			myCommand.Parameters.Add(parameterShoppingCartID);

			SqlParameter parameterwareID = new SqlParameter("@wareID", SqlDbType.NVarChar, 50);
			parameterwareID.Value = wareID;
			myCommand.Parameters.Add(parameterwareID);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();
		}

		// CountShoppingCartItem方法返回购物车中商品种类的数量
		
		public int CountShoppingCartItem(string cartID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("CountShoppingCartItem", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterItemCount = new SqlParameter("@ItemCount", SqlDbType.Int, 4);
			parameterItemCount.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterItemCount);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();

			//利用存储过程的OUTPUT参数返回ItemCount，即商品的数量
			return ((int)parameterItemCount.Value);
		}


		
		// ShoppingCartTotalCost方法返回购物车中所有商品的价格总额
		
		public decimal ShoppingCartTotalCost(string cartID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("ShoppingCartTotalCost", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterTotalCost = new SqlParameter("@TotalCost", SqlDbType.Money, 8);
			parameterTotalCost.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterTotalCost);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			//返回价格总额
			if (parameterTotalCost.Value.ToString() != "") 
			{
				return (decimal)parameterTotalCost.Value;
			}
			else 
			{
				return 0;
			}
		}


		
		// TransplantShoppingCart方法用于把一个购物车里面的商品转移到另一个购物车里面去。
	
		
		public void TransplantShoppingCart(String oldCartId, String newCartId) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("TransplantShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
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

		
		
		// ShoppingCartEmpty方法用于清空一个购物车里面的所有商品
	
		public void ShoppingCartEmpty(string cartID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("EmptyShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter cartid = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			cartid.Value = cartID;
			myCommand.Parameters.Add(cartid);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}


		
		// GetShoppingCartId方法用于生成一个购物车ID来跟踪本商城的顾客的购物行为
		
		public String GetShoppingCartId() 
		{
			
			System.Web.HttpContext thecontext = System.Web.HttpContext.Current;

			//如果用户已经通过登录认证或者注册完毕，则使用该用户的UserID作为永久购物车的ID，并返回这个ID
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
				//产生一个新的随机的GUID
				Guid tempShoppingCartId = Guid.NewGuid();

				//把tempCartId发送到客户端，并作为一个cookie保存下来
				thecontext.Response.Cookies["IStore_CartID"].Value = tempShoppingCartId.ToString();

				//函数返回这个tempCartId
				return tempShoppingCartId.ToString();
			}
		}

	}

}

