using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcFrameForProjectModel
{
    public class ConstantConfig
    {
        //
        public static string Index_Url = "/Home/Index";

        public static string Login_In_Url = "/Index/Index";

        public static string UserName_Error = "用户不存在！";

        public static string PassWd_Error = "密码错误！";

        public static string UserName_Is_Null = "用户名不能为空！";

        public static string PassWd_Is_Null = "密码不能为空！";

        public static string Verification_Code_Is_Null = "验证码不能为空！";

        public static string Login_Ok = "登陆成功！";

        public static string Img_error = "验证码错误！";

        public static string Success = "成功！";

        public static string Error = "错误！";

        public static string Failed = "失败！";

        ///<summary>
        ///加密解密密钥
        ///</summary>
        public static string KEY = "HqXBC*ZK";
    }
}
