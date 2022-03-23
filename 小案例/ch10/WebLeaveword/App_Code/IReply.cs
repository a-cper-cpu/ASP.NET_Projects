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
/// 接口IReply
/// </summary>
public interface IReply
{
	/// <summary>
	/// 获取所有留言回复信息
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetReplys();	

	/// <summary>
	/// 获取单个留言回复
	/// </summary>
	/// <param name="nReplyID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleReply(int nReplyID);

	/// <summary>
	/// 添加新的留言回复
	/// </summary>
	/// <param name="sBody"></param>
	/// <returns></returns>	
	int AddReply(string sBody);

	/// <summary>
	/// 修改留言回复
	/// </summary>
	/// <param name="nReplyID"></param>	
	/// <param name="sBody"></param>
	/// <returns></returns>
	int UpdateReply(int nReplyID,string sBody);	

	/// <summary>
	/// 删除留言回复
	/// </summary>
	/// <param name="nReplyID"></param>
	/// <returns></returns>
	int DeleteReply(int nReplyID);
}
