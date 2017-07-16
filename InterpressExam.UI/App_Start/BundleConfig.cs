using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace InterpressExam.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                "~/Scripts/jquery.signalR-2.2.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/handlebar").Include(
                "~/Scripts/handlebars-v4.0.10.js"));

            bundles.Add(new ScriptBundle("~/bundles/rss").Include(
                "~/Scripts/constant.js",
                "~/Scripts/ajaxmanager.js",
                "~/Scripts/rss.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            if (HttpContext.Current.IsDebuggingEnabled)
            {
                BundleTable.Bundles.ToList().ForEach(b => b.Transforms.Clear());
            }
            else
            {
                BundleTable.EnableOptimizations = true;
            }
        }
    }
}
