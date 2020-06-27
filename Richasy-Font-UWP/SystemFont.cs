using Microsoft.Graphics.Canvas.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Richasy.Font.UWP
{
    public class SystemFont
    {
        public string Name { get; set; }
        public FontFamily FontFamily { get; set; }
        public CanvasFontFace FontFace { get; set; }
        public SystemFont()
        {

        }
        public SystemFont(string name, CanvasFontFace fontFace)
        {
            Name = name;
            FontFamily = new FontFamily(name);
            FontFace = fontFace;
        }

        public static List<SystemFont> GetSystemFonts()
        {
            var fonts = CanvasFontSet.GetSystemFontSet();
            var result = new List<SystemFont>();
            foreach (var item in fonts.Fonts)
            {
                if (item.IsSymbolFont)
                    continue;
                item.FamilyNames.TryGetValue("en-us", out string name);
                if (!string.IsNullOrEmpty(name))
                    result.Add(new SystemFont(name, item));
            }
            return result;
        }
    }
}
