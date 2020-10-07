using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    [TemplatePart(Name = "PART_ToggleNav", Type = typeof(NavigationViewItem))]
    public class NavigationView : TabViewBase, IHeadered
    {
        #region Fields
        NavigationViewItem ToggleNav;
        #endregion

        #region Functionalities
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            ToggleNav = this.GetControl<NavigationViewItem>(e, "PART_ToggleNav");
            ToggleNav.PointerPressed += ToggleNav_PointerPressed;
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);

            //if(change.Property == SelectedItemProperty)
            //{
                ChangeSelectedTitle();
            //}
        }

        private void ChangeSelectedTitle()
        {
            if(SelectedItem is NavigationViewItem)
            {
                Title = (SelectedItem as NavigationViewItem).Title;
            }
        }

        private void ToggleNav_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            ToggleNavigationViewOpenState(this);
        }

        public static void ToggleNavigationViewOpenState(NavigationView navigationView)
        {
            var e = navigationView.IsOpen;
            switch (e)
            {
                case true:
                    navigationView.IsOpen = false;
                    break;
                case false:
                    navigationView.IsOpen = true;
                    break;
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Get or set the expansion state of the NavigationView
        /// </summary>
        public bool IsOpen
        {
            get { return GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        public static readonly StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(IsOpen), false);

        public object Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static readonly StyledProperty<object> TitleProperty =
            AvaloniaProperty.Register<NavigationView, object>(nameof(Title), "Title");


        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<NavigationView, object>(nameof(Header), "Navigation View");

        public ITemplate HeaderTemplate
        {
            get => GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }
        public static readonly StyledProperty<ITemplate> HeaderTemplateProperty =
            AvaloniaProperty.Register<NavigationView, ITemplate>(nameof(HeaderTemplate));

        public double CompactPaneLength
        {
            get => GetValue(CompactPaneLengthProperty);
            set => SetValue(CompactPaneLengthProperty, value);
        }
        public static readonly StyledProperty<double> CompactPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(CompactPaneLength), 150);

        public double OpenPaneLength
        {
            get => GetValue(OpenPaneLengthProperty);
            set => SetValue(OpenPaneLengthProperty, value);
        }
        public static readonly StyledProperty<double> OpenPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(OpenPaneLength), 50);
        #endregion
    }
}