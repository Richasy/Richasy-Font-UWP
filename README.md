# Font library instructions

[中文说明](./README_ZH.md)

## Inclusion font

- [Feather](https://feathericons.com/): This font covers commonly used tool icons, such as arrows, settings icons, etc.
- [Material](https://material.io/resources/icons/?style=baseline): This font matches the Google Material design specifications and provides more than a thousand icons
- [Brands](https://simpleicons.org/): Covers most company logos on the world

## Preview

1. Enter the project, find the required font (`.ttf`) in the **Assets** folder, and use Character Map App after installation to open it.
2. Enter the project, open the `demo.html` file in the corresponding font folder in the **Demo** folder, and preview it locally.

## Usage

> nuget：[Richasy.Font.UWP](https://www.nuget.org/packages/Richasy.Font.UWP/)

### Icon class

Three types of `IconElement` were created in the project, namely `FeatherIcon`, `MaterialIcon` and `BrandIcon`, which correspond to the three fonts above.

The icon class inherits from `FontIcon`, FontFamily has been set by default, and also provides the `Symbol` enumeration dependent property, which is convenient for you to select icons in a more friendly way (relative to input characters).

*Xaml*

```xml
<NavigationViewItem Content="Activity">
    <NavigationViewItem.Icon>
        <font:FeatherIcon Symbol="Activity"/>
    </NavigationViewItem.Icon>
</NavigationViewItem>
```

*C#*

```csharp
var icon = new FeatherIcon(FeatherSymbol.Activity);
```

*C# - Get character from symbol*

```csharp
string icon = ((char)icon).ToString();
```

### System font class

Here mainly uses `CanvasFontSet` to get the current system font, filtering out the icon font and possible garbled font

*Usage*

```csharp
var fonts = SystemFont.GetSystemFonts();
foreach (var font in fonts)
{
    string name = font.Name;
    Debug.WriteLine(name);
}
```

## Precautions

In order to comply with the grammar, I made some modifications to the icon's name, the rules are as follows:

1. Remove the prefix of `icon-`
2. Remove the `-`, `_` and other connectors, the naming method is Pascal
3. If the first character is a number (such as `360`), a `_` will be added at the front

## Thanks

- [win2d](https://github.com/microsoft/Win2D)
- [IcoMoon](https://icomoon.io/)