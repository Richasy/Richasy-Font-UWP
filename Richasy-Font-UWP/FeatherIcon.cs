using Richasy.Font.UWP.Enums;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Richasy.Font.UWP
{
    public class FeatherIcon:FontIcon
    {
        public FeatherIcon()
        {
            FontFamily = new FontFamily("/Richasy-Font-UWP/Assets/Feather.ttf#Feather");
        }

        public FeatherIcon(FeatherSymbol symbol):this()
        {
            Symbol = symbol;
        }

        public FeatherSymbol Symbol
        {
            get { return (FeatherSymbol)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(FeatherSymbol), typeof(FeatherIcon), new PropertyMetadata(null,new PropertyChangedCallback(Symbol_Changed)));

        private static void Symbol_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is FeatherSymbol icon)
            {
                var instance = d as FeatherIcon;
                instance.Glyph = ((char)icon).ToString();
            }
        }
    }
}
