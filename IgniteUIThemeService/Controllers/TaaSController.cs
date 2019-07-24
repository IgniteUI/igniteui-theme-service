using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using LibSassHost;
using LibSassHost.Helpers;
using IgniteUIThemeService.Models;
using IgniteUIThemeService.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IgniteUIThemeService.Controllers
{
    [Route("api/[controller]")]
    public class TaaSController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ThemeModel _themeModel;
        public TaaSController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/values
        [HttpGet]
        public ContentResult Get(bool isDarkTheme, Colors colors, string typeface, float roundness, int elevation)
        {
            string IGPath = _hostingEnvironment.ContentRootPath + "/IG";
            string basePath = IGPath + "/igniteui-angular/lib/core/styles/themes/presets/";
            string inputFilePath = Path.Combine(basePath, "igniteui-angular.scss");
            string outputFilePath = Path.Combine(_hostingEnvironment.ContentRootPath + "/wwwroot/IG", "igniteui-angular-custom.css");
            string sourceMapFilePath = Path.Combine(_hostingEnvironment.ContentRootPath + "/wwwroot/IG", "igniteui-angular-custom.css.map");

            ThemeGenerator generator = new ThemeGenerator(new ThemeModel()
            {
                colors = colors,
                isDarkTheme = isDarkTheme,
                typeface = typeface,
                roundness = roundness,
                elevation = elevation
            }, _hostingEnvironment.ContentRootPath );

            CompilationResult result = new CompilationResult();
            try
            {
                var options = new CompilationOptions { SourceMap = true };
                string content = generator.GenerateCustomTheme();

                result = SassCompiler.Compile(content, inputFilePath, outputFilePath,
                    sourceMapFilePath, options);

            }
            catch (SassСompilationException e)
            {
                // Console.WriteLine(SassErrorHelpers.Format(e));
                return Content("An error occurred during compilation of custom theme. Please try again.");
            }
            return Content(result.CompiledContent, "text/css");
        }
    }
}
