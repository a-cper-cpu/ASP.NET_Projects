using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class TestArray : System.Web.UI.Page 
{
	protected void Page_Load(object sender,System.EventArgs e)
	{
		if(!Page.IsPostBack)
		{
			TestArrayType();

			GraphPicture();

			Response.End();
		}
	}

	private void TestArrayType()
	{
		///定义一个数组，长度为100
		int[] intList = new int[100];
		for(int i = 0; i < intList.Length; i++)
		{
			///赋值
			intList[i] = i;
		}

		///定义一个二维数组
		string[,] strList = new string[5,10];
		for(int i = 0; i < strList.GetLength(0); i++)
		{
			for(int j = 0; j < strList.GetLength(strList.Rank - 1); j++)
			{
				strList[i,j] = i.ToString() + j.ToString();
			}
		}

		///输出二维数组
		for(int i = 0; i < strList.GetLength(0); i++)
		{
			for(int j = 0; j < strList.GetLength(strList.Rank - 1); j++)
			{
				Response.Write(strList[i,j]);
				if(j < strList.GetLength(strList.Rank - 1) - 1)
				{
					Response.Write(",");
				}
			}
			Response.Write("<br>");
		}
	}

	private void GraphPicture()
	{
		Point[][] picPoint = new Point[2][];
		for(int i = 0; i < picPoint.GetLength(0); i++)
		{
			picPoint[i] = new Point[(i + 1) * 10];
		}

		for(int i = 0; i < picPoint.GetLength(0); i++)
		{
			for(int j = 0; j < picPoint[i].Length; j++)
			{
				picPoint[i][j] = new Point((i + 1) * 10,j * 5);
			}
		}

		Bitmap map = new Bitmap(600,400);
		Graphics g = Graphics.FromImage(map);
		g.DrawClosedCurve(new Pen(new SolidBrush(Color.Red)),picPoint[0]);
		g.Dispose();
	}
}
