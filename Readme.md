<h1 align="center">
<img src="DesignSources/auraui-logo.png" width="256"/>
<br/><br/>
Aura.UI
</h1>
<h2 align="center">Control's Library for Avalonia</h2>

# Overview

[![Join the chat at https://gitter.im/AuraDevCommunity/Aura-UI](https://badges.gitter.im/AuraDevCommunity/Aura-UI.svg)](https://gitter.im/AuraDevCommunity/Aura-UI?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

* Controls Availables
  *  AuraTabItem : A Closable TabItem what has extra features.
  *  TitleBar : Similar to GroupBox, but has 2 buttons and is easy-to-custom.
  *  ColorPickerButton : A Toggle Button when you click it, shows a ColorPicker on a Window.

* Controls in Developing
   * GradientColorPicker : This control creates a GradientBrush to use in other controls.
   * SuperListBoxItem : A Powered-ListBoxItem has a Button and two TextBlocks.
* Windows Availables
   * ColorWindowSmall : This window shows a ColorPicker.

* Windows in Developing:
   * ChangeColorWindow : This window creates a SolidColorBrush or GradientBrush.

* Planned Controls and Windows for future versions:
   * ModernWindow : A window with TitleProperty like a UWP Window.
   * TabbedWindow : An optimized window to use with AuraTabItems. 
   * NavigationView : A scrollable MenuItems, like UWP NavigationView.
   * StatusBar : This bar shows an status of application, it will use a class for the status.

* UI Extensions
   * TabControlExtensions:
   ```c#
    CloseTab(this TabControl tabControl, TabItem tabItem) //CloseTab with itself
    CloseTab(this TabControl tabControl, int index) //CLoses Tab with index
    AddTab(this TabControl tabControl, TabItem TabItemToAdd,bool Focus)
    //Add a Tab 
   ```
   * TemplatedControlExtensions:
   ```c#
    GetControl<T>(this TemplatedControl templatedControl ,TemplateAppliedEventArgs e, string name) where T : AvaloniaObject
    //Return an AvaloniaObject from Template
   ```

# Install

Now the library is available in Nuget.org.

<h2>First Step</h2>

Go to the next link: https://www.nuget.org/packages/Aura.UI .

<h2>Second Step</h2>

Install Aura.UI with Visual Studio or dotnetCLI:

<h3>Visual Studio</h3>

Open the Nuget Packages Manager on your project and search 
Aura.UI.

<img src="Pictures\vs_aura_ui.png" ></img>

<h3>Dotnet CLI</h3>

Open the terminal on the root folder of your project and write <br/>

#### dotnet add package Aura.UI --version 0.1.0

 Do it like this:

<img src="Pictures/cli_aura_ui.png"></img>


# Preparation

Add Styles to App.xaml

```xml
  <Application  xmlns="https://github.com/avaloniaui"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                x:Class="YourApp.App">
    <Application.Styles>
        <StyleInclude Source="avares://Avalonia.Themes.Default/DefaultTheme.xaml"/>
        <StyleInclude Source="avares://Avalonia.Themes.Default/Accents/BaseDark.xaml"/>
       <StyleInclude Source="avares://Aura.UI/AuraUI.xaml"/> <!-- Add this Source -->
    </Application.Styles>
  </Application>
```

Next add this *using* instructions:

``` c#
using Aura.UI.Controls;
using Aura.UI.UIExtensions;
using Aura.UI.Windows;
```

# About Aura.UI

This library is open source and free, in a few months come out the first stable version,for now, Aura.UI is a beta. 