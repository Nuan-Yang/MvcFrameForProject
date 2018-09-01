using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;

public class IpHelper
{
    /// <summary>
    /// 获取访问者Ip
    /// </summary>
    /// <returns></returns>
    public static string GetUserIp()
    {
        string userIP;
        // HttpRequest Request = HttpContext.Current.Request;  
        HttpRequest Request = System.Web.HttpContext.Current.Request; // 如果使用代理，获取真实IP  
        if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
            userIP = Request.ServerVariables["REMOTE_ADDR"];
        else
            userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (userIP == null || userIP == "")
            userIP = Request.UserHostAddress;
        return userIP;
    }

    /// <summary>
    /// 获取本机IP
    /// </summary>
    /// <returns></returns>
    public static string GetLocalIp()
    {
        //获取本机外网ip的url
        string getIpUrl = "http://www.ipip.net/ip.html";//网上获取ip地址的网站
        string tempip = "";
        WebRequest wr = WebRequest.Create(getIpUrl);
        Stream s = wr.GetResponse().GetResponseStream();
        StreamReader sr = new StreamReader(s, Encoding.UTF8);
        string all = sr.ReadToEnd(); //读取网站的数据
        //解析出需要的数据
        int start = all.IndexOf("<th colspan=\"3\">您的当前IP: <span style=\"color: rgb(243, 102, 102);\">");
        int end = all.IndexOf("</span></th>");
        tempip = all.Substring(start, end - start).Replace("<th colspan=\"3\">您的当前IP: <span style=\"color: rgb(243, 102, 102);\">", "");
        sr.Close();
        s.Close();
        return tempip;
    }
}

