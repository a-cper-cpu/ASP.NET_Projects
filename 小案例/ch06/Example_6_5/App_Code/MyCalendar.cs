using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CustomControls
{
	/// <summary>
	/// 定义CalendarItem
	/// </summary>
	public class CalendarItem:Control,INamingContainer
	{
		/// <summary>
		/// 数据行
		/// </summary>
		private DataRow m_dataItem;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="dr"></param>
		public CalendarItem(DataRow dr)
		{
			m_dataItem = dr;
		}

		/// <summary>
		/// 属性DataItem
		/// </summary>
		public DataRow DataItem
		{
			get { return m_dataItem; }
			set { m_dataItem = value; }
		}
	}

	/// <summary>
	/// 定义MyCalendar控件
	/// </summary>
	public class MyCalendar:Calendar,INamingContainer
	{
		/// <summary>
		/// 数据源
		/// </summary>
		private object m_dataSource;
		/// <summary>
		/// 数据成员
		/// </summary>
		private string m_dataMember;
		/// <summary>
		/// 域
		/// </summary>
		private string m_dayField;
		/// <summary>
		/// 模板
		/// </summary>
		private ITemplate m_itemTemplate;
		/// <summary>
		/// 模板
		/// </summary>
		private ITemplate m_noEventsTemplate;
		/// <summary>
		/// 样式
		/// </summary>
		private TableItemStyle m_dayWithEventsStyle;
		/// <summary>
		/// 数据源
		/// </summary>
		private DataTable m_dtSource;

		/// <summary>
		/// 属性DataSource
		/// </summary>
		public object DataSource
		{
			get { return m_dataSource; }
			set
			{   ///设置数据源
				if(value is DataTable || value is DataSet)
				{
					m_dataSource = value;
				}
				else
				{
					throw new Exception("数据源必须为DataTable对象或者DataSet对象。");
				}
			}
		}

		/// <summary>
		/// 属性DataMember
		/// </summary>
		public string DataMember
		{
			get { return m_dataMember; }
			set { m_dataMember = value; }
		}
		/// <summary>
		/// 属性DayField
		/// </summary>
		public string DayField
		{
			get { return m_dayField; }
			set { m_dayField = value; }
		}
		/// <summary>
		/// 属性DayWithEventsStyle
		/// </summary>
		public TableItemStyle DayWithEventsStyle
		{
			get { return m_dayWithEventsStyle; }
			set { m_dayWithEventsStyle = value; }
		}

		/// <summary>
		/// 属性ItemTemplate
		/// </summary>
		[TemplateContainer(typeof(CalendarItem))]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		/// <summary>
		/// 属性NoEventsTemplate
		/// </summary>
		[TemplateContainer(typeof(CalendarItem))]
		public ITemplate NoEventsTemplate
		{
			get { return m_noEventsTemplate; }
			set { m_noEventsTemplate = value; }
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public MyCalendar(): base()
		{
			this.SelectionMode = CalendarSelectionMode.None;
			this.ShowGridLines = true;
		}
		/// <summary>
		/// 重新构建每一个日历表格
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="r"></param>
		/// <param name="t"></param>
		private void SetupCalendarItem(TableCell cell,DataRow r,ITemplate t)
		{
			CalendarItem dti = new CalendarItem(r);
			t.InstantiateIn(dti);
			///数据绑定
			dti.DataBind();
			///添加数据
			cell.Controls.Add(dti);
		}
		/// <summary>
		/// 重新构建DayReader
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="day"></param>
		protected override void OnDayRender(TableCell cell,CalendarDay day)
		{
			if(m_dtSource != null)
			{   ///格式化
				DataView dv = new DataView(m_dtSource);
				dv.RowFilter = string.Format(
				   "{0} >= #{1}# and {0} < #{2}#",
				   this.DayField,
				   day.Date.ToString("MM/dd/yyyy"),
				   day.Date.AddDays(1).ToString("MM/dd/yyyy")
				);

				if(dv.Count > 0)
				{   ///添加样式
					if(this.DayWithEventsStyle != null)
					{
						cell.ApplyStyle(this.DayWithEventsStyle);
					}
					///加载模板
					if(this.ItemTemplate != null)
					{   ///加载模板的控件
						for(int i = 0; i < dv.Count; i++)
						{
							SetupCalendarItem(cell,dv[i].Row,this.ItemTemplate);
						}
					}
				}
				else
				{   ///加载模板
					if(this.NoEventsTemplate != null)
					{
						SetupCalendarItem(cell,null,this.NoEventsTemplate);
					}
				}
			}
			base.OnDayRender(cell,day);
		}

		/// <summary>
		/// 重新构建Reader
		/// </summary>
		/// <param name="html"></param>
		protected override void Render(HtmlTextWriter html)
		{
			///定义数据源
			m_dtSource = null;
			if(this.DataSource != null && this.DayField != null)
			{   ///设置数据源
				if(this.DataSource is DataTable)
				{
					m_dtSource = (DataTable)this.DataSource;
				}
				if(this.DataSource is DataSet)
				{   ///数据源为DataSet对象
					DataSet ds = (DataSet)this.DataSource;
					if(this.DataMember == null || this.DataMember == "")
					{
						m_dtSource = ds.Tables[0];
					}
					else
					{   
						m_dtSource = ds.Tables[this.DataMember];
					}
				}
				if(m_dtSource == null)
				{
					throw new Exception("数据源错误。");
				}
			}
			base.Render(html);
		}
	}
}
