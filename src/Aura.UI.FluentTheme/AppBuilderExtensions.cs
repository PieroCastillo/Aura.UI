﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using System;
using System.Reflection;

namespace Aura.UI.FluentTheme
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder UseAuraUIFluentTheme(this AppBuilder appBuilder)
        {
            appBuilder.AfterSetup(x =>
            {
                appBuilder.Instance.Styles.Add(new StyleInclude(new Uri($"avares://{Assembly.GetExecutingAssembly().FullName}/Styles")) 
                {
                    Source = new Uri("avares://Aura.UI.FluentTheme/AuraUI.xaml")
                });
            });
            return appBuilder;
        }
    }
}
