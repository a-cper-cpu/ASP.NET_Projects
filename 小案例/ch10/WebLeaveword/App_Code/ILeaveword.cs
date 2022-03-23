using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// 接口ILeaveword
/// </summary>
public interface ILeaveword
{
	/// <summary>
	/// 获取所有留言信息
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetLeavewords();	

	/// <summary>
	/// 获取单个留言信息
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleLeaveword(int nLeavewordID);

	/// <summary>
	/// 添加新的留言
	/// </summary>
	/// <param name="sTitle"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	int AddLeaveword(string sTitle,string sBody);

	/// <summary>
	/// 修改留言信息
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <param name="sTitle"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	int UpdateLeaveword(int nLeavewordID,string sTitle,string sBody);

	/// <summary>
	/// 删除留言
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <returns></returns>
	int DeleteLeaveword(int nLeavewordID);
}
