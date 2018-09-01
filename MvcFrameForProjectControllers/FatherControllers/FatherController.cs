using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcFrameForProjectControllers
{
    /// <summary>
    /// 身份验证的控制器
    /// </summary>
    [AuthenticationFilter(flag=true)]
    public class FatherController :Controller
    {

    }
}
