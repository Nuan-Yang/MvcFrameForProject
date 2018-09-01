using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

public class ImgCodeHelper
{
    public static ImgCodeHelper _Interface()
    {
        return new ImgCodeHelper();
    }
    public  void ValidateImg( string key)
    {
        VerifyCodeSugarHelper v = new VerifyCodeSugarHelper();
        //是否随机字体颜色
        v.SetIsRandomColor = true;
        //随机码的旋转角度
        v.SetRandomAngle = 4;
        //文字大小
        v.SetFontSize = 15;
        //背景色
        //v.SetBackgroundColor
        //前景噪点数量
        //v.SetForeNoisePointCount = 3;
        //v.SetFontColor =Color.Red;
        //...还有更多设置不介绍了

        var questionList = new Dictionary<string, string>()
           {
 
               {"1+1=？","2"},
               {"喜羊羊主角叫什么名字？","喜羊羊" },
               {"【我爱你】中间的那个字？","爱" },
           };

        var questionItem = v.GetQuestion();//不赋值为随机验证码 例如： 1*2=? 这种

        //指定验证文本
        //v.SetVerifyCodeText

        v.SetVerifyCodeText = questionItem.Key;

        //SessionHelper.SetSession("VerifyCode",questionItem.Value.ToString());
        CookieHelper.SetCookie("VerifyCode", EncryptHelper.Encrypt(key, questionItem.Value.ToString())); 

        //输出图片
        v.OutputImage(System.Web.HttpContext.Current.Response);

    }
}

