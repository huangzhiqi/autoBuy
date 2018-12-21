using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WindowsFormsApp1
{
    public class HttpUtils
    {
        #region http方法
        /// <summary>
        /// Http发送Get请求方法
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpGet(string Url, string postDataStr)
        {
            try
            {

                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.UserAgent = " Mozilla / 5.0(Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 59.0.3071.115 Safari / 537.36";
                request.Accept = "*/*";

                request.Credentials = CredentialCache.DefaultCredentials;
                CookieContainer cookie = new CookieContainer();
                cookie.Add(new Cookie("shippingCountry", "CN", "/", ".macys.com"));
                cookie.Add(new Cookie("currency", "CNY", "/", ".macys.com"));
                cookie.Add(new Cookie("SignedIn", "0", "/", ".macys.com"));
                cookie.Add(new Cookie("GCs", "CartItem1_92_03_87_UserName1_92_4_02_", "/", ".macys.com"));
                cookie.Add(new Cookie("akavpau_www_www1_macys", "1540870468~id=8a0f0cb4aa0e6414def105f86953484f", "/", ".macys.com"));
                cookie.Add(new Cookie("_abck", "F73AD7AF74671CBC7976BD1C86B8BEF117036819371E000018D0D75B9901510C~-1~BQ9mkxZqm1JROREQe6R5Ek3TbADsrxP0I/Dlojjq9tA=~-1~-1", "/", ".macys.com"));
                cookie.Add(new Cookie("bm_sz", "204B09279D485C91C62B2E48CBB9938B~QAAQGWgDF1xozYFmAQAA4uAEwz3DGKbidMOrigIgb/S8vGUbMU5kwZhGz209EkN/8gwFNH9TE9k2mwIEMUNuHg3+5o9SDYKSEj800viFjj/tDJB0Uv5ExaIq+rozA30RwQembziaXBgh090TEp4n4pe4vWiwYz6d/2wKyXJhhHRCzoowAvM1vDo+tYNXNg==", "/", ".macys.com"));
                cookie.Add(new Cookie("TS0132ea28", "0112b7dea0fb81a1c1255d3da0390be07672f627c04444553fee74624fc431a90bc8194de3", "/", ".macys.com"));
                cookie.Add(new Cookie("mercury", "true", "/", ".macys.com"));
                cookie.Add(new Cookie("SEED", "163624101455598056%7C239-11%2C264-20%2C62-21%7C215-23%2C216-20%2C90-23", "/", ".macys.com"));
                cookie.Add(new Cookie("ak_bmsc", "1C1A25A6ECC978E76C69152FAA3DFFC717036819371E000019D0D75B7BA6292F~pl1TFDEA/yqZ7u120HlsjCW8MuBXTRhJqpAcCKL2s301n8iwgGKZQcS9HIbCyNYE/6r5joYRRmJ84fq3d4ciIusI8XBak+4EOWpGRGFzRR5EdE8Emi6k7MqKbptzhUYk0C79aUnKyfdRZEM1NLr2dXO12RRrwemUi4SD8SHZQraqqzj+gUQc3kR7jCjiQ0YYHo4Zk/DXRK2BTV1eWA8Cd6c75PKbyWgeHG7XOE6+aQeNA=", "/", ".macys.com"));
                cookie.Add(new Cookie("mercury", "true", "/", ".macys.com"));
                //cookie.Add(new Cookie("bm_mi", "117B7A94476714EEEE2D2EAE0D6F8CEB~09aKUQdlJ+Dat1b86kimGdgVxW4yjBnPU17S/YHTsdhaCqSuJzAjmcXIKU2wx8g4NdePMGGYqLoLwgGfy5K6xu4cXsT/FDtL+Qeu/b4aSbShLkNr8dsG1SP/qk5nszg9M6pmyu74F6tLwEkoCADKuaZ1bv7zh+If/EVSDo2QBawhqEeT0Txw+V17Ls1nt0HgB80BZ0MSmmMZXfrOyo/bL/dpjJGMSKJf9iE2pvT7erPxB4mtv77/lq+7WxkkfHuhUWNYKvF8cG4VTOhW1MOBcgfGXwBSbZgJIMwW8TWrlP9RFgiGsWr56HsKId2fstYBeWiqeSCZqfnCrJ5f8xyNs7C5uz/TdugzcPC0CZhWDOtrBMvqWBdFKXDf+LhoceQx", "/", ".macys.com"));
                //cookie.Add(new Cookie("AMCVS_8D0867C25245AE650A490D4C%40AdobeOrg", "1", "/", ".macys.com"));
                //cookie.Add(new Cookie("cmTPSet", "Y", "/", ".macys.com"));
                //cookie.Add(new Cookie("AMCV_8D0867C25245AE650A490D4C%40AdobeOrg", "-1891778711%7CMCIDTS%7C17835%7CMCMID%7C90584687645175226394017220932987594887%7CMCAAMLH-1541476039%7C11%7CMCAAMB-1541476039%7C6G1ynYcLPuiQxYZrsz_pkqfLG9yMXBpb2zX5dvJdYQJzPXImdj0y%7CMCOPTOUT-1540878439s%7CNONE%7CMCAID%7CNONE%7CvVersion%7C2.4.0", "/", ".macys.com"));
                cookie.Add(new Cookie("shippingCountry", "US", "/", ".macys.com"));
                cookie.Add(new Cookie("currency", "USD", "/", ".macys.com"));
                //cookie.Add(new Cookie("mercury", "true", "/", ".macys.com"));
                //cookie.Add(new Cookie("mercury", "true", "/", ".macys.com"));

                request.CookieContainer = cookie;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {

                return "";
            }
        }
        /// <summary>
        /// Http发送Post请求方法
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(postDataStr);
            writer.Flush();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码 
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }
        #endregion
    }
}