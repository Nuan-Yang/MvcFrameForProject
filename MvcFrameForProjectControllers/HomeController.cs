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
    public class HomeController :FatherController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
