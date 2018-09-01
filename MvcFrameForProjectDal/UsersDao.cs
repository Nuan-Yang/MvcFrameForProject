using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcFrameForProjectModel;
using System.Data.Entity;
using System.Data.Sql;

namespace MvcFrameForProjectDal
{
    public class UsersDao
    {
        public static UsersDao Interface
        {
            get {return _Interface;}
        }

        private static UsersDao _Interface = new UsersDao();

        /// <summary>
        /// 通过用户名获取该用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns>userdb</returns>
        public UsersDb GetUserInfoByName(string name)
        {

            try
            {
                using (var ef = new SQlConnectConfig())
                {
                    
                    UsersDb item = ef.UserDb.SingleOrDefault(c => c.Username == name);
                    if (item != null)
                    {
                        return item;
                    }
                }
            }
            catch (Exception ex)
            {
                //待定义
            }
            return null;
        }

    }
}
