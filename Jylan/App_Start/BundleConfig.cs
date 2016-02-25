using System.Web.Optimization;

namespace Jylan
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Trying to make font-awesome icons work
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-2.2.0.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.easing.min.js",
                "~/Scripts/jquery.fittext.js",
                "~/Scripts/wow.min.js",
                "~/Scripts/creative.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-1.11.4.js",
                "~/Scripts/jquery-ui-timepicker-addon.js",
                "~/Scripts/jquery.countdown2.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/scripts.js"
                ));
            bundles.Add(new StyleBundle("~/Content/fontawesomebundle").Include(
                "~/Content/font-awesome/css/font-awesome.css"
                ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/animate.min.css",
                "~/Content/creative.css"
                ));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/jquery-ui-timepicker-addon.css"
                ));
        }
    }
}