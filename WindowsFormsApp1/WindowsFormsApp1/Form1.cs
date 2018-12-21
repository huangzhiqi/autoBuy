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
                    #region 雅诗兰黛
                    if (!string.IsNullOrEmpty(url1))
                    {
                        pageResult = HttpUtils.HttpGet(url1, "");
                        if (pageResult.Contains("\"isShoppable\":1"))
                        {
                            msg = now + " 雅诗兰黛1有货";
                            textBox1.Text = msg + textBox1.Text;
                            threadPro();
                        }
                    }
                    #endregion
                    #region 德亚爱3
                    if (!string.IsNullOrEmpty(url2))
                    {
                        pageResult = HttpUtils.HttpGet(url2, "");
                        if (pageResult.Contains("InStock"))
                        {
                            msg = now + " dm白2有货";
                            textBox1.Text = msg + textBox1.Text;
                            threadPro();
                        }
                    }
                    #endregion
                    #region dm Pre
                    //if (!string.IsNullOrEmpty(url3))
                    //{
                    //    pageResult = HttpUtils.HttpGet(url3, "");
                    //    if (pageResult.Contains("InStock"))
                    //    {
                    //        msg = now + " dmPre有货";
                    //        textBox1.Text = msg + textBox1.Text;
                    //        threadPro();
                    //    }
                    //}
                    #endregion
                    #region 雅诗兰黛
                    if (!string.IsNullOrEmpty(url3))
                    {
                        pageResult = HttpUtils.HttpGet(url3, "");
                        if (pageResult.Contains("\"isShoppable\":1"))
                        {
                            msg = now + " 雅诗兰黛三件套有货";
                            textBox1.Text = msg + textBox1.Text;
                            threadPro();
                        }
                    }
                    #endregion
                    #region 雅诗兰黛3
                    if (!string.IsNullOrEmpty(url4))
                    {
                        pageResult = HttpUtils.HttpGet(url3, "");
                        if (pageResult.Contains("\"isShoppable\":1"))
                        {
                            msg = now + " 雅诗兰黛昼夜有货";
                            textBox1.Text = msg + textBox1.Text;
                            threadPro();
                        }
                    }
                    #endregion
                    #region 梅西
                    if (!string.IsNullOrEmpty(url2))
                    {
                        pageResult = HttpUtils.HttpGet(url2, "");
                        if (!string.IsNullOrEmpty(pageResult))
                        {
                            dynamic json = JsonConvert.DeserializeObject<dynamic>(pageResult);
                            if (json[0].product.availability.available == true)
                            {
                                msg = now + " macys有货";
                                textBox1.Text = msg + textBox1.Text;
                                threadPro();
                            }
                        }
                    }
                    #endregion
                    #region 德亚hipp
                    //if (!string.IsNullOrEmpty(url3))
                    //{
                    //    pageResult = HttpUtils.HttpGet(url3, "");
                    //    reg = new Regex("<span class='a-color-price'>￥ (.+)</span>");
                    //    if (string.IsNullOrEmpty(pageResult))
                    //    {
                    //        continue;
                    //    }
                    //    match = reg.Match(pageResult);
                    //    result = match.Groups[1].Value;
                    //    price = Convert.ToDouble(result);
                    //    if (price <= 973)
                    //    {
                    //        msg = now + "价格:" + result;
                    //        textBox1.Text = now + "价格:" + result + "\r\n" + textBox1.Text;
                    //        threadPro();
                    //    }
                    //}
                    #endregion
                    #region rossmann
                    //pageResult = HttpUtils.HttpGet(url3, "");
                    //if (pageResult.Contains("c-product-buy"))
                    //{
                    //    msg = now + "rossmann有货";
                    //    textBox1.Text = now + "rossmann有货" + "\r\n" + textBox1.Text;
                    //    threadPro();
                    //}
                    #endregion
                    #region dm
                    //pageResult = HttpUtils.HttpGet(this.urlDm, "");
                    //if (string.IsNullOrEmpty(pageResult))
                    //{
                    //    continue;
                    //}
                    //if (pageResult.Contains(IsHaveString))
                    //{
                    //    textBox1.Text = now + "dm有货" + "\r\n" + textBox1.Text;
                    //    MessageBox.Show(now + "dm有情况赶紧看！");

                    //}
                    #endregion
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
            test.main();
        }


        public void threadPro()
        {
            MethodInvoker MethInvo = new MethodInvoker(ShowForm2);
            BeginInvoke(MethInvo);
        }
        public void ShowForm2()
        {
            MsgShowForm f2 = new MsgShowForm(msg);
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Clipboard.SetDataObject(textBox2.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                Clipboard.SetDataObject(textBox4.Text);
            }
        }
    }
}
