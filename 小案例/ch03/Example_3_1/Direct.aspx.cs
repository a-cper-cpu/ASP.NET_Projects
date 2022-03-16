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

public partial class Direct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{   ///获取Application对象中的数据
			if(Application["Application"] != null)
			{
				Application.Lock();
				AppData.Text = Application["Application"].ToString();
				Application.UnLock();
			}
			else
			{
				AppData.Text = "值为空。";
			}
			///获取Session对象中的数据
			if(Session["Session"] != null)
			{
				SesData.Text = Session["Session"].ToString();
			}
			else
			{
				SesData.Text = "值为空。";
			}
			///获取ViewState对象中的数据
			if(ViewState["ViewState"] != null)
			{
				ViewData.Text = ViewState["ViewState"].ToString();
			}
			else
			{
				ViewData.Text = "值为空。";
			}
		}
    }
}
