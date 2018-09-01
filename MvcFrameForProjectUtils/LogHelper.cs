using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// 日志帮助类
/// </summary>
public class LogHelper
{

    /// <summary>
    /// 记录错误信息
    /// </summary>
    /// <param name="ex">错误</param>
    public static void ErrorLog(Exception ex)
    {
        string dir = Path() + @"/Log/" + DateTime.Now.ToString("yyyy-MM") + "/";
        string fileName = "Errorlogs_" + DateTime.Now.ToString("dd") + ".Log";
        string path = dir + fileName;
        StreamWriter sw = null;
        try
        {
            Directory.CreateDirectory(dir);
            sw = new StreamWriter(path, true);
            sw.WriteLine(string.Format("-------------{0}--------------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")));
            sw.WriteLine(ex.ToString());
            sw.WriteLine();
            sw.Flush();
        }
        catch { }
        finally
        {
            if (sw != null)
            {
                sw.Close();
                sw = null;
            }
        }
    }

    /// <summary>
    /// 记录详细信息
    /// </summary>
    /// <param name="type">警号类型</param>
    /// <param name="title">标题</param>
    /// <param name="ip">ip</param>
    /// <param name="user">用户</param>
    /// <param name="str">错误信息</param>
    public static void Log(string type,string title,string paths,string ip,string user,string str)
    {
        string dir = Path() + @"/Log/" + DateTime.Now.ToString("yyyy-MM") + "/";
        string fileName = "logs_" + DateTime.Now.ToString("dd") + ".Log";
        string path = dir + fileName;
        StreamWriter sw = null;
        try
        {
            Directory.CreateDirectory(dir);
            sw = new StreamWriter(path, true);
            sw.WriteLine(string.Format("---------------------------------{0}-----------------------------------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")));
            sw.WriteLine(string.Format("--警告类型:{0}---", type));
            sw.WriteLine(string.Format("--TITLE:{0}---", title));
            sw.WriteLine(string.Format("--错误地址:{0}---", paths));
            sw.WriteLine(string.Format("--IP:{0}---", ip));
            sw.WriteLine(string.Format("--User:{0}---", user));
            sw.WriteLine(str);
            sw.WriteLine(string.Format("-----------------------------------------------------------------------"));
            sw.WriteLine();
            sw.Flush();
        }
        catch { }
        finally
        {
            if (sw != null)
            {
                sw.Close();
                sw = null;
            }
        }
    }

    /// <summary>
    /// 拿到项目所在目录
    /// </summary>
    /// <returns></returns>
    private static string Path()
    {
        string path = HttpContext.Current.Server.MapPath("~/");
        return path;
    }
}
