[![Build Status](https://dev.azure.com/PieroCastillo/Aura.UI/_apis/build/status/PieroCastillo.Aura.UI)](https://dev.azure.com/PieroCastillo/AuraUI/_build/latest)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AuraDevCommunity/Aura-UI)
[![NuGet](https://img.shields.io/nuget/v/Aura.UI.svg)](https://www.nuget.org/packages/Aura.UI/0.1.3.1)
[![downloads](https://img.shields.io/nuget/dt/Aura.UI.svg)](https://www.nuget.org/packages/Aura.UI) 
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com) 
![Size](https://img.shields.io/github/repo-size/PieroCastillo/Aura.UI)

<h1 align="center">
<img src="../DesignSources/AuraUILogo_full_icon.png" width="256"/> 
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


# How To Collaborate

Just enter to the follow Gitter chat! 

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AuraDevCommunity/Aura-UI) 

Or make a pull request! All pull request are welcome!
