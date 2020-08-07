using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Avalonia;
using Avalonia.Data;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using Avalonia.Media;
using Avalonia.Collections;
using Aura.UI.UIExtensions;
using Avalonia.Markup.Xaml;
using System.Collections.Specialized;

namespace Aura.UI.Controls
{
    public class ColorPickerButtonCollection : ItemsControl 
    {
        public ColorPickerButtonCollection() : base()
        {
            InitializeComponents();
        }

        public void AddButton(int index)
        {
            ((IList)this.Items).Insert(index, new ColorPickerButton());
        }

        public void DeleteButton(int index)
        {
            try
            {
                ((IList)this.Items).RemoveAt(index);
            }
            catch(ArgumentNullException e)
            {
                throw new ArgumentNullException("The \"index\" parameter is null", e);
            }
        }


        public Color GetColor(int index)
        {
            return ((ISolidColorBrush)(((IList)this.Items)[index] as ColorPickerButton).Background).Color;
        }

        protected override void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.ItemsCollectionChanged(sender, e);

            foreach(ColorPickerButton c in this.Items)
            {
                
            }
        }

        protected void InitializeComponents()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
    }
}
