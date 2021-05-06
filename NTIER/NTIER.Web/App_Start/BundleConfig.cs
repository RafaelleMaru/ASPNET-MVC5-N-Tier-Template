using System.Web;
using System.Web.Optimization;

namespace NTIER.Web
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

            bundles.Add(new ScriptBundle("~/bundles/themejs").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/jquery.metisMenu.js",
                "~/Scripts/jquery.slimscroll.min.js",
                "~/Scripts/screenfull.js",
                "~/Scripts/jquery.nicescroll.js",
                "~/Scripts/custom.js",
                "~/Scripts/scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css",
                      "~/Content/style.css"));
            //CSS datatables
            bundles.Add(new StyleBundle("~/Content/cssDatatables").Include(
                "~/Content/bootstrapValidator.min.css",
                "~/Content/dataTables.tableTools.min.css",
                "~/Content/jquery.dataTables.min.css",
                "~/Content/buttons.dataTables.min.css",
                "~/Content/responsive.dataTables.min.css",
                "~/Content/editor.dataTables.min.css"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jsDatatables").Include(
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/jszip.min.js",
                "~/Scripts/pdfmake.min.js",
                "~/Scripts/vfs_fonts.js",
                "~/Scripts/dataTables.tableTools.min.js",
                "~/Scripts/buttons.html5.min.js",
                "~/Scripts/buttons.print.min.js",
                "~/Scripts/dataTables.buttons.min.js",
                "~/Scripts/buttons.colVis.min.js",
                "~/Scripts/dataTables.responsive.js",
                "~/Scripts/dataTables.select.min.js",
                "~/Scripts/dataTables.editor.min.js",
                "~/Scripts/bootstrapvalidator.min.js"

                ));
        }
    }
}
