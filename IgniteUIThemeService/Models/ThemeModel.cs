using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgniteUIThemeService.Models
{
    public class ThemeModel
    {
        public bool isDarkTheme { get; set; }
        public Colors colors { get; set; }
        public string typeface { get; set; }
        public float roundness { get; set; }
        public int elevation { get; set; }
    }
}
