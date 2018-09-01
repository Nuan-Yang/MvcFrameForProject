using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcFrameForProjectModel;
using MvcFrameForProjectDal;

namespace MvcFrameForProjectBll
{
    public class UsersProvider
    {
        /// <summary>
        /// 判断用户信息是否正确
        /// </summary>
        /// <param name="list">用户信息</param>
        /// <param name="mess">信息</param>
        /// <param name="url">地址</param>
        /// <returns>状态</returns>
        public static bool UserLoginIn(UserLoginInModel list , out string mess ,out string url)
        {
            url = ConstantConfig.Login_In_Url;
            UsersDb item = UsersDao.Interface.GetUserInfoByName(list.Username);
            if (item != null)
            {
                if (item.Passwd == list.Passwd)
                {
                    url = ConstantConfig.Index_Url;
                    mess = ConstantConfig.Login_Ok;
                    var UserList = CacheHelper.GetCache(list.Username);
                    if (UserList == null)
                    {
                        CacheHelper.SetCache(item.Username, item.Passwd);
                    }
                    return true;
                }
                mess = ConstantConfig.PassWd_Error;
                return false;
            }
            mess = ConstantConfig.UserName_Error;
            return false;
        }

        /// <summary>
        /// 验证cookie
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Passwd"></param>
        /// <returns>状态</returns>
        public static bool CookieLoginIn(string Username,string Passwd)
        {
            var UserList = CacheHelper.GetCache(Username);
            if (UserList == null)
            {
                UsersDb item = UsersDao.Interface.GetUserInfoByName(Username);
                if (item != null)
                {
                    if (item.Passwd == Passwd)
                    {
                        CacheHelper.SetCache(item.Username, item.Passwd);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                string  Tmp =UserList.ToString();

                if (Tmp == Passwd)
                {
                    return true;
                }
                return false;
            }
           
        }

        /// <summary>
        /// 删除缓存中的用户信息
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Passwd"></param>
        /// <returns>状态</returns>
        public static bool DelCacheList(string Username, string Passwd)
        {
            var UserList = CacheHelper.GetCache(Username);
            if (UserList == null)
            {
                return false;
            }
            else
            {
                CacheHelper.RemoveAllCache(Username);
                return true;
            }

        }
    }
}
