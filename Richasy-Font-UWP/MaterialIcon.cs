using Richasy.Font.UWP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Richasy.Font.UWP
{
    public class MaterialIcon:FontIcon
    {
        public MaterialIcon()
        {
            FontFamily = new Windows.UI.Xaml.Media.FontFamily("/Richasy-Font-UWP/Assets/Material.ttf#Material");
        }
        public MaterialIcon(MaterialSymbol symbol) : this()
        {
            Symbol = symbol;
        }
        public MaterialSymbol Symbol
        {
            get { return (MaterialSymbol)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(MaterialSymbol), typeof(FeatherIcon), new PropertyMetadata(null, new PropertyChangedCallback(Symbol_Changed)));

        private static void Symbol_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is MaterialSymbol icon)
            {
                var instance = d as MaterialIcon;
                instance.Glyph = ((char)icon).ToString();
            }
        }
    }
}
