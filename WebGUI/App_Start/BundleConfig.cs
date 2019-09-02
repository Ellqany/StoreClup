using System.Web.Optimization;

namespace WebGUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/*.css",
                               "~/Content/bootstrap.min.css",
                               "~/Content/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/clientfeaturesscripts")
                .Include("~/Scripts/jquery-3.3.1.min.js",
                               "~/scripts/jquery.validate.min.js",
                               "~/scripts/jquery.validate.unobtrusive.min.js",
                               "~/scripts/jquery.unobtrusive-ajax.min.js",
                               "~/scripts/owl.carousel.js",
                               "~/scripts/poper.min.js",
                               "~/scripts/jquery.nicescroll.js",
                               "~/scripts/bootstrap.min.js",
                               "~/Scripts/ckeditor/ckeditor.js",
                                "~/scripts/swiper.min.js",
                                "~/scripts/page.js"));
        }
    }
}