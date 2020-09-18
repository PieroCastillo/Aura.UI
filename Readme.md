[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/AuraDevCommunity/Aura-UI)
[![NuGet](https://img.shields.io/nuget/v/Aura.UI.svg)](https://www.nuget.org/packages/Aura.UI) 
[![downloads](https://img.shields.io/nuget/dt/Aura.UI.svg)](https://www.nuget.org/packages/Aura.UI) 
[![Discord](https://img.shields.io/badge/discord-join%20chat-JY9sDq)]( https://discord.gg/JY9sDq)

<h1 align="center">
<img src="DesignSources/auraui-logov2.png" width="256"/> 
<br/><br/>
Aura.UI
</h1>


<h2 align="center">Control's Library for Avalonia</h2>

# Overview

* Controls Availables
  *  AuraTabItem 
  *  AuraTabView
  *  SuperColorPicker
  *  ColorPickerButton
  *  PagesView
  *  GroupBox
  *  FilledSlider
  *  ModernSlider

* Controls in Developing
   * GradientEditor : This control creates a GradientBrush to use in other controls.
   * SuperListBoxItem : A Powered-ListBoxItem has a Button and two TextBlocks.
* Windows Availables
   * ColorWindowSmall : This window shows a ColorPicker.

* Windows in Developing:
   * ChangeColorWindow : This window creates a SolidColorBrush or GradientBrush.

* Planned Controls and Windows for future versions:
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
``` CLI 
dotnet add package Aura.UI --version 0.1.3-preview1
```
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
       <StyleInclude Source="avares://Aura.UI/AuraAcrylicBase.xaml"/> <!--When you use a controls with IMaterial Interface , you should add this source-->
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

It's a tool to ease the changes of an application's language.
<img src="DocumentationGifs/Language_Testing.gif">
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
# Controls

## AuraTabItem 

 A Closable TabItem what has extra features.
 <img src="DocumentationGifs/AuraTabItem_Adding_Closing.gif">

## AuraTabView

Is similar to TabControl, but this can add new tabs with a built-in button, also its tabs reduce its width when the spacing is little.

<img src="DocumentationGifs/AuraTabView_Adding_Testing.gif">

## TitleBox

Similar to GroupBox, but has 2 buttons and is easy-to-custom.
<img src="DocumentationGifs/TitleBox_ReScaling.gif">

## SuperColorPicker

This color picker can modify the opacity and the color of a SolidColorBrush, and let you see a preview, too.

<img src="DocumentationGifs/SuperColorPicker_Testing.gif">
## ColorPickerButton 
A Toggle Button when you click it, shows a ColorPicker on a Window.

<img src="DocumentationGifs/ColorPickerButton_Testing.gif">

## PagesView 

 A Pages Collection for simplify the life.

 <img src="DocumentationGifs/PagesView_Testing.gif">

## ModernSlider

This Slider imitates the Android Slider, but uses the Acrylic Textures!

<img src="DocumentationGifs/ModernSlider_Testing.gif">

## GroupBox

This Control has a header and that show it in the top.

<img src="DocumentationGifs/GroupBox_WO_Material_ReScaling.gif">

## Ribbon (Preview)

This control shows a Ribbon, and use its own subcontrols.

<img src="DocumentationGifs/RibbonTesting_prev.gif"> 

### Ribbon SubControls:

   * RibbonItem : It's the principal content selector, has a header and the content property.
   * RibbonPanel : This panel must be into the RibbonItem Content, organizes the RibbonGroups.
   * RibbonGroup : This HeaderedContentControl organizes the groups of the RibbonItem.
   * RibbonSeparator : This control separates the RibbonGroups.
  
 The default height of the container is ```150```, but if you want to change it, you have to edit the follow resource:
 ```xml 
   <ParentWindow xmlns:ms="clr-namespace:System;assembly=netstandard">
      <ParentWindow.Resources>
         <ms:Double x:Key="DefaultRibbonContainerHeight">200</ms:Double>
      </ParentWindow.Resources>
   </ParentWindow>
 ``` 
### Example:

```xml
   <Border Padding="10">
      <Border.Resources>
			<ms:Double x:Key="DefaultRibbonContainerHeight">170</ms:Double>
      </Border.Resources>
		<Ribbon Header="HeaderTest" LeftContent="File" RightContent="Settings" ExpansionState="Total">
			<RibbonItem Header="Start">
			   <RibbonPanel>
					<RibbonGroup Header="Colour">
						<Border Background="Yellow" Height="90" Width="100"/>
					</RibbonGroup>
					<RibbonSeparator/>
					<RibbonGroup Header="Themes">
						<StackPanel Orientation="Horizontal">
							<Border Background="Black" Width="60" Height="90"/>
							<Border Background="White" Width="60" Height="90"/>
						</StackPanel>
					</RibbonGroup>
				   <RibbonSeparator/>
					<RibbonGroup Header="Fonts">
						<StackPanel Spacing="10">
							<TextBlock FontSize="20">Ribbon</TextBlock>
							<TextBlock FontSize="14">Ribbon</TextBlock>
							<TextBlock FontSize="10">Ribbon</TextBlock>
						</StackPanel>
					</RibbonGroup>
				</RibbonPanel>
			</RibbonItem>
			<RibbonItem Header="Edit">
				<RibbonPanel>
				</RibbonPanel>
			</RibbonItem>
		</Ribbon>
	</Border>
```

This xaml code produces this result:

<img src="DocumentationGifs/RibbonTesting_prev2.gif">

# About Aura.UI

This library is open source and free, in a few months come out the first stable version,for now, Aura.UI is a beta. 

# How To Collaborate

If you want to collaborate with this proyect, contact me with the next links:
* [![Whatsapp](https://img.shields.io/badge/Whatsapp-Text%20me!-brightgreen)](https://wa.me/51902446088)
* [![Messenger](https://img.shields.io/badge/Messenger-Text%20me!-blue)](https://www.messenger.com/t/piero.idk.2000)
* [![Gitter](https://img.shields.io/badge/Gitter-Text%20me!-red)](https://gitter.im/PieroCastillo)
