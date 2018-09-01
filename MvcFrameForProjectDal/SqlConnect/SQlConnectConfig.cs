using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Sql;
using MvcFrameForProjectModel;

namespace MvcFrameForProjectDal
{
    public class SQlConnectConfig : DbContext
    {
        //base中为数据库连接字符串在webConfig中设定
        public SQlConnectConfig()
            : base("MvcFrameForPorjectSqlModelContainer")
        {

        }

        public DbSet<UsersDb> UserDb { get; set; }

        public DbSet<UserClassDb> UserClassDb { get; set; }
    }
}
