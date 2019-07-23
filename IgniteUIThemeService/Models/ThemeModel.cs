using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgniteUIThemeService.Models
{
    public class ThemeModel
    {
        public bool isDarkTheme { get; set; }
        public ColorPalette colorPalette { get; set; }
        public string typeface { get; set; }
        public string roundness { get; set; }
        public string elevation { get; set; }
    }
}
