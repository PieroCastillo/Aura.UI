using Aura.UI.Controls.Ribbon;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    public class TabViewBase : TabControl
    {
        public TabViewBase()
        {
            this.SelectionChanged += OnSelectionChanged;

            //PseudoClasses.Set(":selectionchanged", SelectedItemChanged == true);
        }

        protected virtual void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //public bool SelectedItemChanged
        //{
        //    get { return GetValue(SelectedItemChangedProperty); }
        //    private set { SetValue(SelectedItemChangedProperty, value); }
        //}
        //public readonly static StyledProperty<bool> SelectedItemChangedProperty =
        //    AvaloniaProperty.Register<TabViewBase, bool>(nameof(SelectedItemChangedProperty), false);
    }
}
