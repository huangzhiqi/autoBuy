﻿using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;

/// <summary>  
/// Summary description for NetLog  
/// </summary>  
public class NetLog
{
    /// <summary>  
    /// 写入日志到文本文件  
    /// </summary>  
    /// <param name="action">动作</param>  
    /// <param name="strMessage">日志内容</param>  
    /// <param name="time">时间</param>  
    public static void WriteTextLog(string action, string strMessage, DateTime time)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + @"Log\";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string fileFullPath = path + "System.txt";
        StringBuilder str = new StringBuilder();
        str.Append("Time:    " + time.ToString() + "\r\n");
        str.Append("Action:  " + action + "\r\n");
        str.Append("Message: " + strMessage + "\r\n");
        str.Append("-----------------------------------------------------------\r\n\r\n");
        StreamWriter sw;
        if (!File.Exists(fileFullPath))
        {
            sw = File.CreateText(fileFullPath);
        }
        else
        {
            sw = File.AppendText(fileFullPath);
        }
        sw.WriteLine(str.ToString());
        sw.Close();
    }
}