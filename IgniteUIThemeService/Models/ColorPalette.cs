using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgniteUIThemeService.Models
{
    public class ColorPalette
    {
        public string palette { get; set; }
        public ColorPalette(Colors colors)
        {
            this.palette = "igx-palette(" +
                (colors.Primary != null ? "$primary: " + colors.Primary + "," : "") +
                (colors.Primary != null ? "$secondary: " + colors.Secondary + "," : "") +
                (colors.Surface != null ? "$surface: " + colors.Surface + "," : "") +
                (colors.Error != null ? "$error: " + colors.Error + "," : "") +
                (colors.Success != null ? "$success: " + colors.Success + "," : "") +
                (colors.Warning != null ? "$warning: " + colors.Warning + "," : "") +
                (colors.Info != null ? "$info: " + colors.Info + "," : "");

            // remove last coma from the string
            this.palette = this.palette.Remove(this.palette.Length - 1);

            this.palette += ")";
        }

        
    }
}
