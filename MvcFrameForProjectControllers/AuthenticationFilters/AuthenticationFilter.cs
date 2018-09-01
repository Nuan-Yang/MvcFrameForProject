using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcFrameForProjectModel;
using MvcFrameForProjectBll;

namespace MvcFrameForProjectControllers
{
    public class AuthenticationFilter : FilterAttribute ,IActionFilter
    {
        public AuthenticationFilter()
        {
 
        }
        public bool flag;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
 
        }

        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (flag)
            {
                string UserDb = CookieHelper.GetCookieValue("UserInfo");
                if (!string.IsNullOrEmpty(UserDb))
                {
                    //解密
                    UserDb = EncryptHelper.Decrypt(ConstantConfig.KEY, UserDb);
                    string[] sArray=UserDb.Split(',') ;
                    //判断账号密码
                    if (UsersProvider.CookieLoginIn(sArray[0], sArray[1]))
                    {
                        return;
                    }
                    //信息有误 转跳登陆页
                }
                ActionResult url = new RedirectResult(ConstantConfig.Login_In_Url);
                filterContext.Result = url;
                return;
            }
        }
    }
}
