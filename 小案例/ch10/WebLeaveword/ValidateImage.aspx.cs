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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing;
using System.Text;

public partial class ValidateImage : System.Web.UI.Page
{
    private readonly string ImagePath = "Images/Validator.jpg";
    private string sValidator = "";
	private Brush[] BrushList = new Brush[32];	

    private void Page_Load(object sender, System.EventArgs e)
    {
		///初始化
		InitBrushList();

		if(Request.Params["Validator"] != null)
		{
			///获取验证字符串
			sValidator = Request.Params["Validator"].ToString();
		}

        ///创建Bmp位图
        Bitmap bitMapImage = new System.Drawing.Bitmap(Server.MapPath(ImagePath));
        Graphics graphicImage = Graphics.FromImage(bitMapImage);

        ///设置画笔的输出模式
        graphicImage.SmoothingMode = SmoothingMode.AntiAlias;
        ///添加文本字符串
		for(int i = 0; i < sValidator.Length; i++)
		{
			graphicImage.DrawString(sValidator[i].ToString(),
				new Font("Arial",20,(FontStyle)CreateRandomFontStyle(GetRandomint(0,1000))),
				BrushList[GetRandomint(0,BrushList.Length - 1)],
				new PointF(i * 15,GetRandomint(-5,5)));
		}

		//graphicImage.DrawString(sValidator, new Font("Arial", 20, (FontStyle)GetRandomint(0,4)),SystemBrushes.WindowText, new Point(0, 0));

        ///设置图像输出的格式
        Response.ContentType = "image/jpeg";

        ///保存数据流
        bitMapImage.Save(Response.OutputStream, ImageFormat.Jpeg);

        ///释放占用的资源
        graphicImage.Dispose();
        bitMapImage.Dispose();
		Response.End();
    }
	
	/// <summary>
	/// 创建一个随机数
	/// </summary>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	private int GetRandomint(int min,int max)
	{
		Random random = new Random();
		return (random.Next(min,max));
	}

	private int CreateRandomFontStyle(int random)
	{
		if(random < 200)
		{
			return 0;
		}
		if(random < 400)
		{
			return 1;
		}
		if(random < 600)
		{
			return 2;
		}
		if(random < 800)
		{
			return 3;
		}
		if(random < 1000)
		{
			return 4;
		}
		return 4;
	}

	/// <summary>
	/// 初始化Brush列表
	/// </summary>
	private void InitBrushList()
	{
		BrushList[0] = SystemBrushes.ActiveBorder;
		BrushList[1] = SystemBrushes.ActiveCaption;
		BrushList[2] = SystemBrushes.ActiveCaptionText;
		BrushList[3] = SystemBrushes.AppWorkspace;
		BrushList[4] = SystemBrushes.ButtonFace;
		BrushList[5] = SystemBrushes.ButtonHighlight;
		BrushList[6] = SystemBrushes.ButtonShadow;
		BrushList[7] = SystemBrushes.Control;
		BrushList[8] = SystemBrushes.ControlDark;
		BrushList[9] = SystemBrushes.ControlDarkDark;
		BrushList[10] = SystemBrushes.ControlLight;
		BrushList[11] = SystemBrushes.ControlText;
		BrushList[12] = SystemBrushes.Desktop;
		BrushList[13] = SystemBrushes.GradientActiveCaption;
		BrushList[14] = SystemBrushes.GradientInactiveCaption;
		BrushList[15] = SystemBrushes.GrayText;
		BrushList[16] = SystemBrushes.Highlight;
		BrushList[17] = SystemBrushes.HighlightText;
		BrushList[18] = SystemBrushes.HotTrack;
		BrushList[19] = SystemBrushes.InactiveBorder;
		BrushList[20] = SystemBrushes.InactiveCaption;
		BrushList[21] = SystemBrushes.InactiveCaptionText;
		BrushList[22] = SystemBrushes.Info;
		BrushList[23] = SystemBrushes.InfoText;
		BrushList[24] = SystemBrushes.Menu;
		BrushList[25] = SystemBrushes.MenuBar;
		BrushList[26] = SystemBrushes.MenuHighlight;
		BrushList[27] = SystemBrushes.MenuText;
		BrushList[28] = SystemBrushes.ScrollBar;
		BrushList[29] = SystemBrushes.Window;
		BrushList[30] = SystemBrushes.WindowFrame;
		BrushList[31] = SystemBrushes.WindowText;
	}
}