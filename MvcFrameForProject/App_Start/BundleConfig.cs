using System.Web;
using System.Web.Optimization;

namespace MvcFrameForProject
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/Index").Include(
                        "~/Scripts/Views/Index/Index.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Views/*.css"));

            bundles.Add(new ScriptBundle("~/bundles/HomeIndexjs").Include(
                        "~/Scripts/Views/Home/Index.js"));

            bundles.Add(new StyleBundle("~/Content/HomeIndexcss").Include("~/Content/Views/Home/Index.css"));
        }
    }
}