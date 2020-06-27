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

        public static List<SystemFont> GetSystemFonts(string language="en-us")
        {
            language = language.ToLower();
            var fonts = CanvasFontSet.GetSystemFontSet();
            var result = new List<SystemFont>();
            foreach (var item in fonts.Fonts)
            {
                if (item.IsSymbolFont)
                    continue;
                string name = "";
                if(!string.IsNullOrEmpty(language))
                    item.FamilyNames.TryGetValue(language, out name);
                if(string.IsNullOrEmpty(name) && item.FamilyNames.Count > 0)
                {
                    string local = Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString().ToLower();
                    item.FamilyNames.TryGetValue(local, out name);
                    if(string.IsNullOrEmpty(name))
                        name = item.FamilyNames.First().Value;
                }
                if (!string.IsNullOrEmpty(name) && !result.Any(p => p.Name == name))
                {
                    result.Add(new SystemFont(name, item));
                }  
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is SystemFont font &&
                   Name == font.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
