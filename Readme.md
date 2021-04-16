[![Build Status](https://dev.azure.com/PieroCastillo/Aura.UI/_apis/build/status/PieroCastillo.Aura.UI)](https://dev.azure.com/PieroCastillo/AuraUI/_build/latest)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AuraDevCommunity/Aura-UI)
[![NuGet](https://img.shields.io/nuget/v/Aura.UI.svg)](https://www.nuget.org/packages/Aura.UI/0.1.3)
[![downloads](https://img.shields.io/nuget/dt/Aura.UI.svg)](https://www.nuget.org/packages/Aura.UI) 
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com) 
![Size](https://img.shields.io/github/repo-size/PieroCastillo/Aura.UI)

<h1 align="center">
<img src="DesignSources/AuraUILogo_full_icon.png" width="256"/> 
<br/><br/>
Aura.UI
</h1>


<h2 align="center">Control's Library for Avalonia</h2>

# Overview

| Available Controls |  | 
| -----------------  | --- | 
| FloatingButtonBar | ModernSlider |
| ProgressRing | GroupBox |
|CardCollection | AuraTabView |
| NavigationView | Ribbon |
| ContentDialog | MessageDialog |
| BlurryImage |

# Install

Now the library is available in Nuget.org.

<h2>First Step</h2>

Go to the next link: https://www.nuget.org/packages/Aura.UI .

<h2>Second Step</h2>

Install Aura.UI with Visual Studio or dotnetCLI:

<h3>Visual Studio</h3>

Open the Nuget Packages Manager on your project and search 
Aura.UI.

<img src="Pictures\aura.ui stb 1.3 vs.png" ></img>

<h3>Dotnet CLI</h3>

Open the terminal on the root folder of your project and write <br/>
```cmd
dotnet package Aura.UI --version 0.1.3
```
# Preparation

For Fluent Theme add these Styles to App.xaml

```xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             x:Class="YourApp.App">
   <Application.Styles>
      <FluenTheme Mode="Light"/>
      <StyleInclude Source="avares://Aura.UI/AuraUI.xaml"/>
	</Application.Styles> 
</Application>
```

And for Default Theme add these Styles to App.xaml

```xml
<Application  xmlns="https://github.com/avaloniaui"
              xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
              x:Class="YourApp.App">
   <Application.Styles>
      <StyleInclude Source="avares://Avalonia.Themes.Fluent/Accents/BaseLight.xaml"/>
      <StyleInclude Source="avares://Aura.UI/AuraUI.xaml"/>
      <StyleInclude Source="avares://Avalonia.Themes.Default/Accents/BaseLight.xaml"/>
      <StyleInclude Source="avares://Avalonia.Themes.Default/DefaultTheme.xaml"/>
   </Application.Styles> 
</Application>
```

# Gallery

## Sample
<img src="./screenshots/aura.ui_sample_light.png" width="500">
<img src="./screenshots/aura.ui_sample_dark.png" width="500">

## AuraTabView
<img src="./screenshots/auratabview_light.png" width="500">
<img src="./screenshots/auratabview_dark.png" width="500">

## BlurryImage
<img src="./screenshots/blurryimage_neutral.gif" width="500">

## CardCollection 
<img src="./screenshots/cardcollection_light.png" width="500">
<img src="./screenshots/cardcollection_dark.png" width="500">

## ContentDialog
<img src="./screenshots/contentdialog_light.png" width="500">
<img src="./screenshots/contentdialog_dark.png" width="500">

## FloatingButtonBar
<img src="./screenshots/floatingbuttonbar_light.gif" width="500">
<img src="./screenshots/floatingbuttonbar_dark.gif" width="500">

## GroupBox
<img src="./screenshots/groupbox_light.png" width="500">
<img src="./screenshots/groupbox_dark.png" width="500">

## MessageDialog
<img src="./screenshots/messagedialog_light.png" width="500">
<img src="./screenshots/messagedialog_dark.png" width="500">

## ModernSlider 
<img src="./screenshots/modernslider_light.gif" width="500">
<img src="./screenshots/modernslider_dark.gif" width="500">

## NavigationView 
<img src="./screenshots/navigationview_light.png" width="500">
<img src="./screenshots/navigationview_dark.png" width="500">

## ProgressRing
<div>
<img src="./screenshots/progressring_light.gif" width="500">
<img src="./screenshots/progressring_dark.gif" width="500">
</div>
<div>
<img src="./screenshots/progressring_indeterminate_light.gif" width="500">
<img src="./screenshots/progressring_indeterminate_dark.gif" width="500">
</div>

## Ribbon
<img src="./screenshots/ribbon_light.png" width="500">
<img src="./screenshots/ribbon_dark.png" width="500">

# About Aura.UI

This library is open source and free, in a few months come out the first stable version,for now, Aura.UI is a beta. 

## Credits 

This library is possible thanks to the follow projects:
   * [Avalonia](http://avaloniaui.net/) by the AvaloniaUI Team.
   * [ColorPicker](http://github.com/MikeCodesDotNET/ColorPicker) by MikeCodesDotNet.
   * [Math.NET Numerics](https://github.com/mathnet/mathnet-numerics) by Math.NET Team.


## To Do

- Documentation


# How To Collaborate

Just enter to the follow Gitter chat! 

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AuraDevCommunity/Aura-UI) 

Or make a pull request! All pull request are welcome!

# Special thanks to

<a href="https://jb.gg/OpenSource"><img height="200" src="logos/jetbrains-variant-2.svg"><a>
