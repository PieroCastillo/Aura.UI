using Aura.UI.Attributes;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia.DTO;
using System.Collections.Generic;

namespace Aura.UI.Controls
{
    [TemplatePart(Name = "PART_TabManager", Type = typeof(TabControl))]
    [TemplatePart(Name = "PART_ItemsPresenter", Type = typeof(ItemsPresenter))]
    public class TabbedWindow : ContentWindow
    {
        ItemsPresenter itemspresenter;
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
        }

        public TabControl TabManager
        {
            get { return GetValue(TabManagerProperty); }
            set { SetValue(TabManagerProperty, value); }
        }
        public static readonly StyledProperty<TabControl> TabManagerProperty =
            AvaloniaProperty.Register<TabbedWindow, TabControl>(nameof(TabManager));

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            TabManager = this.GetControl<TabControl>(e, "PART_TabManager");
            itemspresenter.MaxWidth = this.GetParentWindowOfLogical().Width - 50;
        }

        public IList<AuraTabItem> Items
        {
            get;
            set;
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);
            itemspresenter.MaxWidth = this.Width - 40;
        }

        public void AddTabItem(TemplatedControl ContentOfTab, string Header_, bool IsClosable_ = true)  
        {
            var tab = new AuraTabItem()
            {
                Content = ContentOfTab,
                Header = Header_,
                IsClosable  = IsClosable_
            };
            TabManager.AddTab(tab, true);
        }

        public void CloseTabItem(int index)
        {
            try
            {
                TabManager.CloseTab(index);
            }
            catch
            {

            }
        }
    }
}
