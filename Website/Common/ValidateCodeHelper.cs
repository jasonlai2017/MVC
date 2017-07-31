using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Policy;

namespace System.Web.Mvc
{
    public static class ValidateCodeHelper
    {
        private const string IdPrefix = "validateCode";
        private const int Length = 4;

        public static MvcHtmlString ValidateCode(this HtmlHelper helper)
        {
            return ValidateCode(helper, IdPrefix);
        }

        public static MvcHtmlString ValidateCode(this HtmlHelper helper, string id)
        {
            return ValidateCode(helper, id, Length);
        }

        public static MvcHtmlString ValidateCode(this HtmlHelper helper, string id, int length)
        {
            return ValidateCode(helper, id, length, null);
        }

        public static MvcHtmlString ValidateCode(this HtmlHelper helper, string id, object htmlAttributes)
        {
            return ValidateCode(helper, id, Length, htmlAttributes);
        }

        public static MvcHtmlString ValidateCode(this HtmlHelper helper, int length, object htmlAttributes)
        {
            return ValidateCode(helper, IdPrefix, length, htmlAttributes);
        }

        public static MvcHtmlString ValidateCode(this HtmlHelper helper, object htmlAttributes)
        {
            return ValidateCode(helper, 4, htmlAttributes);
        }

        public static MvcHtmlString ValidateCode(this HtmlHelper helper, int length)
        {
            return ValidateCode(helper, length, null);
        }

        public static MvcHtmlString ValidateCode(this HtmlHelper helper, string id, int length, object htmlAttributes)
        {
            string finalId = id + "_imgValidateCode";
            var tagBuild = new TagBuilder("img");
            tagBuild.GenerateId(finalId);
            var defaultController = ((Route)RouteTable.Routes["Default"]).Defaults["controller"] + "/";
            int UrlSegLength = HttpContext.Current.Request.Url.Segments.Length;
            var controller = "";
            if (UrlSegLength > 3)
            {
                controller = HttpContext.Current.Request.Url.Segments.Length == 1
                                    ? defaultController
                                    : HttpContext.Current.Request.Url.Segments[1] + HttpContext.Current.Request.Url.Segments[2];
            }
            else
            {
                controller = HttpContext.Current.Request.Url.Segments.Length == 1
                                    ? defaultController
                                    : HttpContext.Current.Request.Url.Segments[1];
            }
            tagBuild.MergeAttribute("src", string.Format("/{0}GetValidateCode?length={1}", controller, length));
            tagBuild.MergeAttribute("alt", "点击重新获取");
            tagBuild.MergeAttribute("style", "cursor:pointer;");
            tagBuild.MergeAttribute("id", finalId);
            tagBuild.MergeAttributes(AnonymousObjectToHtmlAttributes(htmlAttributes));
            var sb = new StringBuilder();
            sb.Append("<script language=\"javascript\" type=\"text/javascript\">");
            sb.Append("$(document).ready(function () {");
            sb.AppendFormat("$(\"#{0}\").bind(\"click\", function () {{", finalId);
            sb.Append("var url = $(this).attr(\"src\");");
            sb.Append("url += \"&\" + Math.random();");
            sb.Append("$(this).attr(\"src\", url);");
            sb.Append("});");
            sb.Append("});");
            sb.Append("</script>");
            return MvcHtmlString.Create(tagBuild + sb.ToString());
        }

        public static RouteValueDictionary AnonymousObjectToHtmlAttributes(object htmlAttributes)
        {
            var result = new RouteValueDictionary();

            if (htmlAttributes != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes))
                {
                    result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
                }
            }

            return result;
        }
    }

    public class ValidateCode
    {
        public ValidateCode()
        {
        }
        /// <summary>
        /// verification code max length
        /// </summary>
        public int MaxLength
        {
            get { return 10; }
        }
        /// <summary>
        /// verification code min length
        /// </summary>
        public int MinLength
        {
            get { return 1; }
        }
        /// <summary>
        /// generate verification code 
        /// </summary>
        /// <param name="length">assign verification code length</param>
        /// <returns></returns>
        public string CreateValidateCode(int length)
        {
            var randMembers = new int[length];
            var validateNums = new int[length];
            var validateNumberStr = "";
            //generate start sequence value
            var seekSeek = unchecked((int)DateTime.Now.Ticks);
            var seekRand = new Random(seekSeek);
            var beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            var seeks = new int[length];
            for (var i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //generate random number
            for (var i = 0; i < length; i++)
            {
                var rand = new Random(seeks[i]);
                var pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //extract random number
            for (var i = 0; i < length; i++)
            {
                var numStr = randMembers[i].ToString();
                var numLength = numStr.Length;
                var rand = new Random();
                var numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //generate verification code
            for (var i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }
        /// <summary>
        /// create verification code image
        /// </summary>
        /// <param name="validateCode">verification code</param>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            var image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            var g = Graphics.FromImage(image);
            try
            {
                //generate random maker
                var random = new Random();
                //clear image background
                g.Clear(Color.White);
                //drawn image foreground interfering line
                for (int i = 0; i < 25; i++)
                {
                    var x1 = random.Next(image.Width);
                    var x2 = random.Next(image.Width);
                    var y1 = random.Next(image.Height);
                    var y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                //string[] fontName = { "华文新魏", "宋体", "圆体", "黑体", "隶书" };
                //var font = new Font(fontName[new Random().Next(0, validateCode.Length)], 12, (FontStyle.Bold | FontStyle.Italic));
                var brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                //drawn image foreground troubling point 
                for (var i = 0; i < 100; i++)
                {
                    var x = random.Next(image.Width);
                    var y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //drawn image border 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //save image data
                var stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //output image stream
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// get verification code image width
        /// </summary>
        /// <param name="validateNumLength">verification code width</param>
        /// <returns></returns>
        public static int GetImageWidth(int validateNumLength)
        {
            return (int)(validateNumLength * 12.0);
        }
        /// <summary>
        /// get verification code height
        /// </summary>
        /// <returns></returns>
        public static double GetImageHeight()
        {
            return 23;
        }
    }
}