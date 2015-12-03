using System.Web.Optimization;

namespace Jylan
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-2.1.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-2.1.3.js",
                "~/Scripts/jquery-ui-1.11.4.js",
                "~/Scripts/jquery-ui-timepicker-addon.js",
                "~/Scripts/jquery.countdown.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/pluginjs").Include(
                "~/Scripts/jquery.easing.min.js",
                "~/Scripts/jquery.fittext.js",
                "~/Scripts/wow.min.js",
                "~/Scripts/creative.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/scripts.js"
                ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/animate.min.css",
                "~/Content/creative.css",
                "~/Content/font-awesome/css/font-awesome.min.css",
                "~/Content/zocial.css"
                ));
            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/jquery-ui-timepicker-addon.css"
                ));
        }
    }
}