# 字体库使用说明

[English](./README.md)

## 收录字体

- [Feather](https://feathericons.com/)：该字体涵盖了常用的工具图标，比如箭头、设置图标等
- [Material](https://material.io/resources/icons/?style=baseline)：该字体对标Google Material设计规范，提供了一千余图标
- [Brands](https://simpleicons.org/)：涵盖了市面上绝大多数公司Logo

## 图标预览

1. 进入项目，在**Assets**文件夹中找到需要的字体(`.ttf`)，安装后使用[Character Map](https://www.microsoft.com/store/productId/9WZDNCRDXF41)应用打开
2. 进入项目，在**Demo**文件夹中点开对应字体文件夹的`demo.html`文件，在本地预览

## 使用方法

> nuget：[Richasy.Font.UWP](https://www.nuget.org/packages/Richasy.Font.UWP/)

### 图标类

项目中创建了3种`IconElement`，分别是`FeatherIcon`, `MaterialIcon`和`BrandIcon`，分别对应上面的3种字体。

图标类继承自`FontIcon`，FontFamily默认已经设定好，同时提供了`Symbol`枚举依赖属性，方便你以一种更友好的方式（相对于输入字符）来选取图标。

*Xaml中使用*

```xml
<NavigationViewItem Content="心电图">
    <NavigationViewItem.Icon>
        <font:FeatherIcon Symbol="Activity"/>
    </NavigationViewItem.Icon>
</NavigationViewItem>
```

*C#中使用*

```csharp
var icon = new FeatherIcon(FeatherSymbol.Activity);
```

*C#中获取图标对应的文本*

```csharp
string icon = ((char)icon).ToString();
```

### 系统字体类

这里主要使用`CanvasFontSet`来获取当前的系统字体，过滤掉了图标字体和可能的乱码字体

*使用*

```csharp
var fonts = SystemFont.GetSystemFonts();
foreach (var font in fonts)
{
    string name = font.Name;
    Debug.WriteLine(name);
}
```

## 注意事项

为了符合语法，我对图标的名称进行了一些修改，规则如下：

1. 去除`icon-`的前缀
2. 去除`-`,`_`等连接符，命名方式为帕斯卡命名
3. 首字符为数字的（比如`360`），会在最前面加一个`_`

## 感谢

- [win2d](https://github.com/microsoft/Win2D)
- [IcoMoon](https://icomoon.io/)
