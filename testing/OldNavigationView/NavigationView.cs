using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Avalonia.Controls.Metadata;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;

namespace Aura.UI.Controls.Navigation
{
    [TemplatePart(Name = "PART_ToggleNav", Type = typeof(NavigationViewItem))]
    [PseudoClasses(":normal")]
    public partial class NavigationView : TabViewBase, IHeadered, IMaterial
    {
        #region Fields
        private NavigationViewItem ToggleNav;

        public new readonly static RoutedEvent<SelectionChangedEventArgs> SelectionChangedEvent =
            RoutedEvent.Register<SelectingItemsControl, SelectionChangedEventArgs>(nameof(SelectionChanged),
                                                                                    RoutingStrategies.Direct);
        #endregion

        public NavigationView()
        {
            SelectedItemProperty.Changed.AddClassHandler<NavigationView>((x, e) => x.OnSelectionChanged(x, e));
        }

        #region Functionalities
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            ToggleNav = this.GetControl<NavigationViewItem>(e, "PART_ToggleNav");
            ToggleNav.PointerPressed += ToggleNav_PointerPressed;

        }

        protected override void OnSelectionChanged(object sender,AvaloniaPropertyChangedEventArgs e)
        {
            base.OnSelectionChanged(sender, e);
            
            PseudoClasses.Remove(":normal");
            PseudoClasses.Add(":normal");
        }


        protected override void OnContainersMaterialized(ItemContainerEventArgs e)
        {
            base.OnContainersMaterialized(e);

            UpdateSelectedTitle();
        }
        
        protected override void OnContainersRecycled(ItemContainerEventArgs e)
        {
            base.OnContainersRecycled(e);

            UpdateSelectedTitle();
        }

        private void UpdateSelectedTitle()
        {
            if(SelectedIndex == -1)
            {
                Title = TitleTemplate = null;
            }
            else
            {
                var navitem = SelectedItem as NavigationViewItem;
                if(navitem != null)
                {
                    Title = navitem.Title;
                    TitleTemplate = navitem.TitleTemplate;
                }
            }
        }

        private void ToggleNav_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            ToggleNavigationViewOpenState(this);
        }

        public static void ToggleNavigationViewOpenState(NavigationView navigationView)
        {
            var e = navigationView.IsOpen;
            var a = navigationView.AlwaysOpen;
            if(a != true)
            {
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
            else if(a == true)
            {
                navigationView.IsOpen = true;
            }
        }
        #endregion
    }
}