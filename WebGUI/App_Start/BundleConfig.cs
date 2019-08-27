using System.Web.Optimization;

namespace WebGUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/YMMM/css").Include(
                            "~/wwwroot/css/bootstrap.min.css",
                            "~/wwwroot/css/swiper.min.css",
                            "~/wwwroot/css/owl.theme.default.min.css",
                            "~/wwwroot/css/owl.carousel.css",
                            "~/wwwroot/css/animate.css",
                            "~/wwwroot/css/main.css",
                            "~/wwwroot/css/VarelaRound.css",
                            "~/wwwroot/css/fontawesome.css"
                            ));

            bundles.Add(new ScriptBundle("~/bundles/clientfeaturesscripts")
            .Include("~/wwwroot/js/jquery.min.js",
                "~/wwwroot/js/owl.carousel.js",
                "~/wwwroot/js/poper.min.js",
                "~/wwwroot/js/jquery.nicescroll.js",
                "~/wwwroot/js/bootstrap.min.js",
                "~/wwwroot/js/swiper.min.js",
                "~/wwwroot/js/page.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
