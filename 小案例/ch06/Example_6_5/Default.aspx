<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Namespace="CustomControls" tagprefix="cc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
	<cc:MyCalendar id="cal1" runat="server" width="100%" DayField="Day" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" SelectionMode="None" ShowGridLines="True">
		 <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
		 <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
		 <SelectorStyle BackColor="#FFCC66" />
		 <OtherMonthDayStyle ForeColor="#CC9966" />
		 <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
		 <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
		 <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
		<ItemTemplate>			
            <br />
            <a href='Event.aspx?Eventid=<%# Container.DataItem["EventID"] %>'>                    
                <font color='<%# Container.DataItem["Color"] %>'>
                    <%# Container.DataItem["Title"] %>
                </font>
            </a>                            
        </ItemTemplate>   
    </cc:MyCalendar>
    </div>
    </form>
</body>
</html>
