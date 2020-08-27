using Aura.UI.Attributes;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace Aura.UI.Controls
{
    [Experimental]
    public class PagesView : SelectingItemsControl
    {
        public PagesView()
        {
            this.InitializeComponent();
        }
        static PagesView()
        {
            KeyRightEvent.AddClassHandler<PagesView>((x, e) => x.OnKeyRight(e));
            KeyLeftEvent.AddClassHandler<PagesView>((x, e) => x.OnKeyLeft(e));
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        public event EventHandler<KeyEventArgs> KeyLeft 
        { 
            add { AddHandler(KeyLeftEvent, value); } 
            remove { RemoveHandler(KeyLeftEvent, value); }
        }
        #region Events
        public static readonly RoutedEvent<KeyEventArgs> KeyLeftEvent =
        RoutedEvent.Register<PagesView, KeyEventArgs>("KeyLeft", RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        public event EventHandler<KeyEventArgs> KeyRight
        {
            add { AddHandler(KeyRightEvent, value); }
            remove { RemoveHandler(KeyRightEvent, value); }
        }
        public static readonly RoutedEvent<KeyEventArgs> KeyRightEvent = 
        RoutedEvent.Register<PagesView, KeyEventArgs>("KeyRight", RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        #endregion
        #region Properties
        public bool CanChangeTheWindowTitle
        {
            get { return GetValue(CanChangeTheWindowTitleProperty); }
            set { SetValue(CanChangeTheWindowTitleProperty, value); }
        }
        public static readonly StyledProperty<bool> CanChangeTheWindowTitleProperty =
            AvaloniaProperty.Register<PagesView, bool>(nameof(CanChangeTheWindowTitle), true);
        #endregion

        protected virtual void OnKeyLeft(KeyEventArgs e) 
        {
            if (e.Key == Key.FnLeftArrow)
            {
                e.Handled = true;
                Previous();
            }
        }
        protected virtual void OnKeyRight(KeyEventArgs e) 
        {
            if (e.Key == Key.FnLeftArrow)
            {
                e.Handled = true;
                Next();
            }
        } 
        
        public void Previous()     
        {
            try
            {
                Page Index;
                if ((Items as IList)[SelectedIndex - 1] != null)
                {
                    var _index = (Items as IList)[SelectedIndex - 1] as Page;
                    Index = _index;

                    if (this.Items != null)
                    {
                        if (Index != null & Index.GetType() == typeof(Page))
                        {
                            SelectedItem = Index as Page;
                            (Index as Page).IsSelected = true;
                            if (CanChangeTheWindowTitle == true)
                            {
                                this.GetParentWindowOfLogical().Title = (Index as Page).Title;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public void Next()
        {
            try
            {
                Page Index;
                if ((Items as IList)[SelectedIndex + 1] != null)
                {
                    var _index = (Items as IList)[SelectedIndex + 1] as Page;
                    Index = _index;
                    if (this.Items != null)
                    {
                        if (Index != null & Index.GetType() == typeof(Page))
                        {
                            SelectedItem = Index as Page;
                            (Index as Page).IsSelected = true;
                            if (CanChangeTheWindowTitle == true)
                            {
                                this.GetParentWindowOfLogical().Title = (Index as Page).Title;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
