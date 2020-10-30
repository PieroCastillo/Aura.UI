using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Aura.UI.Controls
{
    public partial class TabbedWindow : ContentWindow
    {
        protected AuraTabView TabManager;
        #region Fields
        Border DragBorder;
        protected const double BUTTONSWIDTH = 240;
        double new_W;
        #endregion
        public TabbedWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
           
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            TabManager = this.Find<AuraTabView>("tab_manager");
            DragBorder = this.Find<Border>("drag_border");
            DragBorder.PointerPressed += (s, e) =>
            {
                this.BeginMoveDrag(e);
            };
            //DragBorder.Width = TabManager.WidthRemainingSpace;
            //DragBorder.Height = TabManager.HeightRemainingSpace;
            new_W = this.Width - new_W;
            TabManager.MaxWidthOfItemsPresenter = new_W;

            this.PropertyChanged += TabbedWindow_PropertyChanged;
        }

        private void TabbedWindow_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            new_W = this.Width - BUTTONSWIDTH;
            TabManager.MaxWidthOfItemsPresenter = new_W;
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);

            if(change.Property == TabbedWindow.TabItemsProperty)
            {
                TabManager.Items = this.TabItems;
            }
        }
        #region Functions
        public void AddTab(AuraTabItem tabItem)
        {
            this.TabManager.AddTab(tabItem, true);
        }

        public void AddActionToAddButton(Action action)
        {
            this.TabManager.AddActionToAdderButton(action);
        }

        public void CloseTab(AuraTabItem tabItem)
        {
            this.TabManager.CloseTab(tabItem);
        }

        public void CloseTab(int index)
        {
            this.TabManager.CloseTab(index);
        }
        //protected virtual void OnTabItemDragged(object sender, PointerPressedEventArgs e)
        //{

        //}
        //public  virtual void CreateNewTabbedWindowByDrag(AuraTabItem tabItem)
        //{

        //}
        #endregion
    }
}
