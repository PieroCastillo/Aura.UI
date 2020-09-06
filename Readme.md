[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AuraDevCommunity/Aura-UI)
[![NuGet](https://img.shields.io/nuget/v/Aura.UI.svg)](https://www.nuget.org/packages/Aura.UI) 
[![downloads](https://img.shields.io/nuget/dt/Aura.UI.svg)](https://www.nuget.org/packages/Aura.UI) 
[![Discord](https://img.shields.io/badge/discord-join%20chat-JY9sDq)]( https://discord.gg/JY9sDq)

<h1 align="center">
<img src="DesignSources/auraui-logo.png" width="256"/>
<br/><br/>
Aura.UI
</h1>
<h2 align="center">Control's Library for Avalonia</h2>

# Overview

* Controls Availables
  *  AuraTabItem : A Closable TabItem what has extra features.
  *  TitleBar : Similar to GroupBox, but has 2 buttons and is easy-to-custom.
  *  ColorPickerButton : A Toggle Button when you click it, shows a ColorPicker on a Window.
  *  PagesView : A Pages Collection for simplify the life.

* Controls in Developing
   * GradientEditor : This control creates a GradientBrush to use in other controls.
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

# Language Manager

## What's that?

It's a tool to ease the changes of an application's language .

## How to use

Add the using statements to ```App.xaml.cs``` and ```MainWindow.xaml```
```c#
using Aura.UI.Managers;
```
On ```App.xaml.cs```
```c#
public static ILanguageManager? Manager { get; set; }
public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Manager = LanguageManager.Create("Languages");
                Manager.LoadSelectedLanguage("Language.theme");
                desktop.MainWindow = new MainWindow()
                {
                    DataContext = Manager
                };
                desktop.Exit += (sender , e) =>
                {
                    Manager.SaveSelectedLanguage("Language.theme");
                };
            }
            base.OnFrameworkInitializationCompleted();
        }
```
On ```MainWindow.xaml.cs```
```c#
public MainWindow(){
   InitializeComponent();
   App.Manager.EnableLanguages(this);
}
```
Finally, add this using statement to ```Program.cs```
```c#
using Avalonia.Controls.ApplicationLifetimes;
```

# About Aura.UI

This library is open source and free, in a few months come out the first stable version,for now, Aura.UI is a beta. 

# How To Collaborate

If you want to collaborate with this proyect, contact me with the next links:
* [![Whatsapp](https://img.shields.io/badge/Whatsapp-Text%20me!-brightgreen)](https://wa.me/51902446088)
* [![Messenger](https://img.shields.io/badge/Messenger-Text%20me!-blue)](https://www.messenger.com/t/piero.idk.2000)
* [![Gitter](https://img.shields.io/badge/Gitter-Text%20me!-red)](https://gitter.im/PieroCastillo)
