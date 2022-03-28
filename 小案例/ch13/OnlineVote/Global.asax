<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
		SystemTools st = new SystemTools();
		SqlDataReader dr = st.GetProfiles();
		if(dr.Read())
		{
			Session["IsRepeatVote"] = dr["IsRepeatVote"].ToString();
		}
		dr.Close();
    }

    void Session_End(object sender, EventArgs e) 
    {
		Session.Clear();
		Session.Abandon();
    }
       
</script>
