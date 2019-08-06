using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgniteUIThemeService.Models
{
    public class Colors
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public string Surface { get; set; }
        public string Error { get; set; }
        public string Success { get; set; }
        public string Warn { get; set; }
        public string Info { get; set; }

        public string GetPalette()
        {
            string palette = "igx-palette(" +
                (Primary != null ? "$primary: " + Primary + "," : "") +
                (Secondary != null ? "$secondary: " + Secondary + "," : "") +
                (Surface != null ? "$surface: " + Surface + "," : "") +
                (Error != null ? "$error: " + Error + "," : "") +
                (Success != null ? "$success: " + Success + "," : "") +
                (Warn != null ? "$warn: " + Warn + "," : "") +
                (Info != null ? "$info: " + Info + "," : "");

            // remove last coma from the string
            palette = palette.Last() == ',' ? palette.Remove(palette.Length - 1) : palette;
            palette += ")";

            // use the default palette if no colors are specified
            palette = palette == "igx-palette()" ? "$default-palette" : palette;

            return palette;
        }
    }
}
