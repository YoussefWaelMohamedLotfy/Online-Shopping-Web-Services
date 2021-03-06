﻿using System.Web;
using System.Web.Optimization;

namespace Online_Shopping_Service
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/themechanger.js",
                        "~/Scripts/fontawesome.js",
                        "~/Scripts/jquery.signalR-2.4.1.min.js",
                        "~/Scripts/DataTables/jquery.datatables.js",
                        "~/Scripts/DataTables/datatables.bootstrap4.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap-flatly.css",
					  //"~/Content/bootstrap-darkly.css",
                      "~/Content/DataTables/css/datatables.bootstrap4.css",
                      "~/Content/toastr.css",
                      "~/Content/notification.css",
                      //"~/Content/all.css",
                      "~/Content/site.css"));
        }
    }
}
