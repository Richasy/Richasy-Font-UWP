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
    public class BrandIcon : FontIcon
    {
        public BrandIcon()
        {
            FontFamily = new Windows.UI.Xaml.Media.FontFamily("/Assets/Brands.ttf#Brands");
        }
        public BrandIcon(BrandSymbol symbol) : this()
        {
            Symbol = symbol;
        }
        public BrandSymbol Symbol
        {
            get { return (BrandSymbol)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(BrandSymbol), typeof(BrandIcon), new PropertyMetadata(null, new PropertyChangedCallback(Symbol_Changed)));

        private static void Symbol_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is BrandSymbol icon)
            {
                var instance = d as BrandIcon;
                instance.Glyph = ((char)icon).ToString();
            }
        }
    }
}
