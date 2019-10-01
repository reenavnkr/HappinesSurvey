using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HappinesSurvey.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/plugins/jQuery/jQuery-2.1.4.min.js",
                       "~/Scripts/plugins/jQuery/jquery.validate.min.js",
                        "~/Scripts/plugins/jQuery/jquery.validate.unobtrusive.min",
                      "~/Scripts/plugins/bootstrap/js/bootstrap.min.js",
                      "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js",
                      "~/Scripts/plugins/fastclick/fastclick.min.js",
                      "~/Scripts/plugins/dist/js/app.min.js",
                     "~/Scripts/plugins/dist/js/demo.js",
                     "~/Scripts/plugins/iCheck/icheck.min.js"
                     
                     ));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/dist/css/skins/_all-skins.min.css"                    
                      ));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css/bootstrap").Include("~/Content/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform()));


            BundleTable.EnableOptimizations = true;
        }
    }
}