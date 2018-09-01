using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using MvcFrameForProjectModel;
using MvcFrameForProjectBll;
using System.Configuration;

namespace MvcFrameForProjectControllers
{
    public class IndexController : FatherController
    {

        #region actionresult
        [AuthenticationFilter(flag = false)]
        public ActionResult Index()
        {
            return View();
        }
        #endregion


        #region JsonResult

        /// <summary>
        /// 登陆接口
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [AuthenticationFilter(flag = false)]
        public JsonResult LoginApi(UserLoginInModel list)
        {
            string mess = "", url = ConstantConfig.Login_In_Url;
            bool status = false;
            string tmp = CookieHelper.GetCookieValue("VerifyCode") != null ? CookieHelper.GetCookieValue("VerifyCode").ToString() : null;
            if (!string.IsNullOrEmpty(tmp) && !string.IsNullOrEmpty(list.VerificationCode))
            {
                if (EncryptHelper.Decrypt(ConstantConfig.KEY, tmp) == list.VerificationCode)
                {
                    //判断用户名密码是否为空
                    if (!string.IsNullOrEmpty(list.Username) && !string.IsNullOrEmpty(list.Passwd))
                    {
                        status = UsersProvider.UserLoginIn(list, out mess, out url);
                        if (status)
                        {
                            string cookie = list.Username + "," + list.Passwd;
                            //SetCookie
                            CookieHelper.SetCookie("UserInfo", EncryptHelper.Encrypt(ConstantConfig.KEY, cookie));
                            //登陆成功并返回首页链接
                            return Json(new { status = status, mess = mess, url = url });
                        }
                        //状态为false
                        status = false;
                        //返回状态值为失败并返回错误信息
                        return Json(new { status = status, mess = mess, url = url });
                    }
                    else
                    {
                        //账号为空
                        if (string.IsNullOrEmpty(list.Username))
                        {
                            mess = ConstantConfig.UserName_Is_Null;
                            return Json(new { status = status, mess = mess, url = url });
                        }
                        else
                        {
                            //密码为空
                            mess = ConstantConfig.PassWd_Is_Null;
                            return Json(new { status = status, mess = mess, url = url });
                        }
                    }
                }
                //验证码错误
                mess = ConstantConfig.Img_error;
                return Json(new { status = status, mess = mess, url = url });
            }
            if (string.IsNullOrEmpty(list.VerificationCode))
            {
                //未输入验证码
                mess = ConstantConfig.Verification_Code_Is_Null;
                return Json(new { status = status, mess = mess, url = url });
            }
            //cooke为空 或未输入验证码
            mess = ConstantConfig.Error;
            return Json(new { status = status, mess = mess, url = url });

        }


        /// <summary>
        /// 注册接口
        /// </summary>
        /// <returns></returns>
        [AuthenticationFilter(flag = false)]
        public JsonResult RegisterApi()
        {

            return Json("");
        }

        /// <summary>
        /// 注销接口
        /// </summary>
        /// <returns></returns>
        public JsonResult DelCookieApi()
        {
            string mess = "", url = ConstantConfig.Login_In_Url;
            bool status = false;
            if (!string.IsNullOrEmpty(CookieHelper.GetCookieValue("UserInfo")))
            {
                //解密
                string UserDb = EncryptHelper.Decrypt(ConstantConfig.KEY, CookieHelper.GetCookieValue("UserInfo"));
                string[] sArray = UserDb.Split(',');
                UsersProvider.DelCacheList(sArray[0], sArray[1]);
                status = true;
                mess = ConstantConfig.Success;
                CookieHelper.ClearCookie("UserInfo");
                return Json(new { status = status, mess = mess, url = url });
            }
            mess = ConstantConfig.Error;
            LogHelper.Log(mess, "异常的注销操作", "IndexController.cs:93", IpHelper.GetUserIp(), "未知", "注销操作时，没有找到Cookie值（不应该出现的错误）。");
            return Json(new { status = status, mess = mess, url = url });
        }

        /// <summary>
        /// 验证码接口
        /// </summary>
        /// <returns></returns>
        [AuthenticationFilter(flag = false)]
        public JsonResult ImgApi()
        {
            ImgCodeHelper._Interface().ValidateImg(ConstantConfig.KEY);
            return Json("");
        }
        #endregion
    }
}
