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
/// 接口IReplyLeaveword
/// </summary>
public interface IReplyLeaveword
{
	/// <summary>
	/// 根据留言获取回复
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <returns></returns>
	SqlDataReader GetReplyByLeaveword(int nLeavewordID);

	/// <summary>
	/// 添加留言的回复
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <param name="nReplyID"></param>
	/// <returns></returns>
	int AddLeavewordReply(int nLeavewordID,int nReplyID);

	/// <summary>
	/// 删除留言的回复
	/// </summary>
	/// <param name="nLeavewordID"></param>
	/// <param name="nReplyID"></param>
	/// <returns></returns>
	int DeleteLeavewordReply(int nLeavewordID,int nReplyID);
}