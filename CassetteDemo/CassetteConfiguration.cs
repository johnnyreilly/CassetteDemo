using Cassette;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace CassetteDemo
{
    /// <summary>
    /// Configures the Cassette asset bundles for the web application.
    /// </summary>
    public class CassetteBundleConfiguration : IConfiguration<BundleCollection>
    {
        public void Configure(BundleCollection bundles)
        {
            // TODO: Configure your bundles here...
            // Please read http://getcassette.net/documentation/configuration

            // This default configuration treats each file as a separate 'bundle'.
            // In production the content will be minified, but the files are not combined.
            // So you probably want to tweak these defaults!
            //bundles.AddPerIndividualFile<StylesheetBundle>("Content");
            //bundles.AddPerIndividualFile<ScriptBundle>("Scripts");

            // To combine files, try something like this instead:
            //   bundles.Add<StylesheetBundle>("Content");
            // In production mode, all of ~/Content will be combined into a single bundle.

            // If you want a bundle per folder, try this:
            //   bundles.AddPerSubDirectory<ScriptBundle>("Scripts");
            // Each immediate sub-directory of ~/Scripts will be combined into its own bundle.
            // This is useful when there are lots of scripts for different areas of the website.

            AddStylesheetBundles(bundles);
            AddScriptBundles(bundles);
        }

        private static void AddStylesheetBundles(BundleCollection bundles)
        {
            bundles.Add<StylesheetBundle>("~/bundles/css",
                                          "~/Content/Site.css",
                                          "~/Content/themes/base/jquery-ui.css"
                );
        }

        private static void AddScriptBundles(BundleCollection bundles)
        {
            // A bundle of the scripts that will need to be added to the head (likely only ever to be Modernizr but you never know)
            bundles.Add<ScriptBundle>("~/bundles/head",
                                      new[] {"~/Scripts/modernizr-2.6.2.js"},
                                      bundle => bundle.PageLocation = "head"
                );

            // A bundle of the core scripts that will likely be used on every page of the app
            bundles.Add<ScriptBundle>("~/bundles/core",
                                      new[]
                                          {
                                              "~/Scripts/jquery-1.8.2.js",
                                              "~/Scripts/jquery-ui-1.8.24.js"
                                          });

            // Validation scripts; only likely necessary on date entry screens
            bundles.Add<ScriptBundle>("~/bundles/validate",
                                      new[]
                                          {
                                              "~/Scripts/jquery.validate.js",
                                              "~/Scripts/jquery.validate.unobtrusive.js"
                                          },
                                      bundle => bundle.AddReference("~/bundles/core")
                );

            // Create a per file bundle for all areas / views
            bundles.AddPerIndividualFile<ScriptBundle>("~/Scripts/Views");
        }
    }
}