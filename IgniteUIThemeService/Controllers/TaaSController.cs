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
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IgniteUIThemeService.Controllers
{
    [Route("api/[controller]")]
    public class TaaSController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        public TaaSController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/values
        [HttpGet]
        public string Get(string colors, string typeface, string roundness, string elevation)
        {
            Colors deserializedColors = JsonConvert.DeserializeObject<Colors>(colors);
            string IGPath = _hostingEnvironment.ContentRootPath + "/IG";
            string basePath = IGPath + "/igniteui-angular/lib/core/styles/themes/presets/";
            string inputFilePath = Path.Combine(basePath, "igniteui-angular.scss");
            string outputFilePath = Path.Combine(_hostingEnvironment.ContentRootPath + "/wwwroot/IG", "igniteui-angular-custom.css");
            string sourceMapFilePath = Path.Combine(_hostingEnvironment.ContentRootPath + "/wwwroot/IG", "igniteui-angular-custom.css.map");

            ColorPalette cp = new ColorPalette(deserializedColors);
            CompilationResult result = new CompilationResult();
            try
            {
                var options = new CompilationOptions { SourceMap = true };
                //CompilationResult result = SassCompiler.CompileFile(inputFilePath, outputFilePath,
                //    sourceMapFilePath, options);

                

                string content =
"@import \"" + IGPath.Replace('\\', '/') + "/igniteui-angular/lib/core/styles/themes/index\";" +
"@include igx-core();" +
"@include igx-theme(" + cp.palette + ");" +
"@include igx-typography($font-family: \"" + typeface + "\");";

                result = SassCompiler.Compile(content, inputFilePath, outputFilePath,
                    sourceMapFilePath, options);

                Console.WriteLine("Compiled content:{1}{1}{0}{1}", result.CompiledContent,
                    Environment.NewLine);
                Console.WriteLine("Source map:{1}{1}{0}{1}", result.SourceMap, Environment.NewLine);
                Console.WriteLine("Included file paths: {0}",
                    string.Join(", ", result.IncludedFilePaths));

                var outputFile = System.IO.File.Create(outputFilePath);
                using (StreamWriter logWriter = new StreamWriter(outputFile))
                {
                    logWriter.WriteLine(result.CompiledContent);
                    logWriter.Dispose();
                }

            }
            catch (SassСompilationException e)
            {
                Console.WriteLine("During compilation of SCSS file an error occurred. See details:");
                Console.WriteLine();
                Console.WriteLine(SassErrorHelpers.Format(e));
            }

            //if (outputFilePath == null) return NotFound();

            //return View(result.CompiledContent);
            //return File(outputFilePath, "text/css", Path.GetFileName(outputFilePath));
            return result.CompiledContent;
        }
    }
}
