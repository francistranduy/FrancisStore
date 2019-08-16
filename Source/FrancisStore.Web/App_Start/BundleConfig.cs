using System.Web;
using System.Web.Optimization;

namespace FrancisStore.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            //Francis Store style bundles
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.min.css"));

            //Libary shared font styles
            bundles.Add(new StyleBundle("~/fonts/css").Include(
                "~/fonts/Font-Awesome-4.7.0/css/font-awesome.min.css",
                "~/fonts/themify-icons/themify-icons.css",
                "~/fonts/Linearicons-Free-v1.0.0/style.css",
                "~/fonts/elegant_font/style.css"));

            //Libary shared styles
            bundles.Add(new StyleBundle("~/lib/animate.css").Include(
                "~/lib/animate.css/animate.min.css"));

            bundles.Add(new StyleBundle("~/lib/hamburgers").Include(
                "~/lib/hamburgers/hamburgers.min.css"));

            bundles.Add(new StyleBundle("~/lib/animsition").Include(
                "~/lib/animsition/css/animsition.min.css"));

            bundles.Add(new StyleBundle("~/lib/select2").Include(
                "~/lib/select2/css/select2.min.css"));

            bundles.Add(new StyleBundle("~/lib/slick-carousel").Include(
                "~/lib/slick-carousel/slick.css"));

            //Custom shared styles
            bundles.Add(new StyleBundle("~/Content/FrancisStore").Include(
                "~/Content/util.css",
                "~/Content/main.css"));

            //Home styles
            bundles.Add(new StyleBundle("~/lib/bootstrap-daterangepicker").Include(
                "~/lib/bootstrap-daterangepicker/daterangepicker.min.css"));

            bundles.Add(new StyleBundle("~/lib/lightbox2").Include(
                "~/lib/lightbox2/css/lightbox.min.css"));

            //Product styles
            bundles.Add(new StyleBundle("~/lib/noUiSlider").Include(
                "~/lib/noUiSlider/nouislider.min.css"));

            //Francis Store script bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/animsition").Include(
                "~/lib/animsition/js/animsition.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/umd/popper.min.js",
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                "~/lib/select2/js/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/slick-carousel").Include(
                "~/lib/slick-carousel/slick.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/lightbox2").Include(
                "~/lib/lightbox2/js/lightbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                "~/lib/sweetalert/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/daterangepicker").Include(
                "~/lib/bootstrap-daterangepicker/moment.min.js",
                "~/lib/bootstrap-daterangepicker/daterangepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/noUiSlider").Include(
                "~/lib/noUiSlider/nouislider.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/FrancisStore").Include(
                "~/Scripts/slick-custom.js",
                "~/Scripts/countdowntime.js",
                "~/Scripts/parallax100.js",
                "~/Scripts/main.js"));
        }
    }
}
