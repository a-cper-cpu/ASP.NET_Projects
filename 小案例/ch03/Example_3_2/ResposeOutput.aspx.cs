using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ResposeOutput : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{	///输出Respose对象的属性
			Response.Write("是否使用Buffer:" + Response.Buffer.ToString() + "<br>");
			Response.Write("是否使用BufferOutput:" + Response.BufferOutput.ToString() + "<br>");
			Response.Write("Cahce:" + Response.Cache.VaryByHeaders.ToString() + Response.Cache.VaryByParams.ToString() + "<br>");
			Response.Write("CacheControl:" + Response.CacheControl.ToString() + "<br>");
			Response.Write("字符集:" + Response.Charset + "<br>");
			Response.Write("编码:" + Response.ContentEncoding.EncodingName + "<br>");
			Response.Write("MIME类型:" + Response.ContentType.ToString() + "<br>");
			Response.Write("网页过期时间（单位：分钟）:" + Response.Expires.ToString() + "<br>");
			Response.Write("头编码:" + Response.HeaderEncoding.EncodingName + "<br>");
			Response.Write("是否仍然链接服务器:" + Response.IsClientConnected.ToString() + "<br>");
			Response.Write("是否正在被传输到新的位置:" + Response.IsRequestBeingRedirected.ToString() + "<br>");
			Response.Write("RedirectLocation:" + Response.RedirectLocation + "<br>");
			Response.Write("状态栏:" + Response.Status.ToString() + "<br>");
			Response.Write("状态代码:" + Response.StatusCode.ToString() + "<br>");
			Response.Write("状态字符串:" + Response.StatusDescription.ToString() + "<br>");
			Response.Write("是否将HTTP内容发送到客户端:" + Response.SuppressContent.ToString() + "<br>");			
		}
		///结束输出
		Response.End();
    }
}
