using Aura.UI.Controls.Ribbon;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Avalonia.Interactivity;

namespace Aura.UI.Controls.Primitives
{
    public class TabViewBase : TabControl
    {
        public TabViewBase()
        {
            this.AddHandler(SelectionChangedEvent, OnSelectionChanged, RoutingStrategies.Bubble);
        }
        
        protected virtual void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
