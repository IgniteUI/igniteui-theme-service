using IgniteUIThemeService.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IgniteUIThemeService.Util
{
    public class ThemeGenerator
    {
        private readonly ThemeModel _themeModel;
        private readonly string _contentRootPath;

        public ThemeGenerator(ThemeModel themeModel, string contentRootPath)
        {
            _themeModel = themeModel;
            _contentRootPath = contentRootPath;
        }

        private string LoadTemplate()
        {
            string fileContent;
            
            using (StreamReader reader = File.OpenText(_contentRootPath + "/Util/Templates/custom-theme.template"))
            {
                fileContent = reader.ReadToEnd();
            }

            fileContent = fileContent.Replace("{{RootPath}}", _contentRootPath.Replace('\\', '/'))
                .Replace("{{theme}}", _themeModel.isDarkTheme ? "igx-dark-theme" : "igx-theme")
                .Replace("{{palette}}", _themeModel.colorPalette.palette)
                .Replace("{{typeface}}", _themeModel.typeface)
                .Replace("{{roundness}}", _themeModel.roundness)
                .Replace("{{elevation}}", _themeModel.elevation);
            return fileContent;
        }

        public string GenerateCustomTheme()
        {
            return this.LoadTemplate();
        }
    }
}
