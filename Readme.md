<h1 align="center">
<img src="DesignSources/auraui-logo.png" width="256"/>
<br/><br/>
Aura.UI
</h1>
<h2 align="center">Control's Library for Avalonia</h2>

# OverView

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
    //Return a AvaloniaObject from Template
   ```

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
