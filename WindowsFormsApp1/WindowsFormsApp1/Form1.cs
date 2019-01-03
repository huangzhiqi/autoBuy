using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AutoBuy
{
    using Newtonsoft.Json;
    using System.Resources;
    using System.Speech.Synthesis;
    using System.Text.RegularExpressions;
    using System.Threading;
    using WindowsFormsApp1;

    public partial class Form1 : Form
    {
        //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; 
        //private static string url = "http://www.baidu.com";
        private static string IsHaveString = "Sofort lieferbar";

        private static bool IsBegin = false;

        string url1 = "";// "https://www.amazon.de/Aptamil-Profutura-Folgemilch-nach-Monat/dp/B016WEDI6K/";

        string url2 = "";

        string url3 = "";

        string url4 = "";

        string msg = "";

        string content = "";
        SpeechSynthesizer Speech = new SpeechSynthesizer();

        //梅西 https://www.macys.com/xapi/discover/v1/product?productIds=6893781&_deviceType=DESKTOP&_shoppingMode=SITE&_regionCode=US&currencyCode=USD&_customerState=GUEST&clientId=RVI
        //雅诗兰黛 https://m.esteelauder.com/rpc/jsonrpc.tmpl?JSONRPC=[{"method":"prodcat.querykey","params":[{"products":["PROD25671"],"query_key":"catalog-mpp-volatile"}],"id":1}]
        //sephora https://www.sephora.com/api/users/profiles/current/full?&productId=P417172
        //nd https://shop.nordstrom.com/s/estee-lauder-nutritious-2-in-1-foam-cleanser/5179951
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(GetResult);
            t.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            IsBegin = true;
            this.url1 = this.textBox2.Text;
            this.url2 = this.textBox3.Text;
            this.url3 = this.textBox4.Text;
            this.url4 = this.textBox5.Text;
        }

        private void GetResult()
        {
            while (true)
            {
                try
                {

                    string result = string.Empty;


                    if (!IsBegin)
                    {
                        continue;
                    }
                    DateTime now = DateTime.Now;
                    string pageResult = "";
                    Regex reg;
                    Match match;
                    double price;
                    textBox1.Text = now + "开始爬数据..." + "\r\n" + textBox1.Text;
                    //#region 德亚
                    //if (!string.IsNullOrEmpty(urlAmazon))
                    //{
                    //    pageResult = HttpUtils.HttpGet(urlAmazon, "");
                    //    reg = new Regex("<span class='a-color-price'>EUR (.+)</span></span>");
                    //    if (string.IsNullOrEmpty(pageResult))
                    //    {
                    //        continue;
                    //    }
                    //    match = reg.Match(pageResult);
                    //    result = match.Groups[1].Value;
                    //    price = Convert.ToDouble(result) / 100;
                    //    if (price <= 80)
                    //    {
                    //        msg = now + "德亚白2价格:" + result;
                    //        textBox1.Text = now + "德亚白2价格:" + result + "\r\n" + textBox1.Text;
                    //        threadPro();

                    //    }
                    //}
                    //#endregion

                    getNordStormResult(url1, "洗面奶");
                    getNordStormResult(url2, "科颜氏套装");
                    getYSLDResult(url3, "红石榴三件套");
                    getSEPHResult(url4, "法拉利");




                    #region 雅诗兰黛兑换
                    //if (!string.IsNullOrEmpty(url4))
                    //{
                    //    pageResult = HttpUtils.HttpGet(url4, "");

                    //    if (!string.IsNullOrEmpty(pageResult))
                    //    {
                    //        dynamic json = JsonConvert.DeserializeObject<dynamic>(pageResult);
                    //        if (json[0].result.value.offers[0].benefit_fields.ChoiceOfSkus.choicesPcatData.Count > 3)
                    //        {
                    //            msg = now + " 雅诗兰黛兑换有货";
                    //            textBox1.Text = msg + textBox1.Text;
                    //            threadPro();
                    //        }
                    //    }
                    //}
                    #endregion
                    Thread.Sleep(60000);
                }
                catch (Exception exception)
                {
                    textBox1.Text += exception.ToString() + "\r\n";
                }
            }

        }
        /// <summary>
        /// 获取雅诗兰黛结果
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="remark">备注内容</param>
        public void getYSLDResult(string url, string remark)
        {
            if (!string.IsNullOrEmpty(url))
            {
                DateTime now = DateTime.Now;
                string pageResult = HttpUtils.HttpGet(url, "");
                if (pageResult.Contains("\"isShoppable\":1"))
                {
                    string content = "雅诗兰黛" + remark + "有货";
                    string msg = now + content + "\r\n";
                    textBox1.Text = msg + textBox1.Text;
                    threadPro(msg, content);


                }
            }
        }

        /// <summary>
        /// 获取梅西结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="remark"></param>
        public void getMXResult(string url, string remark)
        {
            DateTime now = DateTime.Now;
            string pageResult = HttpUtils.HttpGet(url, "");
            if (!string.IsNullOrEmpty(pageResult))
            {
                dynamic json = JsonConvert.DeserializeObject<dynamic>(pageResult);
                if (json[0].product.availability.available == true)
                {
                    string content = "macys" + remark + " 有货";
                    string msg = now + content + "\r\n";
                    textBox1.Text = msg + textBox1.Text;
                    threadPro(msg, content);


                }
            }

        }

        public void getDMResult(string url, string remark)
        {
            DateTime now = DateTime.Now;
            string pageResult = HttpUtils.HttpGet(url, "");
            if (!string.IsNullOrEmpty(url))
            {
                pageResult = HttpUtils.HttpGet(url, "");
                if (pageResult.Contains("InStock"))
                {
                    string content = " dm" + remark + "有货";
                    string msg = now + content + "\r\n";
                    textBox1.Text = msg + textBox1.Text;
                    threadPro(msg, content);


                }
            }
        }

        /// <summary>
        /// 获取sephora结果
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="remark">备注内容</param>
        public void getSEPHResult(string url, string remark)
        {
            if (!string.IsNullOrEmpty(url))
            {
                DateTime now = DateTime.Now;
                string pageResult = HttpUtils.HttpGet(url, "");
                if (pageResult.Contains("\"isAddToBasket\":true"))
                {
                    string content = "丝芙兰" + remark + "有货";
                    string msg = now + content + "\r\n";
                    textBox1.Text = msg + textBox1.Text;
                    threadPro(msg, content);


                }
            }
        }

        /// <summary>
        /// 获取亚马逊结果
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="remark">备注内容</param>
        public void getAmazonResult(string url, string remark)
        {
            if (!string.IsNullOrEmpty(url))
            {
                DateTime now = DateTime.Now;
                string pageResult = HttpUtils.HttpGet(url, "");
                if (!string.IsNullOrEmpty(pageResult))
                {
                    if (!pageResult.Contains("目前无货"))
                    {
                        string content = " 亚马逊" + remark + "有货";
                        string msg = now + content + "\r\n";
                        textBox1.Text = msg + textBox1.Text;
                        threadPro(msg, content);
                    }
                }
            }
        }

        /// <summary>
        /// 获取ND结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="remark"></param>
        public void getNordStormResult(string url, string remark)
        {
            if (!string.IsNullOrEmpty(url))
            {
                DateTime now = DateTime.Now;
                string pageResult = HttpUtils.HttpGet(url, "");
                if (!string.IsNullOrEmpty(pageResult))
                {
                    if (!pageResult.Contains("SOLD OUT"))
                    {
                        string content = " ND" + remark + "有货";
                        string msg = now + content + "\r\n";
                        textBox1.Text = msg + textBox1.Text;
                        threadPro(msg, content);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsBegin = false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false; //不显示在系统任务栏
                notifyIcon.Visible = true; //托盘图标可见
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;  //显示在系统任务栏
            this.WindowState = FormWindowState.Normal;  //还原窗体
            notifyIcon.Visible = false;  //托盘图标隐藏
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //NetLog.WriteTextLog("test", "啊哈啊哈哈哈", DateTime.Now);
            SpeechSynthesizer hello = new SpeechSynthesizer();
            string str = "雅诗兰黛石榴套有货";
            hello.Speak(str);  //Speak(string),Speak加上字符串类型的参数
        }


        public void threadPro(string msg, string content)
        {
            Invoke(DCT, msg, content);
        }
        public static void ShowForm2(string msg, string content)
        {
            MsgShowForm f2 = new MsgShowForm(msg, content);
            f2.Show();
        }

        private delegate void dlgCrossThread(string msg, string content);
        private dlgCrossThread DCT = new dlgCrossThread(ShowForm2);

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Clipboard.SetDataObject(textBox2.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

    }
}
