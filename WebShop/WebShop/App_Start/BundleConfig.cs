using System.Web.Optimization;

namespace WebShop
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout-{version}.js", "~/Scripts/knockout.validation.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new LessBundle("~/Content/less").Include("~/Content/*.less"));
            bundles.Add(new ScriptBundle("~/bundles/viewmodels").Include("~/ViewModels/*.js"));
        }
    }
}